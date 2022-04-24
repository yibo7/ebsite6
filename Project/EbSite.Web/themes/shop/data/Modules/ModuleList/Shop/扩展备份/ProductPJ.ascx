<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductPJ.ascx.cs" Inherits="EbSite.Modules.Shop.ExtContent.ProductPJ" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls"
    TagPrefix="XE" %>
    <div>推荐配件</div>
<XE:BatchProduct runat="server" ID="BestParts" OpTools="推荐配件"  ></XE:BatchProduct>