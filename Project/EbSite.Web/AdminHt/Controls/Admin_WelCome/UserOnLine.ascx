<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserOnLine.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_WelCome.UserOnLine" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%-- <div style=" background: #2664A4; color: #fff; padding: 5px;">
      总计<%=CountUserOnline%>人在线 
  </div>--%>

  
 <div class="table-responsive">
     <asp:Repeater ID="rpUserOnline" runat="server"  >
                     <HeaderTemplate> 
                        <table class="table m-0">
														<thead>
															<tr> 
																<th>用户名称</th>
																<th>IP地址</th>
																<th>最后活动时间</th>
																<th>最后活动页面</th> 
															</tr>
														</thead>
                        <tbody> 
                        </HeaderTemplate>
                         <ItemTemplate>
                             <tr>
												<td><%#Eval("UserNiname")%></td>
												<td><%#Eval("Ip")%></td>
												<td><%#Eval("LastUpdateTime")%></td>
												<td><a target="_blank" href="<%#Eval("WebUrl")%>"><%#Eval("WebUrl")%></a></td>
											</tr>
                             
                         </ItemTemplate>
                        <FooterTemplate>
                            </tbody></table>  
                        </FooterTemplate>
                 </asp:Repeater>

</div>
    <XS:PagesContrl ID="pgCtr" PageSize="30" runat="server" /> 
