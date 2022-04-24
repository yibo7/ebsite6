<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.CreditProduct.AddProduct" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0"  border="0">
                    <tr>
                        <td height="25" width="130px" align="right">
                            商品名称：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtProductName" runat="server" Width="200px" IsAllowNull="false"></XS:TextBoxVl>
                        </td>
                        <td height="25" width="130px" align="right">
                            所属分类：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="ddlProductClass" runat="server" Width="200"></asp:DropDownList>
                        </td>
                    </tr>
                   
                    <tr>
                        <td height="25" width="130px" align="right">
                            需要积分 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtScore" runat="server" Width="200px" IsAllowNull="false"></XS:TextBoxVl>
                        </td>
                        <td height="25" width="130px" align="right">
                            是否上架 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rdoIsSale" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="130px" align="right">
                            成本价格 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtCostPrice" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                        <td height="25" width="130px" align="right">
                            参考价格 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtRefPrice" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr><tr>
                        <td height="25" width="130px" align="right">
                            计量单位 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtUnit" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                        
                        <td height="25" width="130px" align="right">
                            商品数量 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtProductCount" runat="server" Width="200px"></XS:TextBoxVl>
                             <XS:TextBoxVl ID="txtExchangeNum" runat="server" Width="200px"  Visible="False"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td width="130px" align="right">
                            简单介绍 ：
                        </td>
                        <td width="*" align="left" colspan="3">
                            <XS:Editor ID="txtSimplInfo"  EditorTools="简单模式"  runat="server" Width="560px" Height="150px"></XS:Editor>
                        </td>
                      
                    </tr>
                    <tr>
                          <td width="130px" align="right">
                            详细介绍 ：
                        </td>
                        <td width="*" align="left" colspan="3">
                            <XS:Editor ID="txtProductInfo" ExtImg="*.jpg"  IsQuickUp="True" EditorTools="全功能模式"  runat="server" Width="560px" Height="300px"></XS:Editor>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="130px" align="right">
                            页面标题 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <XS:TextBoxVl ID="txtPageTitle" runat="server" Width="560px" Height="30px" ></XS:TextBoxVl>
                        </td>
                        
                    </tr>
                    <tr>
                        <td height="25" width="130px" align="right">
                            页面关键词 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <XS:TextBoxVl ID="txtPageKeyWord" runat="server" Width="560px" Height="30px" ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="130px" align="right">
                            页面描述 ：
                        </td>
                        <td height="25" width="*" align="left" colspan="3">
                            <XS:TextBoxVl ID="txtPageDesc" runat="server" Width="560px" Height="30px" ></XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td height="25" width="130px" align="right">
                            商品图片[400*400] ：
                        </td>
                        <td height="25" width="*" align="left" colspan="2">
                            <XS:SWFUpload ID="ImgUpLoad"  AllowSize="2000" AllowExt="jpg,png,gif" runat="server" IsMakeSmallImg="True" AddBtnName="添加图片"  SaveFolder="/themes/shop/data/Upload" />
                        </td>
                         <td><asp:Image ID="showimg" runat="server" Width="100" Height="100" /></td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>

<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
    <input type="button" class="AdminButton" value="返回" onclick="window.location = '/themes/shop/data/Modules/ModuleList/Shop/AdminPages/CreditProduct.aspx?muid=625dcf9b-4a6b-4ff8-9254-7ea7fa8e80f6&mid=cfccc599-4585-43ed-ba31-fdb50024714b'" />
</div>
