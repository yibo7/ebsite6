<li>
    <div class="p-img">
        <a title="<%#Eval("newstitle")%>" href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id").ToString(), Eval("classid").ToString())%>"
            target="_blank">
            <img width="140" height="140" class="err-product" alt="<%#Eval("newstitle")%>" src="<%#Eval("smallpic")%>"></a></div>
    <div class="p-name">
        <a title="<%#Eval("newstitle")%>" href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id").ToString(), Eval("classid").ToString())%>"
            target="_blank">
            <%#Eval("newstitle")%></a></div>
    <div class="p-price">
        <strong class="p-price">гд<%#Eval("Annex16")%></strong>
    </div>
</li>
