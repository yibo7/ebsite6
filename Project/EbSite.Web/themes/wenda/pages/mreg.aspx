<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Wenda.ModuleCore.Pages.mreg" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
    <title>问答达人排行榜</title>
</head>
<body>

 <!--#include file="header.inc"-->

 
<div class="content" style="width:990px; margin:0 auto">
 	
	
<!---中间开始--->
	<!--中间第一部分-->
	<div class="soletcen" style="margin-top:10px; ">
			 <!---内容左侧--->
			<div class="soletr" style="width:694px;">
				<div class="wdtab1"><li>已经有<span><asp:Literal ID="llUserCount" runat="server"></asp:Literal></span>人加了我们的队伍，已经提出问题<span><asp:Literal ID="llaskCount" runat="server"></asp:Literal></span>条，解答问题<span><asp:Literal ID="llSolve" runat="server"></asp:Literal></span>条</li></div>
				
				<div class="drlist">
					<div class="drtab1">
                        <li class="cur1"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.Attractive(GetSiteID) %>">积分达人</a></li>
                         <li class="cur1"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AnswerTop(GetSiteID) %>">回答最多</a></li>
                        <li class="cur2"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.NewReg(GetSiteID) %>">最新注册</a></li>
                          <li class="cur1"><a href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.Expert(GetSiteID) %>">专家列表</a></li>

                       
                    </div>
					  <XS:Repeater ID="rpUserList" runat="server">
                         <ItemTemplate>
                                <div  class="drinfo" >
						        <div class="kfleft" style="padding-left:0px; " >
							          <a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("id")) %>">
                                        <img  src="<%#EbSite.Base.Host.Instance.AvatarBig(int.Parse(Eval("id").ToString()))%>" class="wdtab2" />
                                        </a>
						            </div>
						            <div class="kfright drinfor"  >
							            <li><a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("id")) %>"><%#Eval("NiName")%></a></li>
							            <li>作者介绍：<%#string.IsNullOrEmpty(Eval("Sign").ToString()) ? "<font color='#C4BEBB'>作者很忙，暂时没时间更新签名</font>" : Eval("Sign")%></li>
							            <li>积分：<span><%#Eval("Credits")%></span></li>
						            </div>
					            </div>
					
                          </ItemTemplate>
                           
                        </XS:Repeater>
					
                    
				</div>
			</div>
			 <!---内容左侧--->
			 <!---内容右侧--->
			<div class="soletl drl" >
				<div class="leflst" >
					<div  class="sqzj">
						<div id="requestexpert" class="zjbtn all2pic"></div>
						<li>申请专家立刻<font color="#AD3202">提高身价</font>，直接追加<font color="#34B706">1000</font>积分</li>
					</div>
					
					<div class="Expertsonline">
						<div class="zjzx">专家在线</div>
						 <XS:Widget ID="Widget3"  WidgetName="问答首页专家" WidgetID="c3caec92-9bcd-4a05-b804-1dc915cc65dd" runat="server" />
						
						
					</div>

				</div>			
			</div>
			 <!---内容右侧--->
				
	</div>
<!---中间end---> 
	 
</div> 

  <!--#include file="footer.inc" -->
<span runat="server" id="datacount"></span> 
</body>
</html>