<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditingMember.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.AuditingMember" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>审核会员</h3>
            </div>
            <div class="eb-content">
                 <XS:ToolBar ID="ucToolBar" runat="server" />
				<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="UserName">
                    <Columns>

                        <asp:BoundField DataField="UserName" HeaderText="用户名" />
                        <asp:BoundField DataField="ID" HeaderText="用户ID" />
                        <asp:BoundField DataField="NiName" HeaderText="昵称" />
                        <asp:BoundField DataField="CreateDate" HeaderText="注册日期" />

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:LinkButton ID="lbDelete" CommandArgument='<%#Eval("UserName") %>' CommandName="DeleteModel" Text="删除" runat="server"></XS:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
                
            <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
            </div>
    </div>
</div>
<script>

    function OnRoleChange(ob) {

        var rid = get_selected_value(ob);
        location.href = "<% =GetUrl%>&rid=" + rid;

    }
</script>
