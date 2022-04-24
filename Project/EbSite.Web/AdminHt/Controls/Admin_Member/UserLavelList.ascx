<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLavelList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.UserLavelList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>会员级别管理</h3>
            </div>
            <div class="content">
                <XS:ToolBar ID="ucToolBar" runat="server" />
				<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="LevelName" HeaderText="级别名称" />
                        <asp:BoundField DataField="LevelId" HeaderText="级别ID" />
                        <asp:BoundField DataField="MinCredit" HeaderText="积分下限" />
                        <asp:BoundField DataField="MaxCredit" HeaderText="积分上限" />

                        <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation%>">
                            <ItemTemplate>
                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                                    confirm="true" Text="删除"></XS:LinkButton>
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