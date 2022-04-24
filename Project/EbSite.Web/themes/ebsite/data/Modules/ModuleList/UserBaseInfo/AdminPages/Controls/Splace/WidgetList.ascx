<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.WidgetList" %>
<%@ Import Namespace="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
          
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" DataKeyNames="ID" >
        <Columns>        
          
            <asp:TemplateField HeaderText="部件名称">
                <ItemTemplate>
                    <%#Eval("WidgetName")%>
                </ItemTemplate>
            </asp:TemplateField>   
            
             <asp:TemplateField HeaderText="部件ID">
                <ItemTemplate>
                    <%#Eval("id")%>
                </ItemTemplate>
            </asp:TemplateField>        
             <asp:TemplateField HeaderText="皮肤分类">
                <ItemTemplate>
                    <%#ThemesList.SpaceThemeName(int.Parse(Eval("ThemeClassID").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>    

            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
               
                <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/>/
                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
</div>
        </div>
    </div>
</div>