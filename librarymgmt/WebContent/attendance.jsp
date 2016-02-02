<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title>RFID | Library Management System</title>
<link rel="stylesheet" type="text/css" href="page.css ">

</head>
<body>
<div class="center">
<div id="container">
<div id="header"><br/>
RFID Library Management System
</div>
<div id="content">
<ul>
<li><a href="index.jsp">Home</a></li>
<li><a href="tag.jsp">Tagging</a></li>
<li><a href="attend.jsp">Attendance</a></li>
<li><a href="locate.jsp">Trace Location</a></li>
<li><a href="#">Anti-Theft</a></li>
</ul>
<br/><br/>

	<center><form method=GET action="http://localhost:8080/librarymgmt/Attendance" onsubmit="return validateForm()" name=f1>
	<br/><br/><br/><br/>
<table cellpadding="5" cellspacing="5" >
<tr  ><td>Tag ID</td><td><input type=text size=10 name=btag /></td></tr>


<tr><td colspan="2"><center><input type=submit value=Attend /></center></td></tr>
</table>
</form></center>
	
</div>
</div></div>
</body>
</html>