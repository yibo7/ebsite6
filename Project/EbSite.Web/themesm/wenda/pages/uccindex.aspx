<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pagesm.uccindex" %>
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
      <%--<span class="button fr" url="<%=HostApi.MGetClassHref() %>" id="btnallclass">返回</span>
--%>
 <span class="button fr" url="<%=EbSite.Base.AppStartInit.IISPath%>LogOut.aspx" id="">退出</span>
</div>
     <div style="padding: 3px;">
        <div class="radiusbox" style="padding: 5px;">
           
                <div>
                    <ul   class="data-list data-list-img" >
                      <li style="background: #fff; border: none">
                      <a href="<%=HostApi.MUccUserInfoRw %>">
                          <img   src="<%=HostApi.AvatarBig(UserID) %>"/>
                            <dt><%=UserNiName%></dt>
                            <dd class="eb-content">
                              帐号:<%=UserName%>
                            </dd>
                            <dd class="source">积分：<%=Credits %>&nbsp;&nbsp;级别:<%=UserLevelName%></dd>
                            <span class="arrow"></span>
                        </a>
                        </li> 
                    </ul>
                </div>
               
        </div>
    </div>
    <div style="padding: 3px;">
        <div class="radiusbox" style="padding: 5px;">
           
                <div>
                    <ul   class="data-list data-list-ico" >
                         <asp:Repeater ID="rpModuleMenus" runat="server"  >
                            <ItemTemplate>                                   
                                 <li  style="background: #fff; ">
                                  <a href="<%#Eval("Url")%>">
                                      <img class="ico" src="<%#Eval("imageurl")%>"/>
                                        <dt ><%#Eval("MenuName")%></dt>
                                        <span class="arrow"></span>
                                    </a>
                                  </li> 
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
               
        </div>
    </div>
     
 <!--#include file="foot.inc" -->
</body>
</html>
