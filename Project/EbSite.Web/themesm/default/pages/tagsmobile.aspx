<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pagesm.tagsmobile" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server"></head>
<body>
    
<!--#include file="header.inc" -->
<div class="w-navigator">
       <!--#include file="nav.inc" -->
    </div>
<div style="background: #fff;border: 1px solid #ccc; margin:8px;">
        <ul class="data-list">
              <asp:Repeater ID="rpList"  runat="server">
                                        <ItemTemplate>
                                            <li>  
                                                <a target="tags" href="<%#HostApi.MGetTagvHref(Eval("ID"),1)%>" ><%#Eval("TagName")%></a>(<span style=" color:Red"> <%#Eval("num")%></span>)
                                                              
                                            </li>
                                        </ItemTemplate>
                            </asp:Repeater>                        
                                 
         </ul>  
          <div class="btnloadmore">加载更多...</div> 
          <XS:PagesContrl ID="pgCtr" PageSize="10" runat="server" />                 
</div>

  <!--#include file="foot.inc" --> 
  <script>      loadpage(".data-list", ".btnloadmore", '.data-list li')</script>  
</body>
</html>
