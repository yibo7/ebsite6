<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetSubSpecial.widget" %>

<asp:Literal ID="llIndexLink" runat="server"></asp:Literal>
<asp:Repeater ID="rpSubSpecial" runat="server" EnableViewState="False" >
  <ItemTemplate>            		                
        
            <a class="<%#GetCurrentClass(Eval("ID"))%>" target=_top href="<%#EbSite.Base.Host.Instance.GetSpecialHref(int.Parse(Eval("ID").ToString()),1)%>"><%# Eval("SpecialName")%></a>
       
    </ItemTemplate>
</asp:Repeater>  