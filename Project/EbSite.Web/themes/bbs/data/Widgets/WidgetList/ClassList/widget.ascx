<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.ClassList.widget" %>
<asp:Repeater ID="rpSubClass" runat="server" EnableViewState="False">
    <ItemTemplate>
       
        <li><a <%#(string.IsNullOrEmpty(Eval("OutLike").ToString()))?"":"target=_blank" %>
            href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("HtmlName"),1,Eval("OutLike").ToString())%>"
            class="<%#GetCurrentClass(Eval("ID"),"focus")%>"><span>
                <%# Eval("ClassName")%></span> </a></li>
                 <li class="menu_line" />
    </ItemTemplate>
</asp:Repeater>
