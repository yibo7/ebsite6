<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysLogin.aspx.cs" Inherits="EbSite.Web.AdminHt.SysLogin" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员登录</title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="adminlogin_banner">
            <div id="logo">
            </div>

            <div id="logoRight">
                <a href="<%=EbSite.Base.AppStartInit.IISPath %>">网站首页</a>
            </div>
        </div>
        <div style="text-align: center;width:100%;">
            <div  class="loginbox-p">
                <div class="loginbox-s">
                    <div class="loginbox-title">管理员登录</div>
                    <div class="loginbox-content" style="padding-left: 20px;">

                        <table>
                            <tr>
                                <td>
                                    <font color='#E78A29'>*</font> 用户名称：
                                </td>
                                <td colspan="2">
                                    <XS:TextBoxVl ID="txtUserName" runat="server" IsAllowNull="false" MaxLength="100"></XS:TextBoxVl>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <font color='#E78A29'>*</font> 密码：
                                </td>
                                <td colspan="2">
                                    <XS:TextBoxVl ID="txtPassWord" runat="server" TextMode="Password" IsAllowNull="false"></XS:TextBoxVl>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <font color='#E78A29'>*</font> 验证码：
                                </td>
                                <td>

                                    <XS:TextBoxVl ID="txtSafeCoder" runat="server" Width="80" IsAllowNull="false"></XS:TextBoxVl>

                                </td>
                                <td>
                                    <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" Style="cursor: pointer;" ImageUrl="../ValidateCode.ashx?" HintInfo="图片看不清？点击重新得到验证码,不区分大小写!红色数字,黑色字母!"></asp:Image>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center; height: 50px; padding-left: 100px;">
                                    <XS:Button ID="btnLogIn" runat="server" Width="100" Text="登  录" OnClick="btnLogIn_Click" />
                                    <a style="color: #FF0000;" href="<%=HostApi.LostpasswordRw %>">忘记密码？</a>
                                </td>
                                <td>
                                    <asp:Label ID="lbErrInfo" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
            </div>

        </div>
        <div>
            <div style="text-align: center; padding: 20px;">
                @2009 ebsite Inc. All rights reserved Powered by <a target="_blank" href="https://github.com/yibo7/ebsite6">EbSite</a>
            </div>
        </div>

    </form>
</body>
</html>
