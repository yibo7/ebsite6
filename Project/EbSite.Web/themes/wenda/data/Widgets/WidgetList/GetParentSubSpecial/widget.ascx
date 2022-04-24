<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetParentSubSpecial.widget" %>

<asp:Repeater ID="rpSubSpecial" runat="server" OnItemDataBound="rpSubSpecial_ItemBound" EnableViewState="False" >
  <ItemTemplate>            		                
       <ul class="listbao">
            <b>
                <a class="<%#GetCurrentClass(Eval("ID"))%>" href="<%#EbSite.Base.Host.Instance.GetSpecialHref(Eval("ID"),1)%>"><%# Eval("SpecialName")%>：</a>
            </b>            
            <asp:Repeater ID="rpSSubSpecial" runat="server"  EnableViewState="False" />
        </ul>
    </ItemTemplate>
</asp:Repeater>  
