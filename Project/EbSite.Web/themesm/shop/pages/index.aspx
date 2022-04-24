<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.index" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server">
</head>
<body>
    <!--#include file="header.inc" -->
    <div id="slider">
       <XS:Widget ID="Widget1" WidgetName="�ֻ�����ҳͼƬ�л�"  WidgetID="450291f5-eabd-41cc-9c4b-45487e58da55" runat="server"/>

    </div>
    <div style="margin-top: 5px;" class="content">
        <div class="w-home-search">
            <form action="<%=EbSite.Base.Host.Instance.MSearchRw %>" method="get">
            <input type="submit" value=" �� �� " alog-alias="search">
            <div class="input">
                <div class="ui-input-mask" style="height: 45px;">
                    <input name="k" type="text" autocomplete="off" autocorrect="off" maxlength="100"
                        placeholder="��������Ʒ���ơ�" style="position: absolute; top: 0px; left: 0px; width: auto;
                        right: 40px;">
                    <input type="hidden" name="site" value="<%=GetSiteID %>" />
                    <div class="ui-quickdelete-button" style="height: 20px; width: 20px; top: 13px; right: 10px;">
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
    <div class="indexmenus">
        <ul>
            <li><a href="<%=HostApi.MGetClassHref() %>">
                <img src="<%=MThemeCss %>indexmumus1.jpg" /></a>
                <br />
                <span>��Ʒ��Ŀ</span> </li>
            <li><a href="/md/wodejiaoyijilum.ashx">
                <img src="<%=MThemeCss %>indexmumus2.jpg" /></a>
                <br />
                <span>�ҵĶ���</span> </li>
            <li><a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MShoppingCarUrl(GetSiteID,0) %>">
                <img src="<%=MThemeCss %>indexmumus3.jpg" /></a>
                <br />
                <span>���ﳵ</span> </li>
            <li><a href="<%=HostApi.MUccIndexRw %>">
                <img src="<%=MThemeCss %>indexmumus4.jpg" /></a>
                <br />
                <span>��������</span> </li>
            <li><a href="/md/shoucanggam.ashx">
                <img src="<%=MThemeCss %>indexmumus5.jpg" /></a>
                <br />
                <span>�ҵ��ղ�</span> </li>
            <li><a href="<%=HostApi.MGetSpecialHref() %>">
                <img src="<%=MThemeCss %>indexmumus6.jpg" /></a>
                <br />
                <span>��Ʒר��</span> </li>
        </ul>
    </div>
    <div class="indexmenus2">
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MRushList(GetSiteID)%>">
        <div style="background: #FB7251" class="radiusbox">
            <div class="title">
                ��ʱ����</div>
            <div class="demo">
                ���������У��Ͽ����</div>
        </div>
        </a>
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MGroupList(GetSiteID)%>">
        <div style="background: #7ED2EB" class="radiusbox">
            <div class="title">
                �Ź��</div>
            <div class="demo">
                һ�����������˶������</div>
        </div>
        </a>
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MActFullQuantity(GetSiteID,0)%>">
        <div style="background: #86C400" class="radiusbox">
            <div class="title">
                �����</div>
            <div class="demo">
                �Żݶ�࣬����ȥ</div>
        </div>
        </a>
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MJiFen(GetSiteID)%>">
        <div style="background: #FF9A32" class="radiusbox">
            <div class="title">
                �����̳�</div>
            <div class="demo">
                �л��־Ϳ��Զһ���Ʒ</div>
        </div></a>
    </div>
    <div style="clear: both;">
    </div>
    <asp:Repeater ID="rpMFloorList" runat="server" EnableViewState="False">
        <ItemTemplate>
            <!-- ¥��2 -->
            <div class="floor ">
                <ul>
                    <li class="bigA">
                        <a class="cate-title-position" style="background: #<%# Eval("FloorColor")%>; color: #fff" href="<%# Eval("FloorUrl") %>"><span class="cate-title"><%# Eval("FloorName") %></span></a> 
                        <a class="with-info" href="<%# Eval("AdPicUrl") %>"><img src="<%# Eval("AdUrl") %>"><span class="info"><%# Eval("AdName") %></span></a>
                    </li>
                    <asp:Repeater ID="rpMBigClass" runat="server">
                        <HeaderTemplate>
                            <li class="mid">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a href="<%# Eval("BigClassUrl") %>"><%# Eval("BigClassName") %></a>
                        </ItemTemplate>
                        <FooterTemplate>
                            </li>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="rpMSmallClass" runat="server">
                        <HeaderTemplate>
                            <li class="small">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a href="<%# Eval("SmallClassUrl") %>"><%# Eval("SmallClassName") %></a>
                        </ItemTemplate>
                        <FooterTemplate>
                            </li>
                        </FooterTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <!--#include file="foot.inc" -->
    <script>
        In.ready('gmue-parseTpl', 'gmuw-slider', 'gmuw-arrow', 'gmuw-dots', 'gmuw-touch', 'gmuw-autoplay', 'gmuw-lazyloadimg', function () {
            $('#slider').slider({ imgZoom: true });
        });
    </script>
</body>
</html>
