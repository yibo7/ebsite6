<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Wenda.ModuleCore.Pages.maskhot" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>热门话题_汽车维修问答</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta name="keywords" content="问答,问答网,汽车维修,汽车维修问答" />
    <meta name="Description" content="问答网,一个专业的汽车问答门户网站！拥有多名国内外知名专家任您挑选，电话一对一服务。" />
</head>
<body>
    <!--#include file="header.inc"-->
    <div class="content" style="width: 990px; margin: 8px auto;">
        <div style="width: 100%;">
            <div class="l_top" style="padding: 10px;width:968px;">
                <li class="f_s14"><a href="<%=DomainName%>"><b>
                    <%=SiteName%></b></a> >热门话题 </li>
            </div>
            <div class="l_top3" style="z-index: 0;">
                <div class="zhuyi">
                    <table class="GridView" cellspacing="0" rules="all" border="1" style="border-collapse: collapse;">
                        <tr class="GridViewHeader">
                            <th scope="col" width=69%>
                                标题
                            </th>
                            <th scope="col"  width=10%>
                                提问时间
                            </th>
                            <th scope="col"  width=10%>
                                作者
                            </th>
                            <th scope="col"  width=10%>
                                浏览/回答
                            </th>
                        </tr>
                        
                            <XS:Repeater ID="rpHotList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),1)%>">
                                                <%#Eval("newstitle") %></a>
                                        </td>
                                        <td>
                                            <%#string.Format("{0:d}",Convert.ToDateTime( Eval("addtime")))  %>
                                        </td>
                                        <td>
                                         <a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("UserID")) %>">   <%#Eval("UserNiName")%></a>
                                        </td>
                                        <td>
                                            <%#Eval("hits")%>/<%#Eval("Annex11")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </XS:Repeater>
                       
                    </table>
                    <div style="float: right; display: none;">
                        <XS:PagesContrl ID="pgCtr" runat="server" />
                    </div>
                </div>
            </div>
            <div style="width: 100%;" class="line">
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <div style="top: 1475px;" id="foot">
    </div>
    <!--#include file="footer.inc" -->
   <span runat="server" id="datacount"></span>
</body>
</html>
