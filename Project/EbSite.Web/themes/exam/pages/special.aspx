<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pages.special" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>

<body >
<!--#include file="header.inc" -->


<div class="mainbox">

<div style="margin-top: 10px;" class="contentbox">
            <div style="width: 185px;" class="fLeft">
                <div class="indexclassp" >
                    <div class="indexclass"  >
                        <%=Model.SpecialName%>
                    </div>
                    <asp:Repeater ID="rpSubSpecial" runat="server" EnableViewState="False" >
                      <ItemTemplate>            		                
        
                                <a    href="<%#EbSite.Base.Host.Instance.GetSpecialHref(int.Parse(Eval("ID").ToString()),1)%>"><%# Eval("SpecialName")%></a>&nbsp;&nbsp;
       
                        </ItemTemplate>
                    </asp:Repeater>  
                </div>
            </div>
            <div class="fRight">
                 <div class="listbox" >
                    <div class="title"><h2><a href="<%= EbSite.Base.Host.Instance.GetSpecialHref(Model.id,0)%>" target="_self"><%=Model.SpecialName%></a></h2></div>
                    <div class="datalist">
                        <asp:Repeater ID="rpSpecialList" runat="server"  >
                             <ItemTemplate>                                      
                                <ul>
                                      <li class="news_title">
                                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>"><%#Eval("newstitle")%></a>
                                        
                                          <span class="ot">
                                        <span>作者：<font color="red"><%#EbSite.Base.Host.Instance.GetUserHomePage(Eval("UserID").ToString())%></font> </span><span> 
                                        
                                        <span> 点击：<font color="red"><%#Eval("hits")%></font></span></span>
                                        <br/>
                                        发表于：<font color="red"><%#Eval("addtime")%></font></span>
                                      </li>
                                       
                                      </ul>  
                             </ItemTemplate>
                </asp:Repeater>   
                         <XS:PagesContrl ID="pgCtr" runat="server" />       
                    </div>
                </div>
            </div>
         


    </div>
    
</div>
<div class="clear"></div>

<!--#include file="footer.inc" --> 
</body>
</html>