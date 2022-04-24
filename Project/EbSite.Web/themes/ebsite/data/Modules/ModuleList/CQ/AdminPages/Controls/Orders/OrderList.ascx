<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderList.ascx.cs"
    Inherits="EbSite.Modules.CQ.AdminPages.Controls.Orders.OrderList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" DataKeyNames="ID">
        <columns>                            
               <asp:BoundField HeaderText="ID" DataField="ID" />    
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>  
                                          <a   onclick="return confirm('确认要删除?');"  href="<%#GetDelUrl(Eval("id"))%>">删除</a>     
                                         </ItemTemplate>
                                   </asp:TemplateField> 

                            </columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
