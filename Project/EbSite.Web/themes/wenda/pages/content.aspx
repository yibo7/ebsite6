<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.content" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>
<body>
    <!--#include file="header.inc"-->
    <div style="width: 990px; margin: 8px auto; font-size: 14px;">
       
        <%=GetNav("-", true)%>
    </div>
    <div class="content" style="width: 990px; margin: 8px auto;">
        <div class="c_left">
            <h2 style="text-align: center"><%=Model.NewsTitle %></h2>
            <br /><br />
             <%=ShowInfo%>
            <br /><br /> 
             <% if (!Equals(CPINext, null))
                { %>
             下一节:<a href="<%=CPINext.Href %>"><%=CPINext.Title %></a>
             <% } %>
         </div>
         <div class="c_right">
              <div class="bor_c">
                <div class="crtabtop">章节</div>
                <div class="crtabli">
                   <asp:Repeater ID="rpPageInfo"   runat="server"  >
                       <ItemTemplate>  
                            <li><a href="<%#Eval("Href")%>"><%#Eval("Title")%></a> </li>       
                       </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
             
         </div>
    </div> 
    <!--#include file="footer.inc"-->
    
    <script type="text/javascript" src="<%= base.ThemePage%>content.js"></script>
</body>
</html>