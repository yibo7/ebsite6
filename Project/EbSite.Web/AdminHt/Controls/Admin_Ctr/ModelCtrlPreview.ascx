<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModelCtrlPreview.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctr.ModelCtrlPreview" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>预览控件</h3>
            </div>
            <div class="eb-content">				
                <XS:ExtensionsCtrls ID="ExtensionsCtrls"   runat="server"/>
                                    
                <br><br>
                <asp:Label ID="lbDemoInfo" runat="server" ></asp:Label>
            </div>
    </div>
</div>
<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server" Text=" 测试数据读取 "></XS:Button>
</div>