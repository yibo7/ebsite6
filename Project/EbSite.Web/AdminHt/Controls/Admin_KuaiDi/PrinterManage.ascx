<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrinterManage.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_KuaiDi.PrinterManage" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>打印管理</h3>
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                    <asp:BoundField HeaderText="ID" ItemStyle-Width="60" DataField="id"   />
                      <asp:BoundField HeaderText="单据名称" DataField="Name" />
                        <asp:TemplateField HeaderText="是否启用" >
                            <ItemTemplate>
                            <%#Eval("IsAct")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                              <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/>          
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>'
                                    CommandName="DeleteModel" Text="删除"></XS:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>