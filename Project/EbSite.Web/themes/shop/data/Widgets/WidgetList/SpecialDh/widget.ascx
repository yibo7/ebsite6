<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.SpecialDh.widget" %>

<asp:Literal ID="llIndexLink" runat="server"></asp:Literal>
<asp:Repeater ID="rpSubSpecial" runat="server" EnableViewState="False" >
  <ItemTemplate>            		                
        
            <a class="<%#GetCurrentClass(Eval("ID"))%>" target=_top href="<%#EbSite.Base.Host.Instance.GetSpecialHref(int.Parse(Eval("ID").ToString()),1)%>"><%# Eval("SpecialName")%></a>&nbsp;&nbsp;
       
    </ItemTemplate>
</asp:Repeater>  