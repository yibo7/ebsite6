<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CouponsAdd.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Coupons.CouponsAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加优惠券</h3>
            </div>
            <div class="eb-content">
				<asp:PlaceHolder ID="phCtrList" runat="server">
                <table>
                    <tr>
                        <td height="25" width="30%" align="right">
                            优惠券名称：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="CouponName" runat="server" IsAllowNull="false" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            满足金额 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Amount" runat="server" ValidateType="金额" HintInfo="满足金额 满足金额只能是数值，0.01-10000000，且不能超过2位小数" IsAllowNull="false" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            可抵扣金额 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="DiscountPrice" runat="server"  HintInfo="可抵扣金额只能是数值，0.01-10000000，且不能超过2位小数" IsAllowNull="false" ValidateType="金额"
                                Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            结束日期 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:DatePicker ID="EndDateTime" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            兑换需积分 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="NeedPoint" runat="server"  HintInfo="兑换所需积分只能是数字，必须大于等于O,0表示不能兑换" IsAllowNull="false" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            描述 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="Description" runat="server" TextMode="MultiLine" Height="100px"
                                Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            导出数量 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="SentCount" runat="server"   HintInfo ="导出数量 导出数量只能是数字，必须大于等于O,0表示不导出" IsAllowNull="false" Width="200px"></XS:TextBoxVl>
                        </td>
                    </tr>
                </table>
</asp:PlaceHolder> 
            </div>
    </div>
</div>
 <div class="text-center mt10">
     <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
 </div>
    
 