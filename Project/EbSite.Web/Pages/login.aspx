<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="login.aspx.cs" Inherits="EbSite.Web.Pages.login" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>
<body >
<form id="form1" runat="server">
 <div style="text-align:center">
    <div style=" width:960px; background-color:#FFF; padding-top:10px;">
        <div class="box-p">            
                <div  class="box-s"> 
                <div class="box-title" >
                    <span style="float:left">用户登录</span>
                    <span style="float:right; font-weight:normal">如果您还注册,请先<a style="color:#FF0000;" href="reg.aspx">注册新用户</a></span>
                </div>
                    <div class="box-content" style="padding-left:20px;" >
                        <br />
                        <table  >
                                <tr>
                                    <td>
                                        <font color='#E78A29'>*</font> 用户名称：
                                    </td>
                                    <td colspan="2">
                                        <XS:TextBox ID="txtUserName" runat="server" CanBeNull="必填"  MaxLength="100"></XS:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <font color='#E78A29'>*</font> 密码：
                                    </td>
                                    <td colspan="2">
                                        <XS:TextBox ID="txtPassWord" runat="server" TextMode="Password" CanBeNull="必填" ></XS:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="IsOpenSafeCoder">
                                    <td>
                                        <font color='#E78A29'>*</font> 验证码：
                                    </td>
                                    <td >
                                        
                                        <XS:TextBox ID="txtSafeCoder" runat="server" Width="80" CanBeNull="必填" ></XS:TextBox>
                                    
                                    </td>
                                    <td>
                                        <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" style="cursor:pointer;" ImageUrl="ValidateCode.ashx?"  HintInfo="图片看不清？点击重新得到验证码,不区分大小写!红色数字,黑色字母!"></asp:Image>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:right; height:80px; padding-left:50px;">
                                        <XS:Button ID="btnLogIn" runat="server" Text="登  录" Width="100" onclick="btnLogIn_Click"  />
                                        <a style="color:#FF0000;" href="lostpassword.aspx">忘记密码？</a>
                                    </td>
                                    <td>
                                        <asp:label id="lbErrInfo"  runat="server" ForeColor="Red" ></asp:label>
                                    </td>
                                </tr>
                            </table>
                    </div>       				    
                		
               </div>
    </div>
    
    </div>
        
</div>


</form>
<br />
<!--底部-->                                          
<div class="wrapper mT5 mB10">
  <div class="title_top">
    <div class="title_top_i"></div>
  </div>
  <div class="ucontent">
    <%=EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.Copyright %>
  </div>
  <div class="title_buttom">
    <div class="title_buttom_i"></div>
  </div>
</div>
 
<div style="top: 1475px;" id="foot"></div>

</body>
</html>