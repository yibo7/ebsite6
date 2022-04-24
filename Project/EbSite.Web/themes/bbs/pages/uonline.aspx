<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.uonline" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    

<div  style="background-color:#F4F4F4">
   <div class="usercontainer" style="position:relative; ">
    
	  
     	<div class="top_part2 logoline">
         	 	<div class="bmlogo"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></div>
		 	 <div class="logofont">在线用户</div>
			<div class="logofnt">做最好用的.net网站建设系统</div>
          	<div class="login_link"><a href="/">首页</a> <a>帮助</a></div>
      	</div>
      <div class="clear"></div>
     

   </div>
</div>


<div class="usercontainer2"  >
	<div class="usercontainer"  style="background-color:#FFFFFF; border:1px solid #ccc; height:600px;  ">
	    <asp:Repeater ID="rpUserOnline" runat="server"  >
                     <HeaderTemplate>
                            <div class="gdList_title">
                    
                                <div style="width: 120px;">
                                    用户名称</div>
                                    <div style="width: 200px;">最后活动时间</div>
                                <div style="width: 320px;">最后活动页面</div>
                               
                            </div>
                        </HeaderTemplate>
                         <ItemTemplate>
                             
                                 <div class="gdListContent" style="height: 30px;">
                                        <div style="width: 120px;"><a href="<%#GetUserLink(Eval("UserID")) %>"><%#Eval("UserNiname")%></a></div>
                                        <div style="width: 200px;"><%#Eval("LastUpdateTime")%></div>
                                        <div style="width: 320px;"><a href="<%#Eval("WebUrl")%>"><%#Eval("WebUrl")%></a></div>
                                        
                                 </div>
                                 
                         </ItemTemplate>
                 </asp:Repeater>

            <XS:PagesContrl ID="pgCtr" PageSize="30" runat="server" /> 
	</div>   
</div>
    
</body>
</html>
