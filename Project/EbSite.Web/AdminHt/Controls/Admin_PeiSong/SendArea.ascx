<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendArea.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.SendArea" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>配送区域管理</h3>
            </div>
            <div class="eb-content">
				            
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar> 
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>
          <asp:BoundField HeaderText="区域名称" DataField="AreaName" />          
            <asp:TemplateField HeaderText="区域下属城市">
                <ItemTemplate>
                    <%#Eval("CityNames")%>
                </ItemTemplate>
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                  <XS:EasyuiDialog ID="wbModify" IsFull="true"   Title="修改数据" Text="修改" runat="server"/>          
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Text="删除"></XS:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>

            </div>
    </div>
</div>