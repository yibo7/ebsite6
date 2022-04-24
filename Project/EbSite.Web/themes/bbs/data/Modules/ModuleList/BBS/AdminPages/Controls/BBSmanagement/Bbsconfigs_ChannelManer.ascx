<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bbsconfigs_ChannelManer.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement.Bbsconfigs_ChannelManer" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
        <columns>
            
 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                   <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>


                <asp:TemplateField HeaderText="版主名">
                    <ItemTemplate>
                       <%# Eval("UserName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="版块">
                    <ItemTemplate>
                       <%# Eval("ChannelName")%>
                    </ItemTemplate>
                </asp:TemplateField>              
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <XS:EasyuiDialog ID="wbModify" runat="server"  IsColseReLoad="true"  Text="修改" Title="修改" />
                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>'
                            CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                    <ItemTemplate>
                        <asp:CheckBox ID="Selector" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
    </XS:GridView>
</div>
<div class="pc">
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
