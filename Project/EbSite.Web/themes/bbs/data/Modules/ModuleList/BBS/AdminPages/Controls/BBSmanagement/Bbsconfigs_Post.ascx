<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bbsconfigs_Post.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement.Bbsconfigs_Post" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div>
    <div class="admin_toobar">
        <div style="height: 30px; line-height: 30px;">
            <table cellpadding="0" cellspacing="0" class="CustomTool">
                <tr>
                    <td>
                        <XS:CustomTags ID="ucCurrentTags" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="PagesMain">
        <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            ondatabound="gdList_DataBound">
            <columns>
               <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                   <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="标题">
                    <ItemTemplate>
                        <%#Eval("TopicTitle")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户">
                    <ItemTemplate>
                        <%#Eval("UserName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="板块">
                    <ItemTemplate>
                        <%#Eval("ChannelName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="时间">
                    <ItemTemplate>
                        <%#Eval("CreatedTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IP">
                    <ItemTemplate>
                        <%#Eval("CreatedIP")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <XS:EasyuiDialog ID="wbModify" runat="server"  IsColseReLoad="true"  Text="管理" Title="管理" />       
                        <XS:LinkButton ID="lbQXSC" runat="server" Text="取消删除" OnClientClick="getId(this)" tId='<%# Eval("id")%>' OnClick="blQXSC_Click"></XS:LinkButton>
                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                    <ItemTemplate>
                        <asp:CheckBox ID="Selector" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
        </XS:GridView>
        <XS:PagesContrl ID="pcPage" runat="server" />
    </div>
</div>
<input id="hId" name="hName" type="hidden" />
<script>
    function getId(obj) {
        document.getElementById("hId").value = obj.tId;
    }
</script>
