<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DModel.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.DModel" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>运费模板管理</h3>
            </div>
            <div class="eb-content">
                
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
				  <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>
          <asp:BoundField HeaderText="方式名称" DataField="ModeName" />
            <asp:TemplateField HeaderText="运送模板">
                <ItemTemplate>
                <%#EbSite.BLL.PsFreight.Instance.GetEntity(Convert.ToInt32(Eval("ShippingTemplatesId"))).TemplateName%>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="首重">
                <ItemTemplate>
                <%#EbSite.BLL.PsFreight.Instance.GetEntity(Convert.ToInt32(Eval("ShippingTemplatesId"))).StartWeight%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="缺省价">
                <ItemTemplate>
                <%#EbSite.BLL.PsFreight.Instance.GetEntity(Convert.ToInt32(Eval("ShippingTemplatesId"))).StartPrice%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="加重">
                <ItemTemplate>
                <%#EbSite.BLL.PsFreight.Instance.GetEntity(Convert.ToInt32(Eval("ShippingTemplatesId"))).AddWeight%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="加价">
                <ItemTemplate>
                <%#EbSite.BLL.PsFreight.Instance.GetEntity(Convert.ToInt32(Eval("ShippingTemplatesId"))).AddPrice%>
                </ItemTemplate>
            </asp:TemplateField>
            			 <asp:TemplateField HeaderText="是否支持货到付款">
                <ItemTemplate>
                <%#Eval("IsCod")%> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                  <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/>          
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>'
                        CommandName="DeleteModel" Text="删除"></XS:LinkButton>
<%--                         <XS:EasyuiDialog ID="EasyuiDialog1"  Href='<%# string.Concat(GetUrl,"&t=4&id=",Eval("id"))%>'  Visible=<%#Convert.ToBoolean(Eval("IsCod").ToString())%>  Title="配置到付地区" Text="到付地区" runat="server"/>     
--%>                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
<XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>