<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderOptionAdd.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.OrderOptionAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加订单选项</h3>
            </div>
            <div class="content">
				 <asp:PlaceHolder ID="phCtrList" runat="server">

                <table width="100%">
                    <tr>
                        <td height="25" width="30%" align="right">订单可选项名称：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtItemName" runat="server" IsAllowNull="false" HintInfo="长度限制在1-60个字符之间" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">显示方式：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="ddl_ShowType" runat="server">
                                <asp:ListItem Text="下拉列表" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="单选按钮" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">描述 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Description" runat="server" TextMode="MultiLine" Height="100px" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnNextStep" runat="server" Text=" 下一步 " OnClick="btnNextStep_Click" /></td>
                    </tr>
                </table>

            </asp:PlaceHolder>
            </div>
    </div>
</div>
<script type="text/javascript">
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();
</script>
