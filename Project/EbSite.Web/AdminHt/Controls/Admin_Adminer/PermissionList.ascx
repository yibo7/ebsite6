<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermissionList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Adminer.PermissionList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>权限管理</h3>
            </div>
            <div>
                 <XS:ToolBar ID="ucToolBar" runat="server" />
				 <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="PermissionID">
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:lang,EBPermisName %>" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#Eval("PermissionName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PermissionID" ReadOnly="true" HeaderText="<%$Resources:lang,EBPermisId %>" />
                        <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>">
                            <ItemTemplate>

                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("PermissionID") %>' CommandName="DeleteModel"
                                    confirm="true" Text="删除"></XS:LinkButton>
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