<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Import Namespace="EbSite.BLL.User" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <div id="tagsask" class="lb_top3ex">
                        <div name="tg0" style="cursor: pointer;" u="<%=EbSite.Base.Host.Instance.GetClassHref(GetClassID,1)%>?"
                            class="focus">
                            最近问题
                        </div>
                        <div name="tg1" style="cursor: pointer;" u="<%=EbSite.BLL.GetLink.LinkClass.Instance.GetReWriteInstance(CurrentSite.id).GetClassHref(GetClassID,1)%>?listt=1">
                            待解决问题
                        </div>
                        <div name="tg2" style="cursor: pointer;" u="<%=EbSite.BLL.GetLink.LinkClass.Instance.GetReWriteInstance(CurrentSite.id).GetClassHref(GetClassID,1)%>?listt=2">
                            已解决问题
                        </div>
                        <div name="tg3" style="cursor: pointer;" u="<%=EbSite.BLL.GetLink.LinkClass.Instance.GetReWriteInstance(CurrentSite.id).GetClassHref(GetClassID,1)%>?listt=3">
                            悬赏问题
                        </div>
                    </div>
                    <div class="alldatalistbox">
                        <XS:RepeaterList ID="rpGetClassList"  runat="server">

                         <ItemTemplate>
                                <div class="tab2_one">
                                    <div class="tab2_photo">
                                        <li><a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("UserID")) %>">
                                            <img  src='<%#EbSite.Base.Host.Instance.AvatarBig(int.Parse(Eval("UserID").ToString()))%>'
                                                width="55" />
                                        </a></li>
                                        <li class="tadivf">
                                            <div id="sh_<%#Eval("id") %>" style="<%#Equals(Eval("annex4"),"2")?"display:none":"display:block" %>" >
                                                <a href="javascript:;" onclick="showHF(<%#Eval("id") %>,<%#Eval("userid") %>)">
                                                    <img src="<%=base.ThemeCss %>images/12.png" /></a></div>
                                            <div style="display:none;" id="cl_<%#Eval("id") %>">
                                                <a href="javascript:;" onclick="ColseHF(<%#Eval("id") %> )">
                                                    <img src="<%=base.ThemeCss %>images/12-1.png" />
                                                </a>
                                            </div>
                                        </li>
                                    </div>
                                    <div class="tab2_name">
                                        <div class="tab2_que">
                                            <li>问题:<a href="<%#HostApi.GetContentLink(Eval("id"),GetSiteID)%>">
                                                <%#Eval("newstitle") %>?</a></li></div>
                                        <div class="tab2_min">
                                            <li>提问：</li><li><a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("UserID")) %>">
                                                <%#Eval("userniname") %></a></li><li style="width: 20px;"></li>
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
                                   <div id="hf<%#Eval("id") %>" style="display: none; height:38px;" class="normal">
                                        <div class="normalarrow">
                                        </div>
                                        <input type="question" id="answerinfo<%#Eval("id") %>" class="answerques" />
                                        <div class="anserbtn allpic"  onclick="askfun(<%#Eval("id") %>,<%#Eval("userid") %>)"> 
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                           
                        </XS:RepeaterList>
                    </div>
                    <%--<div class="loadingbtn">
                        <input type="button" value="点击加载更多" />
                    </div>--%>
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
                您可以快速知道您爱车的故障所在及解决方法
            </div>
            <div class="clear">
            </div>
            <div class="clear">
            </div>
            <div class="bor_c">
                <div class="crtabtop">
                    <%=Model.ClassName%>
                    热门问题</div>
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
   <span runat="server" id="datacount"></span>
    <script type="text/javascript" src="<%= base.ThemePage%>index.js"></script>
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
