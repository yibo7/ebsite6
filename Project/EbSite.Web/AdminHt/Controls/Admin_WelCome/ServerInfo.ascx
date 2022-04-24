<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServerInfo.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_WelCome.DataReport" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

  <div style="padding-left:10px;">
 <table  class="datareport" cellpadding="0" cellspacing="0">
        <tr>
						<td width="20%" class="header"><span class="style5">服务器名称：</span></td>
						<td width="30%">
								<asp:Label ID="servername" runat="server" />
							
						</td>
						<td width="20%" class="header"><span class="style5">服务器操作系统：</span></td>
						<td width="30%">
								<asp:Label ID="serverms" runat="server" />
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">服务器IP地址：</span></td>
						<td width="30%">
								<asp:Label ID="serverip" runat="server" />
							
						</td>
						<td width="20%" class="header"><span class="style5">服务器域名：</span></td>
						<td width="30%">
								<asp:Label ID="server_name" runat="server" />
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">服务器IIS版本：</span></td>
						<td width="30%">
								<asp:Label ID="serversoft" runat="server" />
							
						</td>
						<td width="20%" class="header"><span class="style5">.NET解释引擎版本：</span></td>
						<td width="30%">
								<asp:Label ID="servernet" runat="server" />
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">HTTPS：</span></td>
						<td width="30%">
								<asp:Label ID="serverhttps" runat="server" />
							
						</td>
						<td width="20%" class="header"><span class="style5">HTTP访问端口：</span></td>
						<td width="30%">
								<asp:Label ID="serverport" runat="server" />
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">服务端脚本执行超时：</span></td>
						<td width="30%">
								<asp:Label ID="serverout" runat="server" />
								秒</td>
						<td width="20%" class="header"><span class="style5">服务器现在时间：</span></td>
						<td width="30%">
								<asp:Label ID="servertime" runat="server" />
							</td>
					</tr>
					<tr>
						<td class="header"><span class="style5">AspNet内存占用：</span></td>
						<td>
								<asp:Label ID="aspnetn" runat="server" />
								M 
						</td>
						<td class="header"><span class="style5">AspNet CPU时间:</span></td>
						<td>
								<asp:Label ID="aspnetcpu" runat="server" />
								秒 </td>
					</tr>
					<tr>
						<td class="header"><span class="style5">开机运行时长:</span></td>
						<td>
								<asp:Label ID="serverstart" runat="server" />
								小时
						</td>
						<td class="header"><span class="style5">进程开始时间:</span></td>
						<td>
								<asp:Label ID="prstart" runat="server" />
							</td>
					</tr>
					<tr>
						<td class="header"><span class="style5">CPU数：</span></td>
						<td>
								<asp:Label ID="cpuc" runat="server" />
								个
						</td>
						<td class="header"><span class="style5">服务器时区：</span></td>
						<td>
								<asp:Label ID="serverarea" runat="server" />
							</td>
					</tr>
					<tr>
						<td class="header"><span class="style5">CPU类型：</span></td>
						<td colspan="3">
								<asp:Label ID="cputype" runat="server" />
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">虚拟目录绝对路径：</span></td>
						<td colspan="3">
								<asp:Label ID="serverppath" runat="server" />
							</td>
					</tr>
					<tr>
						<td class="header"><span class="style5">执行文件绝对路径：</span></td>
						<td colspan="3">
								<asp:Label ID="servernpath" runat="server" />
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">虚拟目录Session总数：</span></td>
						<td width="30%">
								<asp:Label ID="servers" runat="server" />
							
						</td>
						<td width="20%" class="header"><span class="style5">虚拟目录Application总数：</span></td>
						<td width="30%">
								<asp:Label ID="servera" runat="server" />
							</td>
					</tr>
    </table>
    </div>