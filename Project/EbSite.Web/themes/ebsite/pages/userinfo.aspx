<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.UserInfo" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

</head>
<body>
    
<!--#include file="top.inc" -->

<div  style="background-color:#F4F4F4">
   <div class="usercontainer" style="position:relative; ">
    
	  
     	<div class="top_part2 logoline">
         	 	<div class="bmlogo"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></div>
		 	 <div class="logofont"><%=Model.NiName %>的空间</div>
			<div class="logofnt"><%=HostApi.Domain %><%=Request.RawUrl %></div>
      	</div>
      <div class="clear"></div>
   </div>
</div>


<div class="usercontainer2"  >
	<div class="usercontainer"  style=" height:1600px; padding: 10px;  ">
	    
	    <div class="uhomebox-l">
	            <div class="title">发布内容</div>
                <div class="UserContentInfo">
                    <asp:Repeater ID="rpDataList" runat="server"  >
                      <ItemTemplate> 
                          <li>  <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("ClassId"))%>"><%#Eval("newstitle")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater> 
                </div>
	          
            <XS:PagesContrl ID="pgCtr"  PageSize="18" runat="server" />  

	    </div>
	   
          <div class="uhomebox-r" >
              <div class="userhomeinfo">
                    <img style="width: 150px;border: 5px solid #fff; " src="<%=HostApi.AvatarBig(Model.id) %>" />
                      <div>名    称:<%=Model.NiName%></div>
                      <div>级    别:<%=Model.UserLevelName%></div>
                      <div>积    分:<img src="<%=IISPath %>images/money.gif"/><b><%=Model.Credits%></b></div>
                      <div>注册时间:<span><%=Model.CreateDate%></span></div>
                      <div>最后登录:<span><%=Model.LastLoginDate%></span></div>

                      <div class="userctrico">
                        <span><img src="<%=IISPath %>images/favorite.gif"/><a  href="<%=HostApi.UserAlbumHref(0,Model.id)%>">他的收藏</a></span>
                        <span><img src="<%=IISPath %>images/frd.gif"/><a href="<%=HostApi.GetAddFriend(Model.id)%>">加为好友</a></span>  
                      </div>
                       <div class="userctrico">
                        <span><img src="<%=IISPath %>images/msg.gif"/><a href="<%=HostApi.GetSendMsg(Model.id)%>">发送消息</a></span>
                        <span><img src="<%=IISPath %>images/talk.gif"/><a href="<%=HostApi.GetChatOnline(Model.id)%>">即时聊天</a></span>  
                      </div>
                      <div>签名：</div>
                      <div style="border-top:1px dotted #ccc; margin-top: 5px; ">
                          <%=string.IsNullOrEmpty(Model.Sign)?"<font color=#ccc>这家伙太忙，连签名的时间都没有</font>":Model.Sign%>
                      </div>
                       
              </div>
              <div class="title">最近来访</div>
              <div class="userlist">
                 <asp:Repeater ID="rpVisit" runat="server"  >
                           <ItemTemplate> 
                                <li>
                                    <a href="<%#HostApi.GetUserSiteUrl(Eval("VisitorID")) %>">
                                        <img   src="<%#HostApi.AvatarSmall(Eval("VisitorID")) %>" />
                                    </a>
                                </li>
                           </ItemTemplate>
                  </asp:Repeater> 
                  
              </div>
              
              <div class="title clear">TA的好友</div>
              <div class="userlist">
                   <asp:Repeater ID="rpFrineds" runat="server"  >
                           <ItemTemplate> 
                                <li title="<%#Eval("FriendNiName")%>">
                                    <a href="<%#HostApi.GetUserSiteUrl(Eval("FriendID")) %>">
                                        <img   src="<%#HostApi.AvatarSmall(Eval("FriendID")) %>" />
                                    </a>
                                </li>
                           </ItemTemplate>
                  </asp:Repeater> 
              </div>
             
          </div>

	</div>   
</div>
</body>
</html>
