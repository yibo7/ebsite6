<%@ Import Namespace="EbSite.BLL.GetLink"%>

 <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Convert.ToInt32( Eval("ID").ToString()),1,Convert.ToInt32( Eval("siteid").ToString()))%>"><%#Eval("classname")%></a>