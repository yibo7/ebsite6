<%@ Page Language="C#" AutoEventWireup="true"   Inherits="EbSite.Web.Pagesm.special" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <div id="page">
        <div class="cont">

    <!--#include file="header.inc" -->
<div class="w-navigator">
        <a id="push-right" class="selclass" ><%=Model.SpecialName %> 筛选专题</a><b>|</b>
       <a href="<%=HostApi.MGetIndexHref() %>">首页</a><b>|</b>  
        <a href="<%=HostApi.MUccIndexRw %>">我的中心<span class="unread"></span></a>
</div>
    
     
     <div id="container1">
        <ul class="data-list">
             <asp:Repeater ID="rpSpecialList"     runat="server"  >
                <ItemTemplate> 
                                <li>
                                    <a href="<%#HostApi.MGetContentLink(Eval("ID")) %>">  <%#Eval("newstitle")%></a>
                                </li>  
                             </ItemTemplate>
              </asp:Repeater>
           
          
          <div class="btnloadmore">加载更多...</div> 
           
        </ul>
        </div>
         <XS:PagesContrl ID="pgCtr" runat="server" /> 
      </div>
 <!--#include file="foot.inc" -->
  <div class="panel">
            <h2> 选择专题</h2>
            <ul class="panel-dir"> 
          <XS:RepeaterList  ID="rpGetSubSpecialList" runat="server">
            <ItemTemplate>
                 <li><a href="<%#EbSite.Base.Host.Instance.MGetSpecialHref(Eval("id"),1)%>"><%# Eval("SpecialName")%></a>
                       <hr />
                 </li>   
           </ItemTemplate>
        </XS:RepeaterList>                                
            </ul>
        </div>
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
