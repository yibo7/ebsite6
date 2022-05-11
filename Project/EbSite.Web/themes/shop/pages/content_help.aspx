<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.content" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="header.inc"-->
    <div class="eb-content">
        <div class="container">
            <div class="helptop">
                <li><b>帮助中心</b> > <a href="<%=HostApi.GetContentLink(Model.ID,Model.HtmlName) %>"><%=Model.NewsTitle %></a> </li>
            </div>
            <div class="h_l fleft">
                <div class="hl_top">
                    <li class="fleft w">交易保障</li>
                    <li class="fright"><img src="<%=base.ThemeCss %>images/ico2.png" /></li>
                </div>
                <div class="hl_lst">
                    <ul>
                     <XS:Widget ID="Widget1" WidgetName="帮助中心-交易保障"  WidgetID="7dd3d5f7-36dd-46a6-bfc1-3a399c7ed444" runat="server"/>
                    </ul>
                </div>
                <div class="hl_top">
                    <li class="fleft w">新手上路</li>
                    <li class="fright"><img src="<%=base.ThemeCss %>images/ico2.png" /></li>
                </div>
                <div class="hl_lst">
                    <ul>
                      <XS:Widget ID="Widget2" WidgetName="帮助中心-新手上路"  WidgetID="3f1a98e6-1e4b-4543-9948-e88015b3f809" runat="server"/>
                    </ul>
                </div>
                <div class="hl_top">
                    <li class="fleft w">交易指南</li>
                    <li class="fright"><img src="<%=base.ThemeCss %>images/ico2.png" /></li>
                </div>
                <div class="hl_lst">
                    <ul>
                      <XS:Widget ID="Widget3" WidgetName="帮助中心-交易指南"  WidgetID="8fe43768-3c5d-42dd-8551-4319a74d16f9" runat="server"/>
                    </ul>
                </div>
                <div class="hl_top">
                    <li class="fleft w">支付方式</li>
                    <li class="fright"><img src="<%=base.ThemeCss %>images/ico2.png" /></li>
                </div>
                <div class="hl_lst">
                    <ul>
                       <XS:Widget ID="Widget4" WidgetName="帮助中心-支付方式"  WidgetID="c7bc00cc-c7e1-4e75-83f9-7be66f9ecb4d" runat="server"/>
                    </ul>
                </div>
            </div>
            <div class="h_r fright">
                <div class="hr_top"><li><%=Model.NewsTitle %></li></div>
                <div class="hr_con"><li><%=Model.ContentInfo %></li></div>
            </div>
        </div>
    </div>
    <!--#include file="footer.inc"-->
    <%=KeepUserState()%>
</body>
</html>
