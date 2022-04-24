<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Install.step4" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>

<%=header%>
<body >
     <asp:Panel ID="PanelErr" runat="server">
        <table width="525" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="">
            <tr>
                <td>
                     <img src="images/failure.png" alt="不能安装" style="margin-left:170px" /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <br/>
                   <span style="font-size: 16px; "> 系统已经安装，如果想重新安装系统请删除install目录下的ebsite.lock文件</span>
                </td>
            </tr>
        </table>
    </asp:Panel>
      <asp:Panel ID="PanelOK" runat="server">
    <form id="Form1" method="post" runat="server" onsubmit="return CheckAdmin();">
        <table cellspacing="1" cellpadding="0" width="700" align="center" bgcolor="#6DA805"
            border="0">
            <tr>
                <td bgcolor="#ffffff">
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td bgcolor="#6DA805" colspan="2">
                                <table cellspacing="0" cellpadding="8" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <font color="#ffffff">系统配置</font></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="180">
                                <%=logo%>
                            </td>
                            <td valign="top" width="520">
                                <br>
                                <asp:Literal ID="msg" runat="server" Text="您当前论坛的Web.config文件设置不正确, 请您确保其文件内容正确<BR><FONT color=#996600>详见《安装说明》</FONT>"
                                    Visible="False"></asp:Literal>
                                <table cellspacing="0" cellpadding="8" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <p>
                                            </p>
                                            <table cellspacing="0" cellpadding="8" width="100%" border="0">
                                                <tr>
                                                    <td width="30%">网站的名称:</td>
                                                    <td style="width: 352px">
                                                        <XS:TextBoxVl ID="txtWebSiteName" runat="server" IsAllowNull="false"  Width="150px">EbSite</XS:TextBoxVl></td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">网站 URL:</td>
                                                    <td style="width: 352px">
                                                        <XS:TextBoxVl ID="txtWebUrl" runat="server" IsAllowNull="false" ValidateType="网址Url"
                                                            Width="150px"></XS:TextBoxVl>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">虚拟目录:</td>
                                                    <td style="width: 352px">
                                                        <XS:TextBoxVl ID="txtIISPath" runat="server" IsAllowNull="false" ValidateType="不作验证"
                                                            Width="150px"></XS:TextBoxVl></td>
                                                </tr>
                                                <tr>
                                                    <td>系统管理员名称:</td>
                                                    <td style="width: 352px">
                                                        <XS:TextBoxVl ID="txtManagerName" runat="server" IsAllowNull="false" ValidateType="账号字母开头数字下划线"
                                                            Text="admin" MaxLength="20" Size="20" Width="150px"></XS:TextBoxVl>*&nbsp;
                                                        <input type="checkbox" id="sponsercheck" name="sponsercheck" runat="server" checked style="height: 18px">设置为创始人</td>
                                                </tr>
                                                <tr>
                                                    <td>系统管理员密码:<br />
                                                        (不得少于6位)</td>
                                                    <td style="width: 352px">
                                                        <XS:TextBoxVl ID="txtManagerPass" onkeyup="return loadinputcontext(this);" runat="server" IsAllowNull="false"  ValidateType="匹配由数字和26个英文字母组成的字符串" TextMode="Password"
                                                            MaxLength="32" Size="20" Width="150px"></XS:TextBoxVl>*<br />
                                                        密码强度:<span id="showmsg"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>确认密码:</td>
                                                    <td style="width: 352px">
                                                        <input name="repwd" type="password" maxlength="32" id="repwd" class="FormBase" onfocus="this.className='FormFocus';" IsAllowNull="false" onblur="this.className='FormBase';" maxlength="32" size="20" style="width:150px;" />*
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>管理员邮箱:</td>
                                                    <td style="width: 352px">
                                                        <XS:TextBoxVl ID="txtManagerEmail" runat="server" ValidateType="电子邮箱email" IsAllowNull="false" MaxLength="50"
                                                            Size="20">admin@ebsite.cn</XS:TextBoxVl></td>
                                                </tr>
                                                
                                                
                                            </table>
                                            
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <table cellspacing="0" cellpadding="8" width="60%" border="0">
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="bntStarInstall" runat="server" Text="下一步" onclick="bntStarInstall_Click" ></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%=footer%>
    </form>
    </asp:Panel>
</body>
</html>
