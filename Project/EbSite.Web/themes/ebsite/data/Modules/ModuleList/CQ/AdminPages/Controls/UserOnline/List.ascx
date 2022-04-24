<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.UserOnline.List" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" >
        <Columns>        
            <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                   <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="在线客户">
                <ItemTemplate>                  
                  <b>客户帐号</b>：<%#Eval("CustomerUserName")%> <br>
                  <b>客户IP</b>：<%#Eval("CustomerIp")%> <br>
                  <b>登录户ID</b>：<%#Eval("CustomerUserID")%>
                  <b>登录昵称</b>：<%#Eval("CustomerNiName")%>
                </ItemTemplate>
            </asp:TemplateField>    
            
             <asp:TemplateField HeaderText="交谈客服">
                <ItemTemplate>
                  <b>客服ID</b>:<%#Eval("ServiceID")%> <br>
                  <b>客服名称</b>:<%#GetServiceName(Eval("ServiceID"))%>                               
                </ItemTemplate>
            </asp:TemplateField>        
          
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>