<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.jifenneirong" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <div id="centerbox">
        <!--#include file="headernav.inc" -->
        <!----�м�--->
        <div class="eb-content">
            <div class="container">
                <div class="jf_con">
                    <div class="jf_l fleft">
                     
                        <div class="jf_l2">
                            <div class="jftit">
                                ���Ŷһ�����</div>
                            <XS:Repeater ID="RepHits" runat="server">
                                <ItemTemplate>
                                    <div class="jfl2lst">
                                        <li><span class="cur"><%#Container.ItemIndex+1 %></span>
                                         <a href="<%#ShopLinkApi.JiFenShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id")) %>">
                                        <%#Eval("ProductName") %></a></li>
                                        <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font class="colo666">������֣�</font><font class="coloff6"><%#Eval("Credit") %>��</font></li>
                                        <li>
                                            <img src="<%#Eval("SmallImg") %>" height="120" width="120" /></li>
                                    </div>
                                </ItemTemplate>
                            </XS:Repeater>
                        </div>
                    </div>
                    <div class="jf_r fright">
                        <div class="jfinfol">
                            <img width="400" height="400" src="<%=Model.BigImg %>" class="fleft" /></div>
                        <div class="jfinfor fleft">
                            <li class="cur">
                                <%=Model.ProductName %></li>
                            <li>�г��ۣ�<span><%=Model.MarketPrice %>Ԫ</span></li>
                            <li>������֣�<em class="cur"><%=Model.Credit %></em>&nbsp;��</li>
                            <li>��ǰ��棺<em><%=Model.Stock %></em>&nbsp;��</li>
                            <li>
                                <% if (Model.Stock > 0&&Model.IsSaling==1)
                                   { %>   
                                <span style=" cursor:pointer; " onclick="addtoshoppingcar('<%= ShopLinkApi.ShoppingCarUrlJiFen(GetSiteID, Model.id) %>','<%=Model.Credit %>')">   <div class="kscjbtn all">
                                </div>
                                </span>
                                <% } %>

                            </li>
                        </div>
                      
                
                   <div class="proinfo">
                        <div class="jfprotit">
                            <li>
                                <img src="<%=base.ThemeCss %>images/ico10.png" /><span>��Ʒ����</span>&nbsp;(������Ϣ��Ϊ�ο���������������ϵ�ͷ�)</li>
                        </div>
                        <div class="jfprcon">
                            <%=Model.Info %>
                        </div>
                    </div>
                    </div>
                 
                </div>
            </div>
        </div>
        <!----�м�--->
    </div>
    <div style="clear: both;">
        <!--#include file="footer.inc" -->
         <script type="text/javascript" src="<% =ThemePage%>mjifenshow.js"></script>
          <span runat="server" id="datacount"></span>
    </div>
</body>
</html>