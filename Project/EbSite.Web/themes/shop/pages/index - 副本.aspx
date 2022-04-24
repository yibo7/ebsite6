<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.index" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="header.inc"-->
    <!----中间--->
    <div class="content">
        <!----中间1四部分--->
        <div class="container i_one">
            <div class="con1l">
                <XS:Widget ID="Widget3" WidgetName="首页所有商品分类" WidgetID="5e8263fb-3d3c-4b27-b945-43117c9d2211" runat="server" />
            </div>
            <div class="con1r">
                <!---flash-->
                <div style="padding-left: 0px;" class="f">
                    <div style="" class="fleft">
                         <XS:Widget ID="Widget1" WidgetName="首页幻灯片"  WidgetID="56b0edec-9a1c-473b-84a6-558cde9718c4" runat="server"/>
                                               
                    </div>
                    <div class="frig">
                        <div class="frtab1">
                            <li><a target="_blank" href="<%=EbSite.Base.Host.Instance.GetContentLink(425,EbSite.Base.Host.Instance.GetSiteID)%>"><img alt="正品保障" title="正品保障" src="<%=base.ThemeCss %>images/zheng.jpg" /></a></li>
                            <li><a target="_blank" href="<%=EbSite.Base.Host.Instance.GetContentLink(426,EbSite.Base.Host.Instance.GetSiteID)%>"><img alt="七天包退" title="七天包退" src="<%=base.ThemeCss %>images/bao.jpg" /></a></li>
                            <li><a target="_blank" href="<%=EbSite.Base.Host.Instance.GetContentLink(427,EbSite.Base.Host.Instance.GetSiteID)%>"><img src="<%=base.ThemeCss %>images/xin.jpg" alt="假一赔三" title="假一赔三" /></a></li>
                        </div>
                        <div class="frtab2">
                            <ul>
                                <li class="cur" id="tab1" onclick="show_tab('con','tab',3,1,'cur')">查找</li>
                                <li id="tab2" onclick="show_tab('con','tab',3,2,'cur')">常见问题</li>
                                <li id="tab3" onclick="show_tab('con','tab',3,3,'cur')">购物保障</li>
                            </ul>
                        </div>
                        <div id="con1" class="frtab3">
                            <div class="ipt1 all"><li>请选择品牌</li></div>
                            <div class="ipt1 all"><li>请选择车型</li></div>
                            <div class="ipt1 all"><li>请选择排量</li></div>
                            <div class="bg1"><div class="haocaizhida all"></div></div>
                            <div class="clear"></div>
                        </div>
                        <div id="con2" class="frtab3" style="display:none;">
                            <ul>
                                <XS:Widget ID="Widget4" WidgetName="首页_常见问题"  WidgetID="0ce8f581-5a2e-4b02-b329-eeef3494d5cc" runat="server"/>
                            </ul>
                        </div>
                        <div id="con3" class="frtab3" style="display:none;">
                            <ul>
                                <XS:Widget ID="Widget5" WidgetName="首页_购物保障"  WidgetID="f39ab589-1dd9-4aa8-baf8-c6128b8b2768" runat="server"/>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div style="border-bottom: #CCCCCC solid 1px; background: #F2F2F2; font-size: 14px; font-weight: bold; color: #3A3831; line-height: 32px;">&nbsp;&nbsp;本站推荐</div>
            <div class="pro_lst">
                <XS:Widget ID="Widget7" WidgetName="首页今日优惠"  WidgetID="a040f55f-fc66-44e1-9e70-cc6686141dfc" runat="server"/>
            </div>
        </div>
      
        <!----中间第2部分--->
        <div class="container i_two">
            <div class="pp_tit">
                从车型品牌查找配件》</div>
            <div class="pp_img">
                <XS:Widget ID="Widget2" WidgetName="首页专题分类" WidgetID="5ede103d-9cec-4e6c-bbf4-3c02ba67d50c" runat="server" />
            </div>
        </div>
        <!----中间第2部分--->
        <!----中间第3部分--->
        
         <XS:Widget ID="Widget6" WidgetName="首页楼层展示"  WidgetID="1555371e-0405-4a06-9789-5dc6010267f2" runat="server"/>
                                               
     
    </div>
    <!----中间--->
    <script type="text/javascript" src="<%=base.ThemePage %>index.js"></script>
    <!--#include file="footer.inc"-->
</body>
</html>
