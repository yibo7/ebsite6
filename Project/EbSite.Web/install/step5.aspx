<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Install.step5" %>

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
    <form id="Form1" method="post" runat="server" >
        
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
                                            <font color="#ffffff">开始安装</font></td>
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
                                核心系统采用的数据库类型是: 
                                <asp:Label runat="server" ForeColor="Red" ID="lbDataBaseType" ></asp:Label> 
                                <br />
                                用户系统采用的数据库类型是:
                                <asp:Label runat="server" ForeColor="Red" ID="lbDataBaseTypeUser" ></asp:Label> 
                                <br /><br />
                                下列dll文件可以从bin目录中清除
                                 <br />
                                <asp:Label runat="server" ForeColor="Red" ID="lbBinInfo" ></asp:Label> 
                                <br /> <br />
                                系统将会执行如下操作, 这可能需要一些时间...... 
                                 <br />
                                 <asp:Label runat="server" ForeColor="Red" ID="lbInstallInfo" ></asp:Label> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <table cellspacing="0" cellpadding="8" width="60%" border="0">
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="bntStarInstall" OnClientClick="OpenTipsToCenter('','正在安装,请稍等..',200,100)" Width="100" Height="30" runat="server" 
                                                Text="开始安装" onclick="bntStarInstall_Click"  ></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            
                                            <br /><br />
                                            <asp:CheckBox ID="cbInstallDemoData" Text="同时安装演示数据" Checked="true" runat="server" />
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
