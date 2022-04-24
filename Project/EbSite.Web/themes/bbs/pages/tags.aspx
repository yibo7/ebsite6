<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.tags" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>

<body >
    
<!--#include file="header.inc" -->
  <a href="<%=DomainName%>">
    	        <b><%=SiteName%></b>
    	    </a> → 标签列表
<div class="taglist">
              <asp:Repeater ID="rpList"  runat="server">
                                        <ItemTemplate>
                                            <li>  
                                                <a href="<%#EbSite.Base.Host.Instance.TagsSearchList(Eval("ID"),1)%>" target=_blank><%#Eval("TagName")%></a>(<span style=" color:Red"> <%#Eval("num")%></span>)
                                                              
                                            </li>
                                        </ItemTemplate>
                            </asp:Repeater>                        
                                 
                                    
</div>
<div class="btnloadmore">加载更多...</div> 
 <XS:PagesContrl ID="pgCtr" PageSize="300" runat="server" /> 
    	
        <!--#include file="footer.inc" -->
        
        <script> loadpage(".data-list", ".btnloadmore", '.data-list li');</script>           
</body>
</html>

