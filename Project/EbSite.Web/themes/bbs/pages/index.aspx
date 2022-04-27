<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>

<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="header.inc" -->
    <script runat="server">

        string GetModerator(string Moderators)
        {
            if (!string.IsNullOrEmpty(Moderators))
            {
                return string.Concat("������", Moderators);
            }
            return string.Empty;
        }
        //string GetParentTitle(object ClassID,object ClassName,object HtmlName,object IsCanAddContent)
        //{
        //    string sTitle = string.Empty;
        //    bool blIsCanAdd = bool.Parse(IsCanAddContent.ToString());
        //    if (blIsCanAdd)
        //    {
        //        sTitle = string.Concat("<a href='", HostApi.GetClassHref(ClassID, HtmlName, 1, "", GetSiteID), "'>", ClassName, "</a>");
        //    }
        //    else
        //    {
        //        sTitle = string.Concat("<a>", ClassName, "</a>"); 
        //    }
        //    return sTitle   ;

        //}
        string GetTopicIcon(Object TodayCount)
        {
            if (!Equals(TodayCount.ToString(), "0"))
            {
                return string.Concat(base.ThemeCss, "images/icons/topicicontoday.png");
            }
            return string.Concat(base.ThemeCss, "images/icons/topicicon_default.png");
        }
    </script>

    <div class="mainX">
        <div class="mainby">
            <div class="main-left">
                <table border="0" cellspacing="0" cellpadding="0" class="mapbox">
                    <tr>
                        <td valign="top">
                            <div class="main-gg">
                                <table>
                                    <tr>
                                        <td><span class="gg-bg"></span></td>
                                        <td style="width: 100%;">
                                            <marquee scrollamount="1" style="width: 90%;" onmouseover="this.stop();" onmouseout="this.start();">�ٷ�QQ����Ⱥ:81810039</marquee>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">

                            <XS:RepeaterList ID="rpGetSubClassList" runat="server">
                                <ItemTemplate>
                                    <div class="ctent">
                                        <div class="ctent-top">
                                            <span class="ctent-title">
                                                <a href='<%#HostApi.GetClassHref(Eval("id"), Eval("HtmlName"), 1, "", GetSiteID)%>'><%#Eval("classname")%></a>
                                                <span><%#GetModerator(Eval("Annex5").ToString())%></span>
                                            </span>
                                        </div>
                                        <div class="bbs-ctent">
                                            <asp:Repeater ID="rpSub" runat="server">
                                                <ItemTemplate>
                                                    <div class="bbs-">
                                                        <div class="left-bbs">
                                                            <a href='<%#HostApi.GetClassHref(Eval("id"),Eval("HtmlName"),1,"",GetSiteID)%>'>
                                                                <img src="<%#GetTopicIcon(Eval("Annex14"))%>"></img>
                                                            </a>
                                                        </div>
                                                        <div class="right-bbs">
                                                            <span class="ctent-title-class">
                                                                <a href='<%#HostApi.GetClassHref(Eval("id"),Eval("HtmlName"),1,"",GetSiteID)%>'>
                                                                    <%#Eval("classname")%>
                                                                </a>
                                                                <em>(<%#Eval("Annex11")%>)</em>

                                                                <%#GetModerator(Eval("Annex5").ToString())%>
                                                            </span>
                                                            ����: <%#Eval("Annex12")%>, ����: <%#Eval("Annex14")%><br />
                                                            ��󷢱�: <%#Eval("Annex3")%><br />
                                                            <a style="color: #336699" href='<%#HostApi.GetContentLink(Eval("Annex1"),GetSiteID,Eval("id"))%>'><%#Eval("Annex4")%></a>

                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </XS:RepeaterList>


                            <div class="ctent">
                                <div class="indexfrdlink">
                                    <a href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).FrdlinkRw%>">��������yy</a>
                                    &nbsp;&nbsp;
                                           <a href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).FrdlinkPostRw%>">������������</a>
                                </div>
                                <div class="bbs-ctent">
                                    <XS:Widget WidgetName="��ҳ��������" WidgetID="b0e551c7-5f7d-4584-9328-43f74cfd0dc1" runat="server" />

                                </div>
                            </div>


                            <div class="ctent">
                                <div class="indexuseronline">
                                    <a href="<%=EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).UserOnlineRw%>">�ܼ�<%=CountUserOnline%>������</a>
                                </div>

                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="box_b_bc"></td>
                    </tr>
                </table>
            </div>
            <div class="main-right">
                <!---��������--->
                <div class="new-title">��������</div>
                <div class="new-lst">
                    <ol>
                        <XS:Widget ID="Widget1" WidgetName="��ҳ��������" WidgetID="fba403c7-73f6-446e-ba24-12f420c8deff" runat="server" />

                    </ol>
                </div>

                <!---������������--->
                <div class="new-title">��������</div>
                <div class="new-lst">
                    <ol>
                        <XS:Widget ID="Widget2" WidgetName="��������-��������" WidgetID="c108121c-c159-4fea-b800-6ecf849801e0" runat="server" />

                    </ol>
                </div>

                <div class="new-title"><a href="<%=HostApi.TagsList(1,GetSiteID) %>">���ű�ǩ</a>>></div>
                <div class="new-lst">
                    <ol>
                        <XS:Widget ID="Widget10" WidgetName="��ȡ���ű�ǩ" WidgetID="48a468fb-c0ba-4ebe-ad6b-b7e3f555f865" runat="server" />

                    </ol>
                </div>

                <!---���˰�--->
                <div class="new-title">����ע��</div>
                <div class="usr-list">
                    <XS:Widget ID="Widget3" WidgetName="����ע���û�" WidgetID="db1da758-1a2c-4d48-91a7-d1a9e8e55070" runat="server" />
                </div>
                <!---���˰�end--->
                <!---ͶƱ�б�--->
                <div class="new-title">��վ����</div>
                <div class="usr-list votelist">
                    <XS:Widget ID="Widget4" WidgetName="ͶƱ�б�" WidgetID="daf1b481-596f-435b-b6c8-0146802947af" runat="server" />
                </div>
                <!---ͶƱ�б�--->
            </div>

        </div>
    </div>
    <div class="clear"></div>
    <!--#include file="footer.inc" -->
    <script>
        In.ready('bbsindexjs', function () {
            //ִ�д���
        });
    </script>

</body>
</html>
