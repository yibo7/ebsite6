<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.Tem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>运费模板</h3>
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                 <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>
          <asp:BoundField HeaderText="方式名称" DataField="TemplateName" />
            <asp:TemplateField HeaderText="首重">
                <ItemTemplate>
                <%#Eval("StartWeight")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="起步价">
                <ItemTemplate>
                <%#Eval("StartPrice")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="加重">
                <ItemTemplate>
                <%#Eval("AddWeight")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="加价">
                <ItemTemplate>
                <%#Eval("AddPrice")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                  <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/>          
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>'
                        CommandName="DeleteModel" Text="删除"></XS:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>