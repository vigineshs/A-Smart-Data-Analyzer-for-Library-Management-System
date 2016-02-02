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
if (x==null || x=="")
  {
  alert("TagID must be filled");
  return false;
  }
  var x1=document.forms["f1"]["bname"].value;
if (x==null || x=="")
  {
  alert("Student Name must be filled");
  return false;
  }
  var x=document.forms["f1"]["byear"].value;
if (x==null || x=="")
  {
  alert("Year must be filled");
  return false;
  }
  
 var x=document.forms["f1"]["bdept"].value;
if (x==null || x=="")
  {
  alert("Department must be filled");
  return false;
  }
  var x=document.forms["f1"]["bsection"].value;
if (x==null || x=="")
  {
  alert("Section must be filled");
  return false;
  }
  var x=document.forms["f1"]["buid"].value;
if (x==null || x=="")
  {
  alert("UID must be filled");
  return false;
  }
  var x=document.forms["f1"]["broll"].value;
if (x==null || x=="")
  {
  alert("RollNo must be filled");
  return false;
  }
}
</script>

</head>
<body>
<div class="center">
<div id="container">
<div id="header"><br/>
RFID Library Management System
</div>
<div id="content">
<center>
<ul>
<li><a href="index.jsp">Home</a></li>
<li><a href="tag.jsp">Tagging</a></li>
<li><a href="attend.jsp">Attendance</a></li>
<li><a href="locate.jsp">Trace Location</a></li>
<li><a href="#">Anti-Theft</a></li>
</ul>
<br/><br/>
	
<form name=f1 method=POST action="http://localhost:8080/librarymgmt/Update" onsubmit="return validateForm()" >
<table cellpadding="5" cellspacing="5">
<tr><td>Tag ID</td><td><input type=text size=10 name=btag /></td></tr>
<tr><td>Student Name</td><td><input type=text size=20 name=bname /></td></tr>
<tr><td>Year</td><td><input type=text size=20 name=byear /></td></tr>
<tr><td>Department</td><td><input type=text size=5 name=bdept /></td></tr>
<tr><td>Section</td><td><input type=text size=20 name=bsection /></td></tr>
<tr><td>UID</td><td><input type=text size=10 name=buid /></td></tr>
<tr><td>Roll</td><td><input type=text size=5 name=broll /></td></tr>
<tr><td colspan="2"><center><input type=submit value=Store  /></center></td></tr>
</table>
</form>
</center>
</div>
</div>
</div>
</body>
</html>