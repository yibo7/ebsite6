<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Wenda.ModuleCore.Pages.maskclasslist" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
    <title>全国最大的佛教问答网</title>
</head>
<body>
 <!--#include file="header.inc"-->
    <div class="container">
       
       
            <div style="width: 100%; margin-top:5px;  font-size: 14px">
                当前位置:<a href="/"> 首页</a> &gt; <a href="#">问答分类</a>
            </div>
            <div class="cz_main">
                <XSD:RepeaterIndex ID="AskClassList" ClassIDs="1,2,3,4" runat="server" OnItemDataBound="AskClassList_ItemBound"
                    EnableViewState="False">
                    <ItemTemplate>
                        <div class="cz_title">
                           <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>">
                                <%#Eval("classname")%></a>
                        </div>
                        <asp:Repeater ID="rpSubList" runat="server">
                            <HeaderTemplate>
                                <div class="cz_bg">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="biao">
                                    <div style="text-align: center; font-size: 12px; line-height: 25px;">
                                         <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>">
                                            <%#Eval("classname")%></a><span style="color:red;">(<%#Eval("ContentCount")%>)</span>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="clear">
                                </div>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
               </XSD:RepeaterIndex>
            </div>
        </div>
            <!--#include file="footer.inc" -->
   <span runat="server" id="datacount"></span>
</body>
</html>
