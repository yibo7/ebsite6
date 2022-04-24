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
        <a <%=rpGetSubSpecialList.Items.Count>0?"  id='push-right'":"" %> class="selclass" ><%=Model.SpecialName %> 筛选专题</a><b>|</b>
       <a href="<%=HostApi.MGetIndexHref() %>">首页</a><b>|</b>  
        <a href="<%=HostApi.MUccIndexRw %>">我的中心<span class="unread"></span></a>
</div>
    
     
     <div id="container1">
        <ul class="data-listex">
             <asp:Repeater ID="rpSpecialList"     runat="server"  >
                <ItemTemplate>    <li>
                      <a class="ItemCell" href="<%#HostApi.MGetContentLink(Eval("ID")) %>">
                                    <div class="ProImg">
                                         <img width="80" height="60" alt=" <%#Eval("newstitle")%>" src="<%#Eval("smallpic") %>">
                                    </div>
                                    <div class="proright">
                                        <div class="ProName"><%#Eval("newstitle")%></div>
                                        <div class="NePrice"> <span>&yen;<%#Eval("annex16") %></span><em>(库存：<%# EbSite.Core.Utils.ObjectToInt(Eval("annex12"),0)>0?"有货":"<span style='color:red;'>暂时缺货</span>" %>)</em></div>
                                    </div>
                                </a> 
                                  </li>
                             </ItemTemplate>
              </asp:Repeater>
          
        </ul>
       
        </div>
           <div class="btnloadmore">加载更多...</div> 
         <XS:PagesContrl ID="pgCtr" PageSize="5" runat="server" /> 
      </div>
 <!--#include file="foot.inc" -->
  <div class="panel">
            <h2> 选择专题</h2>
            <ul class="panel-dir"style="padding:0px;height:400px;overflow-y:auto;width:250px; position:fixed;margin-top : 10px;">
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


        loadpage(".data-listex", ".btnloadmore", '.data-listex li');
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
