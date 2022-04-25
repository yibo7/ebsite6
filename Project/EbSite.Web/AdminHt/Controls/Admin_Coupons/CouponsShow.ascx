<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CouponsShow.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Coupons.CouponsShow" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>优惠券明细</h3>
            </div>
            <div class="content">
				<table >
                <tr>
                    <td align="right">优惠券名称:
                    </td>
                    <td>
                        <%=Model.CouponName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">结束日期:
                    </td>
                    <td>
                        <%=Model.EndDateTime%>
                    </td>
                </tr>
                <tr>
                    <td align="right">满足金额:
                    </td>
                    <td>
                        <%=Model.Amount%>
                    </td>
                </tr>
                <tr>
                    <td align="right">可抵扣金额:
                    </td>
                    <td>
                        <%=Model.DiscountPrice%>
                    </td>
                </tr>
                <tr>
                    <td align="right">描述:
                    </td>
                    <td>
                        <%=Model.Description%>
                    </td>
                </tr>
                <tr>
                    <td align="right">导出数量:
                    </td>
                    <td>
                        <%=Model.SentCount%>
                    </td>
                </tr>
                <tr>
                    <td align="right">已经使用数量:
                    </td>
                    <td>
                        <%=Model.UsedCount%>
                    </td>
                </tr>
                <tr>
                    <td align="right">兑换需积分:
                    </td>
                    <td>
                        <%=Model.NeedPoint%>
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>优惠券的操作记录</h3>
            </div>
            <div class="content">
				<table class="table">
                <asp:Repeater runat="server" ID="RepItem">
                    <HeaderTemplate>
                        <tr >
                            <td>
                                优惠券批次号
                            </td>
                            <td>
                                优惠券号码
                            </td>
                            <td >
                                优惠券金额
                            </td>
                            <td >
                                过期时间
                            </td>

                            <td>
                                是否使用
                            </td>
                            <td>
                                发送给用户
                            </td>
                            <td>
                                使用的用户Email
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr >
                            <td>
                                <%#Eval("LotNumber")%>
                            </td>
                            <td>
                                <%#Eval("ClaimCode")%>
                            </td>
                            <td>
                                <%=Model.DiscountPrice%>
                            </td>
                            <td>
                                <%#Eval("AddDateTime")%>
                            </td>
                            <td>
                                <%#Eval("Status")%>
                            </td>
                            <td>
                                <%#!Equals(Eval("UserId"),null)? EbSite.Base.Host.Instance.GetUserUserName(int.Parse(Eval("UserId").ToString())):""%>
                            </td>
                            <td>
                                <%#Eval("EmailAddress")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            </div>
    </div>
</div>
 