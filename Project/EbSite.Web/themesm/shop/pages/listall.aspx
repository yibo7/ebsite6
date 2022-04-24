<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
</head>
<body>
    <div id="page">
        <div style="width:100%;height:auto;position:fixed;top:0px;left:0px;z-index:500;">
    <!--#include file="header.inc" -->
    <div class="w-navigator">
        <a href="<%=HostApi.MGetIndexHref() %>">��ҳ</a><b>|</b>
        <a href="<%=HostApi.MGetSpecialHref() %>">ר��</a><b>|</b>
        <a href="<%=HostApi.MUccIndexRw %>">�ҵ�����<span class="unread"></span></a>
    </div>
            </div>
    <div id="container1" style="z-index:100;margin-top:88px;">
        <ul class="data-list">
            <XS:RepeaterList ID="rpGetSubClassList" runat="server">
                <ItemTemplate>
                    <li class="listitem-classname" id="<%# Eval("id") %>" url="<%#EbSite.Base.Host.Instance.MGetClassHref(Eval("id"), 1, 0,int.Parse( Eval("siteid").ToString())) %>">
                        <span class="classname"><%#Eval("ClassName")%></span>
                        <span class="arrow"></span>
                    </li>
                </ItemTemplate>
            </XS:RepeaterList>

        </ul>
    </div>
    </div>

    <div class="rightpanel" style="padding:0px;height:500px;overflow-y:auto;width:200px; position:fixed;top:88px; right:0px;">
            <h2><%=Model.ClassName %></h2>
            <div class="duanxian"><div class="changxian"></div></div>
    </div>

    <!--#include file="foot.inc" -->
    <script type="text/javascript">
        toggleright2("listitem-classname", "rightpanel", "cont", "right",<%=EbSite.Base.Host.Instance.GetSiteID %>);

      

        //����toolbar
        $('#toolbar').toolbar().fix({ top: 0 });

        //������� (��fixed��λ��toolbar�Ļ���Ҫ����)
        $('#pageswipe').pageswipe({
            toolbar: '#toolbar'
        });
        $('#btnloadclass').click(function () {
            $('#pageswipe').pageswipe('toggle');

        });
        $('#Span1').click(function () {
            $('#pageswipe').pageswipe('toggle');

        });

        //function ToggleItemList(obj) {
        //    $(obj).parent("li").children("ul").toggle();
        //}
    </script>
    <%=KeepUserState()%>
</body>
</html>
