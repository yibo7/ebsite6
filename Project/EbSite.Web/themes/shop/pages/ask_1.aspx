<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.AskRemark" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


    <div class="content" style="background-color:#FAFAFA" >
	            <asp:Repeater runat="server" ID="rpComment" EnableViewState="false" >
                <ItemTemplate>
                    <div class="ifzx">
					    <li><dd><div class="ico1 all2pic"></div>问：<%#Eval("Body") %>？</dd><dt><%#Eval("dateandtime")%></dt></li>
					    <li><dd><div class="ico2 all2pic"></div><b>商家:</b> <%#Eval("Quote")%></dd><dt><%#Eval("dateasktime")%></dt></li>
			      </div>                  
                </ItemTemplate>
            </asp:Repeater>
			
			 <div class="clear"></div> 
			  <div class="ifline"></div>
			  <!---回答结束-->
			  <div class="iffanye">
				 <XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" />
              
			  </div>
			  <!--分页结束--->
			<div class="clear"></div>
			 <div class="iftab2"><li>文明社会，从理性发帖开始。谢绝地域攻击。</li></div>
	  		<div class="iftab3">
                 <% if (base.UserID>0)
                           {%>
                 <li>   您好,<a target="_blank" href="<%=HostApi.GetUserHomePage() %>"><%=EbSite.Base.AppStartInit.UserNiName%></a></li>
                            <%}
                           else
                           { %>
                                <li><asp:TextBox ID="txtUserName" class="inpborw"   runat="server">输入您的帐号</asp:TextBox> </li>
				<li><asp:TextBox ID="txtPass" class="inpborw" TextMode="Password" runat="server">输入您的密码</asp:TextBox> </li>
				<li><asp:Button ID="btnLogIn" runat="server" Width="50" Height="23" Text="登录" style="display:none;"  OnClick="btnLogIn_Click" /></li>
                <li>匿名发表:<asp:CheckBox ID="cbNiName" Text="是" runat="server" /></li>
				<li> <div id="loginpic" class="iflobtn all2pic"></div>  </li>
				<li><a target="_blank" href="<%=EbSite.Base.Host.Instance.RegRw %>">注册用户</a></li>	
				<br />	
                        <%} %>
							
			</div>
			<div class="ifarea">
            <asp:TextBox class="ifline2" Height="100" ID="txtContent" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            
            <div id="savepost" class="msfbtn all3pic"></div>
            <asp:PlaceHolder ID="IsOpenSafeCoder" runat="server">
			<div style="float:right; margin-right:10px; margin-left:10px;" >
            验证码:<asp:TextBox ID="txtSafeCoder" runat="server" Width="80" class="inpborw" ></asp:TextBox>
            <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" Style="cursor: pointer;" ImageUrl="/ValidateCode.ashx?" HintInfo="图片看不清？点击重新得到验证码,不区分大小写!红色数字,黑色字母!"></asp:Image>
            </div>
            </asp:PlaceHolder>

	</div>
    
    <asp:Button ID="btnPl" Width="80" Height="23" BorderColor="#000" style="display:none;"  runat="server" Text="我要留言" OnClick="btnPl_Click" />
    
    </form>
    <script>
        jQuery(function ($) {
            $("#loginpic").click(function () {
                $("#<%=btnLogIn.ClientID %>").click();
            });
            $("#savepost").click(function () {
                $("#<%=btnPl.ClientID %>").click();
            });
        });
    </script>
</body>
</html>
