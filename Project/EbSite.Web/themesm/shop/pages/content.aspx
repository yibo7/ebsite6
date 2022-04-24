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
                if (sType == "0") //���
                {
                    
                    this.PGuiGe.Visible = false;
                    this.PXiangQing.Visible = false;
                    this.PZiXun.Visible = false;
                }
                if (sType == "1") //���
                {
                    
                   // this.PJianjie.Visible = true;
                    this.PGuiGe.Visible = true;
                    this.PXiangQing.Visible = false;
                    this.PZiXun.Visible = false;
                }
                if (sType == "2") //����
                {
                   // this.PJianjie.Visible = false;
                    this.PGuiGe.Visible = false;
                    this.PXiangQing.Visible = true;
                    this.PZiXun.Visible = false;
                }
                if (sType == "3") //��ѯ
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
        <a id="tg0" href="?t=0" <%=EbSite.Base.Host.Instance.GetCurrentCSS("0","cur","t") %>  >���<div></div></a> 
        <a id="tg1" href="?t=1" <%=EbSite.Base.Host.Instance.GetCurrentCSS("1","cur","t") %>  >������<div></div></a> 
        <a id="tg2" href="?t=2" <%=EbSite.Base.Host.Instance.GetCurrentCSS("2","cur","t") %>  >����<div></div></a> 
        <a id="tg3" href="?t=3" <%=EbSite.Base.Host.Instance.GetCurrentCSS("3","cur","t") %>  >��ѯ<div></div></a>
        </nav>
    </div>
    <!--���-->
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
                ��Ʒ�۸�&yen;<b id="spSalePrice"><%=Model.Annex16%></b>
            </div>
            <div>
                ��Ʒ���ţ�<%=Model.Annex1%>
            </div>
            <div>
                ��ƷƷ�ƣ�<%=EbSite.Modules.Shop.ModuleCore.BLL.GoodsBrand.Instance.GetBrandNameByID(Model.Annex11)%></div>
            <XS:Repeater ID="rpCuXiaoListM" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <div style="overflow: auto; zoom: 1;">
                        <span class="fl">�������</span><span class="fr activeinfo">
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
                        <span class="fl">��&nbsp;&nbsp;&nbsp;&nbsp;Ʒ��</span><span class="fr activeinfo">
                </HeaderTemplate>
                <ItemTemplate>
                    <a href='<%#HostApi.GetContentLink(int.Parse(Eval("GiftProductId").ToString()), GetSiteID)%>'>
                        <img src='<%#Eval("SmallImg") %>' width='20' height='20' />
                        <%#Eval("ProductName")%>
                        ��<%#Eval("Quantity")%>
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
                    ��Ʒ���</div>
                <div class="gglist">
                    <div>
                        �۸�&yen;<b id="spSalePrice2"><%=Model.Annex16%></b></div>
                   <div  id="productgglist">
                     <XS:Repeater ID="rpGGList" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <div class="ggitem">
                                <li id="PNorm<%#Eval("ID")%>" dataid="<%#Eval("ID")%>">
                                    <input id="PNormValue<%#Eval("ID")%>" type="hidden" />
                                    <dl>
                                        <%#Eval("Text")%>��</dl>
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
                </div>
                
              
                

                <div class="addtocarbox">
                    <div>
                        �������<b id="spStocks"><%=Model.Annex12%></b></div>
                    <div>
                        ��������:</div>
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
                    <div>��Ʒ�ܼ۸�&yen;<b id="spAllPrice"><%=Model.Annex16%></b></div>
                </div>
                
            </div>
            
             
        </div>
    
    </div>
    <!--��� end-->
    <!--������-->
    <asp:Panel ID="PGuiGe" runat="server">
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    ������</div>
                <div class="gglist">
                    <div>
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
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--������end-->
    <!--����-->
    <asp:Panel ID="PXiangQing" runat="server">
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    ��Ʒ����</div>
                <div>
                    <%=Model.ContentInfo %>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--����end-->
    <!--��ѯ-->
    <asp:Panel ID="PZiXun" runat="server">
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    ��Ʒ��ѯ</div>
                <div class="gglist">
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--��ѯend-->
    <div class="pggbox">
        <div class="addtocarbox">
            <div class="btnaddtocar">
                <input type="button" onclick="addtoshoppingcar()" value="���빺�ﳵ" />
                <input type="button" class="adv" value="�ղ�" />
            </div>
        </div>
    </div>
    <div id="panelMsg" class="vote-dialog">
    </div>
    <!--#include file="foot.inc" -->
      
    <input id="hpAllNormkey" type="hidden" runat="server" /><!--���й���ֵ-->
    <input id="selNormsValue" productid="<%=Model.ID%>" value="<% =Model.Annex5%>" type="hidden" /><!--��ѡ����ֵ-->
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
