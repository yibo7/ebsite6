<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mcontent_product" %>

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
    <!----中间--->
    <!----中间--->
    <div class="content">
        <div class="container">
            <div class="contop">
                <li><a href="<%=DomainName%>">
                    <%=SiteName%></a> ><%=GetNav(">")%></div>
            <!--第一部分左-->
            <div class="conleft">
                <div class="proimg">
                    <a id="ebproductbigimgzoom" title="图片细节" href="<%=FirstModel.BigImg %>">
                        <img id="Img1" src="<%=FirstModel.BigImg %>" />
                    </a>
                </div>
                <div class="smallpic">
                    <li class="ll">
                        <div class="leftpic all2">
                        </div>
                    </li>
                    <asp:Repeater ID="rpPicList" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <li>
                                <img width="47" height="47" src=" <%# Eval("SmallImg")%>" bigimg="<%# Eval("BigImg")%>" /></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li class="rr">
                        <div class="rightpic all2">
                        </div>
                    </li>
                </div>
                <div class="l_three">
                    <div class="fdbg all">
                        <li><a target="_blank" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.PhotoBoxUrl(GetSiteID,Model.ID) %>">
                            查看大图</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" style="_margin-left: 15px;">加入对比</a></li>
                    </div>
                    <div class="fleft savelink">
                        <li>
                            <div class="star all">
                            </div>
                        </li>
                        <li><a onclick="FavContent(<%=Model.ID%>)">收藏此商品</a></li></div>
                </div>
                <div class="mbtok">
                    <div class="tab4">
                        <script type="text/javascript" src="<% =ThemePage%>baidushare.js"></script>
                       
                    </div>
                </div>
            </div>
           
            <!--第一部分右-->
            <div class="conright">
                <div class="mrtitle">
                    <%=Model.NewsTitle %></div>
                <div class="gh_cx">
                    <li>适用车型：奥迪100 3.0排量 自动挡车 <a href="#">[更换车型]</a></li></div>
                <div class="mrinfo">
                    <li><span>商品货号：</span>
                        <dd>
                            <font color="#999999">
                                <%=Model.Annex1%></font>
                        </dd>
                    </li>
                    <li><span>价格：</span>
                        <dd class="cur">
                            ￥<font color="#CC0000" size="5"><b><%=Model.Annex16%></b></font>(<a target="_blank"
                                href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.ReducePriceUrl(GetSiteID,Model.ID) %>">降价通知</a>）
                                (<a target="_blank" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.GetGroupUrl(GetSiteID,Model.ID) %>">求团购</a>)</dd>
                    </li>
                    <li><span>配送：</span>
                        <dd>
                            <font color="#816957">北京</font> 至 <font color="#816957">上海</font>
                            <img src="<%=base.ThemeCss %>images/ico1.png" style="border: none; margin-top: -3px;" />
                            快递：10.00 EMS：20.00</dd></li>
                    <li>
                        <asp:Repeater ID="rpCuXiaoList" runat="server" EnableViewState="False">
                            <HeaderTemplate>
                                <li style="height: 100%; width: 100%;">
                                    <div style="float: left;">
                                        促销信息：</div>
                                    <div style="float: left;">
                                        <div style="width: 100%;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div style="width: 100%;">
                                    <a href='<%#Eval("Url") %>'>
                                        <%#Eval("Title")%></a>[适用于：<%#Eval("SuitUser")%>]</div>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div></div></li>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                    <li style="clear:both;"><span>商品品牌：</span>
                        <dd style=" ">
                            <font color="#999999">
                                <%=string.IsNullOrEmpty(Model.Annex7) ? "" : string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model.Annex7))%>
                             </font>
                        </dd>
                    </li>
                    <asp:Repeater ID="rpZengPinList" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <li style="height: 100%;">
                                <div style="float: left;">
                                    赠&nbsp;&nbsp;&nbsp;&nbsp;品：</div>
                                <div style="float: left;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <a href='<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Product(3,Eval("GiftProductId"))%>'>
                                    <img src='<%#SmallPic(Eval("GiftProductId").ToString()) %>' width='20' height='20' />
                                    <%#GetName(Eval("GiftProductId").ToString())%>
                                    ×<%#Eval("Quantity")%></a></div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div> </li>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="moreinfo">
                    <div class="minfo1 minfo2">
                        <asp:Repeater ID="rpGGList" runat="server" EnableViewState="False" OnItemDataBound="rpList_ItemDataBound">
                            <ItemTemplate>
                                <li id="PNorm<%#Eval("ID")%>" dataid="<%#Eval("ID")%>">
                                    <input id="PNormValue<%#Eval("ID")%>" type="hidden" />
                                    <dl class="bnone">
                                        <%#Eval("Text")%>：</dl>
                                    <asp:Repeater ID="rpSubList" runat="server">
                                        <ItemTemplate>
                                            <dl>
                                                <input type="button" pid="<%#Eval("Value")%>" id="SNorm<%#Eval("ID")%>" valueid="<%#Eval("ID")%>"
                                                    value="<%#Eval("Text")%>" /></dl>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                <li>请选择规格</li>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <input id="hpAllNormkey" value="<%=sAllNormkey %>" type="hidden" />
                    <%--<div class="minfo1">
                        <li>
                            <dl class="bnone">
                                <span>选择颜色：</span></dl>
                            <dl class="cur all">
                                <img src="<%=base.ThemeCss %>images/pro8.gif" /></dl>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro8.gif" /></dl>
                        </li>
                    </div>
                    <div class="minfo1 minfo2">
                        <li>
                            <dl class="bnone">
                                <span>选择尺码：</span></dl>
                            <dl>
                                4L装
                            </dl>
                            <dl class="cur2 all">
                                1L装
                            </dl>
                        </li>
                        <li><span>已经选择</span>“<b>黄壳</b>”,“<b>1L装</b>” </li>
                    </div>--%>
                    <asp:Repeater ID="rpListFeeOption" OnItemDataBound="rpListFeeOption_ItemDataBound"
                        runat="server">
                        <ItemTemplate>
                            <div class=" bgnone">
                               <div class="tab1">
                                   <li> <%#Eval("OptionName")%>：</li></div>
                                <div class="tab2">
                                    <asp:Repeater ID="rpSubList" runat="server">
                                        <ItemTemplate>
                                            <li class="cur">
                                                <%#Eval("ItemName")%>
                                           </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<div class=" bgnone">
                        <div class="tab1">
                            <li>延期保修:</li></div>
                        <div class="tab2">
                            <li class="cur">1年￥456</li><li>2年￥816</li></div>
                    </div>--%>
                    <div class="tab3">
                        <li>数量&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                        <li>
                            <input type="text" value="1" id="num" class="iptdata all" /></li>
                        <li>&nbsp;库存542件&nbsp;&nbsp; 商品总价格：<span><%=Model.Annex16%></span></li>
                        <li>
                            <div class="btnbuy all">
                            </div>
                            <span onclick="addtoshoppingcar('<%=EbSite.Modules.Shop.ModuleCore.GetLinks.ShoppingCarUrl(GetSiteID,Model.ID) %>')">
                                 <div class="btngwc all">
                            </div> </span>
                           
                        </li>
                    </div>
                </div>
            </div>
            <!--第一部分右-->
            <div class="clear">
            </div>
            <!--第二部分开始-->

        
            <div class="container conproinfo">
                <div class="contabs packagetit">
                  <li ><a  class="cur" name="tg11"> 推荐配件</a></li>
                  <li><a name="tg12"> 人气组合</a></li>           
                </div>
                <div  id="tg11" class="packagepro">
                    <div class="pkprolst">
                        <li class="cur">全部配件</li>
                        <li><a href="#">机油滤</a></li>
                        <li><a href="#">空气滤</a></li>
                        <li><a href="#">机油</a></li>
                        <li><a href="#">火花塞</a></li>
                        <li><a href="#">机油滤</a></li>
                        <li><a href="#">空气滤</a></li>
                        <li><a href="#">机油</a></li>
                        <li><a href="#">火花塞</a></li>
                    </div>
                    <div class="pkpro">
                        <div class="master">
                            <li>
                                <dl>
                                    <img src="<%=base.ThemeCss %>images/pro3.gif" /></dl>
                                <dl>
                                    壳牌 helix plus非凡蓝喜力合成机油
                                </dl>
                            </li>
                            <li>
                                <dl class="jiahao all2">
                                </dl>
                            </li>
                        </div>
                        <div class="suits">
                            <ul style="width: 1320px;">
                                <li>
                                    <dl>
                                        <img src="<%=base.ThemeCss %>images/pro3.gif" />
                                    </dl>
                                    <dl>
                                        佳能ir600佳能佳能佳能佳能佳能佳能</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>￥65.00</span></dl>
                                </li>
                                <li>
                                    <dl class="jiahao all2">
                                    </dl>
                                </li>
                                <li>
                                    <dl>
                                        <img src="<%=base.ThemeCss %>images/pro3.gif" />
                                    </dl>
                                    <dl>
                                        佳能ir600佳能佳能佳能佳能佳能佳能</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>￥65.00</span></dl>
                                </li>
                                <li>
                                    <dl class="jiahao all2">
                                    </dl>
                                </li>
                                <li>
                                    <dl>
                                        <img src="<%=base.ThemeCss %>images/pro3.gif" />
                                    </dl>
                                    <dl>
                                        佳能ir600佳能佳能佳能佳能佳能佳能</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>￥65.00</span></dl>
                                </li>
                                <li>
                                    <dl class="jiahao all2">
                                    </dl>
                                </li>
                                <li>
                                    <dl>
                                        <img src="<%=base.ThemeCss %>images/pro3.gif" />
                                    </dl>
                                    <dl>
                                        佳能ir600佳能佳能佳能佳能佳能佳能</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>￥65.00</span></dl>
                                </li>
                                <li>
                                    <dl class="jiahao all2">
                                    </dl>
                                </li>
                                <li>
                                    <dl>
                                        <img src="<%=base.ThemeCss %>images/pro3.gif" />
                                    </dl>
                                    <dl>
                                        佳能ir600佳能佳能佳能佳能佳能佳能</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>￥65.00</span></dl>
                                </li>
                                <li>
                                    <dl class="jiahao all2">
                                    </dl>
                                </li>
                                <li>
                                    <dl>
                                        <img src="<%=base.ThemeCss %>images/pro3.gif" />
                                    </dl>
                                    <dl>
                                        佳能ir600佳能佳能佳能佳能佳能佳能</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>￥65.00</span></dl>
                                </li>
                            </ul>
                        </div>
                        <div class="jieguo">
                            <li>
                                <dl class="denghao all2">
                                </dl>
                            </li>
                            <li>
                                <dl style="padding-top: 10px;">
                                    以选择3个配件</dl>
                                <dl class="dpprice">
                                    搭 配 价：<span>￥25.00</span>
                                    <br />
                                    获得优惠：￥0.00</dl>
                                <dl class="buybtn all" style="width: 80px;">
                                </dl>
                            </li>
                        </div>
                    </div>
                </div>

                <div id="tg12" class="concenter">
                    <div style="height: 200px;">
                        <XS:Widget ID="Widget8" WidgetName="产品页-推荐配件" WidgetID="f408674d-900f-4f25-b5d7-8ffc0e8dd674"
                            runat="server" />
                    </div>
                </div>
            </div>
            <!--第3部分开始-->

           
            <div class="container">
                <div class="packagetit">
                    <li class="cur2">商品介绍</li>
                    <li>规格参数</li>
                    <li>包装清单</li>
                    <li>售后保障</li>
                </div>
                <div class="packagepro">
                      <% =Model.ContentInfo%>
                </div>
            </div>
            <!--第4部分开始-->
            <div class="container">
                <div class="packagetit">
                    <li class="cur2">浏览了该商品用户还浏览了</li>
                    <li>同品牌的商品</li>
                    <li>同价位的商品</li>
                </div>
                <div class="packagepro">
                    <div class="pkpro pkpro2">
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro10.gif" /></dl>
                            <dl>
                                壳牌 helix plus非凡蓝喜力合成机油
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                壳牌 helix plus非凡蓝喜力合成机油
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro10.gif" /></dl>
                            <dl>
                                壳牌 helix plus非凡蓝喜力合成机油
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                壳牌 helix plus非凡蓝喜力合成机油
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                壳牌 helix plus非凡蓝喜力合成机油
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                壳牌 helix plus非凡蓝喜力合成机油
                            </dl>
                        </li>
                    </div>
                </div>
            </div>
            <!--第5部分开始-->
            <div class="sjque">
                <li>商家问答</li>
            </div>                            
            <div class="conproinfo">
                <XS:Widget ID="Widget1" WidgetName="产品页面一问一答"  WidgetID="e270a8ba-af11-4e38-a23f-18206eb1f94a" runat="server"/>
                                               
            </div>
         <%--   <div class="dislst">
                <li>
                    <div class="ico all2">
                    </div>
                    问：请问现在这款有货吗？<dl>
                        2013-03-12 20:04:23</dl>
                </li>
                <li>
                    <div class="ico2 all2">
                    </div>
                    <b>商家</b>：有<dl>
                        2013-03-12 08:59:02</dl>
                </li>
            </div>
            <div class="dislst">
                <li>
                    <div class="ico all2">
                    </div>
                    问：请问现在这款有货吗？<dl>
                        2013-03-12 20:04:23</dl>
                </li>
                <li>
                    <div class="ico2 all2">
                    </div>
                    <b>商家</b>：有<dl>
                        2013-03-12 08:59:02</dl>
                </li>
            </div>
            <div class="dislst">
                <li>
                    <div class="ico all2">
                    </div>
                    问：请问现在这款有货吗？<dl>
                        2013-03-12 20:04:23</dl>
                </li>
                <li>
                    <div class="ico2 all2">
                    </div>
                    <b>商家</b>：有<dl>
                        2013-03-12 08:59:02</dl>
                </li>
            </div>
            <div class="fanye">
                <li>翻页</li></div>
            <div class="distab">
                <li>
                    <div class="tanhao all2">
                    </div>
                    您需要先<a href="#">登录</a>，再向商家提问！</li></div>--%>
        </div>
    </div>
    <!----中间--->
    <input id="selNormsValue" productid="<%=Model.ID%>" value="<% =Model.Annex5%>" type="hidden" />
    <script type="text/javascript" src="<% =ThemePage%>content.js"></script>
    <!----中间--->
    <!--#include file="footer.inc"-->
</body>
</html>
