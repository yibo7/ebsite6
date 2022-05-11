<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StyleList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.StyleList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h3 class="m-t-0 m-b-20 header-title">您当前编辑的样式来自皮肤<font color="red">[<%=CurrentThemeName %>]</font></h3>
            <XS:ToolBar ID="ucToolBar" runat="server" />
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="样式名称" DataField="Name" />
            <asp:BoundField HeaderText="<%$Resources:lang,EBPath %>" DataField="UrlPath" />
            <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>">
                <ItemTemplate>
                    <a class="AdminLinkButton" href="<%# string.Concat(GetTabUrl,"&t=8&na="+Eval("Name"))%>">编辑样式</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </XS:GridView>
</div>
        </div>
    </div>
</div>

