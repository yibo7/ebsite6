<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderOptionList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.OrderOptionList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理订单选项</h3>
            </div>
            <div class="content">
				
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" >
		            <Columns>
			             <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				             <ItemTemplate>
					             <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				             </ItemTemplate>
			             </asp:TemplateField>
			            <asp:TemplateField HeaderText="选项名称">
				            <ItemTemplate>
					            <%#Eval("OptionName")%>
				            </ItemTemplate>
			            </asp:TemplateField>
			            <asp:TemplateField HeaderText="选择方式">
				            <ItemTemplate>
					            <%#Eval("SelectMode").ToString().Equals("0")?"下拉列表":"单选按钮" %>
				            </ItemTemplate>
			            </asp:TemplateField>
			            <asp:TemplateField HeaderText="备注">
				            <ItemTemplate>
					            <%#Eval("Description")%>
				            </ItemTemplate>
			            </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
				            <ItemTemplate>
                                <a class="AdminLinkButton" href="<%=GetUrl %>&t=58&id=<%#Eval("ID") %>">编辑选项列表</a>
                                <XS:EasyuiDialog ID="wbModify" Title="修改" Text="修改" runat="server"/>&nbsp;&nbsp;
					            <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
				            </ItemTemplate>
			            </asp:TemplateField>
		
		            </Columns>
	            </XS:GridView>                
	 <XS:PagesContrl ID="pcPage" runat="server" />
            </div>
    </div>
</div>