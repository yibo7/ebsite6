<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="EbSite.Web.Pagesm.list" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
           <XS:RepeaterList ID="rpGetClassList"   runat="server"  >
                             <ItemTemplate>    
                             
                             <ul>
                              <li class="list_title">
                                <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                              </li>
                              <li class="text">
                                
                                 <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>">[阅读全文]</a></a></li>
                              <li class="ot">
                                <span>作者：<font color="red"><%#Eval("UserNiName").ToString()%></font> </span><span> 
                                发表于：<font color="red"><%#Eval("addtime")%></font></span>
                                <span> 点击：<font color="red"><%#Eval("hits")%></font></span></li>
                              </ul>  <asp:Repeater ID="rpsub"   runat="server"  >
                                     <ItemTemplate>  

                                        
                                     </ItemTemplate>
                                 </asp:Repeater>

                             </ItemTemplate>
                         </XS:RepeaterList>
                         <XS:PagesContrl ID="pgCtr" runat="server" /> 
</body>
</html>
