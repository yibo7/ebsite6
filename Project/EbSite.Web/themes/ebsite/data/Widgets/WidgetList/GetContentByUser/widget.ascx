<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetContentByUser.widget" %>

<asp:Repeater ID="rpList" runat="server"  >
  <ItemTemplate> 
       <li>
    <span class="date"><%#DateTime.Parse(Eval("addtime").ToString()).ToString("MM-dd")%></span>
     <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%# Eval("newstitle")%></a>
</li>    
    </ItemTemplate>
</asp:Repeater> 