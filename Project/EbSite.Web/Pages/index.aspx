<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EbSite.Web.Pages.index" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
<meta http-equiv="mobile-agent" content="format=xhtml; url=" />
<meta http-equiv="mobile-agent" content="format=html5; url=" />
<meta http-equiv="mobile-agent" content="format=wml; url=" />
</head>

<body >
<!--#include file="/PageTemps/Inc/header.inc" -->
<XSD:RepeaterIndex ID="rpGetClassList"   runat="server">
        <ItemTemplate>    
      <div class="box col2" id="xs_<%#Eval("id")%>" uid="<%#Eval("UserID")%>" num-adv="<%#Eval("Advs")%>" num-pl="<%#Eval("CommentNum")%>" num-good="<%#Eval("FavorableNum")%>" >
        
        <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"
            target="_blank">
            <img class="image" isvideo="<%#string.IsNullOrEmpty(Eval("Annex5").ToString())%>" src="<%#Eval("SmallPic")%>">
        </a>
        <h2>
            <a href="<%#HostApi.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>">
                <%#Eval("newstitle")%></a>
        </h2>
        <p>
            <%#EbSite.Core.Strings.GetString.CutLen(Eval("ContentInfo").ToString(), 50)%></p>
           
    </div>
      
            <asp:Repeater ID="rpContent" runat="server">
            <ItemTemplate>
                 <%#Eval("NewsTitle")%>               
            </ItemTemplate>
        </asp:Repeater>
        </ItemTemplate>
</XSD:RepeaterIndex>
                     
    <XS:PagesContrl ID="pgCtr"    runat="server" /> 


    <asp:Repeater ID="rpFrdLink" runat="server">
    <ItemTemplate>
         <%#Eval("SiteName")%>               
    </ItemTemplate>
</asp:Repeater>
                             
</body>
</html>