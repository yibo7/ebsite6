<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoveClassMore.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.MoveClassMore" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
 


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>第一步:请选择源分类</h3>
            </div>
            <div class="eb-content">
				<XSD:SelectClass ID="drpSoure" ApiFunctionName="GetSubClassForAddClass" Size="10" runat="server"></XSD:SelectClass>
            </div>
    </div>
</div>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>第二步:请选择目标分类</h3>
            </div>
            <div class="eb-content">
				
                <XSD:SelectClass ID="drpTarget" ApiFunctionName="GetSubClassForAddClass" Size="10" runat="server"></XSD:SelectClass>
            </div>
    </div>
</div>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>第三步:选择移动方式并提交</h3>
            </div>
            <div class="eb-content">
				    <%=Resources.lang.EBMobileWay %>:
						            <XS:RadioButtonList ID="movetype" runat="server" RepeatColumns="1">
                                        <asp:ListItem Value="0" Text="<%$Resources:lang,EBAdjustOrderBf %>"></asp:ListItem>
                                        <asp:ListItem Value="1" Selected="True" Text="<%$Resources:lang,EBAsTagerClass %>"></asp:ListItem>
                                    </XS:RadioButtonList>
            </div>
    </div>
</div>
<div class="text-center mt10">
    
    <XS:Button ID="bntSave" CssClass="btn btn-primary" Width="200" Text=" 提交移动分类 " runat="server" />
</div>
