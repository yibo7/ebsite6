<div id="top_part1">
  <div class="container aGray mtop3" >
    <div class="fLeft east f">
      <a  href="/">首页</a>&nbsp;&nbsp;<a  href="javascript:favSite();">收藏本站</a>&nbsp;&nbsp;<a href='<%=HostApi.MGetIndexHref() %>'>手机版</a>
    </div>
    <div class="fRight top_r f" id="login_infobmshop">
      <a href=''
        <%=EbSite.Base.Host.Instance.GetLoginApiUrl("SINA")%>'><div class="sinalogin all"></div>
      </a>
      <a href=''
        <%=EbSite.Base.Host.Instance.GetLoginApiUrl("QQ")%>'><div class="qqlogin all"></div>
      </a>
      <li class="cur">
        <a href=""
          <%=EbSite.Base.Host.Instance.LoginRw %>" style="color:#076FA2" >登录
        </a>
      </li>
      <li>
        <a href=""
          <%=EbSite.Base.Host.Instance.RegRw %>" style="color:#FF6633">注册
        </a>
      </li>

    </div>
  </div>
</div>