<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Show.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.ReturnManage.Show" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style type="text/css">
    .imglist_reurn
    {
        width: 100%;
        margin: 0px;
        padding: 0px;
    }
    .imglist_reurn li
    {
        list-style: none;
        float: left;
        padding-left: 10px;
    }
</style>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>详细信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <th height="25" width="30%" align="right">
                            订单编号：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Literal ID="litOrderNum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            商品编号：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Literal ID="litProductNum" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            服务类型：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Literal ID="litServiceType" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            提交数量：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Literal ID="litSubmitCount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            申请凭据：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Literal ID="litApliyProof" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            问题描述：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Literal ID="litQuestionDesc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            提交时间：
                        </th>
                        <td height="25" width="*" align="left">
                            <asp:Literal ID="litSubmitDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            上传图片：
                        </th>
                        <td height="25" width="*" align="left">
                            <ul class="imglist_reurn">
                                <asp:Repeater ID="rptImgList" runat="server">
                                    <ItemTemplate>
                                        <li><a href="<%# Eval("bigimg") %>" target="_blank">
                                            <img alt="" src='<%# Eval("smallimg") %>' width="80" height="80" /></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <th height="25" width="30%" align="right">
                            审核处理结果：
                        </th>
                        <td height="25" width="*" align="left">
                            <XS:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="230" Height="50"></XS:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 5px;">
                    <XS:Button ID="bntSave" runat="server" Text=" 通过审核 " OnClientClick="return window.confirm('确定通过审核吗？')"
                        Enabled="false" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnNoPass" runat="server" Text=" 不通过 " OnClientClick="return window.confirm('确定设置为不通过审核吗？')"
                        CssClass="AdminButton" OnClick="btnNoPass_Click" Enabled="false" />&nbsp;&nbsp;&nbsp;
                    <input type="button" class="AdminButton" value=" 取 消 " onclick="ClosePage()" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<script type="text/javascript">
    function ClosePage() {
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>
