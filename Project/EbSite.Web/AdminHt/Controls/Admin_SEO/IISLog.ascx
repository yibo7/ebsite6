<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IISLog.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.IISLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>IIS日志管理</h3>
            请在iis的日志设置里将日志生成指定到本网站的根目录下的iislog/下即可统计日志数据,日志的后缀名必须为.log
            </div>
            <div class="eb-content">
				<XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="日志名称" ItemStyle-Width="150">
                            <ItemTemplate>
                                <%#Eval("LogName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="大小">
                            <ItemTemplate>
                                <%#Eval("Size")%>MB    
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="日期时间">
                            <ItemTemplate>
                                <%#Eval("AddDateTime")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="统计数据">
                            <ItemTemplate>
                                <%#Eval("CountInfo")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:LinkButton ID="lbDown" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="Down" Text="下载"></XS:LinkButton>
                                <XS:LinkButton ID="SetCount" runat="server" CommandArgument='<%#Eval("id") %>' confirm="true" Tips_Msg="如果日志数据大于10m,分析过程可能需要数十秒" CommandName="SetCount" Text="刷新统计数据"></XS:LinkButton>
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Text="删除日志"></XS:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
                
            <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>