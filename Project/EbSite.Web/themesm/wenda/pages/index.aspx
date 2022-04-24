<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.index" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server">
    <script type="text/C#" runat="server">
        public string tagky = "";
        new protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            string mindex = HostApi.MGetIndexHref();
            tagky = string.Concat(mindex, "?p={0}");
            string sType = Request["t"];

            if (!string.IsNullOrEmpty(sType))
            {
                if (sType == "1") //��������
                {
                    tagky = string.Concat(mindex, "?p={0}&t=1");
                }
                if (sType == "2") //�����
                {
                    string.Concat(mindex, "?p={0}&t=2");
                }

            }
            this.pgCtr.ReWritePatchUrl = tagky;
        }
    </script>
</head>
<body>
    <!--#include file="header.inc" -->
    <div class="w-navigator">
        <a href="<%=HostApi.MGetSpecialHref() %>">ר��</a><b>|</b> <a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.MAskPost(GetSiteID) %>">����</a><b>|</b> <a href="<%=HostApi.MUccIndexRw %>">�ҵ�����<span class="unread"></span></a>
    </div>
    <div style="margin-top: 5px;" class="content">
        <div class="w-home-search">
            <form action="<%=EbSite.Base.Host.Instance.MSearchRw %>" method="get">
            <input type="submit" value=" �� �� " alog-alias="search">
            <div class="input">
                <div class="ui-input-mask" style="height: 45px;">
                    <input name="k" type="text" autocomplete="off" autocorrect="off" maxlength="100"
                        placeholder="�������������⡭" style="position: absolute; top: 0px; left: 0px; width: auto;
                        right: 40px;">
                    <input type="hidden" name="site" value="<%=GetSiteID %>" />
                    <div class="ui-quickdelete-button" style="height: 20px; width: 20px; top: 13px; right: 10px;">
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
    <div style="padding: 10px;">
        <div class="radiusbox">
            <div id="pageswipe">
              
                    <nav style="margin-top: 40px;" class="w-nav"> 
        <a id="tg0" href="?t=0" <%=EbSite.Base.Host.Instance.GetCurrentCSS("0","cur","t") %>  >����<span></span>
        <div></div>
        </a> 
        <a id="tg1" href="?t=1" <%=EbSite.Base.Host.Instance.GetCurrentCSS("1","cur","t") %>   >������<div></div></a> 
        <a id="tg2" href="?t=2" <%=EbSite.Base.Host.Instance.GetCurrentCSS("2","cur","t") %>  >������<div></div></a>
        </nav>
                    <ul style="margin-top: 10px;" class="data-list">
                        
                       
                                <XS:Repeater runat="server" ID="rpList">
                                    <ItemTemplate>
                                        <li><a href="<%#EbSite.Base.Host.Instance.MGetContentLink(Eval("ID")) %>">
                                            <dt>
                                                <%#Eval("NewsTitle")%></dt>
                                            <dd class="content">
                                                <%--  <%# EbSite.Core.UBB.ClearUBB(EbSite.Core.Strings.GetString.CutLen(Eval("ContentInfo").ToString(), 30))%>--%>
                                            </dd>
                                            <dd class="source">
                                                ���ʣ�<%#Eval("UserNiName")%>&nbsp;&nbsp;ʱ��:<%#DateTime.Parse( Eval("AddTime").ToString()).ToShortDateString()%>&nbsp;&nbsp;�ش�:  <%#Eval("annex11") %></dd>
                                        </a>
                                        <span class="arrow"></span>
                                        </li>
                                    </ItemTemplate>
                                </XS:Repeater>
                            </ul>
                           
                        <div style="background: #300701;color: #fff;" class="btnloadmore">
                          ������ظ���
                        </div>
                       
                            <XS:PagesContrl PageSize="5" ID="pgCtr" ReWritePatchUrl="10index.ashx?p={0}" runat="server" />
                        
                </div>
            </div>
        </div>

    <!--#include file="foot.inc" -->
    
    <script>loadpage(".data-list", ".btnloadmore", '.data-list li')</script>  

</body>
</html>

