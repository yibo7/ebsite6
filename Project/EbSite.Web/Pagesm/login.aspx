<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EbSite.Web.Pagesm.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtUserPass" TextMode="Password" runat="server"></asp:TextBox>
        <asp:LinkButton ID="lbLogin" runat="server">登录</asp:LinkButton>
         <asp:label id="lbErrInfo"  runat="server" ForeColor="Red" ></asp:label>
    </div>
    </form>
</body>
</html>
