<!--#include file="top.inc" -->
<div class="top">
   
   <div class="container"  style="position:relative; ">
      
     
      <div class="top_part2">
          <a href="/"><img src="<%=base.ThemeCss %>images/logo.png"  class="logo" /></a> 
	 
		  <div class="wdinp1"  >
        <form  onsubmit="return ChkSo(this);"  method="get" action="<%=HostApi.SearchRw %>"  >
          <table>
            <tr>
              <td style="text-align:right;">
                <input type="text"  name="k" onclick="this.value=''"  value="输入问题关键词"  id="k" />
              </td>
              <td>
                <input type="text" style="display:none;" name="site" value="<%=GetSiteID%>" />
                <input type="submit"  id="btnSearch"  value=" 搜 索 " />
              </td>
            </tr>
          </table>
        </form>
      </div>  
         
      </div>


     
	   <div class="clear"></div>
      <div class="top_part3">
         <ul>
            <li ><a href="\" >首页</a></li>
           <li>
             <a href="<%=HostApi.TagsList(1)%>" >标签</a>
           </li> 
            <li><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AskHot(GetSiteID) %>" >热门话题</a></li>
            <li><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.Attractive(GetSiteID) %>" >问答达人</a></li>
             
         </ul>
      </div>
   </div>
</div>

