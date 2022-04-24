<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.login" %>
<!doctype html>
<html>
<head  runat="server"></head>
<body >

 <!--#include file="header.inc" -->
  <div class="w-navigator">
        <a href="<%=HostApi.MGetIndexHref() %>">首页</a><b>|</b> 
        <a href="<%=HostApi.MGetSpecialHref() %>">专题</a><b>|</b> 
        <a href="<%=HostApi.MUccIndexRw %>">我的中心<span class="unread"></span></a>
</div>
<form id="form1" runat="server">
<div style="padding:10px;">
    <div class="radiusbox">
      <div class="ebinput"  >   
             <%--<input name="word" type="text" maxlength="100"  placeholder="请输入您的帐号"  >--%>
             <asp:TextBox ID="txtUserName" placeholder="请输入您的帐号" runat="server"></asp:TextBox>
       </div>
       <div class="linesolid"></div> 
       <div class="ebinput" >   
             <%--<input name="word" type="password" maxlength="100" placeholder="请输入您的密码"  >--%>
              <asp:TextBox ID="txtUserPass" TextMode="Password" placeholder="请输入您的密码" runat="server"></asp:TextBox>
       </div>
         
    </div>
    <br />
    <asp:LinkButton ID="lbLogin" runat="server">
        <div style="width:100%;"    class="button btngreen2 btnbig"   > 登 录 </div>
    </asp:LinkButton>
     <asp:label id="lbErrInfo"  runat="server" ForeColor="Red" ></asp:label>
</div>
 </form>
 <!--#include file="foot.inc" -->
<script>
//    var btnLogin = $('#btnLogin').button();
</script>
</body>
</html>
