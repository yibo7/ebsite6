<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassConfigList.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.ClassConfigList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div class="table-responsive" id="listP">
     
    <XS:GridView ID="gdList" runat="server" DataKeyNames="id" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID" ItemStyle-Width="50" ReadOnly="true" DataField="id" />

            <asp:TemplateField ItemStyle-CssClass="gvfisrtTD" HeaderText="应用分类"> 
                <ItemTemplate>
                    配置<%#Eval("id") %>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="操作"> 
                <ItemTemplate>
                    <a href='<%#string.Format("{0}&id={1}&pid={2}",GetMenuLink(3),Eval("id"),Eval("parentid"))%>'><img title="修改" src="<%=IISPath %>images/edit.gif" /></a>
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除">
                        <img title="删除分类" src="<%=IISPath %>images/delete.gif" />
                    </XS:LinkButton>
                    <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyClass"
                        confirm="true" Text="复制"><img title="复制分类" src="<%=IISPath %>images/copy.gif" /></XS:LinkButton>
                         
                </ItemTemplate>
            </asp:TemplateField> 
            
        </Columns>
    </XS:GridView>
</div>
<XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" /> 
