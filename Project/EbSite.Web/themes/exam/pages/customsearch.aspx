<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.customsearch" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<body>
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
			                        
			                        <a target=_blank  href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>'>
		                                            <%# MakKeyWord(Eval("newstitle").ToString())%>		                                        
                                    </a>
			                    </dt>
			                    <dd>
			                        
			                    </dd>
			                    <dd>
				                    <span>
				                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%>" target="_blank">
				                        <%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"))%></a>
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
  <!--#include file="footer.inc" -->
</div>
</body>
</html>



    
       