<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddGift.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.Gift.AddGift" %>
<%-- [BuyProductId] (int) 关联购买产品ID
		 [GiftProductId] (int) 关联赠品产品ID
		 [Quantity](int)  赠送数量
		 [EndDateTime](datetime)  结束日期  如果不选择，将永远不过期--%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls"
    TagPrefix="XE" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            关联购买产品ID：
                        </td>
                        <td height="25" width="*" align="left">
                            <XE:SelectProduct Width="300" ID="BuyProductIdX" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            关联赠品产品ID ：
                        </td>
                        <td height="25" width="*" align="left">
                          <span style="float: left;">  <XE:SelectProduct Width="300" ID="GiftProductIdX" SelProduct="不含有商品规格的商品"  runat="server" />    
                             </span><span style="float: left;">
                            <XS:Notes ID="NoteA" runat="server" Text="注意【赠品】选择的范围是没有开启规格的产品.因为 在giftprodctorder表中没  商品编码 ，只有 商品id" /></span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            赠送数量 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Quantity" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            结束日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:DatePicker ID="EndDateTime" IsShowTime="True" runat="server" />
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
<script>
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
</script>
