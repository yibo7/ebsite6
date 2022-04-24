<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lostpassword.aspx.cs" Inherits="EbSite.Web.Pages.lostpassword" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
   <div style="text-align:center; padding-top:50px;">
        <div class="box-p">            
                <div  class="box-s"> 
                <div class="box-title" >
                    <span style="float:left">找回密码</span>
                    <span style="float:right; font-weight:normal; color:Red">请输入您注册时的邮箱地址</span>
                </div>
                    <div class="box-content" style="padding:20px;   vertical-align:middle" >
                         <div id="tbEmail" runat="server">
                             <table  >
                            <tr>
                                <td>输入手机号:</td>
                                <td>
                                   <input type="text" name="reg_emailormobile" value="您的Email地址" id="reg_email" class="inp_name" />
                                </td> 
                            </tr>
                            <tr>                              
                                <td align="right" height="59">验证码：</td>
                                    <td>
                                        <input type="text" name="reg_yzmmobile" id="reg_yzmmobile" class="inp_yzm2" style="float: left" /> 
                                        <input type="button"  value="获取验证码" onclick="sendMobileMsg(this)" style="float: left;height:35px;" /> 
                                </td>
                            </tr>

                        </table>
                        </div>
                        <div id="tbPass" runat="server" >
                            <table >
                            <tr>
                                <td>新密码:</td>
                                <td> <XS:TextBoxVl  ID="txtPassWord"  runat="server" TextMode="Password"  IsAllowNull="false" /></td>
                            </tr>
                             <tr>
                                <td>确认密码:</td>
                                <td> <XS:TextBoxVl  ID="txtCfPassWord"  runat="server" TextMode="Password" IsAllowNull="false" /></td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:Button ID="btnSave" runat="server" Text=" 提 交 " onclick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                 
                         </div>
                        
                        
                          
                    </div>       				    
                		
               </div>
    </div>
    
    </div>
    </form>
</body>
</html>
