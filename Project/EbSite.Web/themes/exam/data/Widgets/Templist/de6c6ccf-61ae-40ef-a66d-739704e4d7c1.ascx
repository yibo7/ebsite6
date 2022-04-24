<%@ Import Namespace="EbSite.BLL.GetLink"%>
<li>
<span class="date">
<%# DateTime.Parse(Eval("addtime").ToString()).ToString("MM-dd")%></a>
</span>
<a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>"><%# Eval("newstitle")%></a>
</li>