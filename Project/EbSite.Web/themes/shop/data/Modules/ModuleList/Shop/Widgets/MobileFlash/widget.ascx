<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.MobileFlash.widget" %>

<asp:Repeater ID="rpList" runat="server" EnableViewState="False" >
    <ItemTemplate>
         <div>
            <a href="<%#Eval("url") %>">
                <img src="<%#Eval("picurl") %>"></a>
            <p>
                <%# Container.ItemIndex + 1%>.<%#Eval("name") %></p>
        </div>
       
    </ItemTemplate>
</asp:Repeater>
