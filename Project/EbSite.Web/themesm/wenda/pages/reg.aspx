<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pagesm.reg" %>
<!doctype html>
<html>
<head    runat="server">
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
</head>
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
             <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" placeholder="请输入一个常用的email"  ></asp:TextBox>       
       </div>
       <div class="linesolid"></div> 
       <div class="ebinput" >   
            <asp:TextBox ID="txtPassWord" runat="server" TextMode="Password"   placeholder="请输入您的密码" MaxLength="100"></asp:TextBox>  
       </div>
        <div class="linesolid"></div> 
           <div class="ebinput" >   
            <asp:TextBox ID="txtCfPassWord" runat="server" TextMode="Password"   placeholder="请确认密码" MaxLength="100"></asp:TextBox>  
       </div>
    </div>
    <br />
    <asp:LinkButton ID="btnAddUser" runat="server" Text="注册用户" OnClick="btnAddUser_Click" OnClientClick="return SaveOrderInfo();" >
        <div style="width:100%;"    class="button btngreen2 btnbig"  >
        注 册
    </div>
    </asp:LinkButton>
    
</div>
</form>
 <!--#include file="foot.inc" -->

  <div id="dialog4"  class="vote-dialog" style="z-index:9999;">
        
    </div>
</body>
</html>
<script>
    m_dialog("dialog4", "200", "130");
   
    function SaveOrderInfo() {
        var $pEmail = $("#<%=txtEmail.ClientID%>").val();
        var $pPass = $("#<%=txtPassWord.ClientID%>").val();
        var $pCfPass = $("#<%=txtCfPassWord.ClientID%>").val();
        if ($pEmail == null || $pEmail.length == 0) {
            $('#dialog4').html("请输入Email");
            $('#dialog4').dialog('open', 20, 20);
            return false;
        }
        var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        if (!myreg.test($pEmail)) {
           
            $('#dialog4').html("请输入有效E_mail！");
            $('#dialog4').dialog('open', 20, 20);
            return false;
        }

        if ($pPass == null || $pPass.length == 0) {
            $('#dialog4').html("请输入密码");
            $('#dialog4').dialog('open', 20, 20);
            return false;
        }
       
        if ($pCfPass == null || $pCfPass.length == 0) {
            $('#dialog4').html("请输入确认密码");
            $('#dialog4').dialog('open', 20, 20);
            return false;
        }
       
        if ($pCfPass != $pPass) {
            $('#dialog4').html("两次密码不一致请重新输入。");
            $('#dialog4').dialog('open', 20, 20);
            return false;
        }
        if ($pPass.length < 6 || $pCfPass.length < 6) {
            $('#dialog4').html("密码长度最少是6位");
            $('#dialog4').dialog('open', 20, 20);
            return false;
        }
    }
</script>