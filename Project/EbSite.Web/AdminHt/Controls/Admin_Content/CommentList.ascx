<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.CommentList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">

            <XS:Repeater ID="rpRemarkClass" runat="server">
                <ItemTemplate>

                    <li class="nav-item">
                        <a class="<%#GetCurrentClass(Eval("id")) %> nav-link" href="?t=6&remarkclass=<%#Eval("itype") %>&cid=<%#Eval("id") %>">
                            <span class="visible-xs"><i class="fa fa-comment-o"></i></span>
                            <span class="hidden-xs"><%#Eval("ClassName") %></span>
                        </a>
                    </li>
                </ItemTemplate>
            </XS:Repeater>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">

                <XS:ToolBar ID="ucToolBar" runat="server" />
                <div class="table-responsive" id="PagesMain">
                    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                        <Columns>
                            <asp:TemplateField HeaderText="评论" ItemStyle-CssClass="gvfisrtTD">
                                <ItemTemplate>
                                    <%#Eval("Body")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="用户名">
                                <ItemTemplate>
                                    <%#bool.Parse(Eval("IsNiName").ToString()) ? "匿名" : Eval("Username")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="支持" DataField="Support" />
                            <asp:BoundField HeaderText="反对" DataField="Discourage" />
                            <asp:BoundField HeaderText="举报" DataField="Information" />
                            <asp:BoundField HeaderText="IP" DataField="Ip" />
                            <asp:BoundField HeaderText="日期时间" DataField="DateAndTime" />
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>

                                    <a class="AdminLinkButton" href='<%#EbSite.BLL.Remark.PageUrl(Convert.ToInt32( Eval("classid")),Convert.ToInt32( Eval("contentid"))) %>' target="_blank">进入页面</a>
                                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除" />

                                    <XS:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="ShowModel" Text="查看回复" />


                                    <XS:LinkButton ID="LinkButton2" Visible='<%#Eval("IsNoAuditing") %>' runat="server" CommandArgument='<%#Eval("id") %>' CommandName="AuditingModel" Text="通过审核" />

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Selector" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </XS:GridView>
                </div>
                <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
            </div>

        </div>
    </div>
</div>

