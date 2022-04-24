<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysLogin.aspx.cs" Inherits="EbSite.Web.AdminHt.SysLogin" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server" >
    <title>管理员登录</title>
</head>
<body style=" background-color:#EDF4F9">
    <form id="form1" runat="server">

    <div class="adminlogin_banner">
                                            <div id = "logo">	
                                                   										
											</div>
                                         
                                            <div id = "logoRight">
                                            &nbsp;&nbsp;
                                          <a href="<%=EbSite.Base.AppStartInit.IISPath %>"> 网站首页</a>
                                           &nbsp;&nbsp;
                                           <a href="http://www.ebsite.net/help/">使用帮助</a>
                                           &nbsp;&nbsp;
                                           <a href="http://www.ebsite.net">关于EbSite</a>
                                            </div>
    </div>

    <div class="adminlogin_banner2">
        <table style=" margin-left:auto; margin-right:auto;  ">
            <tr>
                <td  class="ebsiteadminpic" >
                    <div class="loginbox-p">            
                            <div  class="loginbox-s"> 
                            <div class="loginbox-title" >管理员登录</div>
                                <div class="loginbox-content" style="padding-left:20px;" >
                                   
                                    <table  >
                                <tr>
                                    <td>
                                        <font color='#E78A29'>*</font> 用户名称：
                                    </td>
                                    <td colspan="2">
                                        <XS:TextBoxVL ID="txtUserName" runat="server"  IsAllowNull="false"   MaxLength="100"></XS:TextBoxVL>
                                    </td>
                                </tr>
                    
                                <tr>
                                    <td>
                                        <font color='#E78A29'>*</font> 密码：
                                    </td>
                                    <td colspan="2">
                                        <XS:TextBoxVL ID="txtPassWord" runat="server" TextMode="Password" IsAllowNull="false" ></XS:TextBoxVL>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font color='#E78A29'>*</font> 验证码：
                                    </td>
                                    <td>
                            
                                        <XS:TextBoxVL ID="txtSafeCoder" runat="server" Width="80"  IsAllowNull="false" ></XS:TextBoxVL>
                        
                                    </td>
                                    <td>
                                        <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" style="cursor:pointer;" ImageUrl="../ValidateCode.ashx?"  ToolTip="图片看不清？点击重新得到验证码,不区分大小写!红色数字,黑色字母!"></asp:Image>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center; height:50px; padding-left:100px;">
                                        <XS:Button ID="btnLogIn" runat="server" Width="100" Text="登  录" onclick="btnLogIn_Click"  />
                                        <a style="color:#FF0000;" href="<%=HostApi.LostpasswordRw %>">忘记密码？</a>
                                    </td>
                                    <td>
                                                    <asp:label id="lbErrInfo"  runat="server" ForeColor="Red" ></asp:label>
                                    </td>
                                </tr>
                            </table>
                                </div>       				    
                		
                           </div>
                </div>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <div style=" text-align:center; padding:20px;">
            @2009 ebsite Inc. All rights reserved Powered by <a target=_blank href="http://www.ebsite.net">EbSite</a>
        </div>
    </div>
    
    </form>
</body>
</html>
