<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ctrl.ascx.cs" Inherits="EbSite.Modules.Shop.ExtensionsCtrls.TypeNames.Ctrl" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:DropDownList Width="100" ID="drpGoodsType" runat="server"></XS:DropDownList>
<script>
    jQuery(function ($) {
        productTypeSelector = $("#<%=drpGoodsType.ClientID %>"); //商品类型
        
    });
</script>