<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.index" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls" Assembly="EbSite.Modules.Shop" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="header.inc"-->
    <!----中间--->
    <div class="eb-content">
        <div class="container i_one">
            <div class="con1l">
                <XS:Widget ID="Widget3" WidgetName="首页所有商品分类" WidgetID="5e8263fb-3d3c-4b27-b945-43117c9d2211"
                    runat="server" />
            </div>
            <div class="fRight" style="overflow: hidden; width: 789px;">
                <div style="margin-left: -10px;">
                    <XS:Widget ID="Widget1" WidgetName="首页幻灯片" WidgetID="56b0edec-9a1c-473b-84a6-558cde9718c4"
                        runat="server" />
                </div>
                <div id="divindextag" class="indextag">
                    <li name="divindextag1" class="current">限时抢购</li>
                    <li name="divindextag2">推荐产品</li>
                    <li name="divindextag3">最新上架</li>
                    <li name="divindextag4">团购</li>
                    <li name="divindextag5">热卖</li>
                </div>
                <div id="divindextag1" class="pro_lst">
                    <XS:Widget ID="Widget6" WidgetName="首页-抢购" WidgetID="a040f55f-fc66-44e1-9e70-cc6686141dfc"
                        runat="server" />
                </div>
                <div id="divindextag2" class="pro_lst">
                    <XS:Widget ID="Widget4" WidgetName="首页-推荐产品" WidgetID="65d77746-785d-417c-9dfd-fe17c96a7e18"
                        runat="server" />
                </div>
                <div id="divindextag3" class="pro_lst">
                    <XS:Widget ID="Widget5" WidgetName="首页-最新上架产品" WidgetID="2fdbcfb2-982a-46d3-8a55-b44871be0c9f"
                        runat="server" />
                </div>
                <div id="divindextag4" class="pro_lst">
                    <XS:Widget ID="Widget7" WidgetName="首页-团购" WidgetID="6717b06c-4d0c-45a2-b2f7-3d7b476e1e7a"
                        runat="server" />
                </div>
                <div id="divindextag5" class="pro_lst">
                    <XS:Widget ID="Widget8" WidgetName="首页-热卖商品" WidgetID="7a424789-5011-459c-80ed-3171089a165a"
                        runat="server" />
                </div>
            </div>
        </div>
        <div class="container i_two">
            <div class="pp_tit">
                商品专题</div>
            <div class="pp_img">
                <XS:Widget ID="Widget2" WidgetName="首页专题分类" WidgetID="5ede103d-9cec-4e6c-bbf4-3c02ba67d50c"
                    runat="server" />
            </div>
        </div>
        <asp:Repeater ID="rpFloorList" runat="server" EnableViewState="False">
            <ItemTemplate>
                <div class="container i_two">
                    <div class="tit_1" style="background: #<%#Eval("floorcolor")%>">
                        <li class="cur0">
                            <%#Eval("floorid") %>F
                            <%#Eval("floorname") %></li>
                        <asp:Repeater ID="rpFloorBigClass" runat="server">
                            <ItemTemplate>
                                <li class="<%#Equals(Container.ItemIndex,0)?"cur":"" %>"><a href="<%#Eval("BigClassUrl")%>">
                                    <%#Eval("BigClassName")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <li style="width: 12px; float: right;">
                            <div class="ico1 all">
                            </div>
                        </li>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="tab_1">
                        <div class="tab_ll">
                            <asp:Repeater ID="rpFloorLeftAd" runat="server">
                                <ItemTemplate>
                                    <a href="<%#Eval("AdUrl") %>" title="<%#Eval("AdTitle") %>" target="_blank">
                                        <img src="<%#Eval("AdPicUrl") %>" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="tab_cen">
                            <div class="tab_2">
                                <span class="fleft">&nbsp;专用：</span>
                                <asp:Repeater ID="rpFloorSmallClass" runat="server">
                                    <ItemTemplate>
                                        <li><a href="<%#Eval("SmallClassUrl")%>">
                                            <%#Eval("SmallClassName")%></a></li>
                                        <li>
                                            <div class="shuline">
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <asp:Repeater ID="rpFloorProducts" runat="server">
                                <ItemTemplate>
                                    <div class="protab">
                                        <li><a href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()),  GetSiteID) %>">
                                            <img width="160" height="170" src="<%#Eval("SmallPic") %>" /></a><br />
                                            <div style="height: 3em; line-height: 1.5em; overflow: hidden; padding-top: 10px;
                                                padding-bottom: 10px;">
                                                <%#Eval("NewsTitle")%></div>
                                            <span>￥<%#Eval("Annex16")%>&nbsp;</span><font color="#999999" class="cenline">￥<%#Eval("Annex2")%></font></li>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="tab_rr">
                            <div class="tab_4">
                                <asp:Repeater ID="rpFloorRightBrand" runat="server">
                                    <ItemTemplate>
                                        <li><a href="<%#Eval("BrandUrl")%>">
                                              <%#Equals( Eval("BrandPicUrl").ToString(),"")?Eval("BrandTitle"):"<img width=120 height=50 src="+Eval("BrandPicUrl")+" /> " %>  
                                          
                                          </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="lst_1">
                            <asp:Repeater ID="rpFloorRightAd" runat="server">
                                <ItemTemplate>
                                    <li class="red">·<a href="<%#Eval("AdUrl")%>">
                                        <%#Eval("AdTitle")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <script type="text/javascript" src="<%=base.ThemePage %>index.js"></script>
    <!--#include file="footer.inc"-->
    <div style="float:right;position:relative;width:100px;right:50px;top:-239px;">
		<img style="height: 80px;border: 1px solid #ccc;" src="<%=HostApi.MobileBarcode %>" alt="扫一扫访问手机版" />
        <div style="color:#808080;margin-top:3px;">扫扫访问手机版</div>
	</div>
</body>
</html>
