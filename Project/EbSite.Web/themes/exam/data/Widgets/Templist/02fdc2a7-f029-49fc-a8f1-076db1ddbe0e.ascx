<%@ Import Namespace="EbSite.BLL.GetLink"%>
<ul class="addlist">
                  <div class="litimg">
                    <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>" class="tooltip">
                    <img src="/<%#Eval("smallpic")%>" width="172" height="162"/></a>
                  </div>
                  <div class="techdes">
                    <div class="addinfo">����ʱ�䣺<%#Eval("addtime")%></div>
                    <ul>
                      <li class="dtitle"><a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>"><%#Eval("newstitle")%></a></li>
                      <li>�������֣�<img src="/images/star_7.gif" width="91" height="19" /></li>
                      <li>��������� <%#Eval("hits")%></li>
                      <li>��վ��飺<%#Eval("contentinfo")%></li>
                    </ul>
                  </div>
                  <div class="clear"></div>
          
                </ul>