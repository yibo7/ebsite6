<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Install.step1" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<%=header%>
<body>
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
        <table width="700" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#6DA805">
            <tr>
                <td bgcolor="#ffffff">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2" bgcolor="#6DA805">
                                <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                    <tr>
                                        <td>
                                            <font color="#ffffff">欢迎安装
                                                <%=producename%>
                                            </font>
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
                                <br>
                                <br>
                                <table id="Table2" cellspacing="1" cellpadding="1" width="90%" align="center" border="0">
                                    <tr>
                                        <td>
                                            <p>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 欢迎您选择安装<%=producename%></p>
                                            <p>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 本向导将协助您一步步的安装和初始化系统.</p>
                                            <p>
                                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 强烈建议您在运行本向导前仔细阅读程序包中的《安装说明》文档, 如果您已经阅读过, 请点击下一步.</p>
                                        </td>
                                    </tr>
                                </table>
                                <p>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <table width="90%" border="0" cellspacing="0" cellpadding="8">
                                    <tr>
                                        <td align="right">
                                            <input type="button" onclick="javascript:window.location.href='step2.aspx';" value="下一步">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%= footer%>
    </asp:Panel>
</body>
</html>
