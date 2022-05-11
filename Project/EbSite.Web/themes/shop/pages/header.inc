<div id="top">
  <!--#include file="headersmall.inc"-->

  <div id="top_part2" class="container">
	  <form onsubmit="return ChkSo(this);" method="get" target="_so" action="<%=HostApi.SearchRw %>">
	  <div class="logo fLeft">
      <a href="/"><img src="<%=base.ThemeCss %>images/logo.png" /></a>
    </div>
    <div class="soinput fLeft f">
      <li>
		  <input type="text" style="display:none;" name="site" value="<%=GetSiteID %>" />
        <input type="text" class="inp1" id="k" name="k" value="请输入关键词" />
		<input type="submit" class="sub1 all" value="" id="btnheadseach" />
	  </li>
	  <li>
      热门搜索：<span id="seachhotkey"><a onclick="searchkeyword(this)" >倒车镜</a>&nbsp;&nbsp;&nbsp;<a  onclick="searchkeyword(this)">发电机</a>&nbsp;&nbsp;&nbsp;<a  onclick="searchkeyword(this)" >前大灯</a></span>
    </li>
	  </form>
  </div>

</div>

<div id="top_part3" class="eb-content">
  <div class="container ">
    <a  href="<%=HostApi.GetAllClassHref() %>">
      <div class="bnr_fl">
        <li>
       所有商品分类 <span>CATEGORIES</span>
    </li>
    </div>
    </a>
    <div  class="bnr_dh"  >
      <li>
        <a href="<%=HostApi.GetMainIndexHref(GetSiteID) %>">首页</a>
      </li>
      <li>
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.RushList(GetSiteID)%>" >限时抢购</a>
      </li>
      <li>
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GroupList(GetSiteID)%>" >团购</a>
      </li>
      <li>
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ActFullQuantity(GetSiteID,0)%>" >优惠活动</a>
      </li>
      <li>
        <a href="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.JiFen(GetSiteID)%>" >积分商城</a>
      </li>
    </div>
    <div id="ebshowcartinfo" class="bnr_gwc all">
      <li>(0)购物车</li>
      <li class="tab6">
        <a href="#">去结算</a>
      </li>
    </div>
  </div>
  
</div>

