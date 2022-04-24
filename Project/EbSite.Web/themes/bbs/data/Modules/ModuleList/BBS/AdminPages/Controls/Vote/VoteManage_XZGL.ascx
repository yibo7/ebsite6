<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteManage_XZGL.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.VoteManage_XZGL" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    <fieldset>
        <legend>常规操作 </legend>
        <div style="height: 30px; line-height: 30px;">
            <table cellpadding="0" cellspacing="0" class="CustomTool">
                <tr>
                    <td>
                        <XS:CustomTags ID="CustomTags1" runat="server" />
                    </td>
                    <td>
                        <XS:EasyuiDialog ID="wbAdd" runat="server" Text="添加" Title="添加" />
                    </td>
                    <td>
                        <XS:LinkButton ID="lbDeleteMore" runat="server" confirm="true" IsButton="true" Text=" 批量删除 "></XS:LinkButton>
                    </td>
                    <td>
                        <XS:LinkButton ID="lbOutPutExcel" runat="server" IsButton="true" Text=" 导出Excel"></XS:LinkButton>
                    </td>
                    <td>
                        <XS:LinkButton ID="lbOutPutWord" runat="server" IsButton="true" Text=" 导出Word"></XS:LinkButton>
                    </td>
                    <td>
                      <%--  <XS:PrintButton ID="pbPrint" runat="server" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</div>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
        <Columns>
            <asp:TemplateField HeaderText="选项">
                <ItemTemplate>
                    <%#Eval("title")%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属主题">
                <ItemTemplate>
                    <%#Eval("bigtitle")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="票数">
                <ItemTemplate>
                    <%#Eval("piaoshu")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <XS:EasyuiDialog ID="wbShow" runat="server" Text="查看" Title="查看" />
                    <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />
                    
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
