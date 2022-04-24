<%@ Page Language="C#" AutoEventWireup="true"   Inherits="EbSite.Web.Pages.album" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

<!--#include file="headerlist.inc" -->

<div class="mainbox">

<div style="margin-top: 10px;" class="contentbox">
            <div style="width: 185px;" class="fLeft">
                <div class="indexclassp" >
                    <div class="indexclass"  >
                        TA的收藏盒
                    </div>
                    <div class="datalist">
                          <asp:Repeater ID="rpAlbum" runat="server"  >
                             <ItemTemplate>
                                  <li> <a href="<%#HostApi.UserAlbumHref(Eval("ID"),CUserID) %>"><%#Eval("ClassName")%></a></li>
                             </ItemTemplate>
                         </asp:Repeater>
                    </div>
                  
                </div>
        
            </div>
            <div class="fRight">
                 <div class="listbox" >
                      <div class="title">
                         <%=Model.ClassName %>
                    </div>
                    <div class="datalist">
                         <asp:Repeater ID="rpContentList" runat="server"  >
                             <ItemTemplate>
                                 <li>
                                    <a href="<%#HostApi.GetContentLink(Eval("ContentID"))%>"><%#Eval("Title")%></a>
                                </li>
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
<span runat="server" id="datacount"></span>

             
</body>
</html>
