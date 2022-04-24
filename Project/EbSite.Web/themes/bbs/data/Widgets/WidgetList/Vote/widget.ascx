<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.Vote.widget" %>

  <asp:Repeater ID="rpVote" runat="server">
    <ItemTemplate>
        <a  href='<%#EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetVoteView(Eval("id"))%>'><%#Eval("VoteName")%>   </a>            
    </ItemTemplate>
</asp:Repeater>          