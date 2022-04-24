<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.content" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server">
    <script type="text/C#" runat="server">
       
        new protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            string sType = Request["t"];

            if (!string.IsNullOrEmpty(sType))
            {
                if (sType == "0") //简介
                {
                    
                    this.PGuiGe.Visible = false;
                    this.PXiangQing.Visible = false;
                    this.PZiXun.Visible = false;
                }
                if (sType == "1") //规格
                {
                    
                   // this.PJianjie.Visible = true;
                    this.PGuiGe.Visible = true;
                    this.PXiangQing.Visible = false;
                    this.PZiXun.Visible = false;
                }
                if (sType == "2") //详情
                {
                   // this.PJianjie.Visible = false;
                    this.PGuiGe.Visible = false;
                    this.PXiangQing.Visible = true;
                    this.PZiXun.Visible = false;
                }
                if (sType == "3") //咨询
                {
                   // this.PJianjie.Visible = true;
                    this.PGuiGe.Visible = false;
                    this.PXiangQing.Visible = false;
                    this.PZiXun.Visible = true;
                }
            }
            else
            {
              //  this.PJianjie.Visible = true;
                this.PGuiGe.Visible = false;
                this.PXiangQing.Visible = false;
                this.PZiXun.Visible = false;
            }

        }
    </script>
    
    <title></title>
