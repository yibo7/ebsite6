<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_module.aspx.cs" EnableEventValidation="false" Inherits="EbSite.Web.AdminHt.main_module" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=ModulsName %>-模块</title>

</head>
<body>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; position: absolute">
        <tr id="top_001">
            <td style="width: 100%; height: 49px;">
                <table style="width: 100%; height: 50px;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div id="top_logo">
                                <div id="logo">
                                </div>
                                <div id="line">
                                    <span class="current">
                                        <%=ModulsName %>
                                    </span>
                                </div>

                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 100%;">
                <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td id="leftList" width="183" height="100%" valign="top">
                            <table id="tdMenuList" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr onclick="OnMenuTitle(this)" isop="1">
                                        <td class="treeview_unfocus">模块功能
                                        </td>
                                    </tr>
                                    <tr style="">
                                        <td>
                                            <div class="BasicinfoShow">
                                                <ul>
                                                    <XS:Repeater ID="rpMenus" runat="server">
                                                        <ItemTemplate>
                                                            <li>
                                                                <a target="rform" href="<%#Eval("Url")%>"><%#Eval("PageName")%> </a>
                                                            </li>
                                                        </ItemTemplate>
                                                    </XS:Repeater>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr onclick="OnMenuTitle(this)" isop="1">
                                        <td class="treeview_unfocus">基础配置
                                        </td>
                                    </tr>
                                    <tr style="">
                                        <td>
                                            <div class="BasicinfoShow">
                                                <ul>
                                                    <li>
                                                        <a target="rform" href="<%=AdminPath %>Admin_Modules.aspx?t=2&mid=<%=sModelID %>">模块设置</a>
                                                    </li>
                                                    <li>
                                                        <a target="rform" href="<%=AdminPath %>Admin_Modules.aspx?t=1&mid=<%=sModelID %>">菜单设置</a>
                                                    </li>
                                                    <li>
                                                        <a target="rform" href="<%=AdminPath %>Admin_Modules.aspx?t=20&mid=<%=sModelID %>">权限管理</a>
                                                    </li>
                                                    <%-- <li>
                                                    <a href="<%=AdminPath %>Admin_Modules.aspx?t=18&mid=<%=sModelID %>">模块升级</a>
                                                </li>--%>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td class="resizeBar" onclick="OpenLeftMenu();">
                            <img id="sp_img" src="themes/splitbar.gif" width="8" />
                        </td>
                        <td style="height: 100%; vertical-align: top;">
                            <div class="container-fluid main-title">
                                开发者:<a href="<%=ProducerUrl %>" target="_blank"><%=Producer %></a> ┊  版本:<% =Version%> 
                                                 
                            </div>
                            <iframe name="rform" id="RightForm" src="Admin_Modules.aspx?t=2&mid=<%=sModelID %>" frameborder="0" width="100%" height="100%" scrolling="yes" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</body>
</html>
