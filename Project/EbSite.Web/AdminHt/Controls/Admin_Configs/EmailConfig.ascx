<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailConfig.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.EmailConfig" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>邮件设置</h3>
            </div>
            <div class="content">
				<table>
                    <tr>
                        <td>默认邮件发送插件：             
                        </td>
                        <td>
                            <XS:DropDownList ID="drpEmailSendPlugin" AppendDataBoundItems="True" runat="server">
                                <asp:ListItem Text="还没安装相关插件" Value="" />
                            </XS:DropDownList>
                        </td>
                    </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBSendMailName%>：
                    </td>
                    <td>
                        <XS:TextBox ID="emailfrom" runat="server" HintInfo="如果不知道怎么填写，可以为空" HintShowType="down"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBSmtpSvrName%>：
                    </td>
                    <td>
                        <XS:TextBox ID="smtpserver" runat="server" HintInfo="如果不知道怎么填写，可以为空" HintShowType="down"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBSendEmailAddr%>：
                    </td>
                    <td>
                        <XS:TextBox ID="emailuserName" runat="server" CanBeNull="必填"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBSendEmailPass%>：
                    </td>
                    <td>
                        <XS:TextBox ID="emailuserpwd" runat="server" CanBeNull="必填"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBCluNumOfPar%>：
                    </td>
                    <td>
                        <XS:TextBox ID="SynNum" runat="server" Width="80" Text="1" RequiredFieldType="数据校验" HintInfo="群发邮件时，以队列式发送，一次发送可以发送多少分邮件,一次发送的邮件过多可能会被邮件接收服务器拒绝" CanBeNull="必填"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBCluInterQue%>：
                    </td>
                    <td>
                        <XS:TextBox ID="iTimeSpan" runat="server" Width="80" Text="2" RequiredFieldType="数据校验" HintInfo="群发邮件时，以队列式发送，一次发送可以发送多少分邮件,每次发送的时间间隔,以秒为单位，如果发送速度过快可能会被邮件接收服务器拒绝" CanBeNull="必填"></XS:TextBox>秒
                    </td>
                </tr>
                <tr>
                    <td>发送端口：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtPort" runat="server" Width="50" Text="0" ValidateType="匹配正整数"></XS:TextBoxVl>
                        (默认为0,gmail的端口为587)
                    </td>
                </tr>
                <tr>
                    <td>开启SSL：
                    </td>
                    <td>
                        <XS:CheckBox ID="cbIsOpenSSL" runat="server"></XS:CheckBox>(默认不选择,如果是gmail要选上)
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>" />
                        &nbsp;&nbsp;
                        
                       
                    </td>
                </tr>

            </table>
            </div>
    </div>
</div>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>邮件发送测试</h3>
            </div>
            <div class="content">
				 <div>
                    测试邮箱：<XS:TextBox ID="txtTestEmail" runat="server" Width="300" HintInfo="如abc@ebsite.net" HintShowType="down"></XS:TextBox>
                </div>
                <div class="mt10">

                    <XS:Button ID="btnTestEmail" runat="server" Text="发送一份测试邮件" OnClick="btnTestEmail_Click"></XS:Button>
                </div>
            </div>
    </div>
</div>
 