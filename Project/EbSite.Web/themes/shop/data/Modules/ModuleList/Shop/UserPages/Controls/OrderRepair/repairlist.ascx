<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="repairlist.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderRepair.repairlist" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div class="gdList_title" >
        <div  style="width:150px;">订单编号</div>
        <div  style="width:506px;">商品</div>
        <div  style="width:150px;">下单时间</div>
    </div> 
    <XS:Repeater ID="gdList" runat="server" OnItemCommand="gdList_ItemCommand"  OnItemDataBound="gdList_ItemDataBound" >            
    <itemtemplate>           
    <div class="gdListContent" style="height:80px;" >
        <div  style="width:150px; height:80px; line-height:80px; vertical-align:middle; border-right:1px dotted #808080;border-left:1px dotted #808080;"><%#Eval("OrderId")%></div>
        <div  style="width:506px;height:75px; padding-top:5px; text-align:left; padding-left:10px;border-right:1px dotted #808080;">
            <asp:Repeater ID="rpItemList" runat="server">
                <ItemTemplate>
                    <img width="50" title='<%# Eval("productname") %>' height="50" src='<%# Eval("thumbnailsurl") %>' /><br />
                    <%# GetLinkURL(Eval("id"),Eval("itemstatus")) %>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div  style="width:150px;height:80px; line-height:80px; vertical-align:middle;border-right:1px dotted #808080;">&nbsp;<%#Eval("OrderAddDate")%></div>
    </div>    
</itemtemplate>
</XS:Repeater>
<div><XS:PagesContrl ID="pcPage" runat="server" PageSize="5" /></div>