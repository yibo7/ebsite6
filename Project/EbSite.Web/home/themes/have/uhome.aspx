<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.uhome" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">   
</head>
<body>
<%=ToolBarFloatTop()%>
<div id="topbar" style="left: 0px; top: 0px; position: absolute">
<a href="./">返回我的首页</a>
</div>
<div align="right" class="menu">
<nobr>&nbsp;
 <%if (UserID > 0){%>
          
          <a href="<%=UccUrl %>" ><%=UserNiName %></a>
          (<a href="<%=IISPath %>LogOut.aspx" >退出</a>)
             &nbsp;|&nbsp;
            <a href="<%=UccUrl %>" >管理面板</a>
          <%}else{%>

             <a href="<%=LoginUrl %>" >登录</a>
             &nbsp;|&nbsp;
            <a href="<%=RegUrl %>" >注册</a>
            &nbsp;|&nbsp;
            <a href="<%=IISPath %>">首页</a>
          <%}%>

</nobr></div></div>
<div id="doc">
<div id="nhdrwrap">
<div id="nhdrwrapinner">
<div id="nhdrwrapsizer">
<div class="title"><h1><%=HomeTitle%></h1></div>
<div class="subtitle"><%=HomeDemo%></div>

<noscript><div id="noscript_msg" class="msg">
<div id="noscript_box" class="msg_box">本功能需要JavaScript支持，开启以获得更多功能。</div></div></noscript>

<div id="new_user_demo" align="center"></div>

</div> 

<div id="tabs"><ul>

<li class="tab spacer">&nbsp;</li>

 <asp:Repeater ID="rpTabs" runat="server"  >
            <ItemTemplate> 
            <li class="tab unselectedtab_l">&nbsp;</li>
            <li id="tab2_view" class="tab <%#GetCurrentCss(Eval("id")) %>" style="display:block" >
            <span id="tab2_view_title" <%#GetManageLink(Eval("id"),Eval("TabName")) %> >
                  <a  href="<%#GetTabUrl(Eval("id"))%>"><%#Eval("TabName")%></a>
            </span>
            </li>
            <li class="tab unselectedtab_r">&nbsp;</li>
            </ItemTemplate>
        </asp:Repeater>

        <%if (IsMyPlace){%>
        <li  class="tab addtab">
            <span onclick="AddSpaceTab(0)">添加</span> &nbsp;<span onclick="MoveSpaceTab()">排序</span>
        </li>
        <%}%>

</ul></div></div> </div>

<div id="modules">
<div class="widgetmain">

    <asp:PlaceHolder ID="LayoutPanes" runat="server" />
</div>
</div>
</div>


<div id="footer">
Powered by EbSite 2.0 Inc
</div>
		

  <asp:Literal ID="llBaseInfo" runat="server"></asp:Literal>
</body>
</html>