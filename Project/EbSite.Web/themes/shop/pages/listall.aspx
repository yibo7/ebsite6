<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <!--#include file="header.inc"-->
      <div class="eb-content">
          <div class="containerallclass">
              <div class="classbox" >


            <XS:RepeaterList ID="rpGetSubClassList" ModelID="cfd5666c-0bd5-4beb-884b-75d23e7ca158"  runat="server">
                <ItemTemplate>
                    <div class="classboxparent" >
                        <div class="classparentname">
                           <a href="<%#HostApi.GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>"><%#Eval("ClassName")%></a> 
                        </div>
                        <div class="classboxsub">
                             <asp:Repeater ID="rpSub" runat="server">
                                <ItemTemplate>
                                        <li>
                                            <a href="<%#HostApi.GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>"><%#Eval("ClassName")%></a> 
                                        </li>                                  
                                </ItemTemplate>
                            </asp:Repeater>         

                        </div>
                    </div>
                    
                        
                </ItemTemplate>
            </XS:RepeaterList>
            </div>

        </div>
    </div>
    <!--#include file="footer.inc"-->
</body>
</html>
