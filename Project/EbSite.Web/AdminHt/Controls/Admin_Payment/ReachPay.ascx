<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReachPay.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.ReachPay" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>  
<asp:PlaceHolder ID="phCtrList" runat="server">
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>货到付款配置</h3>
            启用货到付款功能并不代表所有物流公司都支持货到付款，所以你还需要在配送方式里设置相应的配送方式是否支付货到付款选项及不同物流公司的货到付款费用
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
            <table>
                    <tr>
                        <td>
                            是否启用:
                        </td>
                        <td>
                            <XS:CheckBox ID="IsCod" runat="server" AutoPostBack="true" OnCheckedChanged="IsCod_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            是否百分比:
                        </td>
                        <td>
                            <XS:CheckBox ID="IsPercent" HintInfo="这里不选上，增减费用值为指定数额，如果选上，增减费用值为百分数，结算时将以(商品价格+快递费)*百分比"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            增减费用值:
                        </td>
                        <td>
                            <XS:TextBoxVl Text="0" ID="UseMoney" Width="50" ValidateType="金额" HintInfo=" 支付手续费(正数)，或免除费用（负数）,一般情况下为正数，但如果您为了鼓励客户使用某种支付方式，也可以使用负数，将在结算时减少指定数额"
                                runat="server"></XS:TextBoxVl>
                        </td>
                    </tr>
                </table>
            </div>
    </div>
</div>
    
</asp:PlaceHolder>
<div class="text-center mt10"> 
     <XS:Button ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="BB" />
</div>
