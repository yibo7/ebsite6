<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="EbSite.Web.Pages.top" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         .mainbox{ text-align:center; width:100%;
           text-align: -moz-center !important;/*火狐*/}
.contentbox{ width:990px;margin:0 auto;text-align: left;}

.indexclassp{width: 100%;vertical-align:top;border: 1px solid #C0D9CF;}
.indexclass{background: #E0F0FF; width: 100%;height: 30px; line-height: 30px;font-weight: bold;font-size: 14px;color: #1D6F98;text-align: center;}

.indexclasslist{ text-align: left;padding: 5px;border-bottom: 1px solid #ccc;background: #F7FBFF; }
.indexclasslist .title{ padding-bottom: 10px;}
.indexclasslist .title a{ font-size: 14px;font-weight: bold;color: #0455A1;padding: 5px; }
.indexclasslist .subtitle a{ color: #000;  }
.indexclasslist .subtitle li{ width: 48%;display:block;float: left;height: 30px; }
.indexclasslist .subtitle{ }

.listbox{width: 785px; border: 2px solid #DAF0F7; overflow:auto;zoom:1;padding-bottom: 10px;  }
.listbox .title{ padding: 10px;font-size: 14px;font-weight: bold;border-bottom: 1px solid #EDEDED;text-align: left; }
.listbox .datalist{ padding: 8px;}
.listbox .datalist ul{;line-height: 30px;}
.listbox .datalist .news_title{ font-size: 14px;}
.listbox .datalist .ot{ color: #ccc;}

.tabtop{ border-bottom: 1px solid #EDEDED;text-align: left;overflow: hidden;background: #E8F9FF;  }
.tabtop li{ list-style: none;padding: 8px;float: left;padding-left: 15px;padding-right: 15px; }
.tabtop li.current{ background: #ffffff; }

 .datalist li{ list-style: none;padding: 5px;overflow :hidden ;text-overflow:ellipsis; white-space:nowrap;}
 .listbox .datalist .news_title{ font-size: 14px;}
    </style>
</head>
<body>
 <!--#include file="headernav.inc"-->


<div class="mainbox">

<div style="margin-top: 10px;" class="contentbox">
            <div style="width: 185px;" class="fLeft">
                <div class="indexclassp" >
                    <div class="indexclass"  >
                        总排行
                    </div>
                  <div class="datalist">
                     <XS:Widget ID="Widget4" WidgetName="排行数据-总排行"  WidgetID="c825775f-5a4b-45b4-8556-2edb65fc1000" runat="server"/>
                </div>
                </div>
            </div>
            <div class="fRight">
                 <div class="listbox" >
                      <div class="tabtop">
                          
                            <li <%=GetCurrentCss("0","current","t") %>><a href="<%=HostApi.GetTopHref(0,1)%>"  >总排行</a></li>
                            <li <%=GetCurrentCss("1","current","t") %>><a href="<%=HostApi.GetTopHref(1,1)%>"  >今日排行</a></li>
                            <li <%=GetCurrentCss("2","current","t") %>><a href="<%=HostApi.GetTopHref(2,1)%>"  >本周排行</a></li>
                            <li <%=GetCurrentCss("3","current","t") %>><a href="<%=HostApi.GetTopHref(3,1)%>"  >本月排行</a></li>
                            <li <%=GetCurrentCss("4","current","t") %> ><a href="<%=HostApi.GetTopHref(4,1)%>"  >最新数据</a></li>
                            <li <%=GetCurrentCss("5","current","t") %>><a href="<%=HostApi.GetTopHref(5,1)%>"  >推荐数据</a></li>
                       </div>
                    <div class="datalist">
                           <asp:Repeater ID="rpTop" runat="server"  >
                                    <ItemTemplate>
                                                <li class="news_title"> <%# (pgCtr.PageIndex-1)*pgCtr.PageSize+ Container.ItemIndex + 1 %>  <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%#Eval("newstitle")%></a>
                                       
                                                </li>  
                                    </ItemTemplate>
                            </asp:Repeater>
                           <XS:PagesContrl ID="pgCtr" PageSize="20" runat="server" />   
                    </div>
                </div>
            </div>
         


    </div>
    
</div>
<div class="clear"></div>

<!--#include file="footer.inc" -->

    

           
</body>
</html>
