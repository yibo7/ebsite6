<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mgroupshow" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
</head>
<body>
    <!--#include file="headernav.inc" -->
    <div class="content">
        <div class="container">
            <div class="conleft">
                <div class="proimg">
                    <a id="ebproductbigimgzoom" title="图片细节" href="#"  jghref="#" >
                        <asp:Image ID="ebproductbigimg" Width="425" Height="425" runat="server" />
                    </a>
                </div>
                <div class="smallpic" id="pic_smallimgsel">
                    <div class="xll spec-control disabled " id="spec-forward">
                    </div>
                    <div class="little_img">
                        <div class="little_move">
                            <XS:Repeater ID="rpPicList" runat="server" EnableViewState="False">
                                <ItemTemplate>
                                    <li style="float: left;">
                                        <img width="47" height="47" src="<%# Eval("SmallImg")%>"  bigimg="<%# EbSite.Core.Strings.GetString.GetBigImgUrl(Eval("BigImg").ToString())%>"  oldimg="<%# Eval("BigImg").ToString()%>"/></li>
                                </ItemTemplate>
                            </XS:Repeater>
                        </div>
                    </div>
                    <div class="xrr spec-control" id="spec-backward">
                    </div>
                </div>
                <div class="l_three">
                    <div class="fdbg all">
                        <li><a target="_blank" id="picurl" href="<%=ShopLinkApi.PhotoBoxUrl(GetSiteID,Model.ID) %>">
                            查看大图</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" style="_margin-left: 15px;">加入对比</a></li>
                    </div>
                    <div class="fleft savelink">
                        <li>
                            <div class="star all">
                            </div>
                        </li>
                        <li><a onclick="FavContent(<%=Model.ID%>)">收藏此商品</a></li>
                    </div>
                </div>
                <div class="mbtok">
                    <div class="tab4">
                        <script type="text/javascript" src="<% =ThemePage%>baidushare.js"></script>
                    </div>
                </div>
            </div>
            <div class="conright">
             
                

                <div class="mrtitle">
                    <%=Model.NewsTitle %></div>
                <div class="gh_cx">
                    <li>适用车型：<asp:Label ID="suitcar" runat="server" /></li>
                </div>
                <div class="mrinfo">
                    <li><span>商品货号：</span><dd id="spPNumber"><font color="#999999"><%=Model.Annex1%></font></dd></li>
                    <li><span>价格：</span><dd class="cur"><font color="#CC0000" size="5"><b
                        id="spSalePrice">&yen;<%=Model.Annex16%></b></font></dd></li>
                   
                    <li style="clear: both;"><span>商品品牌：</span>
                        <dd >
                            <font color="#999999">
                                <%=Model.Annex11>0 ? string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model.Annex11)) :"" %>
                            </font>
                        </dd>
                    </li>
                </div>
                <div class="moreinfo">
                    <div class="minfo1 minfo2" id="productgglist">
                        <!--规格-->
                        <XS:Repeater ID="rpGGList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <li id='PNorm<%#Eval("ID")%>' dataid="<%#Eval("ID")%>">
                                    <input id='PNormValue<%#Eval("ID")%>' type="hidden" />
                                    <dl class="bnone">
                                        <%#Eval("Text")%>：</dl>
                                    <XS:Repeater ID="rpSubList" runat="server">
                                        <ItemTemplate>
                                            <input type="button" pid="<%#Eval("Value")%>" id='SNorm<%#Eval("ID")%>' valueid="<%#Eval("ID")%>"
                                                value="<%#Eval("Text")%>" />
                                        </ItemTemplate>
                                    </XS:Repeater>
                                </li>
                            </ItemTemplate>
                        </XS:Repeater>
                        <li></li>
                    </div>
                    <div class="tab3">
                        <li style="margin-right: 25px;">数量</li>
                        <li><span class="tb-amount-widget" id="J_Amount">
                            <input title="请输入购买量" class="tb-text" id="txtChangeBuyNum" type="text" maxlength="8"
                                value="1">
                            <span class="increase"></span><span class="decrease"></span></span></li>
                        <li>&nbsp;库存<span id="spStocks"><%=Model.Annex12%></span>件&nbsp;&nbsp; 商品总价格：<span
                            id="spAllPrice"><%=Model.Annex16%></span></li>
                       
                        <div class="mbtok">
                             <div id="goodsendsecond" style="display: none;">
                                    <%=EndSecond %></div>
                            </div>
                        </div>
                        
                        <div class="mbtok">
											<div class="tuantab6">
												<div class="tuanbtn all"><li style="line-height:70px;">￥<%=ModelG.BuyPrice %></li><li class="cur"> <%= EbSite.Modules.Shop.ModuleCore.Core.GetDiscountRate(ModelG.Price,ModelG.BuyPrice) %>折</li>
                                                   <li>
                                                       <% if (ModelG.Status == Convert.ToInt32(EbSite.Modules.Shop.ModuleCore.SystemEnum.GroupBuyState.正在进行中))
                                                          { %>
                                                            <a href="javascript:addtoshoppingcar('<%=ShopLinkApi.ShoppingGroupCarUrl(GetSiteID,Model.ID,ModelG.id) %>')"  > <img src="<%= base.ThemeCss %>images/tuangou.jpg"/></a>
                                                       <% }
                                                          else
                                                          { %>
                                                          
                                                            <img src="<%= base.ThemeCss %>images/jiesu.jpg"/>
                                                       
                                                       <%}%>
                                                   </li>
                                                </div>
												<div class="tab8"><li>满足<span><%=ModelG.BuyCount %></span>人参团，团购成功，已经有<span><%=ModelG.Buyed%> </span>人参团</li></div>
												<div class="tab7"><li class="cur"><b>剩余时间：</b></li><li id="remainTime"><span>0</span>天<span>30</span>小时<span>29</span>分钟<span>30</span>秒</li></div>												
											</div>
											
									</div>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="tuancen">
                <div class="centit">
                    <ul id="tabbottom">
                        <li name="cur1" class="curs">团购详情</li>
                        <li name="cur4">规格参数</li>
                        <li name="cur2">售后保障</li>
                        <li name="cur3">商家问答</li>
                    </ul>
                </div>
                <div id="cur1" class="ceninfo">
                    <%=ModelG.Content
                        %></div>
                <div id="cur2" class="ceninfo">
                     <XS:Widget ID="Widget1" WidgetName="产品页售后保障" WidgetID="e14c3789-2fd2-4a53-a5b6-84e1fab53e88"
                        runat="server" /></div>
                <div id="cur3" class="ceninfo">
                    <iframe id="win" name="win" style="width: 100%; height: 600px;" src='<%=HostApi.GetDiscussHref("1",3,GetSiteID,1,4, Model.ID)%>' frameborder="0" scrolling="no"></iframe>
                </div>  
                <div id="cur4" class="ceninfo">
                  <table width="100%" class="Ptable" border="0" cellspacing="1" cellpadding="0">
                        <tbody>
                            <tr>
                                <th class="tdTitle" colspan="2">
                                    主体
                                </th>
                            </tr>
                            <tr>
                                <td class="tdTitle">
                                    产品品牌
                                </td>
                                <td>
                                    <%=Model.Annex11>0 ? string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model.Annex11)) :"" %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdTitle">
                                    适用车型
                                </td>
                                <td>
                                   <span id="eXSuitCar"></span>
                                </td>
                            </tr>
                            <XS:Repeater ID="rpListGGParameter" runat="server" EnableViewState="False">
                                <HeaderTemplate>
                                    <tr>
                                        <th class="tdTitle" colspan="2">
                                            规格参数
                                        </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="tdTitle">
                                            <%# Eval("SXName")%>
                                        </td>
                                        <td>
                                            <%#Eval("SXValues")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </XS:Repeater>
                        </tbody>
                    </table>
            </div>
        </div>
  </div>
    
      
    <!--#include file="footer.inc"-->
    <span runat="server" id="datacount"></span>
    <input id="hpAllNormkey" type="hidden" runat="server" /><!--所有规格的值-->
    <input id="selNormsValue" productid="<%=Model.ID%>" value="<% =Model.Annex5%>" type="hidden" /><!--所选规格的值-->
    <script type="text/javascript" src="<% =ThemePage%>mgroupshow.js"></script>
</body>
</html>
