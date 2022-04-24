<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bbslist.ascx.cs" Inherits=" EbSite.Modules.BBS.UserPages.Controls.BBS.bbslist" %>
<%@ Import Namespace="System.ComponentModel" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="/themes/bbs/data/Modules/ModuleList/BBS/DataStore/Attachments/img/CssBbs.css"
    rel="stylesheet" />
<div id="mainX">

    
    <div id="mainby">
        <div id="main-left">
    <table border="0" cellspacing="0" cellpadding="0" class="mapbox">
	<tr>
		<td valign="top" class="box_t_l">
		<div style="width:9px;overflow:hidden"></div>
		</td>
		<td valign="top" class="box_t_c">
        <div class="main-gg">
                    <span class="gg-bg"></span>公告 * 没有任何公告</div>
		</td>
		<td valign="top" class="box_t_r">
		<div style="width:9px;overflow:hidden"></div>
		</td>
	</tr>
	<tr>
		<td valign="top" class="box_b_l">
		</td>
		<td valign="top" class="box_b_c">
			    <%--内容区已 --%>
                <XS:Repeater runat="server" ID="bbsSection" OnItemDataBound="bbsSection_ItemDataBound">
                    <ItemTemplate>
                        <div class="ctent">
                            <div class="ctent-top">
                                <span class="ctent-title">
                                  <%#GetChannelUrl(int.Parse(Eval("id").ToString()),Eval("ChannelName").ToString())%>  </span>
                            </div>
                            <asp:Repeater runat="server" ID="rpquestionlist">
                                <HeaderTemplate>
                                    <div class="bbs-ctent">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="bbs-">
                                        <div class="left-bbs">
                                            <%#EbSite.Modules.BBS.ModuleCore.BLL.Channels.GetUrlT(int.Parse(Eval("id").ToString())) %>
                                        </div>
                                        <div class="right-bbs">
                                            <span class="ctent-title-class"> <%#Eval("ChannelName")%></span> 
                                           <%#GetSectionInfo(int.Parse(Eval("id").ToString()))%>
                                            主题: <%#Eval("PostCount")%>, 帖数: <%#Eval("TopicCount")%>
                                            <br />
                                            最后发表: <%#Eval("SatisticsTime")%>
                                        </div>
                                    </div>
                                    <%#EbSite.Modules.BBS.ModuleCore.BLL.Channels.RebackLine((Container.ItemIndex + 1),int.Parse(Eval("ParentID").ToString()))%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </ItemTemplate>
                </XS:Repeater>
                <XS:Repeater runat="server" ID="bbsSectionChild">
                    <HeaderTemplate>
                        <div class="ctent">
                            <div class="ctent-top">
                                <span class="ctent-title">
                                    <%#GetClassName()%></span>
                            </div>
                            <div class="bbs-ctent">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="bbs-">
                            <div class="left-bbs">
                                <%#EbSite.Modules.BBS.ModuleCore.BLL.Channels.GetUrlT(int.Parse(Eval("id").ToString())) %>
                            </div>
                            <div class="right-bbs">
                                <span class="ctent-title-class">
                                    <%#Eval("ChannelName")%></span> 主题: <%#Eval("PostCount")%>, 帖数: <%#Eval("TopicCount")%>
                                            <br />
                                            最后发表: <%#Eval("SatisticsTime")%>
                            </div>
                        </div>
                        <%#EbSite.Modules.BBS.ModuleCore.BLL.Channels.RebackLine((Container.ItemIndex + 1),int.Parse(Eval("ParentID").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div> </div>
                    </FooterTemplate>
                </XS:Repeater>
              
       
      
    
      <div id="ctent-botton">
                    <div class="ctent-top">
                        <span class="ctent-title">在线会员 详细在线列表</span>
                    </div>
                    <div class="ctent-botton-nr">
                       <div class="botton-pic-a"></div> <div class="botton-title-g">管理员</div>
                         <div class="botton-pic-b"></div><div class="botton-title-g">超级版主  </div>
                         <div class="botton-pic-c"></div><div class="botton-title-g">分类版主 </div>
                          <div class="botton-pic-d"></div><div class="botton-title-g">版主  </div>
                          <div class="botton-pic-e"></div><div class="botton-title-g">注册用户 </div>
                           <div class="botton-pic-f"></div><div class="botton-title-g">游客</div>
                   
                </div>
		</td>
		<td valign="top" class="box_b_r">
		</td>
	</tr>
	<tr>
		<td class="box_b_bl">
		</td>
		<td class="box_b_bc">
		</td>
		<td class="box_b_br">
		</td>
	</tr>
	</table>
        </div>
     <div id="main-right">
            <div class="main-rr-top">
            </div>
            <div class="main-ss">
                <div class="main-gg">
                </div>
            </div>
            <div class="main-s-down">
            </div>
            <%-- <div class="main-rr-l-bg">
            </div>
            <div class="main--rr-nr">
            </div>
            <div class="main-rr-bg">
            </div>--%>
            <div class="main-rr-l-coner">
            </div>
            <div class="main-rr-down-bg">
            </div>
            <div class="main-rr-r-coner">
            </div>
        </div>

  <div id="main-down">
            Copyright &copy;2005 - 2011 Tencent. All Rights Reserved 北京亿博科技 版权所有
        </div>