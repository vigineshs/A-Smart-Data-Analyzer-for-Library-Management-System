<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title>RFID | Library Management System</title>
<link rel="stylesheet" type="text/css" href="page.css ">
<script>
function validateForm()
{
var x=document.forms["f1"]["btag"].value;
var x1=document.forms["f1"]["bauthor"].value;
if ((x==null || x=="") && 1(x==null || x1==""))
  {
  alert("Atleast one field must be filled");
  return false;
  }}
  </script>
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
<br/><br/><center>
Enter Tag ID to locate Book</center>
	
	<form method=GET action="http://localhost:8080/librarymgmt/location.jsp" onsubmit="return validateForm()" name=f1  ><br/><br/>
	<center>
<table>
<tr><td>Tag ID</td><td><input type=text size=10 name="btag" /></td></tr>
<tr><td colspan="2">OR</td></tr><tr><td>Author</td><td><input type=text size=10 name="bauthor" /></td></tr>
<tr  ><td colspan="2"><center><input type=submit value=Locate /></center></td></tr>
</table></center>
</form>

</div>
</div>
</div>
</body>
</html>