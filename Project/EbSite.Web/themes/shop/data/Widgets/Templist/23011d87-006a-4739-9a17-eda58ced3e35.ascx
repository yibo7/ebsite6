<%@ Import Namespace="EbSite.BLL.GetLink"%>
<div class="prolist">
<ul>
 <li>  <h3> <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("htmlname"),0)%>">
  <%#Eval("ClassName")%>
  </a></h3></li>
<asp:PlaceHolder ID="phList" runat="server"></asp:PlaceHolder>

</ul>
</div>