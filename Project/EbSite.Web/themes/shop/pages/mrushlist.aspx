<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mrushlist" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>

<body>
<!--#include file="headernav.inc" -->
    <div style="clear: both;">
        <div class="content">
            <div class="container">
                <div class="tuanprice w990">
                    <div class="tpl">
                        <ul>
                            <li>价格: &nbsp;</li>
                            <li>
                               <dt class="w40"><a href="<%=ShopLinkApi.RushList(3)%>" class="crr">全部</a></dt>
                                <dt><a href="<%=ShopLinkApi.RushList(GetSiteID,1,1)%>">0-100元</a></dt>
                            <dt><a href="<%=ShopLinkApi.RushList(GetSiteID,2,1)%>">100-200元</a></dt>
                            <dt><a href="<%=ShopLinkApi.RushList(GetSiteID,3,1)%>">200-500元</a></dt>
                            <dt><a href="<%=ShopLinkApi.RushList(GetSiteID,4,1)%>">500-1000元</a></dt>
                            <dt><a href="<%=ShopLinkApi.RushList(GetSiteID,5,1)%>">1000元以上</a></dt>
                            </li>
                        </ul>
                    </div>
                    
                </div>
                <div class="yhtuanlst">
                    <asp:Repeater ID="rpList" runat="server">
                        <ItemTemplate>
                          

                            <div class="tuaninfo h399">
                                <div class="tuantab1">
                                    <li>
                                        <a href="<%#ShopLinkApi.RushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>">
                                            <img src="<%# Eval("smallimg") %>" width="290" height="290" />
                                        </a>
                                    </li>
                                    <li style="height:3em;line-height:1.5em;overflow:hidden;">
                                        <a href="<%#ShopLinkApi.RushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>">
                                            <%#Eval("Title")%>
                                        </a>
                                    </li>
                                </div>
                                <div class="tuantab4">
                                    <li class="fleft"><font color="#FF6633" size="+3"><b>&yen;<%# Eval("CountDownPrice") %></b></font><br />
                                        &nbsp;&nbsp;原价：<span>&yen;<%# Eval("Price") %></span> | 折扣：<%# GetDiscountRate(Eval("Price"),Eval("CountDownPrice")) %></li>
                                    <li class="fRight">
                                        <div class="gobuy all "><a  href="<%#ShopLinkApi.RushShow(GetSiteID, Eval("id"), Eval("ProductId"))%>"><img style="width: 100px; height: 30px;" src="/images/bglink.gif"/></a></div>
                                    </li>
                                </div>
                                <div class="tuantab3 h35">
                                    <li><%# EbSite.Modules.Shop.ModuleCore.Pages.mgrouplist.GetEndDays(Eval("enddate"),"抢购")%></li>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>



                   

                </div>
                
                <div class="page"><XS:PagesContrl ID="pgCtr"   runat="server" /></div>
                 
            </div>
        </div>
        <!--#include file="footer.inc" -->
    </div>
    <script type="text/javascript" src="<% =ThemePage%>mgrouplist.js"></script>
    <script type="text/javascript">
        In.ready('times', function () {

            $(".subdiv-l div").each(function (index, element) {
                var id = $(this).attr("vid");
                var enddate = $(this).attr("enddate");

                var obShowTarget = {
                    sec: document.getElementById("sec" + id),
                    mini: document.getElementById("mini" + id),
                    hour: document.getElementById("hour" + id),
                    day: document.getElementById("day" + id)
                }

                fnTimeCountDown(enddate, obShowTarget, null);
            });



        });
    </script>

</body>
</html>
