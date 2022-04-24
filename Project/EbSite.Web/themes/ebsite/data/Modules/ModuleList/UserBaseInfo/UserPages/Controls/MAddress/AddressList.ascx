<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.MAddress.AddressList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBarMobile ID="ucToolBar" runat="server"></XS:ToolBarMobile>

<ul class="data-list">
    <XS:Repeater ID="gdList" runat="server">            
                <ItemTemplate>
                    <li>
                        <input name="cbdataid" value="<%#Eval("id")%>" type="checkbox"/> 
                    <a href="<%#GetShowUrl(Eval("id")) %>"><span ><%# Eval("AddressInfo")%></span></a> 
                    <span class="arrow"></span>
                    </li>
                </ItemTemplate>
    </XS:Repeater>
</ul>

    <div class="btnloadmore">加载更多...</div>
    <XS:PagesContrl ID="pcPage"  runat="server" />

<script type="text/javascript">loadpage(".data-list", ".btnloadmore", '.data-list li');</script>