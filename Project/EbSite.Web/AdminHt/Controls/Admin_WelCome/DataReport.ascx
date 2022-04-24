<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataReport.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_WelCome.ServerInfo" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 <div style="width:100%; text-align:center;">

 <div style=" text-align:center; width:80%; font-weight:bold; font-size:20px; padding:20px;">
        网站数据报表
    </div>
     <table class="datareport" cellpadding="0" cellspacing="0">
      <tr>
            <td class="header">
                 &nbsp;&nbsp;
            </td>
            <td class="header">
                 今日
            </td>
            <td class="header">
                 本周
            </td>
            <td class="header">
                 本月
            </td>
             <td class="header">
                 本季
            </td>
            <td class="header">
                 本年
            </td>
            <td class="header">
                 汇总
            </td>
        </tr>
        <%=GetContentCount%>
        <tr>
            <td class="header">
                 网站分类
            </td>
            <td >
                 <%=EbSite.BLL.NewsClass.GetCountByToday(base.GetSiteID)%>
            </td>
            <td>
                 <%=EbSite.BLL.NewsClass.GetCountByWeek(base.GetSiteID)%>
            </td>
            <td>
                 <%=EbSite.BLL.NewsClass.GetCountByMonth(base.GetSiteID)%>
            </td>
            <td>
                 <%=EbSite.BLL.NewsClass.GetCountByQuarter(base.GetSiteID)%>
            </td>
            <td>
                 <%=EbSite.BLL.NewsClass.GetCountByYear(base.GetSiteID)%>
            </td>
            <td>
                 <%=EbSite.BLL.NewsClass.GetCountAll(base.GetSiteID)%>
            </td>
        </tr>
        <tr>
            <td class="header">
                 注册会员
            </td>
            <td>
                 <%=EbSite.BLL.User.MembershipUserEb.Instance.GetCountByToday%>
            </td>
            <td>
                 <%=EbSite.BLL.User.MembershipUserEb.Instance.GetCountByWeek%>
            </td>
            <td>
                 <%=EbSite.BLL.User.MembershipUserEb.Instance.GetCountByMonth%>
            </td>
             <td>
                 <%=EbSite.BLL.User.MembershipUserEb.Instance.GetCountByQuarter%>
            </td>
            <td>
                 <%=EbSite.BLL.User.MembershipUserEb.Instance.GetCountByYear%>
            </td>
            <td>
                 <%=EbSite.BLL.User.MembershipUserEb.Instance.GetCountAll%>
            </td>
        </tr>
     </table>

     <div style="text-align:right; width:80%; padding:5px; ">
        本报表数据统计于:<%=DateTime.Now %>
     </div>
 
 </div>


    