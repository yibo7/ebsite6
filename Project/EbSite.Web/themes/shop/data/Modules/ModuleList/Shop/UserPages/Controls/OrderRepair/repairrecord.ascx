<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="repairrecord.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderRepair.repairrecord" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="gdList_title" >
        <div  style="width:150px;">订单编号</div>
        <div  style="width:365px;">商品名称</div>
        <div  style="width:130px;">申请时间</div>
        <div  style="width:80px;">状态</div>
        <div style="width:80px;">操作</div>
    </div> 
    <XS:Repeater ID="gdList" runat="server" OnItemCommand="gdList_ItemCommand"  OnItemDataBound="gdList_ItemDataBound" >            
    <itemtemplate>           
    <div class="gdListContent" style="height:80px;" >
        <div  style="width:150px; height:80px; line-height:80px; vertical-align:middle; border-right:1px dotted #808080;border-left:1px dotted #808080;"><%#Eval("OrderId")%></div>
        <div  style="width:365px;height:80px; text-align:left; padding-left:10px;line-height:80px; vertical-align:middle;border-right:1px dotted #808080;">
            <a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("productid").ToString()),3) %>" target="_blank" style="color:blue;"><%# Eval("productname") %></a></div>
        <div  style="width:130px;height:80px; line-height:80px; vertical-align:middle;border-right:1px dotted #808080;"><%# Eval("returndate") %></div>
        <div  style="width:80px;height:80px; line-height:80px; vertical-align:middle;border-right:1px dotted #808080;"><%# GetItemStatus(Eval("itemstatus")) %></div>
        <div style="width:79px;height:80px; line-height:80px; vertical-align:middle;border-right:1px dotted #808080;"><a href="?mukey=999ebbca-0202-4a18-9141-3fd7a8808957&t=5&id=<%# Eval("id") %>">查看</a></div>
    </div>    
</itemtemplate>
</XS:Repeater>
<div><XS:PagesContrl ID="pcPage" runat="server" PageSize="5" /></div>