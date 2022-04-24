<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mproductphotobox" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <div id="centerbox">
        <!--#include file="header.inc" -->
    </div>
    <div>
        <div class="w main">
            <div class="left">
                <div class="g-0 overflow">
                    <div class="o-m-1">
                        <div class="p-sort">
                            
                            <a href="<%=HostApi.GetClassHref(model.ClassID,1) %>"><%=model.ClassName %></a>
                        </div>

                        <a id="link-return" href="<%=HostApi.GetContentLink(model.ID,model.HtmlName) %>"></a>
                        <h1>
                            <a href="<%=HostApi.GetContentLink(model.ID,model.HtmlName) %>"><%=model.NewsTitle %></a>
                        </h1>
                    </div>
                    <div id="biger" index="0" >
                        <a class="control prev prev-disabled" title="上一张" href="#prev"><span></span>上一张</a>
                        <a class="control next" title="下一张" href="#next"><span></span>下一张</a>
                        <img alt="" src=""><b></b>
                    </div>
                    <div id="explain" class="hide">
                    </div>
                    <!--o-m-1 end-->
                </div>
            </div>
            <!--left end-->
            <div class="right">
                <div id="list-img" class="m">


                    <div class="mt">
                        <h2>全部图片</h2>
                        <span>(<%=iPicCount %>张)</span>
                    </div>
                    <div class="mc">
                        <ul class="list-h" style="background-color: #fff;">
                            <asp:Repeater ID="rpListProductPic" runat="server" EnableViewState="False">
                                <ItemTemplate>
                                    <li index="<%# this.rpListProductPic.Items.Count%>">
                                        <img id="p<%# this.rpListProductPic.Items.Count%>" alt="" src="<%#Eval("smallimg") %>" width="50" height="50" data="">
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                         
                        </ul>
                    </div>
                    <div class="mb">
                    </div>
                </div>
                <!--list-img end-->
                <div id="p-info" class="m">
                    <div class="mc marginbottom" >
                        <div class="dt">
                            价&nbsp;&nbsp;格：
                        </div>
                        <div class="dd">
                            <strong>￥<%=model.Annex16 %></strong>
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                    
                    <%-- <div style="clear:both; " onclick="addtoshoppingcar('<%=ShopLinkApi.ShoppingCarUrl(GetSiteID,model.ID) %>')">
                                 <div class="btngwc all"></div> 
                     </div>--%>
                </div>
            </div>
            <!--right end-->
            <span class="clr"></span>
            <div class="hide">
            </div>
        </div>
    </div>
    <div style="clear: both;">
        <!--#include file="footer.inc" -->
    </div>
    <script type="text/javascript" src="<% =ThemePage%>mproductphotobox.js"></script>
</body>
</html>
