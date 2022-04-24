<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.lostpassword" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>   
    
<div  style="background-color:#F4F4F4">
   <div class="usercontainer" style="position:relative; ">
    
	  
     	<div class="top_part2 logoline">
         	 	<div class="bmlogo"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></div>
		 	 <div class="logofont">找回密码</div>
			<div class="logofnt">做最好用的.net网站建设系统</div>
          	<div class="login_link"><a href="/">首页</a> <a>帮助</a></div>
      	</div>
      <div class="clear"></div>
     

   </div>
</div>
<div class="usercontainer2"  >
	<div class="usercontainer"  style="background-color:#FFFFFF; border:1px solid #ccc; height:600px;  ">
	   <div class="login">
		 
		  <div> 
          <div class="dl_main">
          <form id="form2" runat="server">
              <div id="tbEmail" runat="server">
                  <table  >
                            <tr>
                                <td>输入手机号:</td>
                                <td>
                                   <input type="text"  id="emailormobile" class="inp_name" />
                                </td> 
                            </tr>
                            <tr>                              
                                <td align="right" height="59">验证码：</td>
                                    <td>
                                        <input type="text"  id="yzmmobile" class="inp_yzm2" style="float: left" /> 
                                        <input type="button"  value="获取验证码" onclick="getSafeCode(this)" 
                                            style="float: left;height:35px;" /> 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="button"  value="提交" onclick="gotoChangePass()" style="height:35px;" /> 
                                </td>
                                <td></td>
                            </tr>
                        </table>
              </div>
              <div id="tbPass" runat="server">
                  <table>
                            <tr>
                                <td>新密码:</td>
                                <td> <XS:TextBoxVl  ID="txtPassWord"  runat="server" TextMode="Password"  IsAllowNull="false" /></td>
                            </tr>
                             <tr>
                                <td>确认密码:</td>
                                <td> <XS:TextBoxVl  ID="txtCfPassWord"  runat="server" TextMode="Password" IsAllowNull="false" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnSave"  runat="server" CssClass="btn" Text=" 提 交 " onclick="btnSave_Click" />
                                </td>
                            </tr>
                  </table>
               </div> 
			  </form>
              </div>
			 <div class="qita">
			    <div style="font-size: 14px; margin-top: 50px; padding-left:40px;"> 还没有账号？请先<a style="color: #076FA2; text-decoration: underline" href="<%=HostApi.RegRw%>">注册
                </a>
              </div>
              <div style="font-size: 14px; color: #9B9B9B; padding-left: 40px; padding-top: 25px;">
                使用合作网站账号登陆
              </div>
              <div style="padding-left: 40px; margin-top: 5px;">
                <a  href='<%=HostApi.GetLoginApiUrl("SINA")%>'><img src="<%=base.ThemeCss%>user/qq_1.jpg" /></a>
              </div>
              <div style="padding-left: 40px; margin-top: 5px;">
                <a  href='<%=HostApi.GetLoginApiUrl("QQ")%>'><img src="<%=base.ThemeCss%>user/qq_2.jpg" /></a>
              </div>
           
              
			 </div>
			 <div class="clear"></div>
		  </div>
	   </div>
	</div>   
</div>
<script src="/js/lostpassword.js" language="JavaScript"></script>

</body>
</html>
