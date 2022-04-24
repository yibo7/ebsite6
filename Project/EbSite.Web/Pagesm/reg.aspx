<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="EbSite.Web.Pagesm.reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:TextBox ID="txtEmail" runat="server" ValidateType="电子邮箱email" IsAllowNull="false" ></asp:TextBox>
     <asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" IsAllowNull="false" ></asp:TextBox>
     <asp:TextBox ID="txtCfPassWord" runat="server" TextMode="Password" IsAllowNull="false" ></asp:TextBox>
     <asp:LinkButton ID="btnAddUser" runat="server" Text="注册用户"  OnClick="btnAddUser_Click" />
    </div>
    </form>
</body>
</html>
