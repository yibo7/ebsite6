<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.frdlinkpost" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        
        
        
        
        
<div  style="background-color:#F4F4F4">
   <div class="usercontainer" style="position:relative; ">
    
	  
     	<div class="top_part2 logoline">
         	 	<div class="bmlogo"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></div>
		 	 <div class="logofont">申请友情连接</div>
			<div class="logofnt">做最好用的.net网站建设系统</div>
          	<div class="login_link"><a href="/">首页</a> <a>帮助</a></div>
      	</div>
      <div class="clear"></div>
     

   </div>
</div>


<div class="usercontainer2"  >
	<div class="usercontainer"  style="background-color:#FFFFFF; border:1px solid #ccc; height:600px;  ">
	    
        
        <div style="margin: 0 auto; width: 99%; padding-top: 20px;">

            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>站点名称:
                    </td>
                    <td>

                        <XS:TextBoxVl ID="tbSiteName" Width="300" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>站点地址:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tburl"  ValidateType="网址Url"  Width="300" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>logo 图片:
                    </td>
                    <td>
                        <XS:SWFUpload ID="upTest" AllowExt="jpg,gif,png"  UploadModel="SWFUpload组件"  AllowSize="1024" Width="300"  HintInfo="上传文件只允许上传图片文件哦，并且只能上传jpg,gif,png格式的图片" SaveFolder="LogoPic"  runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>QQ:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbQQ" Width="300" IsAllowNull="false" ValidateType="QQ号" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>Emal:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbemail" Width="300" IsAllowNull="false" ValidateType="电子邮箱email" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>电话:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbtel" Width="300" IsAllowNull="false" runat="server" ValidateType="电话号码加区号" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                 <tr>
                    <td>手机:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbmobile" Width="300" IsAllowNull="false" runat="server" ValidateType="手机号" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>描述:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbdemo" Width="300" Height="100" IsAllowNull="false" TextMode="MultiLine" runat="server" ValidationGroup="BB"></XS:TextBoxVl>

                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                            <XS:Button ID="bntSave" runat="server" Text="  提 交 申 请  " ValidationGroup="BB"  OnClick="bntSave_Click"/>
                            
                            <br/><br/>
                            
                             <a href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).FrdlinkRw %>">查看所有友情连接</a>
                        </div>
                    
                    </td>
                </tr>
            </table>

        </div>

	</div>   
</div>
        

    </form>
</body>
</html>
