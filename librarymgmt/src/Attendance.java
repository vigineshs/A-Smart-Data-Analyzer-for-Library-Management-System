

import java.io.IOException;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class for Servlet: Attendance
 *
 */
 public class Attendance extends javax.servlet.http.HttpServlet implements javax.servlet.Servlet {
	 public static int scount;
	 public static int count;
   static final long serialVersionUID = 1L;
   
    /* (non-Java-doc)
	 * @see javax.servlet.http.HttpServlet#HttpServlet()
	 */
	public Attendance() {
		super();
	}   	
	
	/* (non-Java-doc)
	 * @see javax.servlet.http.HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		Dbconn dbc = Dbconn.getConnection();
	  	Connection con=dbc.getDbconnection();
	  	Statement st;
	  	String tid=request.getParameter("btag");
	  	String tuid=request.getParameter("buid");
	  	
	  	String mess="";
	  	String link="";
	  	try
		{
			System.out.println("inside try");
		    st=con.createStatement();  
		    SimpleDateFormat sdfDate = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		    Date now = new Date();
		    String lastdat = sdfDate.format(now);
		    System.out.println(lastdat);
		    
		    int month=2;
		    int month1=Integer.parseInt(lastdat.substring(5,7));
		    int date=Integer.parseInt(lastdat.substring(8,10));
		    if(month==month1){
		    	if(date<=7){
		    		date=7;
		    	System.out.println("count="+date);
		    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"'))");
		    	System.out.println("count="+date);
		    	}
		    	else if(date<=14){
		    		date=14;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"') AND ([UID] ='"+tuid+"'))");
			    	System.out.println("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	}
		    	else if(date<=21){
		    		date=21;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    	else if(date<=28){
		    		date=28;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    }
		    else if(month+1==month1)
		    {
		    	if(date<=7){
		    		date=35;
		    	System.out.println("count="+date);
		    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
		    	System.out.println("count="+date);
		    	}
		    	else if(date<=14){
		    		date=42;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    	else if(date<=21){
		    		date=49;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    	else if(date<=28){
		    		date=56;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    	
		    }
		    else if(month+2==month1)
		    {
		    	if(date<=7){
		    		date=63;
		    	System.out.println("count="+date);
		    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
		    	System.out.println("count="+date);
		    	}
		    	else if(date<=14){
		    		date=70;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    	else if(date<=21){
		    		date=77;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    	else if(date<=28){
		    		date=83;
			    	System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SCount] = '"+date+"' WHERE (([TID] = '"+tid+"')  )");
			    	System.out.println("count="+date);
			    	}
		    	st.close();
		    }
		    System.out.println(month1);
		    ResultSet rs=st.executeQuery("select * from Student where TID='"+tid+"'");
		    System.out.println("select * from Student where TID='"+tid+"'");
		    while(rs.next())
		    {
		    	System.out.println("while");
		    	scount=Integer.parseInt(rs.getString("SCount"));
		    	count=rs.getInt("Count");
		    	System.out.println(count);
		    	
		    }
		    
		    	System.out.println(count);
		    	if(scount==7 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek1] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==7 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek1o] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==14 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek2] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==14 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek20] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==21 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek3] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==21 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek30] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==28 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek4] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==28 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek40] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==35 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek5] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==35 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek50] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==42 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek6] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==42 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek60] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==49 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek7] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==49 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek70] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==56 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek8] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==56 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek80] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==63 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek9] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==63 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek90] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==70 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek10] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==70 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek100] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==77 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek11] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==77 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek110] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==84 && count==0){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek12] = '"+lastdat+"', [Count]='1' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	else if(scount==84 && count==1){
		    		System.out.println("count="+date);
			    	st.executeUpdate("UPDATE Student SET [SWeek120] = '"+lastdat+"', [Count]='0' WHERE (([TID] = '"+tid+"')  )");
		    	}
		    	mess="Attendance Successful. Click Ok to Scan another.";
				   link="http://localhost:8080/librarymgmt/attendance.jsp";
		    
	}   
	  	catch(Exception e){
	  		e.printStackTrace();
	  		}
	    request.setAttribute("mess", mess);    
	  request.setAttribute("link", link);     

	     RequestDispatcher rd = this.getServletContext().getRequestDispatcher("/message.jsp");
		  	rd.forward(request, response);
	  	}

	
	
	/* (non-Java-doc)
	 * @see javax.servlet.http.HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		
}
 }