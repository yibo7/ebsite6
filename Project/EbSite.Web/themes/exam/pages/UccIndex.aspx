<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.UccIndex" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:content id="Content1" runat="Server" contentplaceholderid="ctphBody">
<div class="UserRight_Title">管理首页</div>
<div>
         <div class="fLeft" >        
                <div >
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="UserPhoto">
                                        <img  src="<%=HostApi.AvatarBig(UserID) %>" />
                                        <div><a href="<%=HostApi.GetChangeUserICO %>">更新头像</a></div>
                                    </div>
                                    <div class="UserGroup">
                                        <%=HostApi.UserGroupNames%> &nbsp;&nbsp;                                        
                                    </div>
                                </td>
                                <td class="IndexUserInfo">
                                     <div>帐号:<%=UserName%></div>
                                    <div>名称:<%=UserNiName%>[<a href="<%=HostApi.GetNiNameUrl%>">修改</a>]</div>
                                    <div>积分:<span><%=Credits %></span></div>
                                    <div ><a style=" color:#000000;" href="<%=HostApi.CurrentSiteUrl%>" target="_blank" >我的主页</a>[<a href="<%=HostApi.GetSpaceSettingUrl%>">设置</a>]</div>
                                    <div>帐户余额:<span><%=Credits %></span>[<a href="<%=HostApi.GetMoneyInUrl%>">充值</a>]</div>
                                </td>
                            </tr>  
                        </table>                      
                
                </div>
        </div>
        <div class="fRight">
               <div class="newmsgtitle">
                    最新信息[<a href="<%=HostApi.GetNewMsg(UserID) %>">更多</a>]:
              </div>
              <div class="newmsgtitleline"></div>
              <div class="newmsgcontent">
                        <XS:Widget ID="Widget1" WidgetName="个人后台调最新消息"  WidgetID="d68da10c-05e8-425c-bedd-b130976258c7" runat="server"/>
              </div>
        </div>
</div>
<div class="clear"></div>
</asp:content>