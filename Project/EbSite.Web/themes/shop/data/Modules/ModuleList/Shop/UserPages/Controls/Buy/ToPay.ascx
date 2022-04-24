<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToPay.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.Buy.ToPay" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div id="PagesMain">
    <div class="ListLine">
        <ul >
        <XS:Repeater ID="gdList" runat="server"  >
            <ItemTemplate> 
                <li>
                  <%#Eval("PayLink")%>
                  <br>
                  <span>
                  <%#Eval("Help")%>                    
                  </span>
                </li>
            </ItemTemplate>
        </XS:Repeater>
        </ul>
    </br>
</div>