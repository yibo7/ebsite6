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
                <li><a href="http://localhost:8088/m/BBSTaoLunGou.ashx"><span>��ҳ</span></a></li>
                <li><a href="http://www.ebsite.net/26-1-0c.ashx" target="_blank"><span>���²�Ʒ </span></a>
                </li>
                <li><a href="http://www.ebsite.net/25-0-0c.ashx" target="_blank"><span>������־ </span></a>
                </li>
                <li><a href="http://wiki.ebsite.net/MainPage.ashx" target="_blank"><span>ʹ�ð��� </span>
                </a></li>
                <li><a href="http://www.ebsite.net/8-1-0c.ashx" target="_blank"><span>��������</span></a></li>
                <li><a href="http://www.ebsite.net/16-0-0c.ashx" target="_blank"><span>������� </span></a>
                </li>
            </ul>
            <div class="userbar">
                <a href="">������¼</a> <a href="">ע�����ʺ�</a>
            </div>
        </div>
    </div>
    <div class="header">
        <div class="clearfix">
            <div class="brand">
                <a href="" title="EbSite֧������" rel="home">
                    <img src="<%=base.ThemeCss %>images/logo.png" alt="EbSite֧������">
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
                    <li><a class="current" href="BBSTaoLunGou.ashx"><span>������ҳ</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=26"><span>EbSIte2.0������</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=33"><span>c#4.0������ </span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=27"><span>������ʵ��</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=1&tid=45"><span>NET</span></a></li>
                    <li><a class="" href="BBSTaoLunGou.ashx?t=5&tid=-1"><span>��������</span></a></li>
                </ul>
                <div class="myapptrigger" onmouseover="addCssClass(this,'myapptrigger-expand')" onmouseout="removeCssClass(this,'myapptrigger-expand')">
                    <a class="myapptrigger-button" href="" id="appdock_dropdown"><span><strong>�ҵ�����</strong></span></a>
                    <div class="dropdownmenu-wrap menu-appdock" id="menu_appdock">
                        <div class="dropdownmenu">
                            <div class="clearfix dropdownmenu-inner">
                                <div class="needlogin">
                                    �㻹û�е�¼.</div>
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
                                <a class="crumbnav-label" href="javascript:void(0)" id="forumboard_menu" title="ҳ�浼��">
                                    <span>ҳ�浼��:</span></a> <a href="BBSTaoLunGou.ashx" id="max_nav_root_1"><span>EbSite��̳</span></a>
                                <span class="separator">&raquo;</span> <span class="current"><span>��ӭ���٣�������2012/12/22
                                    19:33:11 </span></span>
                            </div>
                            <div style="float: right;">
                                <div class="forumstatus">
                                    ����: <em class="numeric">0</em> , ����: <em class="numeric">0</em> , ����: <a href=""><em
                                        class="numeric">8</em></a> , ����: <em class="numeric">26</em> , �û�:<a href=""> <em
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
                                    <span class="gg-bg"></span>���� * û���κι���</div>
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
                                        <span class="ctent-title"><a href='?t=1&tid=6'>��˾��ҵ��̬ </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=22'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">Ӳ��ָ��</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 15:51:07
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=23'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">����֮��</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 15:51:19
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="ctent">
                                    <div class="ctent-top">
                                        <span class="ctent-title"><a href='?t=1&tid=24'>eBSite԰�� </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=25'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">ģ�͵�����</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:02
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=26'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">ģ��ռ�</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:05
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=27'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">Ƥ������</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:09
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
                                                <span class="ctent-title-class">����̳�</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:13
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=29'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">ģ�������</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:16
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=38'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">����ѧϰ</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:55
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="ctent">
                                    <div class="ctent-top">
                                        <span class="ctent-title"><a href='?t=1&tid=30'>Ϸ˵���� </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=31'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">����</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:24
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=32'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">�ļ�</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:28
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=33'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">�＾</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:32
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
                                                <span class="ctent-title-class">����</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:36
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="ctent">
                                    <div class="ctent-top">
                                        <span class="ctent-title"><a href='?t=1&tid=35'>IT���� </a></span>
                                    </div>
                                    <div class="bbs-ctent">
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=36'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">��ó��</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:49
                                            </div>
                                        </div>
                                        <div class="bbs-">
                                            <div class="left-bbs">
                                                <a href='?t=1&tid=37'>
                                                    <img src="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/topicicon_default.png"></img></a>
                                            </div>
                                            <div class="right-bbs">
                                                <span class="ctent-title-class">�йش���</span> ����: 0, ����: 0
                                                <br />
                                                ��󷢱�: 2011/2/22 17:48:52
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="ctent-botton">
                                    <div class="ctent-top">
                                        <span class="ctent-title">���߻�Ա ��ϸ�����б�</span>
                                    </div>
                                    <div class="ctent-botton-nr">
                                        <div class="botton-pic-a">
                                        </div>
                                        <div class="botton-title-g">
                                            ����Ա</div>
                                        <div class="botton-pic-b">
                                        </div>
                                        <div class="botton-title-g">
                                            ��������
                                        </div>
                                        <div class="botton-pic-c">
                                        </div>
                                        <div class="botton-title-g">
                                            �������
                                        </div>
                                        <div class="botton-pic-d">
                                        </div>
                                        <div class="botton-title-g">
                                            ����
                                        </div>
                                        <div class="botton-pic-e">
                                        </div>
                                        <div class="botton-title-g">
                                            ע���û�
                                        </div>
                                        <div class="botton-pic-f">
                                        </div>
                                        <div class="botton-title-g">
                                            �ο�</div>
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
                    Copyright &copy;2005 - 2011 Tencent. All Rights Reserved �����ڲ��Ƽ� ��Ȩ����
         </div>
</body>
</html>
