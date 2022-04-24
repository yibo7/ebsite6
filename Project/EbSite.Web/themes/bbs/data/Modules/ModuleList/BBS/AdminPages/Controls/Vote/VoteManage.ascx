<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteManage.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.VoteManage" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
        <Columns>
            <asp:TemplateField HeaderText="投票主题">
                <ItemTemplate>
                    <%#Eval("title")%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="选择类型">
                <ItemTemplate>
                    <%#Eval("xuanze")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="当前状态">
                <ItemTemplate>
                    <%#Eval("type")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="公开投票">
                <ItemTemplate>
                    <%#Eval("ifopen")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>           
                    <XS:EasyuiDialog ID="wbModify" runat="server" Href='<%# string.Concat(AddUrl,"&id=",Eval("id"))%>'
                        IsColseReLoad="true"  Text="修改" Title="修改" />
                        <a href='<%# string.Concat("Vote.aspx?t=2&mid="+ModuleID,"&id=",Eval("id"))%>' id='A1' onclick="CaoZuo_Click(this,1)">管理</a>
                        <a href="#" id='<%# Eval("id")%>' onclick="CaoZuo_Click(this,1)">结束</a>
                        <a href="#" id='<%# Eval("id")%>' onclick="CaoZuo_Click(this,2)">公开</a>
                        <a href="#" id='<%# Eval("id")%>' onclick="CaoZuo_Click(this,3)">关闭</a>
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
<input id="hId" name="hName" type="hidden"/>
<input id="numId" name="numName" type="hidden"/>
<XS:Button ID="btn" runat="server" OnClick="btn_Click" style="display:none"/>
<script>
    function CaoZuo_Click(obj, num) {
        document.getElementById("hId").value = obj.id;
        document.getElementById("numId").value = num;
        document.getElementById("<%=btn.ClientID%>").click();
    }
</script>