<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdGoodsType.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.AdGoodsType" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="../css/index.css" rel="stylesheet" />
<asp:PlaceHolder ID="phCtrList" runat="server">
<div class="Steps Pg_45">
    <ul>
        <li class="huang">第一步：添加类型名称 </li>
        <li class="iocns "></li>
        <li class="fui">第二步：添加扩展属性 </li>
        <li class="iocns "></li>
        <li class="fui">第三步：添加规格 </li>
    </ul>
</div>
<div id="tg1">
    <table>
        <tr>
            <td>
                商品类型名称:
            </td>
            <td>
                <XS:TextBox Width="150" runat="server" ID="tx_TypeName" IsAllowNull="false" HintInfo="长度限制在1-30个字符之间" >
                </XS:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                排序编号:
            </td>
            <td>
                <XS:TextBox Width="150" runat="server" ID="tx_OrderID" IsAllowNull="false" >
                </XS:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                关联品牌:
            </td>
            <td>
                <XS:CheckBoxList ID="tx_BrandIDs" runat="server"  Width="750" RepeatDirection="Vertical" >
                </XS:CheckBoxList>
            </td>
        </tr>

         <tr>
            <td>
                是否关联专题:
            </td>
            <td>
                <asp:CheckBox ID="Ck_IsSpecial" runat="server" /> 关联专题 在检索时会出现专题的检索条件【只出现包含此分类内容的专题】。选择专题-添加内容，把产品添加到相应的专题中。
            </td>
        </tr>
    </table>
</div>
</asp:PlaceHolder>
<div style="text-align: center; padding: 10px;">
    <XS:Button ID="bntSave" Text=" 下一步" runat="server"  />
</div>
<script>
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
</script>
