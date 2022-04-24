<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.BmAsk.Widgets.GetHighScoreAsk.widget" %>

<asp:Repeater ID="rpList" runat="server"  >
  <ItemTemplate> 
       <li> 
   
     <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%# Eval("NewsTitle")%></a>
</li>    
    </ItemTemplate>
</asp:Repeater> 