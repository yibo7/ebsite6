<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Install.step3" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<%=header%>
<body>
    <asp:Panel ID="PanelErr" runat="server">
        <table width="525" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="">
            <tr>
                <td>
                    <img src="images/failure.png" alt="不能安装" style="margin-left: 170px" /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <span style="font-size: 16px;">系统已经安装，如果想重新安装系统请删除install目录下的ebsite.lock文件</span>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelOK" runat="server">
        <form id="Form1" method="post" runat="server" onsubmit="return CheckDataBaseConfig();">
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
                                            <font color="#ffffff">
                                                <asp:Literal ID="llTitle" runat="server"></asp:Literal></font>
                                        </td>
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
                                            <table cellspacing="0" cellpadding="5" width="100%" border="0">
                                                <tr>
                                                    <td style="background-color: #f5f5f5;">
                                                        数据库类型:
                                                    </td>
                                                    <td style="background-color: #f5f5f5; width: 352px;">
                                                        <XS:DropDownList ID="ddlDbType" runat="server" onchange="SelectChange(this)">
                                                            <asp:ListItem Value="0">请选择数据库类型</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="MySql">MySql</asp:ListItem>
                                                            <%-- <asp:ListItem  Value="SqlServer">SqlServer</asp:ListItem>--%>
                                                        </XS:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="MySql" colspan="2">
                                                        <table cellspacing="0" cellpadding="5" width="100%" border="0">
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    主机名或IP地址:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtMySqlDatasource" runat="server" Width="150" Enabled="true" onblur="checkid(this,'1')"></XS:TextBox>*<span
                                                                        id="Span1"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    端口:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtSport" runat="server" Width="150" Enabled="true" onblur="checkid(this,'1')"></XS:TextBox>*<span
                                                                        id="Span4"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据库名称:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtMySqlDataBaseName" runat="server" Width="150" Enabled="true" onblur="checkid(this,'2')"></XS:TextBox>*<span
                                                                        id="Span2"> </span>
                                                                    <br>
                                                                    这里输入数据库名称，要确保数据库中已经存在此数据库
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据库用户名称:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtMySqlDataBaseUser" runat="server" Width="150" Enabled="true" onblur="checkid(this,'3')">sa</XS:TextBox>*<span
                                                                        id="Span3"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据库用户密码:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtMySqlDataBasePass" runat="server" Width="150" Enabled="true" TextMode="Password"></XS:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据表前缀:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtMySqlTableprefix" runat="server" Width="150" Enabled="true">EB_</XS:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="SqlServer" colspan="2" style="display: none">
                                                        <table cellspacing="0" cellpadding="5" width="100%" border="0">
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    服务器名或IP地址:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtDatasource" runat="server" Width="150" Enabled="true" onblur="checkid(this,'1')"></XS:TextBox>*<span
                                                                        id="msg1"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据库名称:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtDataBaseName" runat="server" Width="150" Enabled="true" onblur="checkid(this,'2')"></XS:TextBox>*<span
                                                                        id="msg2"> </span>
                                                                    <br>
                                                                    这里输入数据库名称，要确保数据库中已经存在此数据库
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据库用户名称:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtDataBaseUser" runat="server" Width="150" Enabled="true" onblur="checkid(this,'3')">sa</XS:TextBox>*<span
                                                                        id="msg3"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据库用户密码:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtDataBasePass" runat="server" Width="150" Enabled="true" TextMode="Password"></XS:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="background-color: #f5f5f5">
                                                                    数据表前缀:
                                                                </td>
                                                                <td style="background-color: #f5f5f5; width: 352px;">
                                                                    <XS:TextBox ID="txtTableprefix" runat="server" Width="150" Enabled="true">EB_</XS:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <table cellspacing="0" cellpadding="8" width="60%" border="0">
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="bntStarInstall" runat="server" Text="下一步" OnClick="bntStarInstall_Click">
                                            </asp:Button>&nbsp;&nbsp;
                                            <asp:CheckBox ID="cbIsOutOfUser" Text="用户库分离" ToolTip="也就是将用户的数据单独保存在另一个数据库,是否分离用户数据库,如果您不知道这是什么，请保持默认"
                                                runat="server" />
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
