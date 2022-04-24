<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.lostpassword" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head   runat="server"></head>
<body>
    
 <!--#include file="header.inc" -->
  <div class="w-navigator">
        <a href="<%=HostApi.MGetIndexHref() %>">首页</a><b>|</b> 
        <a href="<%=HostApi.MGetSpecialHref() %>">专题</a><b>|</b> 
        <a href="<%=HostApi.MUccIndexRw %>">我的中心<span class="unread"></span></a>
</div>
  <!--#include file="foot.inc" -->
</body>
</html>
