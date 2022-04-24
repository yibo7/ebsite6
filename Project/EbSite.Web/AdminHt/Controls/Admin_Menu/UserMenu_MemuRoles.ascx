<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMenu_MemuRoles.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.UserMenu_MemuRoles" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:Notes ID="ntInfo"   runat="server" />
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>用户菜单权限管理</h3>
            </div>
            <div class="content">
				
            <XS:ToolBar ID="ucToolBar" runat="server"/>
                 <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>
            <asp:TemplateField HeaderText="<%$Resources:lang,EBMenuName %>" ItemStyle-CssClass="gvfisrtTD">
                <ItemTemplate>
                    <%#Eval("MenuName")%>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="<%$Resources:lang,EBIcon %>" >                 
                    <ItemTemplate>  
                            <img src="<%#Eval("imageurl") %>" width=16 height=16 />
                    </ItemTemplate>                 
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="<%$Resources:lang,EBMenuID %>">                 
                    <ItemTemplate>  
                        <XS:TextBoxVl ID="TextBox1" Text='<%#Eval("id") %>' runat="server"></XS:TextBoxVl>
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
<div class="text-center mt10">
    <XS:Button ID="bntSave" OnClick="bntSave_Click" Tips_CompleteMsg="权限保存成功" Tips_Msg="正在保存权限..." IsTipsButtonRight="true" runat="server" Text="保存权限" />&nbsp;&nbsp;
</div>
<%--<script>
    function SaveFrame() {
        $("#<%=bntSave.ClientID%>").click();
    }
</script>--%>