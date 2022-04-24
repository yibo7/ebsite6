<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginsList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Plugins.PluginsList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>管理插件</h3>
            插件也叫提供者程序，插件的开发来自第三方，使用过程中如果有问题请与开发商联系
            </div>
            <div class="content">				
                    <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="Name">
        <columns>
         <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                   <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="插件名称" ItemStyle-CssClass="gvfisrtTD">
                <ItemTemplate>
                    <%#Eval("Description")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态" ItemStyle-CssClass="gvfisrtTD">
                <ItemTemplate>
                    <%#bool.Parse(Eval("Enabled").ToString()) ? " 启用 " : " <font color=red>禁用</font> "%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="类型" ></asp:BoundField>  
           <asp:BoundField DataField="Version" HeaderText="版本" ></asp:BoundField>      
            <asp:TemplateField HeaderText="开发者" >
                <ItemTemplate>
                    <%#Eval("Author")%>
                </ItemTemplate>
            </asp:TemplateField>               
              <asp:TemplateField HeaderText="操作">
                <ItemTemplate>                
                <XS:EasyuiDialog ID="EasyuiDialog1" runat="server" Href='<%# string.Concat("?t=1&id=",Eval("Name"))%>'  Text="插件管理" Title="插件设置" />     
                <%--<XS:EasyuiDialog ID="WinBox2" runat="server" Href='<%# string.Concat("?t=2&id=",Eval("Name"))%>'  Text="导出插件" Title="导出插件" />--%>                
                </ItemTemplate>
            </asp:TemplateField>                
        </columns>
    </XS:GridView>
                
<XS:PagesContrl ID="pcPage" runat="server">    </XS:PagesContrl>
            </div>
    </div>
</div>