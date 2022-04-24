<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupBuyEdit.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.SalesActivities.GroupBuyEdit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls"
    TagPrefix="XE" %>
<style type="text/css">
    .topsearch
    {
        width: 800px;
        background-color: #FFFADF;
        border: 1px solid #CCCCCC;
        height: 50px;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
    }
    .tblist tbody tr td span
    {
        color: #888888;
    }
</style>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tblist">
                    <tr>
                        <td height="25" width="30%" align="right">
                            团购商品:
                        </td>
                        <td height="25" width="*" align="left">
                            <XE:SelectProduct Width="300" ID="ProductIDX" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>当此团购活动有会员已订购时，商品不能再进行编辑</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Title" runat="server" IsAllowNull="false" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品价格:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Price" runat="server" IsAllowNull="false" ValidateType="金额" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品缩略图: [290*290]
                        </td>
                        <td height="25" width="*" align="left">
                           
                          <XS:SWFUpload ID="SmallImg"  AllowSize="2000" AllowExt="jpg,png,gif" runat="server" IsMakeSmallImg="False" AddBtnName="添加图片"   SaveFolder="/themes/shop/data/Upload"  />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            开始日期:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:DatePicker ID="StartDate" IsShowTime="True" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>当达到开始日期时，活动会自动变为正在参与活动状态</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            结束日期:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:DatePicker ID="EndDate" IsShowTime="True" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>当达到结束日期时，活动会自动变为结束未处理状态</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            违约金:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="NeedPrice" runat="server" IsAllowNull="false" ValidateType="金额"
                                Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>违约将扣除的金额，不填表示没有违约金,客户在管理员主动将活动设置为失败的情况下不视为违约</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            限购总数量:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="MaxCount" runat="server" IsAllowNull="false" ValidateType="匹配正整数"
                                HintInfo="团购总数量" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>此次活动可购买的商品总数量,不能为空,订购达到此上限时，活动会自动变为结束未处理状态</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            排序:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="OrderID" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            团购满足数量:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="BuyCount" runat="server" Width="200px" IsAllowNull="false" ValidateType="匹配正整数"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>满足此次活动的最低商品订购数量,不能为空</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            团购价格:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="BuyPrice" runat="server" Width="200px" IsAllowNull="false" ValidateType="金额"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>达到团购满足数量后享受的团购价格,不能为空</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            活动说明:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:Editor ID="editorContent" EditorTools="简单模式" runat="server"></XS:Editor>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " OnClientClick="return IsCanSave();" />
    <XS:Button ID="btnGroupOver" runat="server" Text=" 结束活动 " Visible="false" OnClick="btnGroupOver_Click" />
    <XS:Button ID="btnGroupSuccess" runat="server" Text=" 活动成功 " Visible="false" OnClick="btnGroupSuccess_Click" />
    <XS:Button ID="btnGroupFail" runat="server" Text=" 结束失败 " Visible="false" OnClick="btnGroupFail_Click" />
    <input type="button" class="AdminButton" onclick="ClosePage(0)" value=" 关闭 " />
</div>
<script type="text/javascript">
    function IsCanSave() {
        var mCount = parseInt($("#<%=MaxCount.ClientID%>").val());
        var sCount = parseInt($("#<%=BuyCount.ClientID%>").val());
        if (mCount >= sCount) {
            return true;
        }
        
    }
    function ClosePage(falg)
    {
        if (falg > 0) {
            alert("操作成功!");
        }
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
</script>
