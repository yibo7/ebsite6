<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowUserPermission.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Adminer.ShowUserPermission" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>[<asp:Label ID="lbUser" runat="server" Text="Label"></asp:Label>]享有的权限</h3>
            </div>
            <div class="eb-content">
				<asp:Literal ID="RoleList" runat="server"></asp:Literal>
            </div>
    </div>
</div>