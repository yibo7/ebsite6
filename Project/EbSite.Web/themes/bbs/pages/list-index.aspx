<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.list" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>

<body>
    <div class="toolbar">
        <div class="clearfix">
            <ul id="topLinks" class="accesslink">
                <li><a href="http://localhost:8088/m/BBSTaoLunGou.ashx"><span>首页</span></a></li>
                <li><a href="http://www.ebsite.net/26-1-0c.ashx" target="_blank"><span>旗下产品 </span></a>
                </li>
                <li><a href="http://www.ebsite.net/25-0-0c.ashx" target="_blank"><span>升级日志 </span></a>
                </li>
                <li><a href="http://wiki.ebsite.net/MainPage.ashx" target="_blank"><span>使用帮助 </span>
                </a></li>
                <li><a href="http://www.ebsite.net/8-1-0c.ashx" target="_blank"><span>常见问题</span></a></li>
                <li><a href="http://www.ebsite.net/16-0-0c.ashx" target="_blank"><span>购买服务 </span></a>
                </li>
            </ul>
            <div class="userbar">
                <a href="">立即登录</a> <a href="">注册新帐号</a>
            </div>
        </div>
    </div>
    <div class="header">
        <div class="clearfix">
            <div class="brand">
                <a href="" title="EbSite支持社区" rel="home">
                    <img src="<%=base.ThemeCss %>images/logo.png" alt="EbSite支持社区">
                </a>
            </div>
        </div>
    </div>
   <div class="nav">
       <%-- <div class="majornav-left">
        </div>--%>
        <div class="majornav">
            <div class="majornav-inner">
                <ul class="majornav-list">
                    <li><a class="current" href="BBSTaoLunGou.ashx"><span>社区首页</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=26"><span>EbSIte2.0功能区</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=33"><span>c#4.0讨论区 </span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=27"><span>部件的实例</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=45"><span>NET</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=5&tid=-1"><span>最新主题</span></a></li>
                </ul>
                <div class="myapptrigger" onmouseover="addCssClass(this,'myapptrigger-expand')" onmouseout="removeCssClass(this,'myapptrigger-expand')">
                    <a class="myapptrigger-button" href="" id="appdock_dropdown"><span><strong>我的中心</strong></span></a>
                    <div class="dropdownmenu-wrap menu-appdock" id="menu_appdock">
                        <div class="dropdownmenu">
                            <div class="clearfix dropdownmenu-inner">
                                <div class="needlogin">
                                    你还没有登录.</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="extranav">
                <div class="subnav-wrap">
                    <div class="subnav">
                        <div class="subnav-inner">
                            <div class="crumbnav">
                                <a class="crumbnav-label" href="javascript:void(0)" id="forumboard_menu" title="页面导航">
                                    <span>页面导航:</span></a> <a href="BBSTaoLunGou.ashx" id="max_nav_root_1"><span>EbSite论坛</span></a>
                                <span class="separator">&raquo;</span> <span class="current"><span>欢迎光临，现在是2012/12/22
                                    19:33:11 </span></span>
                            </div>
                            <div style="float: right;">
                                <div class="forumstatus">
                                    今日: <em class="numeric">0</em> , 昨日: <em class="numeric">0</em> , 主题: <a href=""><em
                                        class="numeric">8</em></a> , 帖子: <em class="numeric">26</em> , 用户:<a href=""> <em
                                            class="numeric">0</em></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
       <%-- <div class="majornav-right">
        </div>--%>
    </div>
      <div class="UserRight_Main">
        
        <div id="mainX">
            <div id="mainby">
                <div id="main-left">
                    <table border="0" cellspacing="0" cellpadding="0" class="mapbox">
                        <tr>
                         <%--   <td valign="top" class="box_t_l">
                                <div style="width: 9px; overflow: hidden">
                                </div>
                            </td>--%>
                            <td valign="top" >
                                <div class="main-gg">
                                    <span class="gg-bg"></span>公告 * 没有任何公告</div>
                            </td>
                            <%--<td valign="top" class="box_t_r">
                                <div style="width: 9px; overflow: hidden">
                                </div>
                            </td>--%>
                        </tr>
                        <tr>
                           <%-- <td valign="top" class="box_b_l">
                            </td>--%>
                            <td valign="top" class="">
                                <div class="ctent">
                                    <div class="ctent-top">
                                        <span class="ctent-title"><a href='?t=1&tid=6'>公司行业动态 </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=22'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">硬性指标</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 15:51:07
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=23'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">生活之行</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 15:51:19
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="ctent">
                                    <div class="ctent-top">
                                        <span class="ctent-title"><a href='?t=1&tid=24'>eBSite园地 </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=25'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">模型的制做</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:02
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=26'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">模板空间</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:05
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=27'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">皮肤下载</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:09
                                            </div>
                                        </div>
                                        <div class="bbs-line">
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=28'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">插件教程</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:13
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=29'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">模块的生成</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:16
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=38'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">部件学习</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:55
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="ctent">
                                    <div class="ctent-top">
                                        <span class="ctent-title"><a href='?t=1&tid=30'>戏说人生 </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=31'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">春季</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:24
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=32'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">夏季</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:28
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=33'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">秋季</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:32
                                            </div>
                                        </div>
                                        <div class="bbs-line">
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=34'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">冬季</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:36
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="ctent">
                                    <div class="ctent-top">
                                        <span class="ctent-title"><a href='?t=1&tid=35'>IT男人 </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=36'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">国贸男</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:49
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=37'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">中关村男</span> 主题: 0, 帖数: 0
                                                <br />
                                                最后发表: 2011/2/22 17:48:52
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="ctent-botton">
                                    <div class="ctent-top">
                                        <span class="ctent-title">在线会员 详细在线列表</span>
                                    </div>
                                    <div class="ctent-botton-nr">
                                        <div class="botton-pic-a">
                                        </div>
                                        <div class="botton-title-g">
                                            管理员</div>
                                        <div class="botton-pic-b">
                                        </div>
                                        <div class="botton-title-g">
                                            超级版主
                                        </div>
                                        <div class="botton-pic-c">
                                        </div>
                                        <div class="botton-title-g">
                                            分类版主
                                        </div>
                                        <div class="botton-pic-d">
                                        </div>
                                        <div class="botton-title-g">
                                            版主
                                        </div>
                                        <div class="botton-pic-e">
                                        </div>
                                        <div class="botton-title-g">
                                            注册用户
                                        </div>
                                        <div class="botton-pic-f">
                                        </div>
                                        <div class="botton-title-g">
                                            游客</div>
                                    </div>
                            </td>
                           <%-- <td valign="top" class="box_b_r">
                            </td>--%>
                        </tr>
                        <tr>
                           <%-- <td class="box_b_bl">
                            </td>--%>
                            <td class="box_b_bc">
                            </td>
                           <%-- <td class="box_b_br">
                            </td>--%>
                        </tr>
                    </table>
                </div>
                <div id="main-right">
                   <%-- <div class="main-rr-top">
                    </div>--%>
                   <%-- <div class="main-ss">
                        <div class="main-gg">
                        </div>
                    </div>--%>
                   <%-- <div class="main-s-down">
                    </div>--%>
                   <%-- <div class="main-rr-l-coner">
                    </div>--%>
                   <%-- <div class="main-rr-down-bg">
                    </div>--%>
                   <%-- <div class="main-rr-r-coner">
                    </div>--%>
                </div>
            
            </div>
        </div>
    </div>
	<div class="clear"></div>
        <div id="main-down">
                    Copyright &copy;2005 - 2011 Tencent. All Rights Reserved 北京亿博科技 版权所有
         </div>
</body>
</html>
