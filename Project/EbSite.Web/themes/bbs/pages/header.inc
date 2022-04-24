
<div class="toolbar">
  <div class="clearfix">
    <ul id="topLinks" class="accesslink">
      <li>
        <a href="<%=HostApi.Domain %>">
          <span>首页</span>
        </a>
      </li>
      <li>
        <a href="<%=HostApi.MGetIndexHref() %>" target="_blank">
          <span>手机版</span>
        </a>
      </li>
    
    </ul>
    <div id="login_info" class="userbar">
      <a href="<%=HostApi.LoginRw %>">登录</a>
      <a href="<%=HostApi.RegRw %>">注册</a>
      </a>
    </div>
  </div>
</div>

<div class="header">
  <div class="clearfix">
    <div class="brand"><a href="/"  rel="home"><img src="<%=base.ThemeCss %>images/logo.png"  ></a></div>
    
  </div>
  <div class="mobileimg">
    <table>
      <tr>
        <td>
          <img src="<%=HostApi.MobileBarcode %>"></img>
        </td>
        <td>手机扫一扫
        <br/>访问手机版
        </td>
      </tr>
     
    </table>
  </div>
</div>

<div class="nav">
  <div class="majornav">
    <div class="majornav-inner">
      <ul class="majornav-list">
        <li><a class="current" href="/"><span>社区首页</span></a></li>
         
      </ul>
      
    </div>
    <div class="extranav">
      <div class="subnav-wrap">
        <div class="subnav">
          <div class="subnav-inner">
            <div class="crumbnav">
              <a class="crumbnav-label" href="javascript:void(0)" id="forumboard_menu" title="页面导航">
                <span>页面导航:</span>
              </a>
              <%=GetNav("&raquo;",true)%>
            </div>
            <div style="float: right;">
              <div class="forumstatus">
                <form  onsubmit="return ChkSo(this);"  method="get" action="<%=HostApi.SearchRw %>"  >
                  <table>
                    <tr>
                      <td>
                        <input type="text"  name="k" onclick="this.value=''"  value="输入问题关键词"  id="k" />
                      </td>
                      <td>
                        <input type="text" style="display:none;" name="site" value="<%=GetSiteID%>" />
                          <input type="submit" id="btnSearch"  value=" 搜 索 " />
                      </td>
                    </tr>
                  
                  </table>
                  </form>

                </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>