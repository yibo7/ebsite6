<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.content" %>
	<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
	<%@ Import Namespace="EbSite.BLL.GetLink"%>
	<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!doctype html>
<html>
	<head runat="server">
	
	</head>
	<body >
	 <div id="page">
        <div class="cont">
 <!--#include file="header.inc" -->
    <div >
       
        <%=GetNav("-", true)%>  
         <a id="push-right" class="selclass" >章节</a>
    </div>
    <div class="content"> 
               <%=ShowInfo%>
               
                <br /><br /> 
             <% if (!Equals(CPINext, null))
                { %>
             下一节:<a href="<%=CPINext.Href %>"><%=CPINext.Title %></a>
             <% } %>
    </div> 
       <!--#include file="foot.inc" --> 
    </div>	
     </div>
	 <div class="panel">
            <h2> 选择章节</h2>
            <ul class="panel-dir"> 
                <asp:Repeater ID="rpPageInfo"   runat="server"  >
                       <ItemTemplate>  
                            <li><a href="<%#Eval("Href")%>"><%#Eval("Title")%></a> </li>       
                       </ItemTemplate>
                    </asp:Repeater>
            </ul>
        </div>

       
   
     <script type="text/javascript">
         In.ready('gmue-touch', 'gmue-throttle', 'gmue-scrollStop', 'gmue-ortchange', 'gmue-matchMedia', 'gmuw-panel', function () {
             $(function ($) {
                 $('.panel').panel({
                     contentWrap: $('.cont')
                 });

                 $('#push-right').on('click', function () {
                     $('.panel').panel('toggle', 'push', 'right');
                 });
             } (Zepto));
         });
    </script>
	</body>
	</html>
    