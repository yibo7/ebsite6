<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Online.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.Online" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar"  runat="server"></XS:ToolBar>

<div class="alert alert-success">模块数据来自<a href='http://www.ebsite.net' target=_blank><b>官方共享平台</b></a>，由网友发布，版权归原作者所有，同时安装使用模块带来的影响与官方无关！"  </div>
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="Title">
        <columns>
            <asp:TemplateField HeaderText="模块名称" ItemStyle-CssClass="gvfisrtTD">
                <ItemTemplate>
                    <%#Eval("Title")%> 
                </ItemTemplate>
            </asp:TemplateField>
           <asp:BoundField DataField="Version" HeaderText="版本" ></asp:BoundField>     
           <asp:TemplateField HeaderText="开发单位" >
                <ItemTemplate>
                    <a target="_blank" href="<%#Eval("AuthorUrl")%>"><%#Eval("Author")%></a>
                </ItemTemplate>
           </asp:TemplateField>
           <asp:BoundField DataField="FMoney" HeaderText="收费" ></asp:BoundField>
            <asp:TemplateField HeaderText="简介" >
                <ItemTemplate>
                    <a target="_blank" href="http://update.ebsite.cn/md-1/?id=<%#Eval("id")%>">查看简介</a>
                </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="演示">
                <ItemTemplate>
                    <a target="_blank" href="http://update.ebsite.cn/md-2/?id=<%#Eval("id")%>">查看演示</a>
                </ItemTemplate>
           </asp:TemplateField>
            <asp:TemplateField HeaderText="下载安装" >
                <ItemTemplate>
                <XS:LinkButton ID="lbDownsetup" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="downsetup"
                        confirm="true" Text="下载并安装"></XS:LinkButton>
                </ItemTemplate>
           </asp:TemplateField>         
        </columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server">
    </XS:PagesContrl>
</div>