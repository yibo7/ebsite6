<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Comment.ClassList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理讨论区数据</h3>
            讨论模块对应于当前站点，非所有站点通用
            </div>
            <div>
				<br />
                    <XS:ToolBar ID="ucToolBar" runat="server" /> 
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="分类名称" ItemStyle-CssClass="gvfisrtTD" ItemStyle-Width="130">
                            <ItemTemplate>
                                <%#Eval("ClassName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="类别">
                            <ItemTemplate>
                                <%#GetType(Eval("itype"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="ID" ReadOnly="true" DataField="id"></asp:BoundField>
            
                        <asp:TemplateField HeaderText="操作" ItemStyle-Width="330">
                            <ItemTemplate>
                                <XS:LinkButton ID="LinkButton3" CommandArgument='<%#Eval("id") %>' CommandName="EditTem"
                                    Text="编辑模板" runat="server"></XS:LinkButton>
                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />
                                <XS:LinkButton ID="lbDelete" Tips_Msg="删除此分类吗？同时删除其下的所有评价。" Visible='<%#!bool.Parse( Eval("IsSystem").ToString())%>'  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                                    Text="删除"></XS:LinkButton> 
                               <a class="AdminLinkButton"  href="Admin_Comment.aspx?t=3&id=<%#Eval("id") %> ">代码调用</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
            </div>
    </div>
</div>