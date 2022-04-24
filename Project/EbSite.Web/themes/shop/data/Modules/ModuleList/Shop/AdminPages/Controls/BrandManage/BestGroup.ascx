<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BestGroup.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.BrandManage.BestGroup" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls" TagPrefix="XE" %>

<style type="text/css">
    .divPanel
    {
        width: 700px;
        height: auto;
        font-size: 12px;
    }
</style>
<div style="text-align: center; font-size: 18px; font-weight: bold; padding: 8px; background: #E6E5E1; border-top:1px solid #DBDAD7; ">
    <%=GetTitle %>-最佳组合[<a style="color: red;" href="javascript:history.go(-1)">返回</a>]
</div>

<input type="hidden" runat="server" id="hidXml" />
<div class="divPanel">
    <h2 class="colorE">最佳组合</h2>
  
    <XE:BatchProduct runat="server" ID="BestParts" OpTools="最佳组合"></XE:BatchProduct>

</div>
<script>
    
    $(".TabsTitle").hide();

    $(".CustomPageTag").hide();
    
</script>