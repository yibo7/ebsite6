<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add_Sec.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.Add_Sec" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加信息</h3>
            </div>
            <div class="content">
				<table  class="tblist">
                    <tr>
                        <td height="25" width="30%" align="right">
                            可选项内容名称：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="TitleName" runat="server" Width="200px" IsAllowNull="false" Msg="可选项内容不能为空"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            用户填写项：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rdoUserTypeList" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="是" Value="0"></asp:ListItem>
                                <asp:ListItem Text="否" Value="1" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr style="display:none;" id="trUTitle">
                        <td height="25" width="30%" align="right">
                            用户填写信息的标题：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="txtUserTitle" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                          <td height="25" width="30%" align="right">
                            附加金额计算方式：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rdoMonType" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="固定金额" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="购物车金额百分比" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                         <td height="25" width="30%" align="right">
                            附加金额：
                        </td>
                        <td height="25" width="*" align="left">
                            <span id="appendFir">固定金额</span>
                            <XS:TextBoxVl id="txtMoney" runat="server" Width="100px"></XS:TextBoxVl>
                            <span id="appendSec">元</span>
                        </td>
                    </tr>
                    <tr>
                         <td height="25" width="30%" align="right">
                            备注：
                        </td>
                        <td height="25" width="*" align="left">
                        <XS:TextBoxVl id="txtRemark" runat="server" Width="200px"></XS:TextBoxVl>
                        </td>
                   </tr>
                   <tr>
                    <td colspan="2" align="center">
                        <XS:Button ID="bntSave" runat="server" Text=" 添加 " />
                    </td>
                   </tr>
               </table>
            </div>
    </div>
</div>
 
</asp:PlaceHolder>
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=rdoUserTypeList.ClientID %>").click(function () {
            var rdoVal = $("input:radio[id^=\"<%=rdoUserTypeList.ClientID %>\"]:checked").val();
            if (rdoVal == "0") {
                $("#trUTitle").show();
            }
            else {
                $("#trUTitle").hide();
            }
        });
        $("#<%=rdoMonType.ClientID %>").click(function () {
            var rdoVal = $("input:radio[id^=\"<%=rdoMonType.ClientID %>\"]:checked").val();
            if (rdoVal == "0") {
                $("#appendFir").text("固定金额");
                $("#appendSec").text("元");
            }
            else {
                $("#appendFir").text("购物车金额百分比");
                $("#appendSec").text("%");
            }
        });
    });
    function CloseReshPage() {
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
        window.parent.location.reload();
    }
</script>