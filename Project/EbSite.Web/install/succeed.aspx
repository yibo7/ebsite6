<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Install.succeed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html>
<%=header%>
<body> <asp:Panel ID="PanelErr" runat="server">
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
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#6DA805">
        <tr>
            <td bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" bgcolor="#6DA805">
                            <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                <tr>
                                    <td>
                                        <span style="color: #ffffff">安装成功</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="180" valign="top">
                            <%=logo%>
                        </td>
                        <td width="520" valign="top">
                            <br />
                            <br />
                            <form runat="server">
                            <table id="Table2" cellspacing="1" cellpadding="1" width="90%" align="center" border="0">
                                <tr>
                                    <td>
                                        <img src="images/succeed.jpg" alt="安装成功" style="margin-left:140px" /><br />
                                        <br />
                                        恭喜! 您已经成功安装<%=producename%><br /><br />
                                       <%-- 您还可以安装以下模块:<br /><br />
                                        <asp:CheckBoxList ID="cblModules"  RepeatColumns="3" CellSpacing="2" runat="server"/>
                                        <br>
                                        <asp:Button id="btnAddModules" runat="server" Text="添加模块"  onclick="btnAddModules_Click" ></asp:Button>
                                             <br />
                                      <font color="red">如果您不需要安装模块可以直接进入以下页面:</font>  --%>
                                        <br />
                                        
                                        <a onclick="OpenTipsToCenter('','初始化配置文件，请稍等...',200,100)" href="../index.aspx">访问首页</a>
                                        &nbsp;&nbsp;|&nbsp;&nbsp;
                                         <a onclick="OpenTipsToCenter('','初始化配置文件，请稍等...',200,100)" href="../AdminHt/syslogin.aspx">进入管理后台</a>
                                        
                                        <br />
                                        <br />
                                        
                                        </td>
                                </tr>
                            </table>
                            </form>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%=footer%>
    </asp:Panel>
</body>
</html>
