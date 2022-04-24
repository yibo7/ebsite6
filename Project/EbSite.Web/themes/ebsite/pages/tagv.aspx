<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.tagv" %>
<%@ Register TagPrefix="XS" Assembly="EbSite.Control" Namespace="EbSite.Control" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>

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
		 	 <div class="logofont">综合搜索</div>
			<div class="logofnt">做最好用的.net网站建设系统</div>
            <div class="searchbox" >
                <form onsubmit="return ChkSo(this);" method="get"   action="<%=HostApi.SearchRw %>">
                    <input id="k" name="k"  type="text" />
                    <select id="ty" name="ty"><option value="0">内容</option><option selected value="1">标签</option></select>
                    <input id="btnSearch" type="submit" value="搜索" />
                    <input type="text" style="display:none;" name="site" value="<%=GetSiteID%>" />
                </form>
            </div>
            
      	</div>
      <div class="clear"></div>
   </div>
</div>


<div class="usercontainer2"  >
	<div   style="width: 100%;  ">
    <div class="searchcount" >
        共搜索到<%=iSearchCount%>条与"<%=KeyWord%>"相关的数据
    </div>
    <div class="slist cbox">
<div class="slist cbox">
		<asp:Repeater ID="rpGetList" runat="server"  >
                             <ItemTemplate>    
                             
                             <dl>
			                    <dt>
			                        <%# Container.ItemIndex + 1%>. <a  href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>'><%# MakKeyWord(Eval("newstitle").ToString())%></a>
			                    </dt>
			                    <dd>
			                        
			                    </dd>
			                    <dd>
				                    <span>
				                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>" target="_blank">
				                        <%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"), Eval("HtmlName"), Eval("classid"))%></a>
				                       </span>
				                    <span>类别: 
				                         <a title="<%#Eval("classname")%>" href="<%#EbSite.Base.Host.Instance.GetClassHref(System.Int32.Parse(Eval("classid").ToString()),0)%>" target="_blank">
                                                                <%#MakKeyWord(Eval("classname").ToString())%>
                                                            </a>
				                     </span>
				                    <span>点击: <%#Eval("hits")%></span>
				                    <span>日期: <%#Eval("addtime")%></span>
			                    </dd>
		                    </dl>                                                                  
                                 
                             </ItemTemplate>
                         </asp:Repeater>

	<XS:PagesContrl ID="pgCtr"    runat="server" /> 			
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
