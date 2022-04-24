<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mjifenneirong" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <script type="text/C#" runat="server">
       
        new protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            string sType = Request["t"];

            if (!string.IsNullOrEmpty(sType))
            {
                if (sType == "0") //简介
                {
                    this.PJianjie.Visible = true;
                    this.PXiangQing.Visible = false;
                }

                if (sType == "1") //详情
                {
                    this.PJianjie.Visible = false;
                    this.PXiangQing.Visible = true;
                }
            }
            else
            {
                this.PJianjie.Visible = true;
                this.PXiangQing.Visible = false;
            }

        }
    </script>
</head>
<body>
    <!--#include file="header.inc" -->
    <div class="navpbox">
        <nav class="w-nav"> 
        <a id="tg0" href="?t=0" <%=EbSite.Base.Host.Instance.GetCurrentCSS("0","cur","t") %>  >简介<div></div></a> 
        <a id="tg1" href="?t=1" <%=EbSite.Base.Host.Instance.GetCurrentCSS("1","cur","t") %>  >详情<div></div></a> 
        </nav>
    </div>
    <!--简介-->
    <asp:Panel ID="PJianjie" runat="server">
        <div id="slider">
            <div style="height: 390px; text-align: center; ">
                <img width="390" height="390" src="<%=Model.BigImg %>">
            </div>
        </div>
        <div class="producinfo">
            <div class="t">
                <%=Model.ProductName %>
            </div>
            <div>
                商品价格：&yen;<b id="spSalePrice"><%=Model.MarketPrice %>元</b>
            </div>
            <div>
                所需积分：<%=Model.Credit %>
                &nbsp;分
            </div>
            <div>
                当前库存：<%=Model.Stock %>
                &nbsp;件</div>
        </div>
    </asp:Panel>
    <!--详情-->
    <asp:Panel ID="PXiangQing" runat="server">
        <div class="pggbox">
            <div class="radiusbox">
                <div class="t">
                    商品详情</div>
                <div>
                    <%=Model.Info %>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="pggbox">
        <div class="addtocarbox">
            <div class="btnaddtocar">
                <div>
                    <% if (Model.Stock > 0 && Model.IsSaling == 1)
                       { %>
                    <input type="button" onclick="addtoshoppingcar('<%= ShopLinkApi.MShoppingCarUrlJiFen(GetSiteID, Model.id) %>','<%=Model.Credit %>','<%=base.UserID %>')"
                        value="我要兑换" />
                    <% } %>
                </div>
                <input type="button" class="adv" value="收藏" />
            </div>
        </div>
    </div>
     <div id="panelMsg" class="vote-dialog">
     </div>
    <!--#include file="foot.inc" -->
     <script>
         m_dialog("panelMsg", "200", "130");
     </script>
     <script type="text/javascript" src="<% =MThemePage%>mmjifenshow.js"></script>
</body>
</html>
