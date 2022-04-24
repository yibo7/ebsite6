<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Widget.ClassList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>部件分类管理</h3>
            </div>
            <div>
				 <XS:ToolBar ID="ucToolBar" runat="server" />
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="分类名称" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#Eval("title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AddDate" HeaderText="添加时期"></asp:BoundField>

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />
                                <%-- <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
            </div>
    </div>
</div>