<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customsearch.aspx.cs" Inherits="EbSite.Web.Pages.customsearch" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

</head>
<body>
<style type="text/css">
<!--
*{
	padding:0px;
	margin:0px;
}
body{
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;  background-color:#fff;
}
a{
	color:#03F;
}
a:hover{
	color:#F30;
	text-decoration:none;
}

.cbox{
	width:98%;
	margin:8px auto 0px;
}
.cbox dt a
{
	color:#03F;
	 text-decoration:underline;
}

.top{
	height:60px;
	background:url(/images/buttom_logo.gif) 6px center no-repeat;
}
.searchbox{
	margin:20px 0px 0px 240px;
	padding-top:20px;
}
input,select,textarea{
	vertical-align:middle;
	font-size:14px;
}
.stitle{
	height:35px;
	line-height:35px;
	background-color:#f9f4ee;
	text-indent:20px;
}
.lightkeyword{
	font-weight:bold;
	color:#F00;
}
.slist{

}
.slist dl{
	display:block;
	width:96%;
	margin:12px auto 0px;
	padding-bottom:8px;
}
.slist dl dt a{
	line-height:27px;
	font-size:14px;
	letter-spacing:1px;
	/*font-weight:bold;*/
}
.slist dl dd p{
	line-height:19px;
	color:#444;
	font-size:14px;
	margin-left:5px;
}
.slist dl dd span{
	font-size:12px;
	line-height:23px;
	color:#390;
}
.slist dl dd a{
	color:#777;
	text-decoration:none
}
.slist dl dd a:hover{
	color:#F30;
}
.slist dl dd span{
	margin-right:10px;
}
.spage{
	margin-top:10px;
	line-height:25px;
	height:25px;
	background:#F7F7F7;
	text-align:center;
}
.spage *{
	text-decoration:none;
	vertical-align:middle;
	letter-spacing:1px;
}
.otherkey{
	margin-top:10px;
	height:31px;
	line-height:31px;
	overflow:hidden;
	text-indent:10px;
}
.footer{
	text-align:center;
	margin-top:10px;
	border-top:1px solid #DDD;
	font-size:12px;
	line-height:37px;
}
.footer span{
	color:#060;
}
-->
</style>
<div class="top cbox">
	<div class="searchbox">
            <FORM  onsubmit="return ChkSo(this);"  method="get" action="/so.aspx" target="_so"> 
                <table>
                    <tr>
                        <td><INPUT class="txtSearch" name="k" onclick="javascript:this.value=''" class="keyword" style="width:200px;" value="请输入关键词" id="k" type="text" maxLength=200 > </td>
                        <td> 
                            <select id="ty" name="ty">
                                <option value="0">内容</option>
                                <option value="1">标签</option>
                            </select>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <input class="btn1" type="submit" value="搜索" />
                        </td>
                    </tr>
                </table>
            
            </FORM>
	</div>
</div>
<div class="stitle cbox">
	共搜索到<%=iSearchCount%>条与"<%=KeyWord%>"相关的数据
</div>
<div class="slist cbox">
		
		<asp:Repeater ID="rpGetList" runat="server"  >
                             <ItemTemplate>    
                             <dl>
			                    <dt>
			                        <%# Container.ItemIndex + 1%>. 
			                        
			                        <a target=_blank  href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>'>
		                                            <%# MakKeyWord(Eval("newstitle").ToString())%>		                                        
                                    </a>
			                    </dt>
			                    <dd>
			                        
			                    </dd>
			                    <dd>
				                    <span>
				                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>" target="_blank">
				                        <%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"), Eval("HtmlName"), Eval("classid"))%></a>
				                       </span>
				                    <span>类别: 
				                         <a title="<%#Eval("classname")%>" href="<%#EbSite.Base.Host.Instance.GetClassHref(System.Int32.Parse(Eval("classid").ToString()),0)%>" target="_blank">
                                                                <%#MakKeyWord(Eval("classname").ToString())%>
                                                            </a>
				                     </span>
				                    <span>点击: <%#Eval("hits")%></span>
				                    <span>日期: <%#Eval("addtime")%></span>
			                    </dd>
		                    </dl>                                                               
                                 
                             </ItemTemplate>
                         </asp:Repeater>
</div>
<div>
	<XS:PagesContrl ID="pgCtr" Linktype="Aspx" runat="server" />			
  
</div>



<div class="footer cbox">
	<%=EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.Copyright %>
</div>

</body>
</html>



    
       