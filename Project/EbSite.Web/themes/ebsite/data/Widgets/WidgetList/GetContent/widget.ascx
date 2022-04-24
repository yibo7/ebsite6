<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetContent.widget" %>
<asp:Repeater ID="rpContent" runat="server"  >
 <ItemTemplate>
   <li>                                  
         <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%# Eval("newstitle")%></a>
    </li>
 </ItemTemplate>
</asp:Repeater>