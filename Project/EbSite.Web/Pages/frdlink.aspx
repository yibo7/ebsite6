<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frdlink.aspx.cs" Inherits="EbSite.Web.Pages.frdlink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    

   <asp:Repeater ID="rpFrdlinkLogo" runat="server">
       <ItemTemplate>
           <a href="<%#Eval("url") %>" target="_blank"><img src=" <%#Eval("logourl") %>"/></a>
       </ItemTemplate>
   </asp:Repeater>


    <asp:Repeater ID="rpFrdlinkText" runat="server">
        <ItemTemplate>
            <a href="<%#Eval("url") %>" target="_blank"><%#Eval("sitename") %></a>
        </ItemTemplate>
    </asp:Repeater>
</body>
</html>
