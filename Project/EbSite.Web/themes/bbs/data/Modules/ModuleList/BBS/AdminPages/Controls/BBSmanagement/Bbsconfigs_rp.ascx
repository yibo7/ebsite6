<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bbsconfigs_rp.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement.Bbsconfigs_rp" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
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
        <alternatingrowstyle borderwidth="0px" cssclass="AlternatingRow"></alternatingrowstyle>
        <columns>
<asp:TemplateField HeaderText="序号" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <div style="text-align: center;">
                        <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="用户名">
                    <ItemTemplate>
                        <%#Eval("UserName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="回复内容">
                    <ItemTemplate>
                       
                      <a href="#">点击查看</a> <%#GetImgs(Eval("ReplyContent").ToString())%>                                          
                       
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="回复时间">
                    <ItemTemplate>
                        <%#Eval("CreatedTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除">
                    </XS:LinkButton>
                     <XS:LinkButton ID="lbQXSC" runat="server" Text="取消删除" OnClientClick="getId(this)" tId='<%# Eval("id")%>' OnClick="blQXSC_Click"></XS:LinkButton>     
                    </ItemTemplate> 
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                    <ItemTemplate>
                        <asp:CheckBox ID="Selector" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
        <headerstyle cssclass="GridViewHeader"></headerstyle>
    </XS:GridView>
</div>
<div class="pc">
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
<script type="text/javascript">
    $("#PagesMain").find("img").attr("width", "45px;");
    $("#PagesMain").find("img").attr("height", "45px;");
        
</script>
<input id="hId" name="hName" type="hidden" />
<script>
    function getId(obj) {
        document.getElementById("hId").value = obj.tId;
    }
</script>
