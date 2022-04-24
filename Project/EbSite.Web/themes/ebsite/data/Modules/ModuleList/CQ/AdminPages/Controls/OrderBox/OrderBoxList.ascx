<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderBoxList.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.OrderBox.OrderBoxList" %>
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
            <asp:TemplateField HeaderText="流程名称">
                <ItemTemplate>
                    <%#Eval("Title")%>
                </ItemTemplate>
            </asp:TemplateField>  
             <asp:TemplateField HeaderText="流失率">
                <ItemTemplate>
                    <%#Eval("CloseNum")%>
                </ItemTemplate>
            </asp:TemplateField>    
            
             <asp:TemplateField HeaderText="客服提示语">
                <ItemTemplate>
                   <%#Eval("Tips")%>
                </ItemTemplate>
            </asp:TemplateField>      
             <asp:TemplateField HeaderText="排序ID">
                <ItemTemplate>
                    <%#Eval("OrderID")%>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>

                <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/>/
                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>/
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
<div style=" text-align:center">

<XS:Button ID="btnSaveJs" runat="server" HintInfo="如果您重新修改或添加了流程，请点击生成一遍" Text="生成订单流程数据" 
    onclick="btnSaveJs_Click" />
    
    &nbsp;
    &nbsp;
<XS:Button ID="btnReSetOutNum" runat="server"  Text="流失率清零" 
    onclick="btnReSetOutNum_Click" />
</div>