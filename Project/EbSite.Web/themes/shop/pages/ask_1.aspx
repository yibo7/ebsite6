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
					    <li><dd><div class="ico1 all2pic"></div>�ʣ�<%#Eval("Body") %>��</dd><dt><%#Eval("dateandtime")%></dt></li>
					    <li><dd><div class="ico2 all2pic"></div><b>�̼�:</b> <%#Eval("Quote")%></dd><dt><%#Eval("dateasktime")%></dt></li>
			      </div>                  
                </ItemTemplate>
            </asp:Repeater>
			
			 <div class="clear"></div> 
			  <div class="ifline"></div>
			  <!---�ش����-->
			  <div class="iffanye">
				 <XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" />
              
			  </div>
			  <!--��ҳ����--->
			<div class="clear"></div>
			 <div class="iftab2"><li>������ᣬ�����Է�����ʼ��л�����򹥻���</li></div>
	  		<div class="iftab3">
                 <% if (base.UserID>0)
                           {%>
                 <li>   ����,<a target="_blank" href="<%=HostApi.GetUserHomePage() %>"><%=EbSite.Base.AppStartInit.UserNiName%></a></li>
                            <%}
                           else
                           { %>
                                <li><asp:TextBox ID="txtUserName" class="inpborw"   runat="server">���������ʺ�</asp:TextBox> </li>
				<li><asp:TextBox ID="txtPass" class="inpborw" TextMode="Password" runat="server">������������</asp:TextBox> </li>
				<li><asp:Button ID="btnLogIn" runat="server" Width="50" Height="23" Text="��¼" style="display:none;"  OnClick="btnLogIn_Click" /></li>
                <li>��������:<asp:CheckBox ID="cbNiName" Text="��" runat="server" /></li>
				<li> <div id="loginpic" class="iflobtn all2pic"></div>  </li>
				<li><a target="_blank" href="<%=EbSite.Base.Host.Instance.RegRw %>">ע���û�</a></li>	
				<br />	
                        <%} %>
							
			</div>
			<div class="ifarea">
            <asp:TextBox class="ifline2" Height="100" ID="txtContent" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            
            <div id="savepost" class="msfbtn all3pic"></div>
            <asp:PlaceHolder ID="IsOpenSafeCoder" runat="server">
			<div style="float:right; margin-right:10px; margin-left:10px;" >
            ��֤��:<asp:TextBox ID="txtSafeCoder" runat="server" Width="80" class="inpborw" ></asp:TextBox>
            <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" Style="cursor: pointer;" ImageUrl="/ValidateCode.ashx?" HintInfo="ͼƬ�����壿������µõ���֤��,�����ִ�Сд!��ɫ����,��ɫ��ĸ!"></asp:Image>
            </div>
            </asp:PlaceHolder>

	</div>
    
    <asp:Button ID="btnPl" Width="80" Height="23" BorderColor="#000" style="display:none;"  runat="server" Text="��Ҫ����" OnClick="btnPl_Click" />
    
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
