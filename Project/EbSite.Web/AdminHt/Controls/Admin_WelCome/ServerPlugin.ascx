<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServerPlugin.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_WelCome.ServerPlugin" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 <div style="padding-left:10px;">

 <table class="datareport" cellpadding="0" cellspacing="0">
            <tr>
						<td width="20%" class="header"><span class="style5">Access数据库：</span></td>
						<td width="30%">
								<asp:Label ID="serveraccess" runat="server" />
							
						</td>
						<td width="20%" class="header"><span class="style5">FSO：</span></td>
						<td width="30%">
								<asp:Label ID="serverfso" runat="server" />
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">CDONTS邮件发送：</span></td>
						<td width="30%">
								<asp:Label ID="servercdonts" runat="server" />
						
						</td>
						<td width="20%" class="header"><span class="style5">JMail邮件收发：</span></td>
						<td width="30%">
								<asp:label ID="jmail" runat="server"></asp:label>
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">ASPemail发信：</span></td>
						<td width="30%">
								<asp:label ID="aspemail" runat="server"></asp:label>
						
						</td>
						<td width="20%" class="header"><span class="style5">Geocel发信：</span></td>
						<td width="30%">
								<asp:label ID="geocel" runat="server"></asp:label>
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">SmtpMail发信：</span></td>
						<td width="30%">
								<asp:label ID="smtpmail" runat="server"></asp:label>
							
						</td>
						<td width="20%" class="header"><span class="style5">ASPUpload文件上传:</span></td>
						<td width="30%">
								<asp:label ID="aspup" runat="server"></asp:label>
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">SoftArtisans文件管理:</span></td>
						<td width="30%">
								<asp:label ID="soft" runat="server"></asp:label>
						
						</td>
						<td width="20%" class="header"><span class="style5">Dimac文件上传:</span></td>
						<td width="30%">
								<asp:label ID="dimac" runat="server"></asp:label>
							</td>
					</tr>
					<tr>
						<td width="20%" class="header"><span class="style5">Dimac的图像读写组件:</span></td>
						<td width="30%">
								<asp:label ID="dimacimage" runat="server"></asp:label>
							
						</td>
						<td width="20%" class="header"><span class="style5">自定义组件查询(ProgId或ClassId)：</span></td>
						<td width="30%">
							<table width="100%" border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td width="60%" class="style5">
										<asp:TextBox ID="zujian" Rows="1" runat="server" TextMode="SingleLine" />
									</td>
									<td width="10%">
										<asp:Button ID="ckzu" runat="server" Text="检测" OnClick="chkzujian" />
									</td>
									<td width="30%">
										<font color="#ff0000">
											<asp:Label ID="serchinfo" runat="server" />
										</font>
									</td>
								</tr>
							</table>
						</td>
					</tr>
        </table>
         </div>