<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.content" %>

<%@ Import Namespace="EbSite.Base.EntityAPI" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />

</head>
<body>

    <!--#include file="header.inc" -->

    <script runat="server">
        EbSite.Base.EntityAPI.MembershipUserEb mdUser(object uid)
        {
            int iuserid = int.Parse(uid.ToString());
            if (iuserid > 0)
            {
                MembershipUserEb md = HostApi.GetUserByID(iuserid);
                if (!Equals(md, null))
                    return md;
            }
            return new MembershipUserEb();


        }
        string GetReference(string Reference)
        {
            if (!string.IsNullOrEmpty(Reference))
            {
                return string.Concat("<div class='reference'>���ã�", Reference, "</div>");
            }
            return string.Empty;
        }
        string GetReplyContent(object ReplyContent, object IsDel)
        {
            if (Equals(IsDel.ToString(), "0"))
            {
                return ReplyContent.ToString();//EbSite.Core.UBB.UBBToHtml(ReplyContent.ToString());
            }
            else
            {
                return "�������ѱ�����Աɾ��";
            }


        }

    </script>

    <div id="mainX">

        <div id="mainby">
            <div>
                <div id="gotoreply" class="topiceTop"></div>
                <a href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.SavePostUrl(Model.ClassID,GetSiteID) %>">
                    <div class="topiceTop2"></div>
                </a>
                <div class="splitpages">
                    <XS:PagesContrl PageSize="10" ID="pgCtr1" runat="server" />
                </div>
            </div>
            <div class="txt-c">
                <table class="contentmain" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contentmain-left"><span class="topic-small">�Ķ�:<%=Model.hits %></span>&nbsp;|&nbsp;<span class="topic-small">�ظ�:<%=Model.CommentNum%></span></td>
                        <td class="contentmain-right posttitle">
                            <b><%=Model.NewsTitle %></b>
                            <span><a href='<%=HostApi.GetContentLink(UpModel.ID,UpModel.HtmlName,UpModel.ClassID) %>'>��һ����
                            </a></span><span><a href='<%=HostApi.GetContentLink(NextModel.ID,NextModel.HtmlName,NextModel.ClassID) %>'>��һ����
                            </a></span>
                        </td>
                    </tr>
                    <asp:PlaceHolder ID="phMainModel" runat="server">
                        <tr>
                            <td style="background: #DECCA4; height: 3px;"></td>
                            <td style="background: #F4E5C4;"></td>
                        </tr>
                        <tr>
                            <td class="contentmain-left">
                                <div class="topic-user">

                                    <a href="<%=HostApi.GetUserSiteUrl(Model.UserID)%>">
                                        <%=Model.UserNiName %>
                                    </a>
                                </div>

                                <div class="topic-user-pic">
                                    <a href="<%=HostApi.GetUserSiteUrl(Model.UserID)%>">
                                        <img src='<%=EbSite.Base.Host.Instance.AvatarBig(Model.UserID)%>' />
                                    </a>

                                </div>

                                <div>
                                    ע��ʱ�� :<%=mdUser(Model.UserID).CreateDate%>
                                    <br />
                                    �ȼ�:<%=mdUser(Model.UserID).UserLevelName%><br />
                                    ����:<%=mdUser(Model.UserID).Credits%><br />

                                </div>
                            </td>
                            <td class="contentmain-right">
                                <div class="topic-ct-r-title">
                                    <span class="topic-title1">������<%=Model.Annex4 %>[<a href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.SavePostUrl(Model.ClassID,GetSiteID,Model.ID) %>">�༭</a>] </span>
                                    <span class="ebshare">
                                        <script>ebshare();</script>
                                    </span>
                                </div>
                                <div class="bbs-line"></div>
                                <div class="topic-ct-r-content">

                                    <asp:Repeater ID="rpPageInfo" runat="server">
                                        <HeaderTemplate>
                                            <div class="booktag">
                                                <div class="booktagt">�½��б�</div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><%#Container.ItemIndex+1 %>.<a <%#bool.Parse(Eval("IsCurrent").ToString())?"class='currentpi'":""%> href="<%#Eval("Href")%>"><%#Eval("Title")%></a> </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </div>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                    <div class="replycontent">
                                        <%=ShowInfo%>
                                    </div>
                                    <div>
                                        <%if (!Equals(CPIUP, null))
       {%> <a href="<%=CPIUP.Href %>"><%=CPIUP.Title %></a> <%}%>
                                        <br />
                                        <%if (!Equals(CPINext, null))
       {%> <a href="<%=CPINext.Href %>"><%=CPINext.Title %></a> <%}%>
                                    </div>
                                    <div style="color: #ccc; padding: 10px;">
                                        <%=Model.Annex10%>
                                    </div>
                                </div>
                                <div class="topic-xgpost">
                                    <div class="title">�������</div>
                                    <table>
                                        <tr>
                                            <td>
                                                <div class="list">
                                                    <XS:Widget ID="Widget1" WidgetName="�������" WidgetID="d3bfcde7-5984-45bd-9c22-32bb11e3efd1" runat="server" />

                                                </div>
                                            </td>
                                            <td>
                                                <div class="savecontent">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <img src="<%=BarCodeImgUrl%>"></img></td>
                                                            <td>
                                                                <div class="t">
                                                                    ɨ���ά�뽫��ƪ���·��������
                                                                </div>
                                                                <div class="c">
                                                                    ������ʹ���ֻ�΢��ɨһɨ�����ֻ�UC������Ķ�ά�빦��ɨ���ά�뼴�ɽ����ֻ��档
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div class="bbs-line"></div>
                                <div class="postbttoolbar">
                                    <div class="topic-ct-copypic">
                                        <img src="<% =ThemeCss%>images/icons/posticon_reply.gif" /></div>
                                    <div style="margin-top: 3px; float: left; margin-right: 3px;">

                                        <a href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.Reply(Model.ID,GetSiteID,pgCtr1.AllCount,pgCtr1.PageSize,Model.Annex21,Model.UserID,Model.ClassID) %>">�ظ�</a>
                                    </div>
                                    <div class="ebid-postbttoolbarright">
                                        <a dataid="<%=Model.ID%>" t="1" v="<%=Model.Annex11%>">֧��<%=Model.Annex11%></a>
                                        <a dataid="<%=Model.ID%>" t="2" v="<%=Model.Annex12%>">����<%=Model.Annex12%></a>
                                        <a dataid="<%=Model.ID%>" t="3">�ٱ�</a>
                                        <a t="13">TOP</a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </asp:PlaceHolder>

                    <XS:Repeater ID="rpTopicReplies" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="background: #DECCA4; height: 3px;"></td>
                                <td style="background: #F4E5C4;"></td>
                            </tr>
                            <tr>
                                <td class="contentmain-left">
                                    <div class="topic-user">
                                        <a target="_blank" href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserID"))%>">
                                            <%#mdUser(Eval("UserID")).NiName%>
                                        </a>
                                    </div>
                                    <div class="topic-user-pic">
                                        <a target="_blank" href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserID")) %>">
                                            <img src='<%#EbSite.Base.Host.Instance.AvatarBig(int.Parse(Eval("UserID").ToString()))%>' />
                                        </a>
                                    </div>

                                    <div style="margin-left: 15px;">
                                        ע��ʱ�� :<%#mdUser(Eval("UserID")).CreateDate%>
                                        <br />
                                        �ȼ�:<%#mdUser(Eval("UserID")).UserLevelName%><br />
                                        ����:<%#mdUser(Eval("UserID")).Credits%><br />

                                    </div>
                                </td>
                                <td class="contentmain-right">
                                    <div class="topic-ct-r-title">������<%#Eval("CreatedTime")%><span class="topic-small"> [<a href="<%#EbSite.Modules.BBS.ModuleCore.GetLinks.ReplyEdite(Model.ID,GetSiteID,Model.ClassID,Eval("id")) %>">�༭</a>] </span></div>
                                    <div class="bbs-line"></div>
                                    <div class="topic-ct-r-content">
                                        <div>
                                            <%#GetReference(Eval("ReferenceContent").ToString())%>
                                        </div>
                                        <div class="replycontent">
                                            <%#GetReplyContent(Eval("ReplyContent"), Eval("DeleteFlag"))%>

                                            <br />
                                            <span style="color: #ccc"><%#Equals(Eval("CreatedTime"), Eval("UpdatedTime")) ? "" : string.Format("�������༭��{0}", Eval("UpdatedTime"))%></span>
                                        </div>
                                    </div>
                                    <div class="bbs-line"></div>
                                    <div class="postbttoolbar">
                                        <div class="topic-ct-copypic">
                                            <img src="<% =ThemeCss%>images/icons/posticon_reply.gif" /></div>
                                        <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                            <a href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.Reply(Model.ID,GetSiteID,pgCtr1.AllCount,pgCtr1.PageSize,Model.Annex21,Model.UserID,Model.ClassID) %>">�ظ�</a>
                                        </div>
                                        <div class="topic-ct-copypic">
                                            <img src="<% =ThemeCss%>images/icons/posticon_quote.gif" /></div>
                                        <div style="margin-top: 3px; float: left; margin-right: 3px;">
                                            <a href="<%#EbSite.Modules.BBS.ModuleCore.GetLinks.Reply(Model.ID,GetSiteID,Eval("id"),pgCtr1.AllCount,pgCtr1.PageSize,Model.Annex21,Model.UserID,Model.ClassID) %>">����</a>
                                        </div>
                                        <div class="ebid-postbttoolbarright">
                                            <a t="10" dataid="<%#Eval("id")%>" v="<%#Eval("IsGoodCount")%>">֧��<%#Eval("IsGoodCount")%></a>
                                            <a t="11" dataid="<%#Eval("id")%>" v="<%#Eval("IsBadCount")%>">����<%#Eval("IsBadCount")%></a>
                                            <a t="12" dataid="<%#Eval("id")%>">�ٱ�</a>
                                            <a t="13">TOP</a>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                        </ItemTemplate>
                    </XS:Repeater>



                </table>
                <div>
                    <a href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.SavePostUrl(Model.ClassID,GetSiteID) %>">
                        <div class="topiceTop2">
                        </div>
                    </a>
                    <div class="splitpages" style="float: right; font-size: 14px; margin-top: 10px;">

                        <XS:PagesContrl ID="pgCtr2" runat="server" />
                    </div>
                </div>

                <table class="contentmain" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="contentmain-left"></td>
                        <td class="contentmain-right">
                            <div>
                                ��ǰΪ���ٻظ�ģʽ,��Ҳ����<a href="<%=EbSite.Modules.BBS.ModuleCore.GetLinks.Reply(Model.ID,GetSiteID,pgCtr1.AllCount,pgCtr1.PageSize,Model.Annex21,Model.UserID,Model.ClassID) %>">����߼�ģʽ</a>�ظ�

                            </div>
                            <div>
                                <%-- <form  runat="server">
                         <XS:UMEditor ViewStateMode="Disabled" ID="edtContentInfo"  Height="300" runat="server"></XS:UMEditor>
                    </form>--%>
                                <link type="text/css" href="<%=IISPath%>js/umeditor/themes/default/css/umeditor.css" rel="stylesheet" />
                                <script src="<%=IISPath%>js/umeditor/umeditor.config.js" type="text/javascript"></script>
                                <script src="<%=IISPath%>js/umeditor/umeditor.min.js" type="text/javascript"></script>
                                <script id="edtContentInfo" name="edtContentInfo" type="text/plain" style="width: 100%; height: 300px"></script>
                                <script type="text/javascript">var edtContentInfo = UM.getEditor('edtContentInfo');</script>
                            </div>
                            <div>

                                <input id="btnSavePost" type="button" value=" ����ظ� " />

                            </div>
                        </td>
                    </tr>
                </table>
            </div>





        </div>
    </div>

    <script>
        var postid = <%=iRequestID%>;
        var pAllCount = <%=pgCtr1.AllCount %>;
        var pPageSize = <%=pgCtr1.PageSize %>;
        var SiteID = <%=GetSiteID %>;
        var ClassID = <%=Model.ClassID %>;
        var IsReSendEmail =  <%=Model.Annex21 %>;
        var ModelUserID = <%=Model.UserID %>;
    </script>
    <script type="text/javascript" src="<%=IISPath%>js/ueditor/ueditor.parse.min.js"></script>
    <script src="<%=this.ThemePage%>content.js" type="text/javascript"></script>

    <!--#include file="footer.inc" -->

    <span runat="server" id="datacount"></span>


</body>
</html>