</head>
<body> 
    <!--#include file="header.inc" -->
    <div class="navpbox">
        <nav class="w-nav"> 
        <a id="tg0" href="?t=0" <%=EbSite.Base.Host.Instance.GetCurrentCSS("0","cur","t") %>  >简介<div></div></a> 
        <a id="tg1" href="?t=1" <%=EbSite.Base.Host.Instance.GetCurrentCSS("1","cur","t") %>  >规格参数<div></div></a> 
        <a id="tg2" href="?t=2" <%=EbSite.Base.Host.Instance.GetCurrentCSS("2","cur","t") %>  >详情<div></div></a> 
        <a id="tg3" href="?t=3" <%=EbSite.Base.Host.Instance.GetCurrentCSS("3","cur","t") %>  >咨询<div></div></a>
        </nav>
    </div>
    <!--简介-->
    <div id="PJianjie"  >
        
        <div id="slider">
            <XS:Repeater ID="rpPicList" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <div style="height: 390px;">
                        <img src="<%# Eval("BigImg")%>">
                    </div>
                </ItemTemplate>
            </XS:Repeater>
        </div>
        <div class="producinfo">
            <div class="t">
                <%=Model.NewsTitle %>
            </div>
            <div>
                商品价格：&yen;<b id="spSalePrice"><%=Model.Annex16%></b>
            </div>
            <div>
                商品货号：<%=Model.Annex1%>
            </div>
            <div>
                商品品牌：<%=EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model.Annex11)%></div>
            <XS:Repeater ID="rpCuXiaoListM" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <div style="overflow: auto; zoom: 1;">
                        <span class="fl">促销活动：</span><span class="fr activeinfo">
                </HeaderTemplate>
                <ItemTemplate>
                    <a href='<%#Eval("Url") %>'>
                        <%#Eval("Title")%>[<%#Eval("SuitUser")%>]</a>
                </ItemTemplate>
                <FooterTemplate>
                    </span> </div>
                </FooterTemplate>
            </XS:Repeater>
            <XS:Repeater ID="rpZengPinList" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <div style="overflow: auto; zoom: 1;">
                        <span class="fl">赠&nbsp;&nbsp;&nbsp;&nbsp;品：</span><span class="fr activeinfo">
                </HeaderTemplate>
                <ItemTemplate>
                    <a href='<%#HostApi.GetContentLink(int.Parse(Eval("GiftProductId").ToString()), GetSiteID)%>'>
                        <img src='<%#Eval("SmallImg") %>' width='20' height='20' />
                        <%#Eval("ProductName")%>
                        ×<%#Eval("Quantity")%>
                    </a>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </XS:Repeater>
        </div>
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    商品规格</div>
                <div class="gglist">
                    <div>
                        价格：&yen;<b id="spSalePrice2"><%=Model.Annex16%></b></div>
                   <div  id="productgglist">
                     <XS:Repeater ID="rpGGList" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <div class="ggitem">
                                <li id="PNorm<%#Eval("ID")%>" dataid="<%#Eval("ID")%>">
                                    <input id="PNormValue<%#Eval("ID")%>" type="hidden" />
                                    <dl>
                                        <%#Eval("Text")%>：</dl>
                                    <div>
                                        <XS:Repeater ID="rpSubList" runat="server">
                                            <ItemTemplate>
                                                <input type="button" pid="<%#Eval("Value")%>" id="SNorm<%#Eval("ID")%>" valueid="<%#Eval("ID")%>"
                                                    title="<%#Eval("Text")%>" value="<%#Eval("Text")%>" />
                                            </ItemTemplate>
                                        </XS:Repeater>
                                        <XS:Repeater ID="rpSubPicList" runat="server">
                                            <ItemTemplate>
                                                <input type="button" style="height: 55px; width: 55px; background: no-repeat url(<%#Eval("Text") %>) center center;"
                                                    pid="<%#Eval("Value")%>" id="SNorm<%#Eval("ID")%>" valueid="<%#Eval("ID")%>"
                                                    title="<%#Eval("altText")%>" value="" />
                                            </ItemTemplate>
                                        </XS:Repeater>
                                    </div>
                                </li>
                            </div>
                        </ItemTemplate>
                    </XS:Repeater>
                    </div>
                    
                    
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
                </div>
                
              
                

                <div class="addtocarbox">
                    <div>
                        库存量：<b id="spStocks"><%=Model.Annex12%></b></div>
                    <div>
                        购买数量:</div>
                    <div class="quantity">
                        <span class="ui-number">
                            <button type="button" class="decrease">
                                -</button>
                            <input type="number" class="num" name="quantity" id="txtChangeBuyNum" autocomplete="off" value="1" min="1"
                                max="1329">
                            <button type="button" class="increase">
                                +</button>
                        </span>
                    </div>
                    <div>商品总价格：&yen;<b id="spAllPrice"><%=Model.Annex16%></b></div>
                </div>
                
            </div>
            
             
        </div>
    
    </div>
    <!--简介 end-->
    <!--规格参数-->
    <asp:Panel ID="PGuiGe" runat="server">
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    规格参数</div>
                <div class="gglist">
                    <div>
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
        </div>
    </asp:Panel>
    <!--规格参数end-->
    <!--详情-->
    <asp:Panel ID="PXiangQing" runat="server">
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    商品详情</div>
                <div>
                    <%=Model.ContentInfo %>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--详情end-->
    <!--咨询-->
    <asp:Panel ID="PZiXun" runat="server">
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    商品咨询</div>
                <div class="gglist">
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--咨询end-->
    <div class="pggbox">
        <div class="addtocarbox">
            <div class="btnaddtocar">
                <input type="button" onclick="addtoshoppingcar()" value="加入购物车" />
                <input type="button" class="adv" value="收藏" />
            </div>
        </div>
    </div>
    <div id="panelMsg" class="vote-dialog">
    </div>
    <!--#include file="foot.inc" -->
      
    <input id="hpAllNormkey" type="hidden" runat="server" /><!--所有规格的值-->
    <input id="selNormsValue" productid="<%=Model.ID%>" value="<% =Model.Annex5%>" type="hidden" /><!--所选规格的值-->
    <input id="selProductOption" type="hidden" />
    <input id="hSalePrice" value="<%=Model.Annex16%>" type="hidden" />
     <input id="ShoppingCarUrl" value="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.MShoppingCarUrl(GetSiteID,Model.ID) %>" type="hidden" />
    <script type="text/javascript" src="<% =MThemePage%>content.js"></script>
    <script>

        m_dialog("panelMsg", "200", "130");
        
        In.ready('gmue-parseTpl', 'gmuw-slider', 'gmuw-arrow', 'gmuw-dots', 'gmuw-touch', 'gmuw-autoplay', 'gmuw-lazyloadimg', function () {
            $('#slider').slider({ imgZoom: true });
        });        
       
    </script>
</body>
</html>
