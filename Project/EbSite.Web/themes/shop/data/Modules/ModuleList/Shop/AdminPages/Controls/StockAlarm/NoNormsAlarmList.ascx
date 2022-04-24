<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoNormsAlarmList.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.StockAlarm.NoNormsAlarmList" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="PagesMain">
	<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" >
		<Columns>
			 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>
            <asp:TemplateField HeaderText="商品货号">
				<ItemTemplate>
                    	<%#Eval("Annex1")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="商品名称">
				<ItemTemplate>
                    	<%#Eval("NewsTitle")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="类别">
				<ItemTemplate>
                <%#Eval("classname")%>
				</ItemTemplate>
			</asp:TemplateField>
		
			<asp:TemplateField HeaderText="库存">
				<ItemTemplate>
                <%#Eval("Annex12")%>
				</ItemTemplate>
			</asp:TemplateField>
            
            <asp:TemplateField HeaderText="报警数">
				<ItemTemplate>
                <%#Eval("Annex13")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="操作" ItemStyle-Width="130">
				<ItemTemplate>
					<XS:EasyuiDialog ID="wbShow"  Title="商品补货" IsColseReLoad="true" Text="补货" runat="server" />&nbsp;&nbsp;
                    <a href="javascript:void(0);" id='<%#Eval("annex1")%>' onclick="LookRecord(this)">进出库记录</a>
				</ItemTemplate>
			</asp:TemplateField>
			
		</Columns>
	</XS:GridView>
</div>
<div>
	 <XS:PagesContrl ID="pcPage" runat="server" />
</div>
<script type="text/javascript">
    function LookRecord(obj) {
        var pnum = $(obj).attr("id");
        window.location = "StockAlarm.aspx?muid=9de5a73a-2f0a-408c-bff8-0aff8a7b3b30&mid=cfccc599-4585-43ed-ba31-fdb50024714b&pnum=" + pnum;
    }
</script>