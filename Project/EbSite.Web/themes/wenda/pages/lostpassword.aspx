<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.lostpassword" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
   <div style=" padding-top:50px; width:100%;" class="txt-c">
        <div class="box-p">            
                <div  class="box-s"> 
                <div class="box-title" >
                    <span style="float:left">找回密码</span>
                    <span style="float:right; font-weight:normal; color:Red">请输入您注册时的邮箱地址</span>
                </div>
                    <div class="box-content" style="padding:20px;   vertical-align:middle" >
                        <table id="tbEmail" runat="server" >
                            <tr>
                                <td>邮箱:</td>
                                <td><XS:TextBoxVl ID="txtEmail" runat="server" Width="200"  IsAllowNull="false" ValidateType="电子邮箱email" /></td>
                            </tr>
                        </table >
                        <table id="tbPass" runat="server" >
                            <tr>
                                <td>新密码:</td>
                                <td> <XS:TextBoxVl  ID="txtPassWord"  runat="server" TextMode="Password"  IsAllowNull="false" /></td>
                            </tr>
                             <tr>
                                <td>确认密码:</td>
                                <td> <XS:TextBoxVl  ID="txtCfPassWord"  runat="server" TextMode="Password" IsAllowNull="false" /></td>
                            </tr>
                        </table>
                    <div>
                    <asp:Button ID="btnSave" runat="server" 
                            Text=" 提 交 " onclick="btnSave_Click" />
                    </div>

                        <div style=" float:right;">
                            <a href="<%=IISPath %>">返回首页</a>
                        </div>
                          
                    </div>       				    
                		
               </div>
    </div>
    
    </div>
    </form>
</body>
</html>
