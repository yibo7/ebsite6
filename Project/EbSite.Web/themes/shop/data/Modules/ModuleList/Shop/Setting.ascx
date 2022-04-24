<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="EbSite.Modules.Shop.Setting" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div id="tg1">
    <style>
        H2
        {
            font-size: 14px;
            border-bottom: #ccc 1px solid;
            margin: 5px 0px;
            line-height: 30px;
        }
    </style>
    <table cellpadding="0" cellspacing="0">
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    购物车设置</h2>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="width: 20%; height: 15px">
                保存购物车：
            </td>
            <td align="left" style="height: 15px">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsSaveShopCar" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="保存">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="不保存">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="NoteA" runat="server" Text="登陆会员下单未完成时，购物车商品是否保留." />
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    发票设置</h2>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 30px;">
                能否开发票：
            </td>
            <td align="left" style="height: 30px">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsOpenInvoice" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="能">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="不能">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes0" Text="可否提供给客户开发票。如果开启，请设置订单税点，税点是以百分比设置。10代表10%" runat="server" />
                </span>
            </td>
        </tr>
        <tr class="FFtr">
            <td style="width: 20%" align="right">
                订单税点：
            </td>
            <td align="left" style="height: 45px">
                <XS:TextBoxVl ID="OrderTaxPoint" Text="0" runat="server" ValidateType="整数"   HintInfo="订单税点" />
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%;">
                积分支付比例：
            </td>
            <td align="left" style="height: 45px">
              <span style="float: left;">  <XS:TextBoxVl ID="ScorePayPoint" Text="0" runat="server"  ValidateType="整数" HintInfo="每100元商品最多可以使用多少元积分。注意此处设置的是百分比。如10代表是10%" />
                </span><span style="float: left;"> <XS:Notes ID="Notes6" Text="每100元商品最多可以使用多少元积分。注意此处设置的是百分比。如10代表是10%" runat="server" />
          </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    缺货设置</h2>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="height: 30px">
                是否使用缺货处理：
            </td>
            <td align="left" style="height: 30px">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsNoGood" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="使用">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="不使用">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes1" Text="使用缺货处理时前台订单确认页面允许用户选择缺货时处理方法" runat="server" />
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td style="width: 20%; height: 30px;" align="right">
                添加缺货登记条件：
            </td>
            <td align="left" style="height: 30px">
                <span style="float: left; margin-top: 5px;">
                    <XS:DropDownList ID="UserGroup" runat="server">
                        <asp:ListItem Value="0" Selected="True" Text="所有用户"></asp:ListItem>
                        <asp:ListItem Value="1" Text="注册用户"></asp:ListItem>
                    </XS:DropDownList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes2" Text="当购买商品提示库存不足时，限制是否必须为会员才能加缺货登记" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    邮件短信设置</h2>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="width: 20%">
                用户下单完成时：
            </td>
            <td align="left">
                <span style="float: left;">
                    <XS:RadioButtonList ID="IsOkEmail" runat="server">
                        <asp:ListItem Value="True" Selected="True" Text="发邮件">
                        </asp:ListItem>
                        <asp:ListItem Value="False" Text="不发送邮件">
                        </asp:ListItem>
                    </XS:RadioButtonList>
                </span><span style="float: left;">
                    <XS:Notes ID="Notes3" Text="客户下单完成时是否邮件通知客户。下同" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%">
                发货时：
            </td>
            <td align="left">
                <XS:RadioButtonList ID="IsSendEmail" runat="server">
                    <asp:ListItem Value="True" Selected="True" Text="发送邮件">
                    </asp:ListItem>
                    <asp:ListItem Value="False" Text="不发送邮件">
                    </asp:ListItem>
                </XS:RadioButtonList>
            </td>
        </tr>
        <tr class="FFtr">
            <td align="right" style="width: 20%">
                取消订单时:
            </td>
            <td align="left">
                <XS:RadioButtonList ID="IsCancelEmail" runat="server">
                    <asp:ListItem Value="True" Selected="True" Text="发送邮件">
                    </asp:ListItem>
                    <asp:ListItem Value="False" Text="不发送邮件">
                    </asp:ListItem>
                </XS:RadioButtonList>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                最小购物金额：
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBox ID="LessMoney" runat="server" Text="0" Width="56px" HintInfo="达到此购物金额，才能提交订单" />
            </td>
        </tr>
        <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    订单设置</h2>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                过期几天自动关闭订单：
            </td>
            <td align="left" style="height: 40px">
                <span style="float: left;">
                    <XS:TextBoxVl ID="AutoCloseOrderDays"  ValidateType="整数" runat="server" Text="0" Width="56px" />
                </span><span style="float: left;">
                    <XS:Notes ID="Notes4" Text="下单后过期几天系统自动关闭未付款订单" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                发货几天自动完成订单：
            </td>
            <td align="left" style="height: 40px">
                <span style="float: left;">
                    <XS:TextBoxVl ID="AutoFinishOrderDays" runat="server" Text="0" ValidateType="整数" Width="56px"  />
                </span><span style="float: left;">
                    <XS:Notes ID="Notes5" Text="货几天后，系统自动把订单改成已完成状态单" runat="server"></XS:Notes>
                </span>
            </td>
        </tr>
         <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    打印设置</h2>
            </td>
        </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                打印销售单是否打印赠品：
            </td>
            <td align="left" style="height: 40px">
                 <XS:DropDownList ID="IsPrintGift"   runat="server">
                        <asp:ListItem Text="不打印"  Value="False"/>
                         <asp:ListItem Text="打印" Value="True" />
                    </XS:DropDownList>   
                
            </td>
        </tr>
         <tr class="F7tr">
            <td colspan="2">
                <h2 class="clear">
                    降价通知、求团购短信模板</h2>
            </td>
        </tr>
         <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                降价通知手机短信模板：
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtDownNoticeMsgTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#商品名称#)
             </td>
         </tr>
         <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                降价通知邮件模板：
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtDownNoticeEmailTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#商品名称#)
             </td>
         </tr>
        <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                求团购手机短信模板：
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtRequestGroupMsgTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#商品名称#)
             </td>
         </tr>
         <tr class="F7tr">
            <td align="right" style="width: 20%; height: 40px;">
                求团购邮件模板：
            </td>
            <td align="left" style="height: 40px">
                <XS:TextBoxVl ID="txtRequestGroupEmailTemp" runat="server" TextMode="MultiLine" Width="500px" Height="80px"  />(#商品名称#)
             </td>
         </tr>
    </table>
</div>
<div id="tg2">
    通etao
</div>
