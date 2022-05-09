<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" EnableEventValidation="false" Inherits="EbSite.Web.AdminHt.main" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=SiteName%>--后台管理</title>

</head>
<body>
    <form id="Form2" runat="server">

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

                                        <XS:Repeater ID="rpTopMenus" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <span id="<%#Eval("ID") %>" rui="<%#Eval("PageUrl") %>">
                                                    <%#Eval("MenuNameResource")%>
                                                </span>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </XS:Repeater>
                                    </div>

                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>


            <tr id="top_002">
                <td style="text-align: center;">

                    <div>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="top_sub_menu">
                            <tr>
                                <td class="returnIndex">
                                    <img src="themes/ext.png" align="absMiddle" />&nbsp;
                            <asp:LinkButton ID="lbLogout" OnClientClick="return confirm('是否确定要注销？')" runat="server" OnClick="lbLogout_Click"><%=Resources.lang.EBExit%></asp:LinkButton>
                                </td>
                                <td class="exitSystem">
                                    <img src="/images/menus/home.png" align="absMiddle" />&nbsp;
                            <a target="rform" href="Admin_WelCome.aspx"><%=Resources.lang.ManageIndex%></a>
                                    <span class="top_splitline"></span>
                                </td>
                                <td>
                                    <div id="SubMenu">
                                        <div style="padding: 10px; float: left;">

                                            <%=Resources.lang.EBTheCurrentAdministrator%>:<%=EbSite.Base.AppStartInit.UserName%>
                                            (<font color="red"><asp:Literal ID="llRoles" runat="server"></asp:Literal></font>)
                                          <a href="javascript:ChangePass()"><%=Resources.lang.EBModifyPassword%></a>

                                        </div>

                                    </div>
                                </td>
                                <td>当前站点:                            
                            <asp:Literal ID="CurrentSiteName" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <div style="float: right;" runat="server" id="logoRight">
                                        <span>切换站点: </span>
                                        <asp:DropDownList ID="drpSites" runat="server" AutoPostBack="true" OnTextChanged="MoneyOptionChanged">
                                        </asp:DropDownList>
                                        <span style="cursor: pointer;" onclick="SetSites()">[站点管理]</span>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>

            <tr>
                <td style="width: 100%; height: 100%;">
                    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td id="leftList" width="183" height="100%" valign="top">
                                <div id="LeftMenuList">
                                </div>
                            </td>
                            <td class="resizeBar" onclick="OpenLeftMenu();">
                                <img id="sp_img" src="themes/splitbar.gif" width="8" />
                            </td>
                            <td style="height: 100%; vertical-align: top;">
                                <iframe name="rform" id="RightForm" src="Admin_WelCome.aspx" frameborder="0" width="100%" height="100%" scrolling="yes" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>


        </table>

    </form>
</body>
</html>
