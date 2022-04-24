<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetAdvGoods.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.SetAdvGoods" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls" TagPrefix="XE" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改 楼层信息</legend>
            <div>
                <XE:BatchProduct runat="server" ID="FloorGoods" OpTools="推荐配件"></XE:BatchProduct>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>

<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " /> <a href="/themes/shop/data/Modules/ModuleList/Shop/AdminPages/FloorSet.aspx?muid=a4de7dee-4d12-4738-ada0-f8b27960811f&mid=cfccc599-4585-43ed-ba31-fdb50024714b&id=<%=fid %>">返回</a>
</div>

