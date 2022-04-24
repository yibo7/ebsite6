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
                    <a id="ebproductbigimgzoom" title="ͼƬϸ��" href="#" jghref="#" >
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
                        <li><a target="_blank" id="picurl" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.PhotoBoxUrl(GetSiteID,Model.ID) %>">�鿴��ͼ</a> </li>
                    </div>
                     <div class="tab4">
                        <script type="text/javascript" src="<% =ThemePage%>baidushare.js"></script>
                    </div>
                </div>
              
            </div>
            <!--��һ�����ҿ�ʼ-->
            <div class="conright">
                <div class="mrtitle">
                    <%=Model.NewsTitle %></div>
                <div class="gh_cx">
                    <li>���ó��ͣ�<asp:Label ID="suitcar"   runat="server"/> </li>
                </div>
                <div class="mrinfo">
                    <li><span>��Ʒ���ţ�</span>
                        <dd id="spPNumber">
                            <font color="#999999">
                                <%=Model.Annex1%></font>
                        </dd>
                    </li>
                    <li><span>�۸�</span>
                        <dd class="cur">
                            <dd class="cur">
                                ��<font color="#CC0000" size="5"><b id="spSalePrice"><%=Model.Annex16%></b></font>(<a
                                    target="_blank" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ReducePriceUrl(GetSiteID,Model.ID) %>">����֪ͨ</a>��
                                (<a target="_blank" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GetGroupUrl(GetSiteID,Model.ID) %>">���Ź�</a>)
                            </dd>
                    </li>
                   <%-- <li><span>���ͣ�</span>
                        <dd>
                            <font color="#816957">����</font> �� <font color="#816957">�Ϻ�</font>
                            <img src="<%=base.ThemeCss %>images/ico1.png" style="border: none; margin-top: -3px;" />
                            ��ݣ�10.00 EMS��20.00</dd>
                    </li>--%>
                    <li>
                        <XS:Repeater ID="rpCuXiaoList" runat="server" EnableViewState="False">
                            <HeaderTemplate>
                                <li style="height: 100%; width: 100%;">
                                    <div style="float: left;">������Ϣ��</div>
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
                    <li style="clear: both;"><span>��ƷƷ�ƣ�</span>
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
                                    ��&nbsp;&nbsp;&nbsp;&nbsp;Ʒ��</div>
                                <div style="float: left;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <a href='<%#HostApi.GetContentLink(int.Parse(Eval("GiftProductId").ToString()), GetSiteID,Eval("classid"))%>'>
                                    <img src='<%#Eval("SmallImg") %>'
                                        width='20' height='20' />
                                     <%#Eval("ProductName")%>
                                    ��<%#Eval("Quantity")%></a></div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div> </li>
                        </FooterTemplate>
                    </XS:Repeater>
                </div>
                <div class="moreinfo">
                    <div class="minfo1 minfo2" id="productgglist">
                        <!--���-->
                        <XS:Repeater ID="rpGGList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <li id="PNorm<%#Eval("ID")%>" dataid="<%#Eval("ID")%>">
                                    <input id="PNormValue<%#Eval("ID")%>" type="hidden" />
                                    <dl class="bnone"><%#Eval("Text")%>��</dl>
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
                    <!--end���-->
                    <!--����ѡ��-->
                    <div id="ProductOption">
                        <XS:Repeater ID="rpListFeeOption" runat="server">
                            <ItemTemplate>
                                <div class="ebProductOptionItem">
                                    <div class="tab1">
                                        <li>
                                            <%#Eval("OptionName")%>��
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
                    <!--end����ѡ��-->
                    <div class="tab3">
                        <li style="margin-right: 25px;">����</li>
                        <li><span class="tb-amount-widget" id="J_Amount">
                            <input title="�����빺����" class="tb-text" id="txtChangeBuyNum" type="text" maxlength="8"
                                value="1">
                            <span class="increase"></span><span class="decrease"></span></span></li>
                        <li>&nbsp;���<span id="spStocks"><%=Model.Annex12%></span>��&nbsp;&nbsp; ��Ʒ�ܼ۸�<span
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
            <!--��һ�����ҽ���-->
            <div class="clear">
            </div>
            <!--�ڶ����ֿ�ʼ-->
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
                                    wmaprice="<%#Eval("shichangjia") %>"><span>��<%#Eval("price") %></span></dl>
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
                                    ��ѡ��<span id="tjcount">0</span>�����</dl>
                                <dl class="dpprice">
                                    �� �� �ۣ���<span id="tjprice"><%=Model.Annex16 %></span>
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
                                    wmaprice="<%#Eval("shichangjia") %>"><span>��<%#Eval("price") %></span></dl>
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
                                    ��ѡ��<span id="bestPCount">0</span>����Ʒ</dl>
                                <dl class="dpprice">
                                    ��ϼ۸񣺣�<span id="bestscj"><%=Model.Annex16 %></span>
                                </dl>
                                <dl class="buybtn all" onclick="addtoshoppingcarmore('eb_zuhecb')" style="width: 80px;">
                                </dl>
                            </li>
                        </div>
                        </div> </div>
                    </FooterTemplate>
                </XS:Repeater>
            </div>
             <!--�ڶ����ֽ���-->
            <!--��3���ֿ�ʼ-->
            <div class="container">
                <ul id="contabs2" class="packagetit">
                    <li class="cur2" name="tg21">��Ʒ����</li>
                    <li name="tg22">������</li>
                    <li name="tg23">��Ʒ����</li>
                    <li name="tg26">�̼��ʴ�</li>
                    <li name="tg24">�ۺ���</li>
                    <li name="tg25">ʹ��ָ��</li>
                </ul>
                <div id="tg21" class="concenter packagepro">
                    <% =Model.ContentInfo%>
                </div>
                <div id="tg22" class="concenter packagepro">
                    <table width="100%" class="Ptable" border="0" cellspacing="1" cellpadding="0">
                        <tbody>
                            <tr>
                                <th class="tdTitle" colspan="2">
                                    ����
                                </th>
                            </tr>
                            <tr>
                                <td class="tdTitle">
                                    ��ƷƷ��
                                </td>
                                <td>
                                    <%=Model.Annex11>0 ? string.Format("<li> {0}</li>", EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model.Annex11)) :"" %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdTitle">
                                    ���ó���
                                </td>
                                <td>
                                   <span id="eXSuitCar"></span>
                                </td>
                            </tr>
                            <XS:Repeater ID="rpListGGParameter" runat="server" EnableViewState="False">
                                <HeaderTemplate>
                                    <tr>
                                        <th class="tdTitle" colspan="2">
                                            ������
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
                    <XS:Widget ID="Widget2" WidgetName="��Ʒҳ���۲���" WidgetID="c8bf8fd1-7dcf-4060-9075-5c52a47685e3" runat="server" />
                </div>
                <div id="tg26" class="concenter packagepro">
               <iframe id="win" name="win" style="width: 100%; height: 600px;" src='<%=HostApi.GetDiscussHref("1",3,GetSiteID,1,4, Model.ID)%>' frameborder="0" scrolling="no"></iframe>
                                                                                                                                                                                   

                </div>
                <div id="tg24" class="concenter packagepro">
                    <XS:Widget ID="Widget1" WidgetName="��Ʒҳ�ۺ���" WidgetID="e14c3789-2fd2-4a53-a5b6-84e1fab53e88"
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
            <!--��4���ֿ�ʼ-->
            <div class="container">
                <div id="contabs3" class="packagetit">
                    <li name="tg31" class="cur2">����˸���Ʒ�û��������</li>
                    <li name="tg32">ͬƷ�Ƶ���Ʒ</li>
                    <li name="tg33">ͬ��λ����Ʒ</li>
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
            <!--��5���ֿ�ʼ-->
        </div>
        <!----�м�--->
        <input id="hpAllNormkey" type="hidden" runat="server" /><!--���й���ֵ-->
        <input id="selNormsValue" productid="<%=Model.ID%>" value="<% =Model.Annex5%>" type="hidden" /><!--��ѡ����ֵ-->
        <input id="selProductOption" type="hidden" />
        <input id="hSalePrice" value="<%=Model.Annex16%>" type="hidden" /> 
        <input id="ShoppingCarUrl" value="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ShoppingCarUrl(GetSiteID,Model.ID) %>" type="hidden" />
        
        
        <script type="text/javascript" src="<% =ThemePage%>content.js"></script>
        </div>
        <!----�м�--->
        <!--#include file="footer.inc"-->
</body>
</html>
