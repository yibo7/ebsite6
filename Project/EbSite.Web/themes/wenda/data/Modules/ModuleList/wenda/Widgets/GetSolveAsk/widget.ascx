<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.GetSolveAsk.widget" %>

<asp:Repeater ID="rpList" runat="server"  >
  <ItemTemplate> 
       <li>

    <a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.WenTi(GetSiteID,Eval("id"))%>"><%# Eval("NewsTitle")%></a>
</li>    
    </ItemTemplate>
</asp:Repeater> 