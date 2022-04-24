<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.RecommendUsers.widget" %>
<asp:Repeater ID="rpAllClass" runat="server"  >
  <ItemTemplate> 
       <div class="member_one">
            <div class="member_photo">
                 <a href="#"  target="_blank">
                    <img  src='<%#EbSite.Base.Host.Instance.AvatarBig(Convert.ToInt16(Eval("id").ToString()))%>' width="52" />
                </a>
              
            </div>
            <div class="member_name">
                 <a href="#" target="_blank">
                    <%# Eval("UserNiName").ToString()%></a>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater> 