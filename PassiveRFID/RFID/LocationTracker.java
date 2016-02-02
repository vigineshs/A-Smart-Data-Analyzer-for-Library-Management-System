import java.io.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.util.*;
public class LocationTracker
{
	public static void main(String ar[]) throws Exception
	{
		RFIDReader rr=new RFIDReader();
		RFIDWriter rw=new RFIDWriter();
		RFIDDisplay rd=new RFIDDisplay(rr);
		Thread t1=new Thread(rr,"Reader");
		//Thread t2=new Thread(rw,"Writer");
		
		t1.start();
		//t2.start();
		
		//t2.join();
		t1.join();
	}
}
class RFIDReader extends JFrame implements Runnable
{
	JLabel jl[]=new JLabel[50];
	JTextField jtf[]=new JTextField[50];
	double totalrssi[]=new double[50];
	float currssi[]=new float[50];
	float avgrssi[]=new float[50];
	int count[]=new int[50];
	DataInputStream dis;

	StringTokenizer st;
	String s;

	RFIDReader()
	{
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		setTitle("Tags-RSSI-Averaging");
		setSize(780,800);
		setEnabled(true);
		
		setLayout(new GridLayout(10,10));
		
		for(int i=0;i<50;i++)
		{
			jl[i]=new JLabel("Tag "+(i+1));
			jtf[i]=new JTextField(10);
			add(jl[i]);
			add(jtf[i]);
		}			

	}
	public void run()
	{
		boolean EOF=false;
		int tagnum;
		float rssi;
		int hit,hitcount=0;
		String str;
		for(int i=0;i<50;i++)
		{
			totalrssi[i]=0;
			currssi[i]=0;
			avgrssi[i]=0;
			count[i]=0;
		}
		try
		{
		Thread.sleep(1000);
		while(true)
		{
		dis=new DataInputStream(new FileInputStream("D:\PassiveRFID\demo.csv"));
		
		while(!EOF)
		{
				try
				{
			
				tagnum=dis.readInt()-1;
				
				dis.readChar();
				rssi=dis.readFloat();
				currssi[tagnum]=rssi;
				totalrssi[tagnum]+=rssi;
				
				dis.readChar();
				
				hit=dis.readInt();
				count[tagnum]=++hitcount;
				avgrssi[tagnum]=(float)(totalrssi[tagnum]/hit);
				jtf[tagnum].setText(""+avgrssi[tagnum]);
				dis.readChar();
			
				}
				catch(EOFException ef)
				{
				EOF=true;
				}
		}
		dis.close();
		Thread.sleep(500);
		EOF=false;
		}
		}
		catch(Exception e)
		{
			System.out.println("Exception details:"+e);
		}
	}
}
/*class RFIDWriter extends JFrame implements Runnable
{
	JTextArea ja;
	JButton jb;
	JPanel jp;
	JScrollPane jsp;
	Random r;

	FileOutputStream fos;
	DataOutputStream dos;
	
	RFIDWriter()
	{
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		setTitle("RFIDReader");
		setSize(400,400);
		setEnabled(true);
		
		setLayout(new BorderLayout());

		ja=new JTextArea();
		jsp=new JScrollPane(ja);
		jb=new JButton("Start Reader");
		jp=new JPanel();
		jp.setLayout(new FlowLayout(FlowLayout.CENTER));
		jp.add(jb);

		add(jsp,BorderLayout.CENTER);
		add(jp, BorderLayout.SOUTH);

	}
	public void run() 
	{
		try
		{
		int hit=0;
		while(true)
		{
		fos=new FileOutputStream("reader.csv");
		dos=new DataOutputStream(fos);

		r=new Random();
		int count=0;
		while(count!=50)
		{
			int tagnum=r.nextInt(50)+1;
			float rssi=r.nextFloat()*100;
			dos.writeInt(tagnum);
			ja.append("Tag:"+tagnum+",rssi:"+rssi+",hit:"+hit+"\n");
			dos.writeChar(',');
			dos.writeFloat(rssi);
			dos.writeChar(',');
			dos.writeInt(hit);
			dos.writeChar('\n');
			count++;
			
		}
		Thread.sleep(500);
		ja.setText("");
		fos.close();
		dos.close();
		hit++;
		}
		}
		catch (Exception e)
		{
			System.out.println("Exception Details:"+e);
		}
			
		
		
	}
}*/
class RFIDDisplay extends JFrame implements ActionListener
{

	
	JPanel jp1,jp2;
	JButton jb[]=new JButton[50];
	ImageIcon image,icon;
	JButton jb2,jb3;

	RFIDReader rr;

	float rssi;
	int reftagselected;

	JLabel jl1;

	JComboBox jcb;

	RFIDDisplay(RFIDReader r)
	{
		rr=r;
		setEnabled(true);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		setTitle("Tags Viewer");
		setSize(780,800);
		setEnabled(true);
		
		setLayout(new BorderLayout());

		image=new ImageIcon("images.jpeg");

		Image img = image.getImage() ;  
   		Image newimg = img.getScaledInstance( 50, 50,java.awt.Image.SCALE_SMOOTH ) ;  
   		icon = new ImageIcon( newimg );
		
		jp1=new JPanel();
		jp2=new JPanel();

		jp1.setLayout(new GridLayout(5,10,100,100));

		jp2.setLayout(new FlowLayout(FlowLayout.CENTER));

		for(int i=0;i<50;i++)
		{
			jb[i]=new JButton(icon);
			jb[i].setEnabled(false);
			jp1.add(jb[i]);
			
		}
		add(jp1,BorderLayout.CENTER);
		jl1=new JLabel("Find...");
		
		jcb=new JComboBox();
		for(int i=0;i<20;i++)
			jcb.addItem("Tag : "+i);
		jcb.addItem("ANY TAG");	
		jcb.setSelectedItem("ANY TAG");	
		
		jb2=new JButton("Locate once");
		jb2.addActionListener(this);
		jb3=new JButton("Track Continuously");
		jp2.add(jl1);
		jp2.add(jcb);
		jp2.add(jb2);
		jp2.add(jb3);

		add(jp2,BorderLayout.SOUTH);

		
		
	}
	public void actionPerformed(ActionEvent ae)
	{
		Random r=new Random();
		int i=0;
		int tagfound=r.nextInt(20);
	
		
		String str=ae.getActionCommand();
		if(str.equals("Locate once"))
		{
			String str1=(String)jcb.getSelectedItem();
			if(str1.equals("ANY TAG"))
			{
				rssi=r.nextFloat()*100;
				jb[reftagselected].setEnabled(false);
				findPassiveTag();
				try
				{
					while(i<=10)
					{
						Thread.sleep(10);
						jb[reftagselected].setEnabled(true);
						Toolkit.getDefaultToolkit().beep();	
   						jb[reftagselected].doClick();
						i++;
					}
				}
				catch(Exception e)
				{
					System.out.println("Exception viewer"+e);
				}
			}
		}
		
	}
	public void findPassiveTag()
	{
		int elem=0;
		float tempdiff,diff=-1;
		for(int i=0;i<rr.avgrssi.length;i++)
		{
			tempdiff=rr.avgrssi[i]-rssi;
			tempdiff=(tempdiff<0)? -tempdiff : tempdiff;
			diff=(diff==-1)?tempdiff:diff;
			if(diff<tempdiff)
			{
				diff=tempdiff;
				elem=i;
			}
		}
		reftagselected=elem;
	}
		
		
}		
		


		

