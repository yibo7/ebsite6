<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.tagv" %>
<%@ Register TagPrefix="XS" Assembly="EbSite.Control" Namespace="EbSite.Control" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

</head>
<body>
    
<!--#include file="top.inc" -->  
    <div  style="background-color:#F4F4F4;width: 100%; border-bottom: 1px solid #ccc;">
   <div class="usercontainer" style="position:relative; text-align: left; width: 100%; ">
    
	  
     	<div style="width:100%;height:103px; float:right; margin-left:20px; padding-right: 10px;" class="logoline">
         	<div class="bmlogo"><a href="/"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></a></div>
		 	 <div class="logofont">综合搜索</div>
			<div class="logofnt"></div>
            <div style="float: right; text-align: left; width: 70%; margin-top: -40px;">
                <form onsubmit="return ChkSo(this);" method="get"   action="<%=DomainName+EbSite.Base.Host.Instance.SearchRw %>">
                    <input id="k" name="k" style="height:28px; line-height:28px; width: 390px;" type="text" />
                    <select id="ty" name="ty"><option value="0">内容</option><option selected value="1">标签</option></select>
                    <input type="submit" id="selectAsk"   style="height:30px; line-height:30px; background: #A31602; color: #fff; " value=" 搜 索 " />
                </form>
            </div>
            
      	</div>
      <div class="clear"></div>
     

   </div>
</div>
    
<div class="usercontainer2"  >
	<div class="usercontainer"  style="width: 100%;  ">
    <div style="background: #F2ECE6; height: 30px; line-height: 30px;">
        共搜索到<%=iSearchCount%>条与"<%=KeyWord%>"相关的数据
    </div>
    
	  <asp:Repeater ID="rpGetList" runat="server">
                            <ItemTemplate>
                              <div style="font-size:16px; margin-top: 8px; " >
                                  <a target="_blank"  href='<%#HostApi.GetContentLink(Eval("id"),Eval("classid"),GetSiteID)%>'>
		                                            <%# MakKeyWord(Eval("newstitle").ToString())%></a>[<a title="<%#Eval("classname")%>" href="<%#HostApi.GetClassHref(Eval("classid"),1,GetSiteID)%>" target="_blank">
                                                                <%#MakKeyWord(Eval("classname").ToString())%>
                                                            </a>]
                              </div>
                              <div style="color: #ccc;">
                                  <%# EbSite.Core.UBB.ClearUBB(EbSite.Core.Strings.GetString.CutLen(Eval("ContentInfo").ToString(), 300))%>
                              </div>  
                            </ItemTemplate>
                         
    </asp:Repeater>
   
   
	<XS:PagesContrl ID="pgCtr" runat="server" /> 

	</div>   
</div>
  <script>

      $("#k").val('<%=KeyWord %>');
  </script>
  
  <!--#include file="footer.inc" -->

</body>
</html>
