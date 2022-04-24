<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.Search" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
<!--#include file="top.inc" -->
<div class="searchbannerbox" >
   <div class="searchbanner">
    
	  
     	<div class="smalllogo"  >
         	<div class="bmlogo"><a href="/"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></a></div>
		 	 <div class="logofont">�ۺ�����</div>
			<div class="logofnt">������õ�.net��վ����ϵͳ</div>
            <div class="searchbox" >
                <form onsubmit="return ChkSo(this);" method="get"   action="<%=HostApi.SearchRw %>">
                    <input id="k" name="k" value="������ؼ���Ȼ�������"  type="text" />
                    <input type="submit" id="btnSearch"    value=" �� �� " />
                </form>
            </div>
            
      	</div>
      <div class="clear"></div>
   </div>
</div>

<div class="usercontainer2"  >
	<div   style="width: 100%;  ">
    <div class="searchcount" >
        ��������<%=iSearchCount%>����"<%=KeyWord%>"��ص�����
    </div>
    <div class="slist cbox">
	  <asp:Repeater ID="rpGetList" runat="server">
                            <ItemTemplate>
                              <dl>
			                    <dt>
			                         <a  href='<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>'><%# MakKeyWord(Eval("newstitle").ToString())%></a>
			                    </dt>
			                    <dd>
			                        
			                    </dd>
			                    <dd>
				                    <span>
				                        <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>" target="_blank">
				                        <%#HostApi.GetContentLink(Eval("id"), Eval("HtmlName"), Eval("classid"))%></a>
				                       </span>
				                    <span>���: 
				                        <%-- <a title="<%#Eval("classname")%>" href="<%#HostApi.GetClassHref(System.Int32.Parse(Eval("classid").ToString()),0)%>" target="_blank">
                                                                <%#MakKeyWord(Eval("classname").ToString())%>
                                                            </a>--%>
				                     </span>
				                    <span>���: <%#Eval("hits")%></span>
				                    <span>����: <%#Eval("addtime")%></span>
			                    </dd>
		                    </dl>                  
                            </ItemTemplate>
                         
    </asp:Repeater>
 <XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" />  
    </div>
	</div>   
</div>

<div class="clear"></div>
  <!--#include file="footer.inc" -->
  <script>
      var keyw = "<%=KeyWord %>";

      In.ready('textauto', function () {
          $("#k").textRemindAuto({ focusColor: "red" });
      });
      if (keyw != "") {
          $("#k").val(keyw);
      }
      
  </script>

</body>
</html>
