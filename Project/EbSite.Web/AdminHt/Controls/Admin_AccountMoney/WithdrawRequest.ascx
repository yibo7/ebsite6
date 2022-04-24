<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WithdrawRequest.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_AccountMoney.WithdrawRequest" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>提现申请</h3>
            </div>
            <div class="content">
				            
           <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server" DataKeyNames="id" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField HeaderText="ID" ItemStyle-Width="50" ReadOnly="true" DataField="id" />

                            <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    会员
                                </HeaderTemplate>
                                <ItemTemplate>
                                      <%#Eval("UserName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    会员ID
                                </HeaderTemplate>
                                <ItemTemplate>
                                      <%#Eval("UserID")%>
                                </ItemTemplate>
                            </asp:TemplateField>
            
                            <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    可用余额
                                </HeaderTemplate>
                                <ItemTemplate>
                                      <%#CountMoney(Convert.ToInt32( Eval("UserID")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
            
                            <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    提现金额
                                </HeaderTemplate>
                                <ItemTemplate>
                                       <%#Eval("Amount")%>
                                </ItemTemplate>
                            </asp:TemplateField>
            
                            <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    开户银行
                                </HeaderTemplate>
                                <ItemTemplate>
                                       <%#Eval("BankName")%> 
                                </ItemTemplate>
                            </asp:TemplateField>
            
            
                             <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    银行开户名
                                </HeaderTemplate>
                                <ItemTemplate>
                                      <%#Eval("AccountName")%> 
                                </ItemTemplate>
                            </asp:TemplateField>
            
                             <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    开户银行账号
                                </HeaderTemplate>
                                <ItemTemplate>
                                      <%#Eval("CardNumber")%>
                                </ItemTemplate>
                            </asp:TemplateField>
            
                              <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    备注
                                </HeaderTemplate>
                                <ItemTemplate>
                                      <%#Eval("Remark")%>
                                </ItemTemplate>
                            </asp:TemplateField>
            
                              <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                <HeaderTemplate>
                                    日期 
                                </HeaderTemplate>
                                <ItemTemplate>
                                        <%#Eval("RequestTime") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <HeaderTemplate>
                                    <%=Resources.lang.EBOperation%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <XS:LinkButton ID="lbOK" runat="server"  confirm="true"    Tips_Msg="要将申请状态更改为成功吗？如果您已经通过在线转账或线下打款，请继续操作"  CommandArgument='<%#Eval("UserID") %>' CommandName="OkModel"
                                            Text="确认"></XS:LinkButton>
                                        <XS:LinkButton ID="lbNO" runat="server"  confirm="true"   Tips_Msg="要将申请状态更改为失败吗？如果您在线转账或线下打款遇到什么问题或不允许此次提款，请继续操作" CommandArgument='<%#Eval("UserID") %>' CommandName="NoModel"
                                            Text="拒绝"></XS:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
           
            
                        </Columns>
                    </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>
 