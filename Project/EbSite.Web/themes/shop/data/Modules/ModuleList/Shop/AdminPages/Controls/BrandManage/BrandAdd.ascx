<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrandAdd.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.BrandManage.BrandAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    
    
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="cbMore" onclick="checkmoreadd(this)" Text="启用批量添加" runat="server" /></td>

                    </tr>
                    <tr id="tbName">
                        <td height="25" width="30%" align="right">品牌名称：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="BrandName" runat="server"  Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>

                    <tr style="display: none" id="tbNames">
                        <td>批量名称
                        </td>
                        <td>批量名称用#号分开，如 分类名称1#分类名称2#分类名称3
                    <br />
                            <XS:TextBox Width="500" Height="200" TextMode="MultiLine" runat="server" ID="txtClassNames"></XS:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">上传Logo ：
                        </td>
                        <td height="25" width="*" align="left">

                            <XS:SWFUpload runat="server" ID="sLogo" SaveFolder="/themes/shop/data/Upload" IsMakeSmallImg="true" AllowExt="jpg,gif,png" AllowSize="2024" />

                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">描述 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Description" runat="server" TextMode="MultiLine" Width="200px"
                                Height="100px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">排序 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="OrderID" runat="server"  ValidateType="匹配正整数"  IsAllowNull="False" Width="200px"></XS:TextBoxVl>
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

    function checkmoreadd(obj) {
        if (obj.checked) {

            $("#tbNames").show();
            $("#tbName").hide();
            var inpu = $("#<%=BrandName.ClientID%> input")[0];
                $(inpu).attr("isnull", "0");
            }
            else {

                $("#tbNames").hide();
                $("#tbName").show();

                var inpu = $("#<%=BrandName.ClientID%> input")[0];
                $(inpu).attr("isnull", "1");
            }
        }



</script>