<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Adminer.RoleManager" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理角色</h3>
            </div>
            <div>
                <XS:ToolBar ID="ucToolBar" runat="server"/>
				<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" 
     onrowcancelingedit="RoleList_RowCancelingEdit"  DataKeyNames="RoleID"
    onrowediting="RoleList_RowEditing" 
    onrowupdating="RoleList_RowUpdating" >
    <Columns> 
             
       <asp:TemplateField HeaderText="<%$Resources:lang,
        EBRoleName%>">
                    <ItemTemplate>
                        <asp:Literal ID="llRoleName" Text='<%#Eval("Description")%>' runat="server"></asp:Literal>
                        
                    </ItemTemplate>
                    <EditItemTemplate>
                        <XS:TextBox ID="txtRoleName"  Text=<%#Eval("Description")%> runat="server">                     
                        &nbsp;&nbsp;&nbsp;&nbsp;                     
                        </XS:TextBox>
                    </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$Resources:lang,
        EBRoleOp%>">
                    <ItemTemplate>
                        <a Href='<%# string.Concat("?t=4&rid=",Eval("RoleID"))%>'>设置权限</a>
                          <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("RoleID") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                        <a Href='<%# string.Concat("?t=7&rid=",Eval("RoleID"))%>'>查看管理员</a>
                        
                    </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                    <ItemTemplate>
                        <asp:CheckBox ID="Selector"  runat="server" />
                    </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</XS:GridView>
            </div>
    </div>
</div>