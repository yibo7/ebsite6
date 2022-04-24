<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MsgList.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.MsgHistorys.MsgList" %>
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
            <asp:TemplateField HeaderText="标题">
                <ItemTemplate>
                    <%#Eval("title")%>
                </ItemTemplate>
            </asp:TemplateField>  
              <asp:TemplateField HeaderText="时间">
                <ItemTemplate>
                    <%#Eval("senddate")%>
                </ItemTemplate>
            </asp:TemplateField>  
                 <asp:TemplateField HeaderText="内容">
                <ItemTemplate>
                    <%#Eval("msgcontent")%>
                </ItemTemplate>
            </asp:TemplateField>  
             <asp:TemplateField HeaderText="发送人">
                <ItemTemplate>
                    <%#Eval("senderniname")%>
                </ItemTemplate>
            </asp:TemplateField>  
           
         
        </Columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage"  runat="server" />
</div>