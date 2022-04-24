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
    <!----�м�--->
    <!----�м�--->
    <div class="content">
        <div class="container">
            <div class="contop">
                <li><a href="<%=DomainName%>">
                    <%=SiteName%></a> ><%=GetNav(">")%></div>
            <!--��һ������-->
            <div class="conleft">
                <div class="proimg">
                    <a id="ebproductbigimgzoom" title="ͼƬϸ��" href="<%=FirstModel.BigImg %>">
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
                            �鿴��ͼ</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" style="_margin-left: 15px;">����Ա�</a></li>
                    </div>
                    <div class="fleft savelink">
                        <li>
                            <div class="star all">
                            </div>
                        </li>
                        <li><a onclick="FavContent(<%=Model.ID%>)">�ղش���Ʒ</a></li></div>
                </div>
                <div class="mbtok">
                    <div class="tab4">
                        <script type="text/javascript" src="<% =ThemePage%>baidushare.js"></script>
                       
                    </div>
                </div>
            </div>
           
            <!--��һ������-->
            <div class="conright">
                <div class="mrtitle">
                    <%=Model.NewsTitle %></div>
                <div class="gh_cx">
                    <li>���ó��ͣ��µ�100 3.0���� �Զ����� <a href="#">[��������]</a></li></div>
                <div class="mrinfo">
                    <li><span>��Ʒ���ţ�</span>
                        <dd>
                            <font color="#999999">
                                <%=Model.Annex1%></font>
                        </dd>
                    </li>
                    <li><span>�۸�</span>
                        <dd class="cur">
                            ��<font color="#CC0000" size="5"><b><%=Model.Annex16%></b></font>(<a target="_blank"
                                href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.ReducePriceUrl(GetSiteID,Model.ID) %>">����֪ͨ</a>��
                                (<a target="_blank" href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.GetGroupUrl(GetSiteID,Model.ID) %>">���Ź�</a>)</dd>
                    </li>
                    <li><span>���ͣ�</span>
                        <dd>
                            <font color="#816957">����</font> �� <font color="#816957">�Ϻ�</font>
                            <img src="<%=base.ThemeCss %>images/ico1.png" style="border: none; margin-top: -3px;" />
                            ��ݣ�10.00 EMS��20.00</dd></li>
                    <li>
                        <asp:Repeater ID="rpCuXiaoList" runat="server" EnableViewState="False">
                            <HeaderTemplate>
                                <li style="height: 100%; width: 100%;">
                                    <div style="float: left;">
                                        ������Ϣ��</div>
                                    <div style="float: left;">
                                        <div style="width: 100%;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div style="width: 100%;">
                                    <a href='<%#Eval("Url") %>'>
                                        <%#Eval("Title")%></a>[�����ڣ�<%#Eval("SuitUser")%>]</div>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div></div></li>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                    <li style="clear:both;"><span>��ƷƷ�ƣ�</span>
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
                                    ��&nbsp;&nbsp;&nbsp;&nbsp;Ʒ��</div>
                                <div style="float: left;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <a href='<%#EbSite.Modules.Shop.ModuleCore.GetLinks.Product(3,Eval("GiftProductId"))%>'>
                                    <img src='<%#SmallPic(Eval("GiftProductId").ToString()) %>' width='20' height='20' />
                                    <%#GetName(Eval("GiftProductId").ToString())%>
                                    ��<%#Eval("Quantity")%></a></div>
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
                                        <%#Eval("Text")%>��</dl>
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
                                <li>��ѡ����</li>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <input id="hpAllNormkey" value="<%=sAllNormkey %>" type="hidden" />
                    <%--<div class="minfo1">
                        <li>
                            <dl class="bnone">
                                <span>ѡ����ɫ��</span></dl>
                            <dl class="cur all">
                                <img src="<%=base.ThemeCss %>images/pro8.gif" /></dl>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro8.gif" /></dl>
                        </li>
                    </div>
                    <div class="minfo1 minfo2">
                        <li>
                            <dl class="bnone">
                                <span>ѡ����룺</span></dl>
                            <dl>
                                4Lװ
                            </dl>
                            <dl class="cur2 all">
                                1Lװ
                            </dl>
                        </li>
                        <li><span>�Ѿ�ѡ��</span>��<b>�ƿ�</b>��,��<b>1Lװ</b>�� </li>
                    </div>--%>
                    <asp:Repeater ID="rpListFeeOption" OnItemDataBound="rpListFeeOption_ItemDataBound"
                        runat="server">
                        <ItemTemplate>
                            <div class=" bgnone">
                               <div class="tab1">
                                   <li> <%#Eval("OptionName")%>��</li></div>
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
                            <li>���ڱ���:</li></div>
                        <div class="tab2">
                            <li class="cur">1�꣤456</li><li>2�꣤816</li></div>
                    </div>--%>
                    <div class="tab3">
                        <li>����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                        <li>
                            <input type="text" value="1" id="num" class="iptdata all" /></li>
                        <li>&nbsp;���542��&nbsp;&nbsp; ��Ʒ�ܼ۸�<span><%=Model.Annex16%></span></li>
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
            <!--��һ������-->
            <div class="clear">
            </div>
            <!--�ڶ����ֿ�ʼ-->

        
            <div class="container conproinfo">
                <div class="contabs packagetit">
                  <li ><a  class="cur" name="tg11"> �Ƽ����</a></li>
                  <li><a name="tg12"> �������</a></li>           
                </div>
                <div  id="tg11" class="packagepro">
                    <div class="pkprolst">
                        <li class="cur">ȫ�����</li>
                        <li><a href="#">������</a></li>
                        <li><a href="#">������</a></li>
                        <li><a href="#">����</a></li>
                        <li><a href="#">����</a></li>
                        <li><a href="#">������</a></li>
                        <li><a href="#">������</a></li>
                        <li><a href="#">����</a></li>
                        <li><a href="#">����</a></li>
                    </div>
                    <div class="pkpro">
                        <div class="master">
                            <li>
                                <dl>
                                    <img src="<%=base.ThemeCss %>images/pro3.gif" /></dl>
                                <dl>
                                    ���� helix plus�Ƿ���ϲ���ϳɻ���
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
                                        ����ir600���ܼ��ܼ��ܼ��ܼ��ܼ���</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>��65.00</span></dl>
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
                                        ����ir600���ܼ��ܼ��ܼ��ܼ��ܼ���</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>��65.00</span></dl>
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
                                        ����ir600���ܼ��ܼ��ܼ��ܼ��ܼ���</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>��65.00</span></dl>
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
                                        ����ir600���ܼ��ܼ��ܼ��ܼ��ܼ���</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>��65.00</span></dl>
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
                                        ����ir600���ܼ��ܼ��ܼ��ܼ��ܼ���</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>��65.00</span></dl>
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
                                        ����ir600���ܼ��ܼ��ܼ��ܼ��ܼ���</dl>
                                    <dl>
                                        <input type="checkbox" id="prockb"><span>��65.00</span></dl>
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
                                    ��ѡ��3�����</dl>
                                <dl class="dpprice">
                                    �� �� �ۣ�<span>��25.00</span>
                                    <br />
                                    ����Żݣ���0.00</dl>
                                <dl class="buybtn all" style="width: 80px;">
                                </dl>
                            </li>
                        </div>
                    </div>
                </div>

                <div id="tg12" class="concenter">
                    <div style="height: 200px;">
                        <XS:Widget ID="Widget8" WidgetName="��Ʒҳ-�Ƽ����" WidgetID="f408674d-900f-4f25-b5d7-8ffc0e8dd674"
                            runat="server" />
                    </div>
                </div>
            </div>
            <!--��3���ֿ�ʼ-->

           
            <div class="container">
                <div class="packagetit">
                    <li class="cur2">��Ʒ����</li>
                    <li>������</li>
                    <li>��װ�嵥</li>
                    <li>�ۺ���</li>
                </div>
                <div class="packagepro">
                      <% =Model.ContentInfo%>
                </div>
            </div>
            <!--��4���ֿ�ʼ-->
            <div class="container">
                <div class="packagetit">
                    <li class="cur2">����˸���Ʒ�û��������</li>
                    <li>ͬƷ�Ƶ���Ʒ</li>
                    <li>ͬ��λ����Ʒ</li>
                </div>
                <div class="packagepro">
                    <div class="pkpro pkpro2">
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro10.gif" /></dl>
                            <dl>
                                ���� helix plus�Ƿ���ϲ���ϳɻ���
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                ���� helix plus�Ƿ���ϲ���ϳɻ���
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro10.gif" /></dl>
                            <dl>
                                ���� helix plus�Ƿ���ϲ���ϳɻ���
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                ���� helix plus�Ƿ���ϲ���ϳɻ���
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                ���� helix plus�Ƿ���ϲ���ϳɻ���
                            </dl>
                        </li>
                        <li>
                            <dl>
                                <img src="<%=base.ThemeCss %>images/pro9.gif" /></dl>
                            <dl>
                                ���� helix plus�Ƿ���ϲ���ϳɻ���
                            </dl>
                        </li>
                    </div>
                </div>
            </div>
            <!--��5���ֿ�ʼ-->
            <div class="sjque">
                <li>�̼��ʴ�</li>
            </div>                            
            <div class="conproinfo">
                <XS:Widget ID="Widget1" WidgetName="��Ʒҳ��һ��һ��"  WidgetID="e270a8ba-af11-4e38-a23f-18206eb1f94a" runat="server"/>
                                               
            </div>
         <%--   <div class="dislst">
                <li>
                    <div class="ico all2">
                    </div>
                    �ʣ�������������л���<dl>
                        2013-03-12 20:04:23</dl>
                </li>
                <li>
                    <div class="ico2 all2">
                    </div>
                    <b>�̼�</b>����<dl>
                        2013-03-12 08:59:02</dl>
                </li>
            </div>
            <div class="dislst">
                <li>
                    <div class="ico all2">
                    </div>
                    �ʣ�������������л���<dl>
                        2013-03-12 20:04:23</dl>
                </li>
                <li>
                    <div class="ico2 all2">
                    </div>
                    <b>�̼�</b>����<dl>
                        2013-03-12 08:59:02</dl>
                </li>
            </div>
            <div class="dislst">
                <li>
                    <div class="ico all2">
                    </div>
                    �ʣ�������������л���<dl>
                        2013-03-12 20:04:23</dl>
                </li>
                <li>
                    <div class="ico2 all2">
                    </div>
                    <b>�̼�</b>����<dl>
                        2013-03-12 08:59:02</dl>
                </li>
            </div>
            <div class="fanye">
                <li>��ҳ</li></div>
            <div class="distab">
                <li>
                    <div class="tanhao all2">
                    </div>
                    ����Ҫ��<a href="#">��¼</a>�������̼����ʣ�</li></div>--%>
        </div>
    </div>
    <!----�м�--->
    <input id="selNormsValue" productid="<%=Model.ID%>" value="<% =Model.Annex5%>" type="hidden" />
    <script type="text/javascript" src="<% =ThemePage%>content.js"></script>
    <!----�м�--->
    <!--#include file="footer.inc"-->
</body>
</html>
