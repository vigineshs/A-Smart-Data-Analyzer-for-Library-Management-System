<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title>RFID | Library Management System</title>
<link rel="stylesheet" type="text/css" href="css/page.css ">

</head>
<body>
<div id="container">
<div id="header"><br/>
RFID Library Management System
</div>
<div id="content">
<br/><br/>
	<div id="lcon">

	</div>
	<div id="rcon">
	<form method=GET action="http://localhost:8080/Tagg" >
<table>
<tr><td>Tag ID</td><td><input type=text size=10 name="tag" /></td></tr>
<tr><td>Book Name</td><td><input type=text size=20 name="bname" /></td></tr>
<tr><td>Author</td><td><input type=text size=20 name="bauthor" /></td></tr>
<tr><td>Edition</td><td><input type=text size=20 name="bedition" /></td></tr>
<tr><td>ISBN</td><td><input type=text size=10 name="bisbn" /></td></tr>
<tr><td>Rack</td><td><input type=text size=5 name="brack" /></td></tr>
<tr><td>Row</td><td><input type=text size=5 name="brow" /></td></tr>
<tr  ><td colspan="2"><center><input type=submit value=Store /></center></td></tr>
</table>
</form>
	</div>
</div>
</div>
</body>
</html>