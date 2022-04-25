<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OptionItemList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.OptionItemList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>订单选项管理</h3>
            </div>
            <div class="content">
				 <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" >
		<Columns>
			 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
				 <ItemTemplate>
					 <div style=" text-align:center;">  <%# Container.DataItemIndex + 1%></div> 
				 </ItemTemplate>
			 </asp:TemplateField>
			<asp:TemplateField HeaderText="属性值名称">
				<ItemTemplate>
					<%#Eval("ItemName")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="附加金额">
				<ItemTemplate>
					<%#Eval("AppendMoney")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="用户信息标题">
				<ItemTemplate>
					<%#Eval("UserInputTitle")%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="备注">
				<ItemTemplate>
					<%#Eval("Remark")%>
				</ItemTemplate>
			</asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
				<ItemTemplate>
					<XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</XS:GridView>
    <div>
        <input type="button" value="添加内容" onclick="OpenAddContent()" />
        <input type="button" value=" 完成 " onclick="ClosePage()" />
    </div>
            </div>
    </div>
</div>

<script type="text/javascript">
    function OpenAddContent() {
        OpenDialog_Iframe("<%=OpenUrl %>", "添加可选项内容",600,400, true);
    }
    function ClosePage() {
        //$(window.parent.document.body).find("div[class='panel-tool-close']").click();
        window.location = "?mpid=b05a25ce-d25f-42b8-8dfc-9646cab88142&msid=bd6a405a-b47a-4ded-a983-80ab51c10e79";
    }
</script>