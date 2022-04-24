<%@ Import Namespace="EbSite.BLL.GetLink"%>
<ul class="addlist">
                  <div class="litimg">
                    <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>" class="tooltip">
                    <img src="/<%#Eval("smallpic")%>" width="172" height="162"/></a>
                  </div>
                  <div class="techdes">
                    <div class="addinfo">加入时间：<%#Eval("addtime")%></div>
                    <ul>
                      <li class="dtitle"><a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>"><%#Eval("newstitle")%></a></li>
                      <li>技术评分：<img src="/images/star_7.gif" width="91" height="19" /></li>
                      <li>浏览次数： <%#Eval("hits")%></li>
                      <li>网站简介：<%#Eval("contentinfo")%></li>
                    </ul>
                  </div>
                  <div class="clear"></div>
          
                </ul>