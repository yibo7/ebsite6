<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bbsconfigs.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement.bbsconfigs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
    <div id="PagesMain">
        <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
            <Columns>
                <asp:TemplateField HeaderText="版块名">
                    <ItemTemplate>
                        <%#Eval("ChannelName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="版标">
                    <ItemTemplate>
                        <img src='<%# Eval("ChannelImageUrl")%>' alt="" width="50px" height="50px" onerror="this.src='../DataStore/Attachments/images/noimg.gif';"/>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="排序">
                    <ItemTemplate>
                        <%#Eval("OrderFlag")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="版块描述">
                    <ItemTemplate>
                        <%# Tp(Eval("ChannelDescription").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <XS:EasyuiDialog ID="wbShow" runat="server"  Text="查看" Title="查看" />
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
            </Columns>
        </XS:GridView>
        
    </div>
