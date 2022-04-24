 <%@ Import Namespace="EbSite.BLL.User" %> <dd class="xixun_photo">
           <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserName").ToString())%>" target="_blank">
            <img id="Ab<%# Eval("UserName")%>" src='/themes/default/css/images/zj.jpg' width="80" />
            <script>
              document.getElementById("Ab<%# Eval("UserName")%>").src = "<%#MembershipUserEb.Instance.GetEntity(Convert.ToInt32(Eval("UserID").ToString())).AvatarBig%>? + Math.random()";
            </script>
            </a>
        </dd>
        <dd class="zixun_name">
                <a href="<%#EbSite.Base.Host.Instance.GetUserSiteUrl(Eval("UserName").ToString())%>" target="_blank">
                                            <%# Eval("UserNiName")%></a>
               </dd>
        <dd class="zixun_button">
            <a target="_blank" href="/bmask/12456-1-0c.ashx?uid=<%#Eval("UserID") %>">
                <img src="/themes/default/css/images/tw.jpg" /></a></dd>