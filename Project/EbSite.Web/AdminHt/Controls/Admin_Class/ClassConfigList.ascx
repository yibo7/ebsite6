<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassConfigList.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.ClassConfigList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
            <h3>分类设置管理</h3>
        </div>
        <XS:Notes ID="txtLab" Text="如果要添加新配置，可以复制也可以添加" runat="server" />
        <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
        <XS:GridView ID="gdList" runat="server" DataKeyNames="id" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="ID" ItemStyle-Width="50" ReadOnly="true" DataField="id" />

                <asp:TemplateField ItemStyle-CssClass="gvfisrtTD" HeaderText="应用分类">
                    <ItemTemplate>
                        <%#Eval("ConfigName") %><%#bool.Parse(Eval("IsDefault").ToString())?"[<font color='#ff0000'>默认</font>]":"" %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        
                        <XS:LinkButton ID="lbModify" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="modifyCf">
                            <span class="linkbtn">修改</span>
                        </XS:LinkButton>                       
                        <span class="linkbtn">
                            <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="copy" confirm="true" Text="复制" />
                        </span>
                        
                        <XS:LinkButton ID="lbSetDefault" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="SetToDefault"  confirm="true"  ><span class="linkbtn">设为默认</span></XS:LinkButton>
                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" ><span class="linkbtn">删除</span></XS:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </XS:GridView>

        <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
    </div>
</div>
