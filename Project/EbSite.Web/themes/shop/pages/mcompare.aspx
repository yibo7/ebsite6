<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mcompare" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <div id="centerbox">
        <!--#include file="header.inc" -->
    </div>
    <div style="clear: both;">
        <div class="content">
            <div class="container">
                <!--开始-->
                <div class="w" id="pcomprare">
                    <ul class="tab">
                        <li class="curr">基本信息对比</li>
                    </ul>
                    <div class="tabcon">
                        <table class="tb-1">
                            <tbody>
                                <tr style="background-color: rgb(255, 255, 255);">
                                    <th>
                                        商品图片
                                    </th>
                                    <td>
                                        <%if (Model1.ID > 0){
                                        %>
                                        <a href="<%= EbSite.Base.Host.Instance.GetContentLink(Model1.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                            rel="nofollow">
                                            <img src="<%= Model1.SmallPic %>"></a><div>
                                                <a href="<%= EbSite.Base.Host.Instance.GetContentLink(Model1.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                                    rel="nofollow">
                                                    <%= Model1.NewsTitle %></a></div>
                                        <% } %>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <%if (Model2.ID > 0)
                                           {
                                        %>
                                        <a href="<%=EbSite.Base.Host.Instance.GetContentLink(Model2.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                            rel="nofollow">
                                            <img src="<%=Model2.SmallPic %>"></a><div>
                                                <a href="<%=EbSite.Base.Host.Instance.GetContentLink(Model2.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                                    rel="nofollow">
                                                    <%=Model2.NewsTitle %></a></div>
                                        <% } %>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <%if (Model3.ID > 0)
                                           {
                                        %>
                                        <a href="<%=EbSite.Base.Host.Instance.GetContentLink(Model3.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                            rel="nofollow">
                                            <img src="<%=Model3.SmallPic %>"></a><div>
                                                <a href="<%=EbSite.Base.Host.Instance.GetContentLink(Model3.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                                    rel="nofollow">
                                                    <%=Model3.NewsTitle %></a></div>
                                        <% } %>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <%if (Model4.ID > 0)
                                           {
                                        %>
                                        <a href="<%= EbSite.Base.Host.Instance.GetContentLink(Model4.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                            rel="nofollow">
                                            <img src="<%= Model4.SmallPic %>"></a><div>
                                                <a href="<%= EbSite.Base.Host.Instance.GetContentLink(Model4.ID, EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID) %>"
                                                    rel="nofollow">
                                                    <%= Model4.NewsTitle %></a></div>
                                        <% } %>
                                    </td>
                                </tr>
                                <tr class="p-price1">
                                    <th>
                                        价格
                                    </th>
                                    <td>
                                        <strong>
                                            <% if (Model1.ID > 0)
                                                {
                                            %>
                                            ￥<%= Model1.Annex16 %>
                                            <% } %>
                                        </strong>
                                    </td>
                                    <td>
                                        <strong>
                                            <% if (Model2.ID > 0)
                                                {
                                            %>
                                            ￥<%= Model2.Annex16 %>
                                            <% } %>
                                        </strong>
                                    </td>
                                    <td>
                                        <strong>
                                            <% if (Model3.ID > 0)
                                                {
                                            %>
                                            ￥<%= Model3.Annex16 %>
                                            <% } %>
                                        </strong>
                                    </td>
                                    <td>
                                        <strong>
                                            <% if (Model4.ID > 0)
                                                {
                                            %>
                                            ￥<%= Model4.Annex16 %>
                                            <% } %>
                                        </strong>
                                    </td>
                                </tr>
                                <tr class="brand">
                                    <th>
                                        所属品牌
                                    </th>
                                    <td>
                                        <% if (Model1.ID > 0)
                                            {
                                        %>
                                        <%=Model1.Annex11>0 ? string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model1.Annex11)) :"" %>
                                        <% } %>
                                    </td>
                                    <td>
                                        <% if (Model2.ID > 0)
                                            {
                                        %>
                                        <%=Model2.Annex11>0 ? string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model2.Annex11)) :"" %>
                                        <% } %>
                                    </td>
                                    <td>
                                        <% if (Model3.ID > 0)
                                            {
                                        %>
                                        <%=Model3.Annex11>0 ? string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model3.Annex11)) :"" %>
                                        <% } %>
                                    </td>
                                    <td>
                                        <% if (Model4.ID > 0)
                                            {
                                        %>
                                        <%=Model4.Annex11>0 ? string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model4.Annex11)) :"" %>
                                        <% } %>
                                    </td>
                                </tr>
                                <asp:Repeater ID="rpListAttribute" runat="server" EnableViewState="False">
                                    <ItemTemplate>
                                        <tr>
                                            <th>
                                                <%#Eval("AttributeName") %>
                                            </th>
                                            <td>
                                                <%#Eval("AttributeValue1") %>
                                            </td>
                                            <td>
                                                <%#Eval("AttributeValue2") %>
                                            </td>
                                            <td>
                                                <%#Eval("AttributeValue3") %>
                                            </td>
                                            <td>
                                                <%#Eval("AttributeValue4") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <!--结束-->
            </div>
        </div>
        <!--#include file="footer.inc" -->
    </div>
</body>
</html>
