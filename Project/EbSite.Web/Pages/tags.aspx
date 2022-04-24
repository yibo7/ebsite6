<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tags.aspx.cs" Inherits="EbSite.Web.Pages.tags" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
</head>

<body >
<!--#include file="/PageTemps/Inc/header.inc" -->
<div class="clear"></div>
<div class="wrapper mT5">
  <div id="position">
            <a href="<%=DomainName%>">
    	        <b><%=SiteName%></b>
    	    </a> → 标签列表
 </div>
</div>
<div class="wrapper mT5">
  <div class="l_left">
    <div id="product">
      <div class="otitle"> 标签排行 </div>
      <div class="ocontent">
        <div class="TagsList">
          <ul>
            <XS:Widget   WidgetID="48a468fb-c0ba-4ebe-ad6b-b7e3f555f865" runat="server"/>
                         
          </ul>
        </div>
      </div>
      <div class="otitle_buttom"> </div>
    </div>
     
   
  </div>
  <div class="l_right">
    <div class="utitle">
      <div class="utitlei">
        <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
          <h2><a href="#" style="color:#FFF">标签列表</a></h2>
          </span></span>
         
        </div>
      </div>
    </div>
    <div class="ucontent">
         <div id="tech" class="clear"> 
             
             <div class="TagsList" >
                             <asp:Repeater ID="rpList"  runat="server">
                                        <ItemTemplate>
                                            <li>  
                                                <a href="<%#EbSite.Base.Host.Instance.TagsSearchList(Eval("ID"),1)%>" target=_blank><%#Eval("TagName")%></a>(<span style=" color:Red"> <%#Eval("num")%></span>)
                                                              
                                            </li>
                                        </ItemTemplate>
                            </asp:Repeater>  
            </div>

                
        </div>
    
    <div class="title_buttom">
      <div class="title_buttom_i"></div>
    </div>
    
    
    
    
  </div>
  
  
  <div class="mT5">
      <div class="title_top">
        <div class="title_top_i"></div>
      </div>
      <div class="ucontent">
      <XS:PagesContrl ID="pgCtr" runat="server" /> 
    		
      </div>
      <div class="title_buttom">
        <div class="title_buttom_i"></div>
      </div>
    </div>
  
</div>

       
<!--底部开始-->
<div class="clear"></div>

<div class="wrapper mT5 mB10">
  <div class="title_top">
    <div class="title_top_i"></div>
  </div>
  <div class="ucontent">
    <%=EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.Copyright %>
  </div>
  <div class="title_buttom">
    <div class="title_buttom_i"></div>
  </div>
</div>
 
<div style="top: 1475px;" id="foot"></div>
</body>
</html>

