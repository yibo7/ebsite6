<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.uonline" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
     <asp:Repeater ID="rpUserOnline" runat="server"  >
                             <ItemTemplate>
                                 <div>
                                     <a href="<%#GetUserLink(Eval("UserID")) %>"><%#Eval("UserNiname")%></a>  
                                    
                                     最后活动时间:<%#Eval("LastUpdateTime")%>
                                     
                                     最后活动页面: <a href="<%#Eval("WebUrl")%>"><%#Eval("WebUrl")%></a>  
                                     
                                 </div>
                              
                             </ItemTemplate>
                         </asp:Repeater>

            <XS:PagesContrl ID="pgCtr" PageSize="1" runat="server" /> 
</body>
</html>
