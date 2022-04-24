

<li>
    <span class="date"><%#DateTime.Parse(Eval("addtime").ToString()).ToString("MM-dd")%></span>
     <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%# Eval("newstitle")%></a>
</li>