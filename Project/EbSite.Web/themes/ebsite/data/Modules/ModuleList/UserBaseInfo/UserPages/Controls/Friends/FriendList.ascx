<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Friends.FriendList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    .userlist li{ border: 1px solid #ccc;}
    .userlist dt,b{ line-height: 25px;}
</style>
<div class="userlist">
 <XS:Repeater ID="gdList" runat="server">            
                <itemtemplate>    
                        <li>
                            <table>
                                <tr>
                                    <td>
                                        <a href="<%#HostApi.GetUserSiteUrl(Eval("FriendID")) %>">
                                        <img   src="<%#HostApi.AvatarSmall(Eval("FriendID")) %>" />
                                    </a>
                                    </td>
                                    <td>
                                       <b> <%#Eval("FriendNiName")%></b>
                                      <dt>[<a href="<%#HostApi.GetSendMsg(Eval("FriendID")) %>">留言</a>]|[<a href="<%#HostApi.GetChatOnline(Eval("FriendID")) %>">聊天</a>]</dt>
                                      <dt>[<a  href="<%#HostApi.UserAlbumHref(0,int.Parse(Eval("FriendID").ToString()))%>">删除好友</a>]</dt>
                                    </td>
                                </tr>
                            </table>
                                   
                                </li>
                 </itemtemplate>
   </XS:Repeater>
</div>