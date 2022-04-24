<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Import Namespace="EbSite.BLL.User" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
    <title></title>
</head>
<body>
    <!--#include file="header.inc"-->
    <div class="content" style="width: 990px; margin: 8px auto;">
        <div class="c_left">
            <div class="l_top" style="padding: 10px 0px 10px 1px;">
                <li class="f_s14">
                    <%=GetNav("-", true)%>
                </li>
            </div>
            <div class="lb_top2">
                <XS:Widget ID="Widget1" WidgetName="问答-获取子级分类" WidgetID="eb9138d9-6133-45ba-b812-146a54245380"
                    runat="server" />
            </div>
            <div class="l_top" style="z-index: 0;">
                <div class="zhuyi" style="float: left;">
                   
                    <div class="alldatalistbox">
                         <XS:RepeaterList ID="rpGetClassList"     runat="server"  >
                                 <ItemTemplate>
                                     <ul>
                                          <li class="news_title">
                                            <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                                              
                                            <span>
                                                作者：<a href="<%#HostApi.GetUserSiteUrl(Eval("userid"))%>" target="_blank">
                                                         <font color="red"><%#Eval("userniname")%></font>
                                                     </a> 
                                            </span> 
                                            <span> 点击：<font color="red"><%#Eval("hits")%></font></span> 
                                            发表于：<font color="red"><%#Eval("addtime")%></font> 
                                          </li>
                                      </ul>  
                                 </ItemTemplate>
                            </XS:RepeaterList>
                    </div>
                    <div style="float: right; ">
                        <XS:PagesContrl ID="pgCtr" runat="server" />
                    </div>
                </div>
            </div>
            <div class="line">
            </div>
        </div>
        <div class="c_right">
            <div class="crtab2 ">
               <a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AskPost(GetSiteID) %>">
                    <img src="<%=base.ThemeCss %>images/bnr5.png" title="点击这里，可迅速提问自己的问题。" /></a>
                在这里可以找到你想要的答案
            </div>
            <div class="clear">
            </div>
            <div class="clear">
            </div>
            <div class="bor_c">
                <div class="crtabtop"><%=Model.ClassName%>.热门</div>
                <div>
                    <ul class="NoList">
                        <XS:Widget ID="Widget2" WidgetName="列表页 热门问题" WidgetID="0060c01b-7a28-43eb-a2c2-23b2bba1b887"
                            runat="server" />
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!--#include file="footer.inc" -->
</body>
</html>
<script type="text/javascript">

    var Tags = new CustomTags();
    function InitTags() {
        Tags.ParentObjName = "tagsask";
        Tags.SubObj = "div";
        Tags.CurrentClassName = "focus";
        Tags.ClassName = "";
        Tags.InitOnclickInTags();
        //    Tags.InitOnclick(0);
        Tags.InitCurrent(); //跨页时调用

    }
    InitTags(); 
</script>
