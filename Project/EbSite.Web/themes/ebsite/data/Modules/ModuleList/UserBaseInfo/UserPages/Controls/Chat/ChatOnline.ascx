<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatOnline.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Chat.ChatOnline" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


<table class="chatbox" >
            
                <tr>
                    <td style=" width:40%;" >
                        <div class="chatuserbox">
                            <div id="divFrend" class="title">
                                <li name="tg1" class="current">正在聊天</li>
                              <%--  <li name="tg2" >最近联系人</li>
                                <li name="tg3" >我的好友</li>--%>
                            </div>
                            <div class="clear"></div>
                            <div id="tg1">
                                         <table >
                                            <tr>
                                               <td>
                                                   <asp:Image ID="imgUserIco" Width="60" runat="server" />
                                                </td>
                                                <td id="tdUserInfo">
                                                    <asp:Literal ID="llOnlineInfo" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                            </div>
                           <%-- <div id="tg2">最近联系人未完成</div>
                             <div id="tg3">我的好友 未完成</div>--%>
                                
                   
                            <div style="padding-left: 8px; padding-right: 8px;">
                                <textarea  name="txtMsg" onkeydown="quickpost()"  rows="2" cols="20" id="txtMsg"  maxlength="300"   onkeyup="return isMaxLen(this)" rows="0" cols="0"   style="height:120px;width:300px;"></textarea>
                            </div>
                            <div style="  padding-top:10px; margin-bottom: 10px;text-align: center;">
                                <input type="button" id="bntSend" value="    发 送(Ctrl+Enter)    " onclick="CurrentSendMsg(txtMsg)"  class="AdminButton" />
                         </div>
                        </div>
                         
                    </td>
                    
                    <td style=" width:60%; vertical-align:top; padding-left:10px;">
                        <div style="border-bottom:dotted 1px #ccc; width:100%	"><h3>聊天记录:</h3></div>
                        <div id="ChatList">
                           
                        </div>
                    </td>                 
                </tr>
            </table>
           <bgsound id="MsgSound"  loop="1"> 
           
           
 <script type="text/javascript">

     var CurrentNiName = "<%=UserNiname %>";
     var CurrentUserID = "<%=UserID %>";
     var FriendId = "<%=GetFriendOnlineId%>";
     var FriendUserId = "<%=GetFriendUserID%>";
     //
     In.ready('ebsitechat', 'customtags', function () {//执行代码

         var Tags = new CustomTags();
         Tags.ParentObjName = "divFrend";
         Tags.SubObj = "li";
         Tags.CurrentClassName = "current";
         Tags.ClassName = "";
         Tags.InitOnclickInTags();
         Tags.InitOnclick(0);
         Tags.Effects = "slidedown";

     });   
              
   </script>
