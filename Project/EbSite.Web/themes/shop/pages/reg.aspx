<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.reg" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>

<body >

<div  style="background-color:#F4F4F4">
   <div class="container" style="position:relative; ">
    
	  
     	<div class="top_part2 logoline">
         	 	<div class="bmlogo"><img src="<% =base.ThemeCss%>images/logo.png"  class="logo" /></div>
		 	 <div class="logofont">�û�ע��</div>
			<div class="logofnt">������õ�.net��վ����ϵͳ</div>
          	<div class="login_link"><a href="/">��ҳ</a> <a>����</a></div>
      	</div>
      <div class="clear"></div>
     

   </div>
</div>
<form id="form1"  >
<div class="container2"  >
	<div class="container"  style="background-color:#FFFFFF; border:1px solid #ccc; height:600px;  ">
	   <div class="login">
		 
		  <div>
			 <div class="dl_main">
			<table width="477" border="0" cellpadding="0" cellspacing="0" style="color:#5C5C5C; font-size:14px; margin-top:30px; margin-left:30px;">
                        <tr>
                                <td width="78" height="58"  align="right">
    
                                </td>
                                <td  colspan="2" class="regtype">
                                    <label for="reg_type0"><input type="radio" value="0" checked="checked" name="reg_type" 
                            id="reg_type0" />Emailע��</label>
                                     <label for="reg_type1"><input type="radio" value="1" name="reg_type" id="reg_type1" />�ʺ�ע��
                            </label>
                                     <label for="reg_type2"><input type="radio" value="2" name="reg_type" id="reg_type2" />�ֻ���ע��</label></td>
   
                                </tr>
                                 <tr id="show_username" style=" display:none;">
                                <td width="78" height="58" align="right">�ʺţ�</td>
                                <td width="248"><input type="text" name="reg_username" id="reg_username" value="�����ʺ�" 
                            class="inp_name" /></td>
                                <td width="151"><span id="errreg_username" style="color:#ccc; font-size:12px;"></span></td>
                                </tr>
                              <tr id="show_email">
                                <td width="78" height="58" align="right">Email��</td>
                                <td width="248"><input type="text" name="reg_email" value="����Email��ַ" id="reg_email" 
                            class="inp_name" /></td>
                                <td width="151"><span id="errreg_email" style="color:#ccc; font-size:12px;"></span></td>
                                </tr>
                                <tr id="show_mobile" style=" display:none;">
                                <td width="78" height="58" align="right">�ֻ��ţ�</td>
                                <td width="248"><input type="text" name="reg_mobile" value="�����ֻ���"  id="reg_mobile" 
                            class="inp_name" /></td>
                                <td width="151"><span id="errreg_mobile" style="color:#ccc; font-size:12px;"></span></td>
                                </tr> 
    
                              <tr>
                                <td align="right" height="51">���룺</td>
                                <td><input type="password" name="reg_pwd" value="11111" id="reg_pwd" class="inp_name" /></td>
                                <td><span id="errreg_pwd" style="color:#ccc; font-size:12px;"></span></td>
                                </tr>
                                <tr>
                                <td align="right" height="59">ȷ�����룺</td>
                                <td><input type="password" value="11111" name="reg_pwdr" id="reg_pwdr" class="inp_name" /></td>
                                <td><span id="errreg_pwdr" style="color:#ccc; font-size:12px;"></span></td>
                                </tr>
                                <tr>
                                <td align="right" height="59">��֤�룺</td>
                                <td><input type="text" name="reg_yzm" id="reg_yzm" class="inp_yzm2" style="float:left" />
                                 <img class="ValidateCode" src="/ValidateCode.ashx?" onclick="this.src+=Math.random()"   
                            style="float:left; cursor: pointer; height:30px;" /></td>
                                <td><a onclick="$('.ValidateCode').click();" style="color:#076FA2;cursor: pointer;">�����壿<span 
                            style="text-decoration:underline">��һ��</span></a></td>
                                </tr>
                              <tr>
                                <td height="19">&nbsp;</td>
                                <td style="font-size:12px;"><span id="errreg_yzm" style="color:#ccc"></span></td>
                                <td>&nbsp;</td>
                                </tr>
                                <tr>
                                <td height="33">&nbsp;</td>
                                <td style="font-size:12px;">
                                <br /><br />
                                <input type="checkbox" name="reg_agree"  id="reg_agree" style="float:left; margin-right:5px; 
                            display:inline"/>�����Ķ���ͬ��<a  onclick="openagree()" style="color:#478FDB; cursor:pointer;">�û�Э��</a></td>
                                <td><span id="errreg_agree" style="color:#ccc; font-size:12px;"></span></td>
                                </tr>
                              <tr>
                                <td height="51">&nbsp;</td>
                                <td>
                                     <input  type="image" id="btnRegUser"   src="<%=base.ThemeCss%>images/zc.jpg" />
                                </td>
                                <td></td>
                                </tr>
                            </table>
	
			 </div>
			 <div class="qita">
			    <div style="font-size: 14px; margin-top: 50px; padding-left:40px;"> ���û�����<a style="color: #076FA2; text-decoration: underline" href="<%=HostApi.LoginRw%>">��¼</a>
              </div>
              <div style="font-size: 14px; color: #9B9B9B; padding-left: 40px; padding-top: 25px;">
                ʹ�ú�����վ�˺ŵ�½
              </div>
              <div style="padding-left: 40px; margin-top: 5px;">
                <a  href='<%=HostApi.GetLoginApiUrl("SINA")%>'><img src="<%=base.ThemeCss%>images/qq_1.jpg" /></a>
              </div>
              <div style="padding-left: 40px; margin-top: 5px;">
                <a  href='<%=HostApi.GetLoginApiUrl("QQ")%>'><img src="<%=base.ThemeCss%>images/qq_2.jpg" /></a>
              </div>
           
              
			 </div>
			 <div class="clear"></div>
		  </div>
	   </div>
	</div>   
</div>
</form>
<script type="text/javascript">
    In.ready('userreg', function () {
        inivalidateregform('form1');
    });
</script>
</body>
</html>