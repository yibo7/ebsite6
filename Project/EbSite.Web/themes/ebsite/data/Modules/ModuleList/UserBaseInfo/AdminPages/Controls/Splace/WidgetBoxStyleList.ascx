<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetBoxStyleList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.WidgetBoxStyleList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
         
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" DataKeyNames="ID" >
        <Columns>        
            <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                   <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="样式名称">
                <ItemTemplate>
                    <%#Eval("StyleName")%>
                </ItemTemplate>
            </asp:TemplateField>   
            
             <asp:TemplateField HeaderText="样式模板">
                <ItemTemplate>
                    <%#Eval("StyleTemp")%>
                </ItemTemplate>
            </asp:TemplateField>   
           <%--  <asp:TemplateField HeaderText="适用皮肤">
                <ItemTemplate>
                    <%#GetThemeName(Convert.ToInt16(Eval("ThemeID")))%>
                </ItemTemplate>
            </asp:TemplateField>    --%>         
            
                         

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
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
        </div>
    </div>
</div>