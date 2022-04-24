<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FastMenu_Class.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.FastMenu_Class" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:ToolBar ID="ucToolBar" runat="server"/>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" 
     onrowcancelingedit="RoleList_RowCancelingEdit"  DataKeyNames="Id"
    onrowediting="RoleList_RowEditing" 
    onrowupdating="RoleList_RowUpdating" >
    <Columns> 
             
       <asp:TemplateField HeaderText=" 分类名称 ">
                    <ItemTemplate>
                        <asp:Literal ID="llClassName" Text='<%#Eval("Description")%>' runat="server"></asp:Literal>
                        
                    </ItemTemplate>
                    <EditItemTemplate>
                        <XS:TextBox ID="txtClassName"  Text=<%#Eval("Description")%> runat="server">                     
                        &nbsp;&nbsp;&nbsp;&nbsp;                     
                        </XS:TextBox>
                    </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText=" 操 作 ">
                    <ItemTemplate>
                        <a Href='<%# string.Concat("?t=4&rid=",Eval("RoleID"))%>'>设置权限</a>
                          <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("RoleID") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                        <a Href='<%# string.Concat("?t=7&rid=",Eval("RoleID"))%>'>查看用户</a>
                        
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
