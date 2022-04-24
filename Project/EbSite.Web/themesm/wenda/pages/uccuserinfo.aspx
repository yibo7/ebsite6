<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pagesm.uccuserinfo" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
   <div class="toolbar " id="toolbar">
  <span class="button fl backpage" >返回</span>
  <h2 class="title" >
    <%=MTitle %>
    </h2>
  <span class="button fr" url="<%=HostApi.MGetClassHref() %>" id="btnallclass">返回</span>
</div>
    <div style="padding: 3px;">
        <div class="radiusbox" style="padding: 5px;">
           
                <div>
                    <ul   class="data-list data-list-ico" >
                       
                      <li  style="background: #fff; ">
                      <a href="#">
                          <img class="ico" src="/images/menus/bar_05.gif"/>
                            <dt >用户基本设置</dt>
                            <span class="arrow"></span>
                        </a>
                        </li> 
                        <li style="background: #fff; ">
                          <a href="#">
                              <img class="ico" src="/images/menus/User.gif"/>
                                <dt >预计款管理</dt>
                                <span class="arrow"></span>
                            </a>
                        </li> 
                         <li style="background: #fff; ">
                          <a href="/md/shoucanggam.ashx">
                              <img class="ico" src="/images/menus/User.gif"/>
                                <dt >我的收藏</dt>
                                <span class="arrow"></span>
                            </a>
                        </li> 
                         <li style="background: #fff; ">
                          <a href="/md/wendaguanlim.ashx">
                              <img class="ico" src="/images/menus/2.png"/>
                                <dt >问答管理</dt>
                                <span class="arrow"></span>
                            </a>
                        </li> 
                    </ul>
                </div>
               
        </div>
    </div>
     
 <!--#include file="foot.inc" -->
</body>
</html>
