<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RobBuyAdd.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.RobBuy.RobBuyAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls"
    TagPrefix="XE" %>

      <style>
       .tblist tbody tr td span
    {
        color: #888888;
    }
      </style>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
           
                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tblist">
                    <tr>
                        <td height="25" width="30%" align="right">
                            关联购买产品ID：
                        </td>
                        <td height="25" width="*" align="left">
                          <XE:SelectProduct Width="300" ID="ProductIdX"  runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td>
                        </td>
                        <td valign="top">
                            <span>抢购活动，购买后 不能退货。</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Title" runat="server"  IsAllowNull="false" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品价格:
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Price" runat="server"  IsAllowNull="false" ValidateType="金额" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            商品缩略图[290*290]:
                        </td>
                        <td height="25" width="*" align="left">
                          
                             <XS:SWFUpload ID="SmallImg"  AllowSize="2000" AllowExt="jpg,png,gif" runat="server" IsMakeSmallImg="False" AddBtnName="添加图片"   SaveFolder="/themes/shop/data/Upload"  />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            限时抢购价格 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="CountDownPrice"  IsAllowNull="false" ValidateType="金额" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            活动说明 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:Editor ID="editorContent"  EditorTools="全功能模式"  runat="server"></XS:Editor>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            开始日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:DatePicker ID="StartDate" runat="server" IsShowTime="True" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            结束日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:DatePicker ID="EndDate" runat="server" IsShowTime="True" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            显示顺序 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="OrderID" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                </table>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>

<script type="text/javascript">
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
</script>
