<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.GetHotList.widget" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<asp:Repeater ID="rpSubClass" runat="server"  >
  <HeaderTemplate>
    <ul class="iaskList">
  </HeaderTemplate>
  <ItemTemplate>
  <%--<a href="/ask<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>">--%>
    <li><a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.WenTi(GetSiteID,Eval("id"))%>"><%#Eval("NewsTitle")%></a>
           </li> 
    </ItemTemplate>
    <FooterTemplate>
    </ul>
    </FooterTemplate>
</asp:Repeater>