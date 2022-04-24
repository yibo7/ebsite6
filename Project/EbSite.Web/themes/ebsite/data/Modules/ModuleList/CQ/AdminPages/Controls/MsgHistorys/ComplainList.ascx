<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComplainList.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.MsgHistorys.ComplainList" %>
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
            <asp:TemplateField HeaderText="客服">
                <ItemTemplate>
                    <%#Eval("ServiceName")%>
                </ItemTemplate>
            </asp:TemplateField>   
             <asp:TemplateField HeaderText="类别">
                <ItemTemplate>
                   <%#Eval("TypeName")%>
                </ItemTemplate>
            </asp:TemplateField>    
             <asp:TemplateField HeaderText="内容">
                <ItemTemplate>
                   <%#Eval("Ctent")%>
                </ItemTemplate>
            </asp:TemplateField>      
             <asp:TemplateField HeaderText="时间">
                <ItemTemplate>
                    <%#Eval("OpDateTime")%>
                </ItemTemplate>
            </asp:TemplateField>   
           
        </Columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>