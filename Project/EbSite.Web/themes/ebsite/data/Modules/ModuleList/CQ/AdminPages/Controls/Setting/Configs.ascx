<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Configs.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Setting.Configs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>常规设置</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                     <tr>
                        <td>
                            聊天窗口地址:
                        </td>
                        <td>
                           <a href="<%=Request.RawUrl %>&t=5" target="_blank" ><%=Request.RawUrl%>&t=5</a> 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            订单宝名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="Title" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            公司简介:
                        </td>
                        <td>                        
                            <asp:TextBox TextMode="MultiLine" Height="100" Width="300" ID="Demo" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            简介显示:
                        </td>
                        <td>                        
                            <asp:RadioButtonList ID="DemoModel" RepeatColumns="2" runat="server">
                                <asp:ListItem Value="0" Text="显示客服简介"></asp:ListItem>
                                <asp:ListItem Value="1" Text="显示公司简介"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    
                     
                    <tr>
                        <td>
                            默认打开模式:
                        </td>
                        <td>                        
                             <asp:RadioButtonList RepeatColumns="3" ID="ChatModel" runat="server">
                                <asp:ListItem Value="0" Text="聊天模式"></asp:ListItem>
                                <asp:ListItem Value="1" Text="导购模式"></asp:ListItem>
                                <asp:ListItem Value="2" Text="客服在线聊天模式，不在线导购模式"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            聊天窗口模式:
                        </td>
                        <td>                        
                             <XS:RadioButtonList RepeatColumns="2" ID="IsFull"     runat="server">
                                <asp:ListItem   Value="0" Text="小窗口"></asp:ListItem>
                                <asp:ListItem Value="1" Text="全屏窗口"></asp:ListItem>
                            </XS:RadioButtonList>
                        </td>
                    </tr>
                     
                     <tr>
                        <td>
                            消息刷新时间:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="txtTimeSpan" ValidateType="匹配正整数"  IsAllowNull="false" runat="server" width="50" HintInfo="数值越小用户体验越实时，但同时也会加大服务器请求负担"    >5000</XS:TextBoxVl>毫秒
                            
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            每位客服最多接待客户数:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="txtMaxReceive" ValidateType="匹配正整数"  IsAllowNull="false" runat="server" width="50" HintInfo="为0表示无限，大于0表示到达接待数顶限将自动转移到下一位空闲客服，如果所有客服正忙，将转移到自动下单模式"    >5</XS:TextBoxVl>位                          
                        </td>
                    </tr>
                    <tr>
                        <td>
                            是否保存订单:
                        </td>
                        <td>                        
                            <asp:CheckBox ID="IsSaveOrder" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td>
                            是否启用评价:
                        </td>
                        <td>                        
                            <XS:CheckBox ID="cbIsOpenAppraise" HintInfo="在客户退出时弹出要求评价打分提示！" runat="server" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            欢迎语句:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="txtWelComeInfo" height="100" HintInfo="客户打开聊天窗口第一句话,#客服#替换当前客服名称" TextMode="MultiLine"    runat="server" width="300"></XS:TextBoxVl>
                            
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>

    <div class="admin_toobar">
        <fieldset>
            <legend>飘浮页面设置</legend>
                <div>
                    <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            是否显示关闭按钮:
                        </td>
                        <td>                        
                             <asp:RadioButtonList RepeatColumns="2" ID="IsShowClose" runat="server">
                                <asp:ListItem Value="0" Text="显示"></asp:ListItem>
                                <asp:ListItem Value="1" Text="不显示"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            飘浮列表:
                        </td>
                        <td>                        
                            <asp:RadioButtonList RepeatColumns="2" ID="FloatListModel" runat="server">
                                <asp:ListItem Value="0" Text="只列客服名称"></asp:ListItem>
                                <asp:ListItem Value="1" Text="客服头像与名称"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            飘浮位置:
                        </td>
                        <td>                        
                             <asp:RadioButtonList RepeatColumns="2" ID="FloatPlaceModel" runat="server">
                                <asp:ListItem Value="0" Text="左飘浮"></asp:ListItem>
                                <asp:ListItem Value="1" Text="右飘浮"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            浮动顶部距离(像素):
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="txtTop" ValidateType="匹配正整数"  IsAllowNull="false" runat="server" width="50"    >260</XS:TextBoxVl>
                            
                        </td>
                    </tr>

                    <tr>
                        <td>
                            是否显示更多按钮:
                        </td>
                        <td>                        
                             <asp:RadioButtonList RepeatColumns="2" ID="IsShowMore" runat="server">
                                <asp:ListItem Value="0" Text="显示"></asp:ListItem>
                                <asp:ListItem Value="1" Text="不显示"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            更多连接:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="txtFloatServiceLink"  HintInfo="一般情况下为空，如果这里填写了连接，那么所有漂浮的客服将统一使用此连接,如所有漂浮都连接到客服中心"  runat="server" width="300"    ></XS:TextBoxVl>
                            <br />
                            <asp:CheckBox ID="cbIsServicerOutLink" Text="是否将飘浮客服连接到更多" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            漂浮客服最多显示:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="txtFloatServiceMaxNum" ValidateType="大于等于0整数包括0"  HintInfo="为0表示调用所有，大于将输出指定数目的客服"  runat="server" width="50"    >0</XS:TextBoxVl>
                            
                        </td>
                    </tr>
                        
                    </table>
            </div>
        </fieldset>
    </div>
    <div class="admin_toobar">
        <fieldset>
            <legend>无响应切换设置</legend>
                <div>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td>
                            无响应切换时间:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="txtTimeSpanToAuto" ValidateType="匹配正整数"  IsAllowNull="false" runat="server" width="50" HintInfo="在指定时间内，当客服未能及时响应客户咨询时切换到自动下单模式或下一位空闲客服，如果所有客服都忙，将默认切换自动下单模式"    >5</XS:TextBoxVl>秒
                          
                        </td>
                    </tr>
                    <tr>
                        <td>
                            无响应切换类型:
                        </td>
                        <td>
                            <XS:RadioButtonList ID="rbTimeSpanToAutoModel" RepeatColumns="2" HintInfo="与上面的无响应切换时间一起使用" runat="server">
                                <asp:ListItem Text="自动下单" Value="0"></asp:ListItem>
                                <asp:ListItem Text="空闲客服" Value="1"></asp:ListItem>
                            </XS:RadioButtonList>
                        </td>
                    </tr>
                    </table>
                </div>
        </fieldset>
    </div>

    <div class="admin_toobar">
        <fieldset>
            <legend>主动邀请设置</legend>
                <div>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                是否开户主动邀请:
                            </td>
                            <td>
                                <asp:CheckBox ID="cbIsOpenInvite"   runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                主动邀请延迟:
                            </td>
                            <td>
                              <XS:TextBoxVl ID="txtInviteTimeSpan" ValidateType="匹配正整数"  IsAllowNull="false" runat="server" width="50" HintInfo="客服对当前页面的内容感兴趣一般都会停留查看详细，所以为了不招客户烦，可以设置一个延迟时间发出邀请" >30</XS:TextBoxVl>秒
                          
                            </td>
                        </tr>
                        <tr>
                            <td>
                                主动邀请语:
                            </td>
                            <td>
                              <XS:TextBoxVl ID="txtInviteInfo" TextMode="MultiLine" height="50"   runat="server" width="300" HintInfo="发送邀请时显示的提示语" >您好，请问有什么需要帮到您的吗？</XS:TextBoxVl>                          
                            </td>
                        </tr>
                        <tr>
                        <td>
                            主动邀请弹出模式:
                        </td>
                        <td>                        
                             <asp:RadioButtonList RepeatColumns="5" ID="rbInviteModel" runat="server">
                                <asp:ListItem Value="0" Text="左下角"></asp:ListItem>
                                <asp:ListItem Value="1" Text="右下角"></asp:ListItem>
                                <asp:ListItem Value="2" Text="左上角"></asp:ListItem>
                                <asp:ListItem Value="3" Text="右上角"></asp:ListItem>
                                <asp:ListItem Value="4" Text="窗口中间"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    </table>
                </div>
        </fieldset>
    </div>

</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div> 
