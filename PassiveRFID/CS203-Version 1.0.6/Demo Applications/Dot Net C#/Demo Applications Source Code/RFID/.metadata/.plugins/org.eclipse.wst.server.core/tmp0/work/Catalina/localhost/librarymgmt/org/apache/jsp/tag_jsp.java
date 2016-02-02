package org.apache.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;

public final class tag_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static final JspFactory _jspxFactory = JspFactory.getDefaultFactory();

  private static java.util.List _jspx_dependants;

  private javax.el.ExpressionFactory _el_expressionfactory;
  private org.apache.AnnotationProcessor _jsp_annotationprocessor;

  public Object getDependants() {
    return _jspx_dependants;
  }

  public void _jspInit() {
    _el_expressionfactory = _jspxFactory.getJspApplicationContext(getServletConfig().getServletContext()).getExpressionFactory();
    _jsp_annotationprocessor = (org.apache.AnnotationProcessor) getServletConfig().getServletContext().getAttribute(org.apache.AnnotationProcessor.class.getName());
  }

  public void _jspDestroy() {
  }

  public void _jspService(HttpServletRequest request, HttpServletResponse response)
        throws java.io.IOException, ServletException {

    PageContext pageContext = null;
    HttpSession session = null;
    ServletContext application = null;
    ServletConfig config = null;
    JspWriter out = null;
    Object page = this;
    JspWriter _jspx_out = null;
    PageContext _jspx_page_context = null;


    try {
      response.setContentType("text/html; charset=ISO-8859-1");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;

      out.write("\n");
      out.write("<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">\n");
      out.write("<html>\n");
      out.write("<head>\r\n");
      out.write("<title>RFID | Library Management System</title>\r\n");
      out.write("<link rel=\"stylesheet\" type=\"text/css\" href=\"page.css \">\r\n");
      out.write("<script>\r\n");
      out.write("function validateForm()\r\n");
      out.write("{\r\n");
      out.write("var x=document.forms[\"f1\"][\"btag\"].value;\r\n");
      out.write("if (x==null || x==\"\")\r\n");
      out.write("  {\r\n");
      out.write("  alert(\"TagID must be filled\");\r\n");
      out.write("  return false;\r\n");
      out.write("  }\r\n");
      out.write("  var x=document.forms[\"f1\"][\"bname\"].value;\r\n");
      out.write("if (x==null || x==\"\")\r\n");
      out.write("  {\r\n");
      out.write("  alert(\"Book Name must be filled\");\r\n");
      out.write("  return false;\r\n");
      out.write("  }\r\n");
      out.write(" var x=document.forms[\"f1\"][\"bauthor\"].value;\r\n");
      out.write("if (x==null || x==\"\")\r\n");
      out.write("  {\r\n");
      out.write("  alert(\"Author must be filled\");\r\n");
      out.write("  return false;\r\n");
      out.write("  }\r\n");
      out.write("  var x=document.forms[\"f1\"][\"bedition\"].value;\r\n");
      out.write("if (x==null || x==\"\")\r\n");
      out.write("  {\r\n");
      out.write("  alert(\"Edition must be filled\");\r\n");
      out.write("  return false;\r\n");
      out.write("  }\r\n");
      out.write("  var x=document.forms[\"f1\"][\"bisbn\"].value;\r\n");
      out.write("if (x==null || x==\"\")\r\n");
      out.write("  {\r\n");
      out.write("  alert(\"ISBN must be filled\");\r\n");
      out.write("  return false;\r\n");
      out.write("  }\r\n");
      out.write("  var x=document.forms[\"f1\"][\"brack\"].value;\r\n");
      out.write("if (x==null || x==\"\")\r\n");
      out.write("  {\r\n");
      out.write("  alert(\"Rack must be filled\");\r\n");
      out.write("  return false;\r\n");
      out.write("  }\r\n");
      out.write("  var x=document.forms[\"f1\"][\"brow\"].value;\r\n");
      out.write("if (x==null || x==\"\")\r\n");
      out.write("  {\r\n");
      out.write("  alert(\"Row must be filled\");\r\n");
      out.write("  return false;\r\n");
      out.write("  }\r\n");
      out.write("}\r\n");
      out.write("</script>\r\n");
      out.write("</head>\r\n");
      out.write("<body>\r\n");
      out.write("<div class=\"center\">\r\n");
      out.write("<div id=\"container\">\r\n");
      out.write("<div id=\"header\"><br/>\r\n");
      out.write("RFID Library Management System\r\n");
      out.write("</div>\r\n");
      out.write("<div id=\"content\">\r\n");
      out.write("<ul>\r\n");
      out.write("<li><a href=\"index.jsp\">Home</a></li>\r\n");
      out.write("<li><a href=\"tag.jsp\">Tagging</a></li>\r\n");
      out.write("<li><a href=\"attend.jsp\">Attendance</a></li>\r\n");
      out.write("<li><a href=\"locate.jsp\">Trace Location</a></li>\r\n");
      out.write("<li><a href=\"#\">Anti-Theft</a></li>\r\n");
      out.write("</ul>\r\n");
      out.write("<br/><br/>\r\n");
      out.write("\t<center>\r\n");
      out.write("\t<form method=POST action=\"http://localhost:8080/librarymgmt/Tagg\" onsubmit=\"return validateForm()\" name=f1 ><br/>\r\n");
      out.write("<table cellpadding=\"5\" cellspacing=\"5\">\r\n");
      out.write("<tr><td>Tag ID</td><td><input type=text size=10 name=\"btag\" /></td></tr>\r\n");
      out.write("<tr><td>Book Name</td><td><input type=text size=20 name=\"bname\" /></td></tr>\r\n");
      out.write("<tr><td>Author</td><td><input type=text size=20 name=\"bauthor\" /></td></tr>\r\n");
      out.write("<tr><td>Edition</td><td><input type=text size=20 name=\"bedition\" /></td></tr>\r\n");
      out.write("<tr><td>ISBN</td><td><input type=text size=10 name=\"bisbn\" /></td></tr>\r\n");
      out.write("<tr><td>Rack</td><td><select name=\"brack\">\r\n");
      out.write("  <option value=\"\">Enter Rack</option>\r\n");
      out.write("  <option value=\"IT\">IT</option>\r\n");
      out.write("  <option value=\"CSE\">CSE</option>\r\n");
      out.write("  <option value=\"ECE\">ECE</option>\r\n");
      out.write("    <option value=\"EEE\">EEE</option>\r\n");
      out.write("  <option value=\"EIE\">EIE</option>\r\n");
      out.write("  <option value=\"CIVIL\">CIVIL</option>\r\n");
      out.write("  <option value=\"MBA\">MBA</option>\r\n");
      out.write("  <option value=\"MCA\">MCA</option>\r\n");
      out.write("</select></td></tr>\r\n");
      out.write("<tr><td>Row</td><td><select name=\"brow\">\r\n");
      out.write("  <option value=\"\">Enter Row</option>\r\n");
      out.write("  <option value=\"1ST\">1st</option>\r\n");
      out.write("  <option value=\"2ND\">2nd</option>\r\n");
      out.write("  <option value=\"3RD\">3rd</option>\r\n");
      out.write("    <option value=\"4TH\">4th</option>\r\n");
      out.write("  <option value=\"5TH\">5th</option>\r\n");
      out.write("</select></td></tr>\r\n");
      out.write("<tr  ><td colspan=\"2\"><center><input type=submit value=Store /></center></td></tr>\r\n");
      out.write("</table>\r\n");
      out.write("</form>\r\n");
      out.write("</center>\r\n");
      out.write("</div></div>\r\n");
      out.write("</div>\r\n");
      out.write("</body>\r\n");
      out.write("</html>");
    } catch (Throwable t) {
      if (!(t instanceof SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          try { out.clearBuffer(); } catch (java.io.IOException e) {}
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
      }
    } finally {
      _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}
