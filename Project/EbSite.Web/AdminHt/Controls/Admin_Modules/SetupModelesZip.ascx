<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetupModelesZip.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.SetupModelesZip" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="admin_toobar">
    <fieldset>
        <legend>模块上传成功，现在点击【开始安装】 </legend>

        <div style=" margin:30px;">
            <XS:Button ID="bntSetup" Text="开始安装" Tips_Msg="正在安装,请不要关闭窗口..."  runat="server" onclick="bntSetup_Click"  />
        </div>

    </fieldset>
</div>