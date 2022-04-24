<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.frdlink" %>

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
		 	 <div class="logofont">友情连接</div>
			<div class="logofnt">做最好用的.net网站建设系统</div>
          	<div class="login_link"><a href="/">首页</a> <a>帮助</a></div>
      	</div>
      <div class="clear"></div>
     

   </div>
</div>


<div class="usercontainer2"  >
	<div class="usercontainer"  style="background-color:#FFFFFF; border:1px solid #ccc; height:600px; padding: 10px;  ">
	    <div><%=TisInfo %></div>
	   <div>网站合作:</div>
       <div>
            <asp:Repeater ID="rpFrdlinkLogo" runat="server">
               <ItemTemplate>
                   <a href="<%#Eval("url") %>" target="_blank"><img src="<%#Eval("logourl") %>"/></a>
               </ItemTemplate>
           </asp:Repeater>
       </div>
        <br/>
       <div>友情连接:</div>
       <div>
            <asp:Repeater ID="rpFrdlinkText" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("url") %>" target="_blank"><%#Eval("sitename") %></a>&nbsp;
            </ItemTemplate>
        </asp:Repeater>
       </div>
       <div style="padding: 8px;background: #008000; color: #fff; width: 200px; margin-top: 30px; text-align: center; ">
           <a style="color: #fff;" href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).FrdlinkPostRw %>">点击这里在线提交友情连接</a>
       </div>
	</div>   
</div>

</body>
</html>
