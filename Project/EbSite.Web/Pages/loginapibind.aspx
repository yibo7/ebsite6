<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginapibind.aspx.cs" Inherits="EbSite.Web.Pages.loginapibind" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>完成资料</title>
</head>
<body>
  <form runat="server" id="formregbind" method="post" >

    <div style=" width:800px; height:600px; padding:0px;" class="box">            
                           <div style=" height:30px; line-height:30px; border-bottom:1px solid #ccc; font-size:14px; font-weight:bold; ">
                                完善资料
                           </div>
                           <div style=" width:100%;height:570px; ">

                                <div style="width:250px; height:100%;  padding:20px;" class="fLeft">
                                   <asp:Image ID="imgIcon" runat="server" ImageUrl="/images/no-img.jpg" width="180" height="180" />
                                </div>
                                <div style="width:480px;" class="fRight">
                                   <table width="477" border="0" cellpadding="0" cellspacing="0" style="color:#5C5C5C; font-size:14px; margin-top:30px; margin-left:30px;">
                                    
                                         <tr id="show_username" >
                                        <td width="78" height="58" align="right">姓名/昵称：</td>
                                        <td width="248">
                                             <asp:TextBox ID="reg_username" CssClass="inp_name" Text="姓名/昵称"  runat="server"></asp:TextBox>
                                        </td>
                                        <td width="151"><span id="errreg_username" style="color:#ccc; font-size:12px;"></span></td>
                                        </tr>
                                      <tr id="show_email">
                                        <td width="78" height="58" align="right">Email：</td>
                                        <td width="248">                                            
                                            <asp:TextBox ID="reg_email" class="inp_name" Text="您的Email地址" CssClass="inp_name" runat="server"></asp:TextBox>    
                                        </td>
                                        <td width="151">
                                            <span id="errreg_email" style="color:#ccc; font-size:12px;"></span>
                                         </td>
                                        </tr>                                       
    
                                      <tr>
                                        <td align="right" height="51">密码：</td>
                                        <td>
                                            <asp:TextBox ID="reg_pwd" TextMode="Password" CssClass="inp_name" Text="1111" class="inp_name" runat="server"></asp:TextBox>
                                        </td>
                                        <td><span id="errreg_pwd" style="color:#ccc; font-size:12px;"></span></td>
                                        </tr>
                                        <tr>
                                        <td align="right" height="59">确认密码：</td>
                                        <td>
                                            <asp:TextBox ID="reg_pwdr" TextMode="Password" CssClass="inp_name" Text="1111" class="inp_name" runat="server"></asp:TextBox>
                                        </td>
                                        <td><span id="errreg_pwdr" style="color:#ccc; font-size:12px;"></span></td>
                                        </tr>
                                   
                       
                                      <tr>
                                        <td height="51">&nbsp;</td>
                                        <td>
                                             <asp:Button  ID="btnRegUser" runat="server" Text=" 保 存 " />
                                            
                                        </td>
                                        <td>  </td>
                                        </tr>
                                         <tr>
                                        <td height="51">&nbsp;</td>
                                        <td>
                                          <XS:LinkButton ID="lbtnNext" runat="server" >以后再说,立即去购物!</XS:LinkButton>
                                        </td>
                                        <td>  </td>
                                        </tr>
                                       
                                    </table>
                                    
                                
                                </div>
                           
                           </div>
    </div>
   </form>
</body>
</html>
