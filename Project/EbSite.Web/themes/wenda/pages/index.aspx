<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.index" %>

<%@ Import Namespace="EbSite.BLL.User" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<%@ Register TagPrefix="XSM" Assembly="EbSite.Modules.Wenda" Namespace="EbSite.Modules.Wenda.Ctrs" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
     <script type="text/C#" runat="server">
   
        public string tagky = "/wenda/{0}-index.ashx";
        new  protected void Page_Load(object sender,EventArgs e)
        {
            base.Page_Load(sender,e);
            string sType = Request["listt"];

            if (!string.IsNullOrEmpty(sType))
            {
                if (sType == "1") //悬赏问题
                {
                    tagky = "/index.aspx?site=10&listt=1&tagname=tg1&p={0}";
                }
                if (sType == "2") //待解决
                {
                    tagky = "/index.aspx?site=10&listt=2&tagname=tg2&p={0}";
                }
                if (sType == "3") //已解决
                {
                    tagky = "/index.aspx?site=10&listt=3&tagname=tg3&p={0}";
                }
            }
           this.pgCtr.ReWritePatchUrl = tagky;
        }
    </script>
</head>
<body>

    <!--#include file="header.inc"-->
    <div class="content" style="width: 990px; margin: 8px auto;">
        <div class="c_left">
            <div class="l_top m_top5" style="z-index: 0;">
                
                <!--切换title--->
                <div class="zhuyi" style="float: left; padding-top: 5px;">
                    <div id="tagsask" class="ttl queType" style="background: #FCFCFC; height: 31px;">
                        <div name="tg0" style="cursor: pointer;" u="?site=10" class="focus">
                            最近问题
                        </div>
                        <div name="tg1" style="cursor: pointer;" u="?site=10&listt=1">
                            待解决问题
                        </div>
                        <div name="tg2" style="cursor: pointer;" u="?site=10&listt=2">
                            已解决问题
                        </div>
                        <div name="tg3" style="cursor: pointer;" u="?site=10&listt=3">
                            悬赏问题
                        </div>
                    </div>
                    <div class="alldatalistbox">
                        <XSD:RepeaterIndex ID="rpGetClassList" runat="server">
                            <ItemTemplate>
                                <div class="tab2_one">
                                    <div class="tab2_photo">
                                        <li><a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("UserID")) %>">
                                            <img src='<%#EbSite.Base.Host.Instance.AvatarBig(int.Parse(Eval("UserID").ToString()))%>'
                                                width="55" />
                                        </a></li>
                                        <li class="tadivf">
                                            <div id="sh_<%#Eval("id") %>" style="<%#Equals(Eval("annex21"),"2")?"display:none": "display:block" %>">
                                                <a href="javascript:;" onclick="showHF(<%#Eval("id") %>,<%#Eval("userid") %>)">
                                                    <img src="<%=base.ThemeCss %>images/12.png" /></a></div>
                                            <div style="display: none;" id="cl_<%#Eval("id") %>">
                                                <a href="javascript:;" onclick="ColseHF(<%#Eval("id") %> )">
                                                    <img src="<%=base.ThemeCss %>images/12-1.png" />
                                                </a>
                                            </div>
                                        </li>
                                    </div>
                                    <div class="tab2_name">
                                        <div class="tab2_que">
                                            <li>问题: <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),1)%>">
                                                <%#Eval("newstitle") %>?</a></li></div>
                                        <div class="tab2_min">
                                            <li>提问：</li><li><a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("UserID")) %>">
                                                <%#Eval("UserNiName")%></a></li><li style="width: 20px;"></li>
                                            <li>时间：</li><li>
                                                <%#Eval("addtime") %></li>
                                        </div>
                                    </div>
                                    <div class="tab2_pic2  f_r">
                                        <div>
                                            <image src="<%=base.ThemeCss%>images/<%#Equals(Eval("annex11"),0)?"noask":"ask" %>.png" />
                                        </div>
                                        <div style="padding-top: 5px;">
                                            回答<font color="#ff0000"><%#Eval("annex11") %></font>个
                                        </div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div id="hf<%#Eval("id") %>" style="display: none;" class="normal">
                                        <div class="normalarrow">
                                        </div>
                                        <input type="question" id="answerinfo<%#Eval("id") %>" class="answerques" />
                                        <div class="anserbtn allpic" onclick="askfun(<%#Eval("id") %>,<%#Eval("userid") %>)">
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </XSD:RepeaterIndex>
                    </div>
                    <div class="loadingbtn">
                        <input type="button" value="点击加载更多" />
                    </div>
                    <div class="pageindex">
                        <XS:PagesContrl PageSize="20" ID="pgCtr" ReWritePatchUrl="/wenda/{0}-index.ashx" runat="server" />
                    </div>
                </div>
            </div>
         
            <div class="line">
            </div>
        </div>
        <div class="c_right">
            <div style="margin-top: 3px;" class="crtab2 ">
                <a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AskPost(GetSiteID) %>">
                    <img src="<%=base.ThemeCss %>images/bnr5.png" title="点击这里，可迅速提问自己的问题。" /></a>
                您可以快速知道您爱车的故障所在及解决方法
            </div>
            <div style="height: 5px;" class="clear">
            </div>
            <div class="bor_c" style="margin-top: 0px;">
                <div class="crtabtop">
                    专家在线</div>
                <XS:Widget ID="Widget3"  WidgetName="问答首页专家" WidgetID="c3caec92-9bcd-4a05-b804-1dc915cc65dd"
                    runat="server" />
            </div>
            <div class="bor_c">
                <div class="crtabtop">
                    <div style="float: left;">
                        问答分类</div>
                </div>
                <div class="wdclass">
                    <XS:Widget ID="Widget2" WidgetName="右侧菜单" WidgetID="b2913fa5-7823-49dc-9190-dbd604eb1b8a" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <!--#include file="footer.inc" -->
    <script type="text/javascript" src="<%= base.ThemePage%>index.js"></script>
    <script>
        var SiteConfigsY = { askuseridY: ExUsrID }; 
    </script>
   
</body>
</html>
