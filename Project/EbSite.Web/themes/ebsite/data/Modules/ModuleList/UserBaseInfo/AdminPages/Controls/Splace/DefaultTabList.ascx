<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultTabList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.DefaultTabList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
          
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" DataKeyNames="ID" >
        <Columns>        
          
            <asp:TemplateField HeaderText="标签名称">
                <ItemTemplate>
                    <%#Eval("TabName")%>
                </ItemTemplate>
            </asp:TemplateField>   
            
             <asp:TemplateField HeaderText="版式">
                <ItemTemplate>
                    <%#Eval("Layout")%>
                </ItemTemplate>
            </asp:TemplateField>        
             <asp:TemplateField HeaderText="组名">
                <ItemTemplate>
                    <%#UserGroupName(int.Parse(Eval("UserGroupID").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>   

            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>              
                <XS:EasyuiDialog   Title="初始部件"  Href='<%#InitWidgetsUrl(Eval("id")) %>' Text="初始部件" runat="server"/>
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
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
        </div>
    </div>
</div>