<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.login" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body >

<div  style="background-color:#F4F4F4">
   <div class="usercontainer" style="position:relative; ">
    
	  
     	<div class="top_part2 logoline">
         	 	<div class="bmlogo"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></div>
		 	 <div class="logofont">用户登录</div>
			<div class="logofnt">做最好用的.net网站建设系统</div>
          	<div class="login_link"><a href="/">首页</a> <a>帮助</a></div>
      	</div>
      <div class="clear"></div>
     

   </div>
</div>
<form id="form1"  >
    
<div class="usercontainer2"  >
	<div class="usercontainer"  style="background-color:#FFFFFF; border:1px solid #ccc; height:600px;  ">
	   <div class="login">
		 
		  <div>
			 <div class="dl_main">
			 	<div class="sj_top">
					<li tid="0" name="lg_username" class="cur" ><a >账户登录</a></li>
					<li tid="1" name="lg_emailmobile" style=" width:120px;" ><a>手机或邮箱登录</a></li>
					
				</div>
			  <div id="con1" style="padding-left:10px;">
					<table  border="0" cellpadding="0" cellspacing="0" class="sj_tab" >
						  <tr id="lg_username">
							<td  height="77" align="right">账号：</td>
							<td width="242"><input id="login_username" name="login_username"  type="text" value="您的帐号" class="inp_name"  /></td>
							<td width="171"><span id="errlogin_username" style="color:#ccc; font-size:12px;"></span></td>
					    </tr>
                        <tr id="lg_emailmobile" style="display:none;">
							<td  height="77" align="right">邮箱/手机号：</td>
							<td width="242"><input id="login_em" name="login_em" type="text" value="电子邮箱/手机号" class="inp_name"  /></td>
							<td width="171"><span id="errlogin_em" style="color:#ccc; font-size:12px;"></span></td>
					    </tr>
						  <tr>
							<td align="right">密码：</td>
							<td><input type="password" value="11111" id="login_pwd" name="login_pwd" class="inp_name" /></td>
							<td><span id="errlogin_pwd" style="color:#ccc; font-size:12px;"></span></td>
							</tr>
                          <tr style="display:none;" id="show_yzm">
                            <td align="right" height="59">验证码：</td>
                            <td><input type="text" name="login_yzm" id="login_yzm" class="inp_yzm2" style="float:left" />
                             <img id="ValidateCode" class="ValidateCode" src="/ValidateCode.ashx?" onclick="this.src+=Math.random()"   style="float:left; cursor: pointer; height:30px;" /></td>
                            <td><a onclick="$('.ValidateCode').click();" style="color:#076FA2;cursor: pointer;">看不清？<span style="text-decoration:underline">换一张</span></a></td>
                            </tr>
                            <tr style="display:none;" id="errshow_yzm">
                                <td height="19">&nbsp;</td>
                                <td style="font-size:12px;"><span id="errlogin_yzm" style="color:#ccc"></span></td>
                                <td>&nbsp;</td>
                             </tr>
						  <tr>
							<td height="32">&nbsp;</td>
							<td style="font-size:12px;"><input type="checkbox"    name="isremember" id="isremember" style="float:left; margin-right:5px; display:inline" />记住我（两周内自动登录） | <a  href="<%=HostApi.LostpasswordRw%>">忘记密码</a></td>
							<td>&nbsp;</td>
							</tr>
						  <tr>
							<td height="132">&nbsp;</td>
							<td>
							    <div><input type="image" id="btnLoginUser" src="<% =base.ThemeCss%>user/dl_img1.jpg" /></div>
							    
                                <div id="requesttips" style="margin-top: 10px;display: none;  color: #ff0000;">请求中...</div>
                            </td>
							<td>&nbsp;</td>
							</tr>
                            <tr>
                              <td colspan="3">
                                  <div></div>
                              </td>
                            </tr>
					</table>
				</div>
	
			 </div>
			 <div class="qita">
			    <div style="font-size: 14px; margin-top: 50px; padding-left:40px;"> 还没有账号？请先<a style="color: #076FA2; text-decoration: underline" href="<%=HostApi.RegRw%>">注册
                </a>
              </div>
              <div style="font-size: 14px; color: #9B9B9B; padding-left: 40px; padding-top: 25px;">
                使用合作网站账号登陆
              </div>
              <div style="padding-left: 40px; margin-top: 5px;">
                <a  href='<%=HostApi.GetLoginApiUrl("SINA")%>'><img src="<%=base.ThemeCss%>user/qq_1.jpg"  /></a>
              </div>
              <div style="padding-left: 40px; margin-top: 5px;">
                <a  href='<%=HostApi.GetLoginApiUrl("QQ")%>'><img src="<%=base.ThemeCss%>user/qq_2.jpg" /></a>
              </div>
			     <div style="padding-left: 40px; margin-top: 5px;">
			         <a  href='<%=HostApi.GetLoginApiUrl("WeiXin")%>'><img src="<%=base.ThemeCss%>user/qq_3.jpg" /></a>
			     </div>
              
			 </div>
			 <div class="clear"></div>
		  </div>
	   </div>
	</div>   
</div>
</form>
<script type="text/javascript">

    In.ready('userlogin', function () {
        
        custtomlogin('form1');
    });
</script>
</body>
</html>
