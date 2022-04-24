<!--#include file="top.inc" -->

<div class="mainbox">

  <div class="contentbox">
    <div class="header">

      <a href="/" title="EbSite支持社区" class="logo">
        <img src="<%=base.ThemeCss %>images/logo.gif" alt="eBExam在线考试系统">
      </a>

      <em>
        <form  onsubmit="return ChkSo(this);"  method="get" action=""
          <%=HostApi.SearchRw %>"  >
          <table>
            <tr>
              <td>
                <input type="text"  name="k" onclick="this.value=''"  value="输入问题关键词"  id="k" />
              </td>
              <td>
                <input type="text" style="display:none;" name="site" value=""<%=GetSiteID%>" />
                <input type="submit" id="btnSearch"  value=" 搜 索 " />
              </td>
            </tr>

          </table>
        </form>

      </em>

    </div>

  </div>

  <div class="contentbox">
    <div class="nav">
      <div class="majornav">
        <XS:Widget   WidgetName="导航一级分类"  WidgetID="2f701d33-c7e2-4d42-8638-189daeb00e82" runat="server"/>
      </div>
      <div class="splist">
        <%=GetNav("&raquo;",true)%>
      </div>
    </div>

  </div>
</div>