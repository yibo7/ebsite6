<!--#include file="top.inc" -->

<div class="mainbox">

  <div class="contentbox">
    <div class="header">

      <a href="/" title="EbSite֧������" class="logo">
        <img src="<%=base.ThemeCss %>images/logo.gif" alt="EbSite3.0��վ����">
      </a>

      <em>
        <form  onsubmit="return ChkSo(this);"  method="get" action="<%=HostApi.SearchRw %>"  >
          <table>
            <tr>
              <td style="text-align:right;">
                <input type="text"  name="k" onclick="this.value=''"  value="��������ؼ���"  id="k" />
              </td>
              <td>
                <input type="text" style="display:none;" name="site" value="<%=GetSiteID%>" />
                <input type="submit" id="btnSearch"  value=" �� �� " />
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
        <XS:Widget   WidgetName="����һ������"  WidgetID="2f701d33-c7e2-4d42-8638-189daeb00e82" runat="server"/>
      </div>
      <div class="splist">
        <a>ר��:</a>
        <XS:Widget   WidgetName="ר�⵼��-ȫ��"  WidgetID="1e99dc56-3a30-445c-994e-37d15f45cbaa" runat="server"/>

      </div>
    </div>

  </div>
</div>