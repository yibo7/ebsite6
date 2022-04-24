<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Show.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderRepair.Show" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style type="text/css">
    .headmsg {
        width:97%;
        border:1px solid #FFCCAA;
        background-color:#FFFCF1;
        height:30px;
        line-height:30px;
        margin-top:10px;
        padding:10px;
        vertical-align:middle;
        font-size:14px;
        font-weight:bold;
        color:#4F6B72;
    }
        .headmsg span {
            color:#009900;
        }
</style>
<div style="text-align:left;">
    <div class="headmsg">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;订单号：<asp:Literal ID="litOrderNum" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        状态：<asp:Label ID="labState" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        申请时间：<asp:Literal ID="litAppDate" runat="server"></asp:Literal>
    </div>
    <table border="0" class="thhdetail">
        <tbody>
            <tr><th>商品编号</th><td><asp:Literal ID="litProductNum" runat="server"></asp:Literal></td></tr>
            <tr><th>商品名称</th><td><asp:Literal ID="litProductName" runat="server"></asp:Literal></td></tr>
            <tr><th>提交数量</th><td><asp:Literal ID="litCount" runat="server"></asp:Literal></td></tr>
            <tr><th>服务类型</th><td><asp:Literal ID="litSericeType" runat="server"></asp:Literal></td></tr>
            <tr><th>申请凭据</th><td><asp:Literal ID="litProof" runat="server"></asp:Literal></td></tr>
            <tr><th>问题描述</th><td><span><asp:Literal ID="litQuestionDesc" runat="server"></asp:Literal></span></td></tr>
            <tr><th>上传图片</th><td>
                <ul>
                <asp:Repeater ID="rptDataImgList" runat="server">
                    <ItemTemplate>
                        <li><a href="<%# Eval("bigimg") %>" target="_blank"> <img src='<%# Eval("smallimg") %>' width="80" height="80" /></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                    </ul>
            </td></tr>
               <tr><th>审核结果</th><td><span><asp:Literal ID="litReason" runat="server"></asp:Literal></span></td></tr>
        </tbody>
    </table>
</div>

