<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetUsers.widget" %>

<asp:Repeater ID="rpAllClass" runat="server"  >
  <ItemTemplate> 
        <li>
            <a title="<%# Eval("Visitor")%>"  href='Index.aspx?uid=<%# Eval("Visitor")%>'>
                <img src='<%#  Eval("AvatarSmall")%>'  />
            </a>
        </li>     
    </ItemTemplate>
</asp:Repeater> 