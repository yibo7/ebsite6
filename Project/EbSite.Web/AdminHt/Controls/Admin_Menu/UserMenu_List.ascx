<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMenu_List.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.UserMenu_List" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>用户菜单管理</h3>
            </div>
            <div class="eb-content">
				
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
                 <asp:TemplateField HeaderText="皮肤类型">                 
                    <ItemTemplate>  
                        <%#GetThemeType(Eval("MenuType"))%>
                    </ItemTemplate>                 
                 </asp:TemplateField> 
                 <asp:BoundField HeaderText="<%$Resources:lang,EBSortID %>" DataField="OrderID" /> 
                 <asp:BoundField HeaderText="<%$Resources:lang,ReWritePath %>" DataField="Target" /> 
            <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>">
                <ItemTemplate>
                  <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />                    
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
                    <a class="AdminLinkButton" target=_blank href="<%#Eval("Url") %>">访问模块</a>
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
 