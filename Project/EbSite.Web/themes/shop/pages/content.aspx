<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.content" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"></head>
<body>
 <!--#include file="headernav.inc"-->
    <div class="">
        <div class="container">
           
            <div class="conleft">
                <div class="proimg">
                    <a id="ebproductbigimgzoom" title="图片细节" href="#" jghref="#" >
                        <asp:Image ID="ebproductbigimg" Width="425" Height="425" runat="server"/>
                    </a>
                </div>
                <div class="smallpic" id="pic_smallimgsel">
                    <div class="xll spec-control disabled " id="spec-forward">
                    </div>
                    <div class="little_img">
                    <div class="little_move" >
                        <XS:Repeater ID="rpPicList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <li style=" float: left; ">
                                    <img width="47" height="47" src=" <%# Eval("SmallImg")%>" bigimg="<%# EbSite.Core.Strings.GetString.GetBigImgUrl(Eval("BigImg").ToString())%>"  oldimg="<%# Eval("BigImg").ToString()%>" />
                                </li>
                            </ItemTemplate>
                        </XS:Repeater>
                    </div>
                    </div>
                    <div class="xrr spec-control" id="spec-backward">
                    </div>
                </div>
                <div class="l_three">
                    <div class="fdbg all">
                        <li><a target="_blank" id="picurl" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.PhotoBoxUrl(GetSiteID,Model.ID) %>">查看大图</a> </li>
                    </div>
                     <div class="tab4">
                        <script type="text/javascript" src="<% =ThemePage%>baidushare.js"></script>
                    </div>
                </div>
              
            </div>
            <!--第一部分右开始-->
            <div class="conright">
                <div class="mrtitle">
                    <%=Model.NewsTitle %></div>
                <div class="gh_cx">
                    <li>适用车型：<asp:Label ID="suitcar"   runat="server"/> </li>
                </div>
                <div class="mrinfo">
                    <li><span>商品货号：</span>
                        <dd id="spPNumber">
                            <font color="#999999">
                                <%=Model.Annex1%></font>
                        </dd>
                    </li>
                    <li><span>价格：</span>
                        <dd class="cur">
                            <dd class="cur">
                                ￥<font color="#CC0000" size="5"><b id="spSalePrice"><%=Model.Annex16%></b></font>(<a
                                    target="_blank" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ReducePriceUrl(GetSiteID,Model.ID) %>">降价通知</a>）
                                (<a target="_blank" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GetGroupUrl(GetSiteID,Model.ID) %>">求团购</a>)
                            </dd>
                    </li>
                   <%-- <li><span>配送：</span>
                        <dd>
                            <font color="#816957">北京</font> 至 <font color="#816957">上海</font>
                            <img src="<%=base.ThemeCss %>images/ico1.png" style="border: none; margin-top: -3px;" />
                            快递：10.00 EMS：20.00</dd>
                    </li>--%>
                    <li>
                        <XS:Repeater ID="rpCuXiaoList" runat="server" EnableViewState="False">
                            <HeaderTemplate>
                                <li style="height: 100%; width: 100%;">
                                    <div style="float: left;">促销信息：</div>
                                        <div style="float: left;"><div style="width: 100%;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div style="width: 100%;">
                                    <a href='<%#Eval("Url") %>'><%#Eval("Title")%></a>
                                    [<%#Eval("SuitUser")%>]
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div></div></li>
                            </FooterTemplate>
                        </XS:Repeater>
                    </li>
                    <li style="clear: both;"><span>商品品牌：</span>
                        <dd style="">
                            <font color="#999999">
                                <li><%=EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model.Annex11)%></li>
                            </font>
                        </dd>
                    </li>
                    <XS:Repeater ID="rpZengPinList" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <li style="height: 100%;">
                                <div style="float: left;">
                                    赠&nbsp;&nbsp;&nbsp;&nbsp;品：</div>
                                <div style="float: left;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <a href='<%#HostApi.GetContentLink(int.Parse(Eval("GiftProductId").ToString()), GetSiteID,Eval("classid"))%>'>
                                    <img src='<%#Eval("SmallImg") %>'
                                        width='20' height='20' />
                                     <%#Eval("ProductName")%>
                                    ×<%#Eval("Quantity")%></a></div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div> </li>
                        </FooterTemplate>
                    </XS:Repeater>
                </div>
                <div class="moreinfo">
                    <div class="minfo1 minfo2" id="productgglist">
                        <!--规格-->
                        <XS:Repeater ID="rpGGList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <li id="PNorm<%#Eval("ID")%>" dataid="<%#Eval("ID")%>">
                                    <input id="PNormValue<%#Eval("ID")%>" type="hidden" />
                                    <dl class="bnone"><%#Eval("Text")%>：</dl>
                                    <XS:Repeater ID="rpSubList" runat="server">
                                        <ItemTemplate>
                                            <input  type="button" pid="<%#Eval("Value")%>" id="SNorm<%#Eval("ID")%>" valueid="<%#Eval("ID")%>"
                                             title="<%#Eval("Text")%>"    value="<%#Eval("Text")%>" />
                                        </ItemTemplate>
                                    </XS:Repeater>
                                      <XS:Repeater ID="rpSubPicList" runat="server">
                                        <ItemTemplate>
                                                 <input type="button"  style=" height: 55px; width: 55px;background:no-repeat url(<%#Eval("Text") %>) center center; "  pid="<%#Eval("Value")%>" id="SNorm<%#Eval("ID")%>" valueid="<%#Eval("ID")%>"
                                            title="<%#Eval("altText")%>"    value="" />
                                        </ItemTemplate>
                                    </XS:Repeater>
                                </li>
                            </ItemTemplate>
                        </XS:Repeater>
                        <li></li>
                    </div>
                    <!--end规格-->
                    <!--订单选项-->
                    <div id="ProductOption">
                        <XS:Repeater ID="rpListFeeOption" runat="server">
                            <ItemTemplate>
                                <div class="ebProductOptionItem">
                                    <div class="tab1">
                                        <li>
                                            <%#Eval("OptionName")%>：
                                            <input id="OptionRowSelValue<%#Eval("ID")%>" value="0" type="hidden" />
                                        </li>
                                    </div>
                                    <div class="tab2">
                                        <XS:Repeater ID="rpSubList" runat="server">
                                            <ItemTemplate>
                                                <li rowid="<%#Eval("ProductOptionID")%>" dataid="<%#Eval("ID")%>" isgive="<%#Eval("IsGive")%>"
                                                    appendmoney="<%#Eval("AppendMoney")%>" calculatemode="<%#Eval("CalculateMode")%>"
                                                    title="<%#Eval("Remark")%>">
                                                    <%#Eval("ItemName")%>
                                                </li>
                                            </ItemTemplate>
                                        </XS:Repeater>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </XS:Repeater>
                    </div>
                    <!--end订单选项-->
                    <div class="tab3">
                        <li style="margin-right: 25px;">数量</li>
                        <li><span class="tb-amount-widget" id="J_Amount">
                            <input title="请输入购买量" class="tb-text" id="txtChangeBuyNum" type="text" maxlength="8"
                                value="1">
                            <span class="increase"></span><span class="decrease"></span></span></li>
                        <li>&nbsp;库存<span id="spStocks"><%=Model.Annex12%></span>件&nbsp;&nbsp; 商品总价格：<span
                            id="spAllPrice"><%=Model.Annex16%></span></li>
                        <li id="btnpanel">
                            <div onclick="FavContent(<%=Model.ID%>)" class="btnbuy all">
                            </div>
                            <span onclick="addtoshoppingcar()">
                                <div class="btngwc all">
                                </div>
                            </span></li>
                    </div>
                </div>
            </div>
            <!--第一部分右结束-->
            <div class="clear">
            </div>
            <!--第二部分开始-->
            <div class="container">
            <XS:Repeater ID="repTag" runat="server">
                    <HeaderTemplate>
                          <div id="contabs4" class="packagetit" >
                   </HeaderTemplate>
                    <ItemTemplate>
                         <li class="<%#Equals(Container.ItemIndex ,0)?"cur2":""%>" name="<%#Eval("url") %>"><%#Eval("title") %></li>
                    </ItemTemplate>
                    <FooterTemplate>
                         </div>
                    </FooterTemplate>
                    </XS:Repeater>
                
            <XS:Repeater ID="repTuiJian" runat="server">
                    <HeaderTemplate>
                        <div id="tg11" class="concenter packagepro">
                            <div class="pkpro">
                                <div class="master">
                                    <li>
                                        <dl>
                                            <img src="<%=Model.SmallPic %>" /></dl>
                                        <dl>
                                            <%=Model.NewsTitle %>
                                        </dl>
                                    </li>
                                    <li>
                                        <dl class="jiahao all2">
                                        </dl>
                                    </li>
                                </div>
                                <div class="suits">
                                    <ul style="width: 1320px;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Equals(Container.ItemIndex,0)?"":" <li> <dl class=\"jiahao all2\"></dl> </li>" %>
                        <li>
                            <dl>
                                <a href="<%#HostApi.GetContentLink(int.Parse(Eval("GoodsID").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                      <img src="<%#Eval("GoodsAvatarSmall") %>" /></a>
                            </dl>
                            <dl style="height:3em;line-height:1.5em;overflow:hidden;"><%#EbSite.Core.Strings.GetString.CutLen(Eval("GoodsName").ToString(),100) %></dl>
                            <dl>
                                <input type="checkbox" class="eb_tuijiancb" name="prockb_<%#Eval("GoodsID") %>" id="prockb_<%#Eval("GoodsID") %>"
                                    onclick="calculatePrice(this)" skuid="<%#Eval("GoodsID") %>" wmeprice="<%#Eval("price") %>"
                                    wmaprice="<%#Eval("shichangjia") %>"><span>￥<%#Eval("price") %></span></dl>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul> </div>
                        <div class="jieguo">
                            <li>
                                <dl class="denghao all2">
                                </dl>
                            </li>
                            <li>
                                <dl style="padding-top: 10px;">
                                    以选择<span id="tjcount">0</span>个配件</dl>
                                <dl class="dpprice">
                                    搭 配 价：￥<span id="tjprice"><%=Model.Annex16 %></span>
                                </dl>
                                <dl class="buybtn all" onclick="addtoshoppingcarmore('eb_tuijiancb')" style="width: 80px;">
                                </dl>
                            </li>
                        </div>
                        </div> </div>
                    </FooterTemplate>
                </XS:Repeater>

            <XS:Repeater ID="repBestGroup" runat="server">
                    <HeaderTemplate>
                        <div id="tg12" class="concenter packagepro">
                            <div class="pkpro">
                                <div class="master">
                                    <li>
                                        <dl>
                                            <img src="<%=Model.SmallPic %>" /></dl>
                                        <dl>
                                            <%=Model.NewsTitle %>
                                        </dl>
                                    </li>
                                    <li>
                                        <dl class="jiahao all2">
                                        </dl>
                                    </li>
                                </div>
                                <div class="suits">
                                    <ul style="width: 1320px;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Equals(Container.ItemIndex,0)?"":" <li> <dl class=\"jiahao all2\"></dl> </li>" %>
                        <li>
                            <dl>
                                <a href="<%#HostApi.GetContentLink(int.Parse(Eval("GoodsID").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                        <img src="<%#Eval("GoodsAvatarSmall") %>" /></a>
                            </dl>
                            <dl><%#EbSite.Core.Strings.GetString.CutLen(Eval("GoodsName").ToString(),100) %></dl>
                            <dl>
                                <input type="checkbox" class="eb_zuhecb" name="best_<%#Eval("GoodsID") %>" id="best_<%#Eval("GoodsID") %>"
                                    onclick="calBestPrice(this)" skuid="<%#Eval("GoodsID") %>" wmeprice="<%#Eval("price") %>"
                                    wmaprice="<%#Eval("shichangjia") %>"><span>￥<%#Eval("price") %></span></dl>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul> </div>
                        <div class="jieguo">
                            <li>
                                <dl class="denghao all2">
                                </dl>
                            </li>
                            <li>
                               <dl style="padding-top: 10px;">
                                    以选择<span id="bestPCount">0</span>个商品</dl>
                                <dl class="dpprice">
                                    组合价格：￥<span id="bestscj"><%=Model.Annex16 %></span>
                                </dl>
                                <dl class="buybtn all" onclick="addtoshoppingcarmore('eb_zuhecb')" style="width: 80px;">
                                </dl>
                            </li>
                        </div>
                        </div> </div>
                    </FooterTemplate>
                </XS:Repeater>
            </div>
             <!--第二部分结束-->
            <!--第3部分开始-->
            <div class="container">
                <ul id="contabs2" class="packagetit">
                    <li class="cur2" name="tg21">商品介绍</li>
                    <li name="tg22">规格参数</li>
                    <li name="tg23">商品评价</li>
                    <li name="tg26">商家问答</li>
                    <li name="tg24">售后保障</li>
                    <li name="tg25">使用指南</li>
                </ul>
                <div id="tg21" class="concenter packagepro">
                    <% =Model.ContentInfo%>
                </div>
                <div id="tg22" class="concenter packagepro">
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
                    <br/>
                </div>
                <div id="tg23" class="concenter packagepro">
                    <XS:Widget ID="Widget2" WidgetName="产品页评价部件" WidgetID="c8bf8fd1-7dcf-4060-9075-5c52a47685e3" runat="server" />
                </div>
                <div id="tg26" class="concenter packagepro">
               <iframe id="win" name="win" style="width: 100%; height: 600px;" src='<%=HostApi.GetDiscussHref("1",3,GetSiteID,1,4, Model.ID)%>' frameborder="0" scrolling="no"></iframe>
                                                                                                                                                                                   

                </div>
                <div id="tg24" class="concenter packagepro">
                    <XS:Widget ID="Widget1" WidgetName="产品页售后保障" WidgetID="e14c3789-2fd2-4a53-a5b6-84e1fab53e88"
                        runat="server" />
                </div>
                <div id="tg25" class="concenter packagepro" style="height: 150px;">
                    <XS:Repeater ID="repZhiNan" runat="server">
                        <ItemTemplate>
                            <div class="hid bg">
                                <a title="<%#Eval("Title") %>" target="_blank" href="<%#Eval("url") %>">
                                    <%#Container.ItemIndex+1 %>.
                                    <%#Eval("Title")%></a>
                            </div>
                        </ItemTemplate>
                    </XS:Repeater>
                </div>
            </div>
            <!--第4部分开始-->
            <div class="container">
                <div id="contabs3" class="packagetit">
                    <li name="tg31" class="cur2">浏览了该商品用户还浏览了</li>
                    <li name="tg32">同品牌的商品</li>
                    <li name="tg33">同价位的商品</li>
                </div>
                <div id="tg31" class="packagepro">
                    <div class="pkpro pkpro2">
                        <XS:Repeater ID="repGoodsVisite" runat="server">
                            <ItemTemplate>
                                <li>
                                    <dl>
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("ContentID").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <img src="<%#Eval("Smallpic") %>" /></a></dl>
                                    <dl>
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("ContentID").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <%#Eval("newstitle") %></a>
                                    </dl>
                                </li>
                            </ItemTemplate>
                        </XS:Repeater>
                    </div>
                </div>
                <div id="tg32" class="concenter packagepro">
                    <div class="pkpro pkpro2">
                        <XS:Repeater ID="repSameBrand" runat="server">
                            <ItemTemplate>
                                <li>
                                    <dl>
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <img src="<%#Eval("Smallpic") %>"/></a></dl>
                                    <dl>
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <%#Eval("newstitle") %></a>
                                    </dl>
                                </li>
                            </ItemTemplate>
                        </XS:Repeater>
                    </div>
                </div>
                <div id="tg33" class="concenter packagepro">
                    <div class="pkpro pkpro2">
                        <XS:Repeater ID="repSamePrice" runat="server">
                            <ItemTemplate>
                                <li>
                                    <dl>
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <img src="<%#Eval("Smallpic") %>"/></a>
                                    </dl>
                                    <dl>
                                        <a href="<%#HostApi.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>">
                                            <%#Eval("classid") %></a>
                                    </dl>
                                </li>
                            </ItemTemplate>
                        </XS:Repeater>
                    </div>
                </div>
            </div>
            <!--第5部分开始-->
        </div>
        <!----中间--->
        <input id="hpAllNormkey" type="hidden" runat="server" /><!--所有规格的值-->
        <input id="selNormsValue" productid="<%=Model.ID%>" value="<% =Model.Annex5%>" type="hidden" /><!--所选规格的值-->
        <input id="selProductOption" type="hidden" />
        <input id="hSalePrice" value="<%=Model.Annex16%>" type="hidden" /> 
        <input id="ShoppingCarUrl" value="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ShoppingCarUrl(GetSiteID,Model.ID) %>" type="hidden" />
        
        
        <script type="text/javascript" src="<% =ThemePage%>content.js"></script>
        </div>
        <!----中间--->
        <!--#include file="footer.inc"-->
</body>
</html>
