<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.GetMyCarFriend.widget" %>
<%@ Import Namespace="EbSite.BLL.User" %>
<asp:Repeater ID="rpSubClass" runat="server">
    <ItemTemplate>
        <div class="member_one">
            <div class="member_photo">
                 <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserName").ToString())%>" target="_blank">
                    <img  src='<%#MembershipUserEb.Instance.GetEntity(int.Parse(Eval("id").ToString())).AvatarBig%>? + Math.random()' width="52" />
                </a>
              
            </div>
            <div class="member_name">
                 <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserName").ToString())%>" target="_blank">
                    <%# Eval("NiName").ToString().Length > 10 ? Eval("NiName").ToString().Substring(0, 10) : Eval("NiName")%></a>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
