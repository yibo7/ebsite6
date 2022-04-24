<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendListOfNew.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Friends.FriendListOfNew" %>
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
                                      <dt>[<a href="<%=GetUrl %>&opt=1&id=<%#Eval("id")%>">通过邀请</a>]</dt>
                                       <dt>[<a onclick="return  cftonoallow();" href="<%=GetUrl %>&opt=2&id=<%#Eval("id")%>">拒绝邀请</a>]</dt>
                                    </td>
                                </tr>
                            </table>
                                   
                                </li>
                 </itemtemplate>
   </XS:Repeater>
</div>

<script>
    function cftonoallow() {
        return confirm("你确定拒绝TA的邀请吗？");
    }
</script>