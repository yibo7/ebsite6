<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServiceClass.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Service.ServiceClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" DataKeyNames="ID" >
        <Columns>        
            <asp:TemplateField HeaderText="ID"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                  <%#Eval("ID")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="客服类别">
                <ItemTemplate>
                    <%#Eval("Title")%>
                </ItemTemplate>
            </asp:TemplateField>         

            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>

                <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/>/
                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                 <XS:LinkButton   runat="server" CommandArgument='<%#Eval("id") %>' CommandName="copy"  Text="复制"></XS:LinkButton>
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