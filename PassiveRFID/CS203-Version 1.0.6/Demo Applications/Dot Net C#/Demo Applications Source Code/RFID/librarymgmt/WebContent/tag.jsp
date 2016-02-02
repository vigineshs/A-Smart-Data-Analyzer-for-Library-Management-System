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
  var x=document.forms["f1"]["bname"].value;
if (x==null || x=="")
  {
  alert("Book Name must be filled");
  return false;
  }
 var x=document.forms["f1"]["bauthor"].value;
if (x==null || x=="")
  {
  alert("Author must be filled");
  return false;
  }
  var x=document.forms["f1"]["bedition"].value;
if (x==null || x=="")
  {
  alert("Edition must be filled");
  return false;
  }
  var x=document.forms["f1"]["bisbn"].value;
if (x==null || x=="")
  {
  alert("ISBN must be filled");
  return false;
  }
  var x=document.forms["f1"]["brack"].value;
if (x==null || x=="")
  {
  alert("Rack must be filled");
  return false;
  }
  var x=document.forms["f1"]["brow"].value;
if (x==null || x=="")
  {
  alert("Row must be filled");
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
<ul>
<li><a href="index.jsp">Home</a></li>
<li><a href="tag.jsp">Tagging</a></li>
<li><a href="attend.jsp">Attendance</a></li>
<li><a href="locate.jsp">Trace Location</a></li>
<li><a href="#">Anti-Theft</a></li>
</ul>
<br/><br/>
	<center>
	<form method=POST action="http://localhost:8080/librarymgmt/Tagg" onsubmit="return validateForm()" name=f1 ><br/>
<table cellpadding="5" cellspacing="5">
<tr><td>Tag ID</td><td><input type=text size=10 name="btag" /></td></tr>
<tr><td>Book Name</td><td><input type=text size=20 name="bname" /></td></tr>
<tr><td>Author</td><td><input type=text size=20 name="bauthor" /></td></tr>
<tr><td>Edition</td><td><input type=text size=20 name="bedition" /></td></tr>
<tr><td>ISBN</td><td><input type=text size=10 name="bisbn" /></td></tr>
<tr><td>Rack</td><td><select name="brack">
  <option value="">Enter Rack</option>
  <option value="IT">IT</option>
  <option value="CSE">CSE</option>
  <option value="ECE">ECE</option>
    <option value="EEE">EEE</option>
  <option value="EIE">EIE</option>
  <option value="CIVIL">CIVIL</option>
  <option value="MBA">MBA</option>
  <option value="MCA">MCA</option>
</select></td></tr>
<tr><td>Row</td><td><select name="brow">
  <option value="">Enter Row</option>
  <option value="1ST">1st</option>
  <option value="2ND">2nd</option>
  <option value="3RD">3rd</option>
    <option value="4TH">4th</option>
  <option value="5TH">5th</option>
</select></td></tr>
<tr  ><td colspan="2"><center><input type=submit value=Store /></center></td></tr>
</table>
</form>
</center>
</div></div>
</div>
</body>
</html>