<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MergeSpecial.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.MergeSpecial" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
 
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>第一步:请选择源分类</h3>
            注意事项:1.合并分类后将删除源分类与它的子分类。2.分类的合并包括源分类下的所有数据及其子分类下所有数据
            </div>
            <div class="eb-content">
				<XSD:SelectClass ID="drpSoure" ApiFunctionName="GetSubSpecial" Size="10" runat="server"></XSD:SelectClass>
            </div>
    </div>
</div>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>第二步:请选择目标分类</h3>
            </div>
            <div class="eb-content">
				<XSD:SelectClass ID="drpTarget" ApiFunctionName="GetSubSpecial" Size="10" runat="server"></XSD:SelectClass>
            </div>
    </div>
</div>

<div style="padding:20px;">
    
<XS:Button ID="bntSave" runat="server" Confirm="true" Width="200" Text=" 开始合并 "></XS:Button>
</div>