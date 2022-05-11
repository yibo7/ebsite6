<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserConfig.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.UserConfig" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>用户相关的配置</h3>
            </div>
            <div class="eb-content">
				<table>
                <tr>
                    <td>
                        <%=Resources.lang.EBDefaultGrp%>：
                    </td>
                    <td>
                        <XS:DropDownList ID="UserGroup" Width="200" runat="server">
                        </XS:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        默认用户级别：
                    </td>
                    <td>
                        <XS:DropDownList ID="UserLeval" Width="200" runat="server">
                        </XS:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBNewUserReg%>：
                    </td>
                    <td>
                        <XS:RadioButtonList ID="IsAllowRegister" runat="server" Width="200" HintInfo="">
                            <asp:ListItem Value="0">不允许注册</asp:ListItem>
                            <asp:ListItem Value="1">允许注册</asp:ListItem>
                        </XS:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBNotAllowRegNotice%>：
                    </td>
                    <td>
                        <XS:TextBox ID="NoAllowToRegInfo" Width="300" Height="100" TextMode="MultiLine" HintInfo="当您的上面选择[不允许注册]时请在这里注明原因"
                            runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBDefualtUsIntegral%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="DefaultCredits" ValidateType="大于等于0整数包括0" CanBeNull="必填" Width="100"
                            HintInfo="新注册用户积分可以获得多少积分" runat="server"></XS:TextBoxVl>
                    </td>
                </tr>
               
                 <tr>              
                <td >
                    在线用户过期时间：          
                </td>
                <td  class="form-inline" >
                    <XS:TextBox ID="txtOnlineTimeSpan" runat="server" RequiredFieldType="数据校验" HintInfo="设置为0将不统计在线用户,可节省资源,大于0表示开启统计，并且用户无活动，并且超过这个指定时长时将做一次清理" Width="50px"></XS:TextBox>
                    <XS:DropDownList ID="drpOnlineTimeSpanModel" Width="200" runat="server">
                        <asp:ListItem Text="天" Value="0"></asp:ListItem>
                        <asp:ListItem Text="小时" Value="1"></asp:ListItem>
                        <asp:ListItem Text="分钟" Value="2"></asp:ListItem>
                    </XS:DropDownList>
                </td>
                
           </tr>
                <tr>
                    <td>
                        第一次修改头像可获得积分:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtModifyIcoInCredit" ValidateType="大于等于0整数包括0" IsAllowNull="false"
                            runat="server" Width="50">1</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        添加一条内容可获得积分:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtAddContentInCredit" ValidateType="大于等于0整数包括0" IsAllowNull="false"
                            runat="server" Width="50">1</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        邀请一个用户注册获得积分:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtInviteRegInCredit" ValidateType="大于等于0整数包括0" IsAllowNull="false"
                            runat="server" Width="50">1</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        一天内第一次登录获得积分:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtLoginInCredit" ValidateType="大于等于0整数包括0" IsAllowNull="false"
                            runat="server" Width="50">1</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        发表一个评论可获得积分:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtToCommentInCredit" ValidateType="大于等于0整数包括0" IsAllowNull="false"
                            runat="server" Width="50">1</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBRegUsActWay%>：
                    </td>
                    <td>
                        <XS:DropDownList ID="drpAllowUserType" Width="200" runat="server">
                            <asp:ListItem Value="0" Text="自动激活"></asp:ListItem>
                            <asp:ListItem Value="1" Text="手动激活"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Email激活"></asp:ListItem>
                        </XS:DropDownList>
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <%=Resources.lang.EBUsGrpMech%>：
                    </td>
                    <td>
                        <XS:RadioButtonList ID="GroupType" runat="server">
                            <asp:ListItem Value="0">单用户组</asp:ListItem>
                            <asp:ListItem Value="1">多用户组</asp:ListItem>
                        </XS:RadioButtonList>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <%=Resources.lang.EBMbLogValidCode%>：
                    </td>
                    <td>
                        <XS:RadioButtonList ID="IfCode" Width="200" runat="server" HintInfo="">
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </XS:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBErrLogInLock%>：
                    </td>
                    <td  class="form-inline" >
                        出错次数:<XS:TextBox ID="ErrLoginNumLock" Width="50" HintInfo="错误登录多少次后锁定定用户登录" runat="server"></XS:TextBox>
                        锁定时间（单位分钟）:<XS:TextBox ID="LockTime" Width="50" HintInfo="要锁定多长时间" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBIpLimit%>：
                    </td>
                    <td  class="form-inline" >
                        开始IP<XS:TextBoxVl ID="txtStarIP" ValidateType="IP地址" Width="150" HintInfo="开始IP段,如 192.168.1.1"
                            runat="server" />
                        结束IP<XS:TextBoxVl ID="txtEndIP" ValidateType="IP地址" Width="150" HintInfo="结束IP段,如 192.168.2.10"
                            runat="server" />
                        到期时间:<XS:DatePicker ID="dtEndDate" Width="100" HintInfo="结束IP段,如 192.168.2.10" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        整合用户中心域名:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtUserCenter" HintInfo="默认请置为空，如果您把用户中心独立为一个站点，需要在这里设置用户中心站点的域名,如http://passport.ebsite.net,这样您可以使用ebsite制作多个的站点,分布到多个服务器上，而他们使用同一个用户中心"
                            runat="server" Width="300"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        提示更新:
                    </td>
                    <td>
                        <asp:CheckBox Text="头像" ID="IsHeader" runat="server" />
                        &nbsp;&nbsp;提示语:<asp:TextBox Width="200" ID="HeaderHint" runat="server"></asp:TextBox>&nbsp;&nbsp;提示顺序:<asp:DropDownList
                            runat="server" ID="OrderHeader">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <br>
                        <asp:CheckBox Text="手机号" ID="IsTel" runat="server" />
                        &nbsp;&nbsp;提示语:<asp:TextBox Width="200" ID="TelHint" runat="server"></asp:TextBox>&nbsp;&nbsp;提示顺序:<asp:DropDownList
                           ID="OrderTel" runat="server">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <br>
                        <asp:CheckBox Text="email" ID="IsEmail" runat="server" />
                        &nbsp;&nbsp;提示语:<asp:TextBox Width="200" ID="EmailHint" runat="server"></asp:TextBox>&nbsp;&nbsp;提示顺序:<asp:DropDownList
                           ID="OrderEmail" Width="200"  runat="server">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBRegMebKnow%>：
                    </td>
                    <td style="width: 550px; height: 200px; padding-top: 10px;">
                        <XS:UEditor  ID="RegisterPact" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <br>
                        <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>