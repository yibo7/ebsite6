<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.Bulletin.widget" %>



<asp:Repeater ID="rpBulletin" runat="server"  >
  <ItemTemplate> 
        <li>
            <a title="<%# Eval("Title")%>"  href='/PluginPage/Bulletin/index.aspx?id=<%# Eval("id")%>&wid=<%=DataID %>'>
                <%# Eval("Title")%>
            </a>
        </li>     
    </ItemTemplate>
</asp:Repeater> 