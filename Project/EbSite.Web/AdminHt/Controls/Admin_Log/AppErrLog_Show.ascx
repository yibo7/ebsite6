<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppErrLog_Show.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Log.AppErrLog_Show" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div  class="admin_toobar">
    <fieldset>
        <legend>异常详细信息</legend>
        <div >
            <asp:Literal ID="llInfo" runat="server"></asp:Literal>
        </div>
    </fieldset>
</div>