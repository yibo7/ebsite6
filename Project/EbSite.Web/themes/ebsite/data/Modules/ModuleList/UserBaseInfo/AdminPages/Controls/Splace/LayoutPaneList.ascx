<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LayoutPaneList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.LayoutPaneList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>空间版式</b></h4>
            
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" DataKeyNames="ID" >
        <Columns>        
           
            <asp:TemplateField HeaderText="版式名称">
                <ItemTemplate>
                    <%#Eval("LayoutName")%>
                </ItemTemplate>
            </asp:TemplateField>   
            
             <asp:TemplateField HeaderText="文件名称">
                <ItemTemplate>
                    <%#Eval("FileName")%>
                </ItemTemplate>
            </asp:TemplateField>        
            

            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                <XS:EasyuiDialog   SaveText="保存版式" Title="编辑版式" Text="编辑版式" runat="server" Href='<%#GetUrl + string.Concat("&t=8&fn=",Eval("FileName"))%>' />/
                
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