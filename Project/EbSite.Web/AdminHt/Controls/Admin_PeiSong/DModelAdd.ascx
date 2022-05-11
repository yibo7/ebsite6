<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DModelAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.DModelAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改配送方式</h3>
            </div>
            <div class="eb-content">
				<table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            配送方式名称:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="ModeName" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            选择物流公司:
                        </td>
                        <td>
                            <asp:CheckBoxList ID="ChBCompanyIDs" RepeatColumns="5" TextAlign="Right" RepeatDirection="Horizontal"
                                runat="server">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            选择运费模板:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropTem" runat="server">
                                <asp:ListItem Value="-1"> 请选择运费模板</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            是否货到付款:
                        </td>
                        <td>
                            <XS:CheckBox ID="IsCod" runat="server"  AutoPostBack="true" 
                                oncheckedchanged="IsCod_CheckedChanged"/>
                                <br />
                            <asp:PlaceHolder ID="phIsCod"  Visible="false" runat="server">
                                <div style=" border:1px solid #D98D38; background:#FFE6C9; padding:8px; margin-top:5px; margin-bottom:5px;">                                
                                
                                货到付款参数设置: <br />
                                是否百分比:<XS:CheckBox ID="IsPercent" HintInfo="这里不选上，增减费用值为指定数额，如果选上，增减费用值为百分数，结算时将以(商品价格+快递费)*百分比"
                                runat="server" />
                            增减费用值:
                            <XS:TextBoxVl Text="0" ID="UseMoney" Width="50" ValidateType="金额" Height="15"  HintInfo=" 支付手续费(正数)，或免除费用（负数）,一般情况下为正数，但如果您为了鼓励客户使用某种支付方式，也可以使用负数，将在结算时减少指定数额"
                                runat="server"></XS:TextBoxVl><asp:Literal ID="llIsCod" runat="server"></asp:Literal>
                                </div>
                        </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            备注:
                        </td>
                        <td>
                            <asp:TextBox ID="TbContent" TextMode="MultiLine" Rows="8" Width="300" runat="server"></asp:TextBox>
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
    
 
