<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecommendPart.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.BrandManage.RecommendPart" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls" TagPrefix="XE" %>
<style type="text/css">
      .divPanel
    {
        height: auto;
        font-size: 12px;
    }
</style>
<div style="text-align: center; font-size: 18px; font-weight: bold; padding: 8px; background: #E6E5E1; border-top:1px solid #DBDAD7; ">
    <%=GetTitle %>-推荐商品[<a style="color: red;" href="javascript:history.go(-1)">返回</a>]
</div>
<input type="hidden" runat="server" id="hidXml" />
<div class="divPanel">
    <h2 class="colorE">推荐商品</h2>
  
    <XE:BatchProduct runat="server" ID="BestParts" OpTools="推荐配件"></XE:BatchProduct>

</div>

<script>

    $(".TabsTitle").hide();

    $(".CustomPageTag").hide();
    
</script>