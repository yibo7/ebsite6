<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuySomeAdd.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Promotions.BuySomeAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls" TagPrefix="XE" %>
<style type="text/css">
    .hidrow{ display:none;}
    .tblist tbody tr{ height:36px;}
    .admin_toobar fieldset legend span{ color:Red;}
    </style>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加 买几送几 信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tblist">
                    <tr>
                        <td height="25" width="30%" align="right">
                            买几送几名称:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="TitleName" runat="server" Width="200px" IsAllowNull="false" Msg="促销活动名称不能为空" HintInfo="活动的名称，在1至50个字符之间!">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            买几送几信息:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:Editor ID="txtDescription" runat="server" EditorTools="简单模式" Height="200" ></XS:Editor>
                        </td>
                    </tr>
                      <tr>
                        <td height="25" width="30%" align="right">
                            购买数量:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="txtBuyQuantity" runat="server" Width="200px" HintInfo="买几送几的赠送数据，即购买商品的数量(在1-10000之间)">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td height="25" width="30%" align="right">
                            赠送数量:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="txtGiveQuantity" runat="server" Width="200px" HintInfo="买几送几的赠送数据，即赠送商品的数量(在1-10000之间)">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                           适合的客户:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:CheckBoxList ID="chkUserLevel" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Width="260"></XS:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>
<script type="text/javascript">
$(document).ready(function () {
        //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
});
</script>
