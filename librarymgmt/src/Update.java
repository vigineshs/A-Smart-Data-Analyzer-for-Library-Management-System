

import java.io.IOException;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class for Servlet: Update
 *
 */
 public class Update extends javax.servlet.http.HttpServlet implements javax.servlet.Servlet {
   static final long serialVersionUID = 1L;
   
    /* (non-Java-doc)
	 * @see javax.servlet.http.HttpServlet#HttpServlet()
	 */
	public Update() {
		super();
	}   	
	
	/* (non-Java-doc)
	 * @see javax.servlet.http.HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
	}  	
	
	/* (non-Java-doc)
	 * @see javax.servlet.http.HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		Dbconn dbc = Dbconn.getConnection();
	  	Connection con=dbc.getDbconnection();
	  	Statement st;
	  	String  ttag=request.getParameter("btag");
	  	String tname=request.getParameter("bname");
	  	String tyear=request.getParameter("byear");
	  	String tdept=request.getParameter("bdept");
	  	String tsection=request.getParameter("bsection");
	  	String tuid=request.getParameter("buid");
	  	String troll=request.getParameter("broll");
	  	
	  	String mess="";
	  	String link="";
	  	try
		{
			System.out.println("inside try");
		    st=con.createStatement();  
		    
		    ResultSet rs=st.executeQuery("select * from Student where TID='"+ttag+"' and UID='"+tuid+"'");
		    if(rs.next())
		    {
		    	st.executeUpdate("UPDATE Student SET [SName] = '"+tname+"',[SYear] = '"+tyear+"',[SDept] = '"+tdept+"',[SSection] = '"+tsection+"',[SRoll] = '"+troll+"' WHERE (([TID] = '"+ttag+"') AND ([UID] ='"+tuid+"'))");
 			    mess="Student details updated. Click Ok to Update another.";
 			    link="http://localhost:8080/librarymgmt/updetails.jsp";
 				  	    }
		    
		    
		    else
		    {
		    	
		    System.out.println("INSERT into Student values('"+tuid+"','"+ttag+"','"+tname+"','"+tyear+"','"+tdept+"','"+tsection+"','"+troll+"','','','','','','','','','','','','','','','','','','','','','','','','','0','0');");
		    st.executeUpdate("INSERT into Student values('"+tuid+"','"+ttag+"','"+tname+"','"+tyear+"','"+tdept+"','"+tsection+"','"+troll+"','','','','','','','','','','','','','','','','','','','','','','','','','0','0');");
		   
		    System.out.println("Register succes");     
		    
		    System.out.println("Gethu");
			   mess="Student Added. Click Ok to Continue.";
			   link="http://localhost:8080/librarymgmt/updetails.jsp";
			    	}
		    	
			
		 }
	  	
	  	catch(Exception e)
		{
			e.printStackTrace();
		}
		    request.setAttribute("mess", mess);    
		  	
		    
	     request.setAttribute("link", link);     
	 
	     
	     RequestDispatcher rd = this.getServletContext().getRequestDispatcher("/message.jsp");
		  	rd.forward(request, response);	
	}   	  	    
}