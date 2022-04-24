<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="content.aspx.cs" Inherits="EbSite.Web.Pages.content" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>

</head>

<body >
<!--#include file="/PageTemps/Inc/header.inc" -->
   <asp:Repeater ID="rpPageInfo"   runat="server"  >
               <ItemTemplate>  
                                <a href="<%#Eval("Href")%>"><%#Eval("Title")%></a>        
               </ItemTemplate>
    </asp:Repeater>
<div class="clear"></div>
<div class="wrapper mT5">
  <div id="position">
            <a href="<%=DomainName%>">
    	            <b><%=SiteName%></b>
    	        </a> → 
                <a href="<%= EbSite.Base.Host.Instance.GetClassHref(Model.ClassID,0)%>" >
                    <%=Model.ClassName %>
                </a> → 
                <a href="<%= EbSite.Base.Host.Instance.GetContentLink(Model.ID,Model.HtmlName,Model.ClassID)%>">
                    <b><%=Model.NewsTitle %></b>
                </a>  
 </div>
</div>
<div class="wrapper mT5">
  <div class="l_left">
   
    <div id="buyguide" class="mT5">
      <div class="utitle">
        <div class="utitlei">
          <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
            <h2><a href="#" style="color:#FFF">热门<%=Model.ClassName %></a></h2>
            </span></span></div>
        </div>
      </div>
      <div class="ucontent">
        <div id="guidebody" class="clear"> 
            <ul>
                <XS:Widget   WidgetID="bafa9309-e4df-4913-aa54-3e468e5c07a2" runat="server"/>
                                                                            
            </ul>                                 
        </div>
      </div>
      <div class="title_buttom">
        <div class="title_buttom_i"></div>
      </div>
    </div>
    
    <div id="buyguide" class="mT5">
      <div class="utitle">
        <div class="utitlei">
          <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
            <h2><a href="#" style="color:#FFF">相关信息</a></h2>
            </span></span></div>
        </div>
      </div>
      <div class="ucontent">
        &nbsp;
        <div id="guidebody" class="clear"> 
            <ul>
                <XS:Widget   WidgetID="d3bfcde7-5984-45bd-9c22-32bb11e3efd1" runat="server"/>
                                                                                                         
            </ul>                                 
        </div>
      </div>
      <div class="title_buttom">
        <div class="title_buttom_i"></div>
      </div>
    </div>
   
  </div>
  <div class="l_right">
    
    <div class="utitle">
      <div class="utitlei">
            <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
              <h2><a href="<%=HostApi.GetClassHref(Model.ClassID,1) %>" style="color:#FFF"><%=Model.ClassName %></a></h2>
              </span></span>
              <div class="iterm fRight" style="padding-right: 60px;">
                <ul>         
                     <li>
                         <a href="#2" onClick="FavContent('<%=Model.ID %>')" >
                            收藏
                        </a> (<font color="red">
                                <script src="/ajaxget/GetCount.ashx?id=<%=Model.ID %>&t=5" type='text/javascript' language="javascript"></script>
                            </font>)    
                    </li>
                    <li>
                         <a href="#pliframe" >
                            评论(<font color="red">
                                <script src="/ajaxget/GetCount.ashx?id=<%=Model.ID %>&t=6" type='text/javascript' language="javascript"></script>
                            </font>)
                        </a>     
                    </li>
                </ul>
              </div>
            </div>
      </div>
    </div>
    
    <div class="ucontent">
        
         <div class="arcbody">
        <h1><%=Model.NewsTitle %>  </h1>
        <div class="times"> 
            作者：<a href="<%=HostApi.GetUserHomePage(Model.UserName) %>">
                    <font color="red"><%=Model.UserNiName %></font> 
                  </a> 
            发表于：<font color="red"><%=Model.AddTime %></font>　  
            点击：
            <font color="red">
               <script src="/ajaxget/GetCount.ashx?cid=<%=Model.ClassID %>&id=<%=Model.ID %>&t=0" type='text/javascript' language="javascript"></script>
            </font>
            </div>
        <div id="textbody" class="content">
            <%=Model.ContentInfo %>
        </div>
        
         <div class="linkes">
          <li style="overflow: hidden; white-space: nowrap;">
              <% if (UpModel.ID != Model.ID)
                 { %>
                上一篇：
                <a href='<%= HostApi.GetContentLink(UpModel.ID, UpModel.HtmlName, GetClassID) %>'>
                    <%= UpModel.NewsTitle %>
                </a> 
              <% } %>
          </li>
          <li style="overflow: hidden; white-space: nowrap;">
              <% if (NextModel.ID != Model.ID)
                 { %>
                下一篇：
                <a href='<%=HostApi.GetContentLink(NextModel.ID,NextModel.HtmlName,GetClassID) %>'>
                    <%=NextModel.NewsTitle%>
                </a>  
              <% } %>
          </li>
          <div class="clear"></div>
        </div>
   
  </div>
  </div>
  
    <div class="utitle">
      <div class="utitlei">
            <div class="title"><span class="title_t fLeft"><span class="title_t_i fLeft">
              <h2><a    style="color:#FFF">评论列表</a></h2>
              </span></span>
              <div class="iterm fRight" style="padding-right: 60px;">
                <ul>              
                </ul>
              </div>
            </div>
      </div>
    </div>
    <div class="ucontent">
       
        <XSD:RepeaterRemark OnItemDataBound="rpComment_ItemDataBound" PageSize="10" RemarkClassID="3" runat="server" ID="rpComment" EnableViewState="false">       
		<ItemTemplate>
           
		    <tr>
		        <td class='title'>
		            <%# bool.Parse(Eval("IsNiName").ToString()) ? "匿名网友" : string.Format("<a target=_blank href='{0}'>{1}</a>",HostApi.GetUserSiteUrl(Eval("UserId")),Eval("UserNiName"))%>(<%#Eval("ip") %>)
		                  发表于 <%#Eval("dateandtime")%>
			                
                   评分： <%#Eval("EvaluationScore")%>
			        <span>
                         <a href="#" onclick="reply(<%#Eval("ID") %>)">回复</a> 
	            <a href="#" onclick="ClientExecutePost(0,<%#Eval("ID") %>,this,<%#Eval("Support")%>)">支持[<%#Eval("Support")%>]</a>
	                	               
	            <a href="#" onclick="ClientExecutePost(1,<%#Eval("ID") %>,this,<%#Eval("Discourage")%>)">反对</a>[<%#Eval("Discourage")%>]
	             
	            <a href="#" onclick="ClientExecutePost(2,<%#Eval("ID") %>,this,<%#Eval("Information")%>)">举报</a>[<%#Eval("Information")%>]
                    </span>
                   

		        </td>
		    </tr>
            
            <tr>
                <td class="postbody">
                    <%#Eval("Body") %>
                </td>
            </tr>
              <tr id="postfoot<%#Eval("ID") %>" style="display: none">
                <td class="postfoot">
                      <div>
                       <textarea  rows="2" cols="20" id="replybox<%#Eval("ID") %>"  style="height:100px;width:100%;"></textarea>
                   </div>
                    <div>
                        <input onclick="canclreply(<%#Eval("ID") %>)"  type="button" value="取消"/>
                        <input onclick="replypost(<%#Eval("ID") %>)"  type="button" value="提交"/> 
                    </div>
                </td>
            </tr>
            <tr>
                <td >
                    
                    <asp:Repeater runat="server" ID="rpCommentSubList" >    
                        <HeaderTemplate>
                            <div class="replylist">
                        </HeaderTemplate>   
		                <ItemTemplate>
		                     <div class="replytile">
		                        <%# bool.Parse(Eval("IsNiName").ToString()) ? "匿名网友" : string.Format("<a target=_blank href='{0}'>{1}</a>",HostApi.GetUserSiteUrl(Eval("UserId")),Eval("UserNiName"))%>(<%#Eval("ip") %>)
		                  发表于 <%#Eval("dateandtime")%>
                                 
                                  <span>
                                         <a href="#" onclick="replysub(<%#Eval("ID") %>)">回复</a> 
	                            <a href="#" onclick="ClientExecutePostSub(0,<%#Eval("ID") %>,this,<%#Eval("Support")%>)">支持[<%#Eval("Support")%>]</a>
	                	               
	                            <a href="#" onclick="ClientExecutePostSub(1,<%#Eval("ID") %>,this,<%#Eval("Discourage")%>)">反对</a>[<%#Eval("Discourage")%>]
	             
	                            <a href="#" onclick="ClientExecutePostSub(2,<%#Eval("ID") %>,this,<%#Eval("Information")%>)">举报</a>[<%#Eval("Information")%>]
                                    </span>
		                    </div>
                            <div class="SubQuote">
                                 <%#Eval("QuoteShow") %>
                            </div>
		                    <div class="replybody">
		                        <%#Eval("Body") %>
		                    </div>
                            <div id="postfootsub<%#Eval("ID") %>" style="display: none; margin-bottom: 30px;" class="postfoot">
                                <div>
                                   <textarea  rows="2" cols="20" id="replybox<%#Eval("ID") %>"  style="height:100px;width:100%;"></textarea>
                               </div>
                                <div>
                                    <input onclick="canclreplysub(<%#Eval("ID") %>)"  type="button" value="取消"/>
                                    <input onclick="replypostsub(<%#Eval("ID") %>)"  type="button" value="提交"/> 
                                </div>
                                
                            </div>
                            <div class="clear"></div>
		                </ItemTemplate>
                        <FooterTemplate>
                             </div>
                        </FooterTemplate>
                    </asp:Repeater>
                   
                </td>
            </tr>
 
		</ItemTemplate>
    </XSD:RepeaterRemark>
        
        <style type="text/css" >
        *{padding:0;
            margin-left: 0;
            margin-right: 0; 
            margin-top: 0;
        }
        body{ font-size:12px;background-color:#fff; }
        input{ border:solid 1px #CBCBCB; height:20px;}
        textarea{ border:solid 1px #CBCBCB; margin-top:10px; } 
        table{ width: 100%;}
        .title{ background: #F6F6F6;color: #B5B5B5; }
        .title span{ float: right;}
        .replytile{ color: #B5B5B5;}
        .replytile span{ float: right;}
        .SubQuote{ color: #B0A28B;} 

        .replybody{ padding-bottom: 20px;}
        .postfoot{ padding-bottom: 20px;}
        td{ padding: 8px;}
        .postfoot  input{ float: right;width: 100px;height: 30px;margin-left: 8px; }
        .replylist{ background: #FAF7F2;padding: 8px;border: solid 1px #F0EDE9; }

        .ParentClass table{background:#fff;width: auto;}
        .ParentClass td{padding-left: 10px;padding-right: 10px; height:20px; border:solid 1px #ccc;  text-align:center }
        .CurrentPageCoder{ color:#fff; font-weight:bold; background:#1F3A87}
        
        
        </style>
<script type="text/javascript" src="<% =IISPath%>js/remark.js"></script>

  </div>
  
  
</div>


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
<span runat="server" id="datacount"></span>
                                               
</body>
</html>