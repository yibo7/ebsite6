<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemShow.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Vote.ItemShow" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
<div class="alert alert-success">管理投票选项[<a onclick='javascript:history.go(-1);'>返回</a>]"  </div>
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="选择名称" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("ItemName")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                    <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/> 
                                    <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector"   runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                            </Columns>
             </XS:GridView>
    </div>