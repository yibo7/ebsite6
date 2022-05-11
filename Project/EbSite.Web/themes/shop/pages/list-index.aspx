<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="header.inc" -->
    
   <div class="eb-content">
        <div class="container">
        <div class="left" style="float: left; width: 200px;">
            <div class="m"  id="sortlist">
              <div class="mc">
                  <XS:Widget ID="Widget1" WidgetName="分类主页导航-左则"  WidgetID="7f0c1852-85ce-4538-8068-cbe9f26db929" runat="server"/>
                                               
                </div>
            </div>
           
        </div>
        <div class="middle" >
            <div class="m" >
               <XS:Widget ID="Widget2" WidgetName="列表首页幻灯片"  WidgetID="dd5fc3e0-67aa-4c0b-b8e8-d624c556ea80" runat="server"/>
            </div>
            <div class="m plist"  >
                <div class="mt">
                    <h2>
                        <%=Model.ClassName %>今日推荐</h2>
                    <div class="extra">
                    </div>
                </div>
                                            
                 <div class="mc">
                    <ul >
                         <XS:Widget ID="Widget3" WidgetName="列表主页-推荐商品"  WidgetID="9764d0a2-f4c8-4fa7-bca6-cd596c00e322" runat="server"/>
                    </ul>
                    
                </div>
            </div>
            <div class="m plist" >
                <div class="mt">
                    <h2>
                        新品到货</h2>
                   
                </div>
                <div class="mc">
                    <ul >
                      <XS:Widget ID="Widget4" WidgetName="列表主页-新品到货"  WidgetID="836a959c-e84f-4f8a-8def-709f85eed62c" runat="server"/> 
                    </ul>
                </div>
            </div>
            <div class="m plist" >
                <div class="mt">
                    <h2>
                        特价商品</h2>
                    
                </div>
             <div class="mc ">
                    <ul >
                      <XS:Widget ID="Widget7" WidgetName="分类首页-待价商品"  WidgetID="41520cfe-a30d-4060-aa2a-eeb243437b9e" runat="server"/>
                    </ul>
                    
                </div>
            </div>
        </div>
        <div class="right">
            
           <div class="m rank" >
                <div class="mt">
                    <h2>热卖商品</h2>
                </div>
                <div class="mc">
                    <ul>
                       <XS:Widget ID="Widget6" WidgetName="分类首页-热卖商品"  WidgetID="b8cdb98c-ca6d-4729-a61d-0dbcdccbd940" runat="server"/>
                                               
                      
                    </ul>
                </div>
            </div>
            <div class="m rank" >
                <div class="mt">
                    <h2>直降商品</h2>
                </div>
                <div class="mc">
                    <ul>
                         <XS:Widget ID="Widget5" WidgetName="分类首页-直降商品"  WidgetID="c9d7682a-62a5-4fa9-a4ec-8f863025c316" runat="server"/>
                                               
                    </ul>
                </div>
            </div>
        </div>
       </div>
    </div>
    <!--#include file="footer.inc"-->
</body>
</html>
