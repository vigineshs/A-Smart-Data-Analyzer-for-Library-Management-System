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
		RFIDReader1 rr1=new RFIDReader1();
		//RFIDWriter rw=new RFIDWriter();
		RFIDDisplay rd=new RFIDDisplay(rr);
		Thread t1=new Thread(rr,"Reader");

		//Thread t2=new Thread(rw,"Writer");
		Thread t3=new Thread(rr1,"Reader2");
		
		t1.start();
		//t2.start();
	t3.start();

t3.join();
		//t2.join();
		t1.join();
	}
}
class RFIDReader extends JFrame implements Runnable
{
	JLabel jl[]=new JLabel[50];
	JTextArea jtf[]=new JTextArea[50];
	double totalrssi[]=new double[50];
	float currssi[]=new float[50];
	float avgrssi[]=new float[50];
	int count[]=new int[50];
	DataInputStream dis,dis1;
	
	HashMap hm;
	JScrollPane jsp[]=new JScrollPane[50];

	StringTokenizer st;
	String s;

	RFIDReader()
	{
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		setTitle("Tags-RSSI-Averaging1");
		setSize(780,800);
		setEnabled(true);
		
		setLayout(new GridLayout(7,7));
		
		for(int i=0;i<49;i++)
		{
			jl[i]=new JLabel("Tag "+(i+1));
			jtf[i]=new JTextArea(2,10);
			jsp[i]=new JScrollPane(jtf[i]);
			add(jl[i]);
			add(jsp[i]);
		}
		hm=new HashMap();
		hm.put("3000-038200AC02010170000F3EB4",1);
		hm.put("3000-038200AC02010170000F3F9B",2);
		hm.put("3000-038200AC02010170000F3E87",3);
		hm.put("3000-038200AC02010170000F4270",4);
		hm.put("3000-038200AC02010170000F449E",5);
		hm.put("3000-038200AC02010170000F45D9",6);
		hm.put("3000-413132303133302020202020",7);
		hm.put("3000-038200AC02010170000F3C20",8);
		hm.put("3000-038200AC02010170000F331A",9);
		hm.put("3000-038200AC02010170000F3076",10);
		hm.put("3000-038200AC02010170000F2E1B",11);
		hm.put("3000-038200AC02010170000F2DD9",12);
		hm.put("3000-038200AC02010170000F28C5",13);
		hm.put("3000-038200AC02010170000F27E5",14);
		hm.put("3000-038200AC02010170000F2706",15);
		hm.put("3000-038200AC02010170000F263D",16);
		hm.put("3000-038200AC02010170000F23D9",17);
		hm.put("3000-038200AC02010170000F22B0",18);
		hm.put("3000-038200AC02010170000F20C4",19);
		hm.put("3000-038200AC02010170000EF4E7",20);
		hm.put("3000-038200AC02010170000EEE85",21);
		hm.put("3000-038200AC02010170000EE562",22);
		hm.put("3000-038200AC02010170000EEF2D",23);
		hm.put("3000-038200AC02010170000EE78C",24);
		hm.put("3000-038200AC02010170000EDF04",25);
		hm.put("3000-038200AC02010170000EEE26",26);
		hm.put("3000-038200AC02010170000ED618",27);
		hm.put("3000-038200AC02010010000DC7D2",28);
		hm.put("3000-038200AC02010170000EDD64",29);
		hm.put("3000-038200AC02010170000EE640",30);
		hm.put("3000-038200AC02010170000EE417",31);
		hm.put("3000-038200AC02010170000F4206",32);
		hm.put("3000-038200AC02010170000F4196",33);
		hm.put("3000-038200AC02010170000F3E17",34);
		hm.put("3000-038200AC02010010000DC7D5",35);
		hm.put("3000-038200AC02010010000DBC32",36);
		hm.put("3000-038200AC02010010000DC0FB",37 );
		hm.put("3000-038200AC02010010000DC1C2",38);
		hm.put("3000-038200AC02010010000DC5FB",39);
		hm.put("3000-038200AC02010010000DC5AB",40);
		hm.put("3000-038200AC02010020000E974E",41);
		hm.put("3000-038200AC02010170000ED408",42);
		hm.put("3000-038200AC02010170000ED413",43);
		hm.put("3000-038200AC02010170000ED478",44);
		hm.put("3000-038200AC02010170000ED4F3",45);
		hm.put("3000-E20068828216006522702899",46);
		hm.put("3000-E20068828216006611609F7E",47);
		hm.put("3000-E20068828216016518105B07",48);
		hm.put("3000-E2006882821600661120A3CA",49);		

	}
	public void run()
	{
		boolean EOF=false;
		String stagnum;
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
		String strFile = "D:\\PassiveRFID\\demo.csv";
			File f= new File("D:\\PassiveRFID\\demo.csv");

                        //create BufferedReader to read csv file
                      //  BufferedReader br = new BufferedReader( new FileReader(f));
		while(true)
		{

			BufferedReader br = new BufferedReader(new FileReader(f));

 			
                        String strLine = "";
                        StringTokenizer st = null;
						++hitcount;
                  
		//	br.mark(5000);
                        //read comma separated file line by line
                        while( (strLine = br.readLine()) != null)
                        {
                               
                                //break comma separated line using ","
                                st = new StringTokenizer(strLine, ",");
								
                                String s1=st.nextToken();
								
								if (hm.get(s1) != null)
								{
									tagnum = ((Integer)hm.get(s1)).intValue();
								//	System.out.println(tagnum);
									tagnum--;


									rssi = Float.parseFloat(st.nextToken());
									currssi[tagnum] = rssi;
									totalrssi[tagnum] += rssi;


									count[tagnum] = hitcount;
									avgrssi[tagnum] = (float)totalrssi[tagnum] / hitcount;
									jtf[tagnum].append("" + avgrssi[tagnum]);
									jtf[tagnum].append("," + rssi);
									jtf[tagnum].append("\n");

								}
						}
			
						br.close();

						Thread.sleep(30000);
			}
				
		}
		catch(Exception e)
		{
			System.out.println("Exception details:"+e);
		}
	}
}
class RFIDReader1 extends JFrame implements Runnable
{
	JLabel jl[] = new JLabel[50];
	JTextArea jtf[] = new JTextArea[50];
	double totalrssi[] = new double[50];
	float currssi[] = new float[50];
	float avgrssi[] = new float[50];
	int count[] = new int[50];
	DataInputStream dis, dis1;

