<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SenderMsg.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_KuaiDi.SenderMsg" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>发货人管理</h3>
            </div>
            <div class="content">
				 <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>

                        <asp:TemplateField HeaderText="发货点名称">
                            <ItemTemplate>
                                <%#Eval("ShipperTag")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="默认发货信息">
                            <ItemTemplate>
                                <%#Eval("IsDefault")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="发货人姓名" DataField="ShipperName" />
                        <asp:BoundField HeaderText="地址" DataField="Address" />
                        <asp:BoundField HeaderText="邮编" DataField="Zipcode" />
                        <asp:BoundField HeaderText="手机" DataField="CellPhone" />
                        <asp:BoundField HeaderText="电话" DataField="TelPhone" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:EasyuiDialog ID="wbModify" Title="修改数据" Text="修改" runat="server" />
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                                    Text="删除"></XS:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
                 <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>