<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.SearchKeepWord.widget" %>

<asp:Repeater ID="rpData" runat="server"  >
  <ItemTemplate>            
        
        <a target=_blank href="<%# GetUrl(Eval("ShortId").ToString(),Eval("ReWritePath").ToString())%>">
            <%#Eval("Title")%>
        </a>
        <br>
  </ItemTemplate>
</asp:Repeater> 