	HashMap hm;
	JScrollPane jsp[] = new JScrollPane[50];

	StringTokenizer st;
	String s;

	RFIDReader1()
	{
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		setTitle("Tags-RSSI-Averaging 2");
		setSize(780, 800);
		setEnabled(true);

		setLayout(new GridLayout(7, 7));

		for (int i = 0; i < 49; i++)
		{
			jl[i] = new JLabel("Tag " + (i + 1));
			jtf[i] = new JTextArea(2, 10);
			jsp[i] = new JScrollPane(jtf[i]);
			add(jl[i]);
			add(jsp[i]);
		}
		hm = new HashMap();
		hm.put("3000-038200AC02010170000F3EB4", 1);
		hm.put("3000-038200AC02010170000F3F9B", 2);
		hm.put("3000-038200AC02010170000F3E87", 3);
		hm.put("3000-038200AC02010170000F4270", 4);
		hm.put("3000-038200AC02010170000F449E", 5);
		hm.put("3000-038200AC02010170000F45D9", 6);
		hm.put("3000-413132303133302020202020", 7);
		hm.put("3000-038200AC02010170000F3C20", 8);
		hm.put("3000-038200AC02010170000F331A", 9);
		hm.put("3000-038200AC02010170000F3076", 10);
		hm.put("3000-038200AC02010170000F2E1B", 11);
		hm.put("3000-038200AC02010170000F2DD9", 12);
		hm.put("3000-038200AC02010170000F28C5", 13);
		hm.put("3000-038200AC02010170000F27E5", 14);
		hm.put("3000-038200AC02010170000F2706", 15);
		hm.put("3000-038200AC02010170000F263D", 16);
		hm.put("3000-038200AC02010170000F23D9", 17);
		hm.put("3000-038200AC02010170000F22B0", 18);
		hm.put("3000-038200AC02010170000F20C4", 19);
		hm.put("3000-038200AC02010170000EF4E7", 20);
		hm.put("3000-038200AC02010170000EEE85", 21);
		hm.put("3000-038200AC02010170000EE562", 22);
		hm.put("3000-038200AC02010170000EEF2D", 23);
		hm.put("3000-038200AC02010170000EE78C", 24);
		hm.put("3000-038200AC02010170000EDF04", 25);
		hm.put("3000-038200AC02010170000EEE26", 26);
		hm.put("3000-038200AC02010170000ED618", 27);
		hm.put("3000-038200AC02010010000DC7D2", 28);
		hm.put("3000-038200AC02010170000EDD64", 29);
		hm.put("3000-038200AC02010170000EE640", 30);
		hm.put("3000-038200AC02010170000EE417", 31);
		hm.put("3000-038200AC02010170000F4206", 32);
		hm.put("3000-038200AC02010170000F4196", 33);
		hm.put("3000-038200AC02010170000F3E17", 34);
		hm.put("3000-038200AC02010010000DC7D5", 35);
		hm.put("3000-038200AC02010010000DBC32", 36);
		hm.put("3000-038200AC02010010000DC0FB", 37);
		hm.put("3000-038200AC02010010000DC1C2", 38);
		hm.put("3000-038200AC02010010000DC5FB", 39);
		hm.put("3000-038200AC02010010000DC5AB", 40);
		hm.put("3000-038200AC02010020000E974E", 41);
		hm.put("3000-038200AC02010170000ED408", 42);
		hm.put("3000-038200AC02010170000ED413", 43);
		hm.put("3000-038200AC02010170000ED478", 44);
		hm.put("3000-038200AC02010170000ED4F3", 45);
		hm.put("3000-E20068828216006522702899", 46);
		hm.put("3000-E20068828216006611609F7E", 47);
		hm.put("3000-E20068828216016518105B07", 48);
		hm.put("3000-E2006882821600661120A3CA", 49);

	}
	public void run()
	{
		boolean EOF = false;
		String stagnum;
		int tagnum;
		float rssi;
		int hit, hitcount = 0;
		String str;
		for (int i = 0; i < 50; i++)
		{
			totalrssi[i] = 0;
			currssi[i] = 0;
			avgrssi[i] = 0;
			count[i] = 0;
		}
		try
		{
			Thread.sleep(1000);
			String strFile = "\\20.30.23.193\\csv\\demo.csv";
			File f = new File("//20.30.23.193//csv//demo.csv");
			System.out.println("fdgdfgf");
			//create BufferedReader to read csv file
			//  BufferedReader br = new BufferedReader( new FileReader(f));
			while (true)
			{

				BufferedReader br = new BufferedReader(new FileReader(f));
			//	System.out.println("test");

				String strLine = "";
				StringTokenizer st = null;
				++hitcount;

				//	br.mark(5000);
				//read comma separated file line by line
				while ((strLine = br.readLine()) != null)
				{
				//	System.out.println("tesdfgt");
					//break comma separated line using ","
					st = new StringTokenizer(strLine, ",");

					String s1 = st.nextToken();
				//	System.out.println("tesd1");
					if (hm.get(s1) != null)
					{
				//		System.out.println("tesd2");
						tagnum = ((Integer)hm.get(s1)).intValue();
			//			System.out.println(tagnum);
					//	System.out.println("tesd3");
						tagnum--;


						rssi = Float.parseFloat(st.nextToken());
						currssi[tagnum] = rssi;
						totalrssi[tagnum] += rssi;


						count[tagnum] = hitcount;
						avgrssi[tagnum] = (float)totalrssi[tagnum] / hitcount;
						jtf[tagnum].append("" + avgrssi[tagnum]);
						jtf[tagnum].append("," + rssi);
						jtf[tagnum].append("\n");

					}
				}

				br.close();

				Thread.sleep(30000);
			}

		}
		catch (Exception e)
		{
			System.out.println("Exception details:" + e);
		}
	}
}
class RFIDWriter extends JFrame implements Runnable
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
}
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
   		Image newimg = img.getScaledInstance( 150, 50,java.awt.Image.SCALE_SMOOTH ) ;  
   		icon = new ImageIcon( newimg );
		
		jp1=new JPanel();
		jp2=new JPanel();

		jp1.setLayout(new GridLayout(7,7,50,50));

		jp2.setLayout(new FlowLayout(FlowLayout.CENTER));

		for(int i=0;i<49;i++)
		{
			jb[i]=new JButton(icon);
			jb[i].setEnabled(true);
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
		


		

