<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.Search" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    
                         
<div  style="background-color:#F4F4F4;width: 100%; border-bottom: 1px solid #ccc;">
   <div class="usercontainer" style="position:relative; text-align: left; width: 100%; ">
    
	  
     	<div style="width:100%;height:103px; float:right; margin-left:20px; padding-right: 10px;" class="logoline">
         	<div class="bmlogo"><a href="/"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></a></div>
		 	 <div class="logofont">综合搜索</div>
			<div class="logofnt">ebSite</div>
            <div style="float: right; text-align: left; width: 70%; margin-top: -40px;">
                <form onsubmit="return ChkSo(this);" method="get"   action="<%=DomainName+EbSite.Base.Host.Instance.SearchRw %>">
                    <input id="k" name="k" style="height:28px; line-height:28px; width: 390px;" type="text" />
                    <input type="submit" id="selectAsk"   style="height:30px; line-height:30px; background: #A31602; color: #fff; " value=" 搜 索 " />
                </form>
            </div>
            
      	</div>
      <div class="clear"></div>
     

   </div>
</div>


<div class="usercontainer2"  >
    <div style="background: #F2ECE6; height: 30px; line-height: 30px; padding-left:8px;">
        共搜索到<%=iSearchCount%>条与"<%=KeyWord%>"相关的数据
    </div>
	<div class="usercontainer"  style="width: 100%; padding:8px;   ">


	  <asp:Repeater ID="rpGetList" runat="server">
                            <ItemTemplate>
                              <div class="searcht" >
                                  <a  href='<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>'><%# MakKeyWord(Eval("newstitle").ToString())%></a>
                              </div>
                              <div class="searchc">
                                  <%# MakKeyWord(EbSite.Core.Strings.GetString.ClearHtml(EbSite.Core.Strings.GetString.CutLen(Eval("ContentInfo").ToString(), 300)))%>
                              </div>  
                            </ItemTemplate>
                         
    </asp:Repeater>
    <XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" />  
	</div>   
</div>
  <script>

      $("#k").val('<%=KeyWord %>');
  </script>
</body>
</html>
