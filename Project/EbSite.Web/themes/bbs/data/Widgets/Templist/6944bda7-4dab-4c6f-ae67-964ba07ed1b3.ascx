<%@ Import Namespace="EbSite.BLL.GetLink"%>

                   <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("htmlname"),0)%>">
  <%#Eval("ClassName")%>
  </a>