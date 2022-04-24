<%@ Import Namespace="EbSite.BLL.GetLink"%>

            <li class="<%#EbSite.Base.Host.Instance.GetCurrentClass(Eval("ID"),"current")%>" >       <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("htmlname"),0)%>">
  <%#Eval("ClassName")%>
  </a></li>