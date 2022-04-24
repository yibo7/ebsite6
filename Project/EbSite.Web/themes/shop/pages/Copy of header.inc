<div id="top">

  <div id="top_part1">
    <div class="container aGray mtop3" >
      <div class="fLeft east f">
        <a  href="http://www.beimai.com">北迈首页</a>&nbsp;&nbsp;<a  href="javascript:favSite();">收藏本站</a>
      </div>
      <div class="fRight top_r f" id="login_infobmshop">
		  <a href='<%=EbSite.Base.Host.Instance.GetLoginApiUrl("SINA")%>'><div class="sinalogin all"></div></a>
		  <a href='<%=EbSite.Base.Host.Instance.GetLoginApiUrl("QQ")%>'><div class="qqlogin all"></div></a>
        <li class="cur">
			<a href="<%=EbSite.Base.Host.Instance.LoginRw %>" style="color:#076FA2" >登录</a>
        </li>
        <li>
			<a href="<%=EbSite.Base.Host.Instance.RegRw %>" style="color:#FF6633">注册</a>
        </li>

      </div>
    </div>
  </div>
  <div id="top_part2" class="container">
	  <form onsubmit="return ChkSo(this);" method="get" target="_so" action="<%=EbSite.Base.Host.Instance.SearchRw %>">
	  <div class="logo fLeft">
      <a href="http://www.beimai.com"><img src="<%=base.ThemeCss %>images/logo.png" /></a>
    </div>
    <div class="soinput fLeft f">
      <li>
		  <input type="text" style="display:none;" name="site" value="3" />
        <input type="text" class="inp1" id="k" name="k" value="前保险扛" />
		<input type="submit" class="sub1 all" value="" />
	  </li>
	  <li>
      热门搜索：<a  href="#">倒车镜</a>&nbsp;&nbsp;&nbsp;<a  href="#">倒车镜</a>&nbsp;&nbsp;&nbsp;<a  href="#">倒车镜</a>
    </li>
	  </form>
  </div>

</div>

<div id="top_part3" class="content">
  <div class="container ">
    <div class="bnr_fl">
      <li>
        所有商品分类 <span>CATEGORIES</span>
      </li>
      
    </div>
   
    <div  class="bnr_dh"  >
      <li class="" id="nav-home">
        <a href="/index.aspx?site=3"> 首页</a>
      </li>
      <li class="" id="nav-rushlist-3-1">
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.RushList(3)%>" >限时抢购
        </a>
        
      </li>
      <li class="" id="nav-grouplist-3-1">
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.GroupList(3)%>" >团购
        </a>
        
      </li>
      <li class="" id="nav-activities-3-0-1">
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.ActFullQuantity(3,0)%>" >优惠活动
        </a>

      </li>
      <li class="" id="nav-jifen-3">
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.JiFen(3)%>" >积分商城
        </a>

      </li>
    </div>
    <div class="bnr_gwc all">
      <li>(0)购物车</li>
      <li class="tab6">
        <a href="#">去结算</a>
      </li>
    </div>
  </div>
  
</div>

<div class="nav_box">
  <div class="hide_sort_box" style="display:none;" onfocus=""  id="hmenu" on="">
    <XS:Widget ID="Widget31" WidgetName="首页所有商品分类" WidgetID="5e8263fb-3d3c-4b27-b945-43117c9d2211"
                        runat="server" />
  </div>
</div>
<script type="text/javascript">

  var　re = new RegExp("/([^/]+)(\.ashx)$"); 
　var  r = window.location.pathname.match(re); 
   if(r!=null)
  {
    var  navId=r[1];
    var object = document.getElementById("nav-"+navId);
    if (object) object.className += " cur";
  }
　
</script>