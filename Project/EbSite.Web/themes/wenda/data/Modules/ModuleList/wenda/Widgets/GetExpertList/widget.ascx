<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.GetExpertList.widget" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Import Namespace="EbSite.BLL.User" %>
  <%@ Import Namespace="EbSite.BLL.User" %>

<asp:Repeater ID="rpList" runat="server"     EnableViewState="False">
    <ItemTemplate>

                        <div  class="drinfo drtab2">
							<div class="kfleft"  >
                                <div>
                                        <a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("UserID")) %>">
                                        <img   src='<%#EbSite.Base.Host.Instance.AvatarBig(int.Parse(Eval("UserID").ToString()))%>' width="70" height="70" />
                                    </a>
                                </div>
                                <div class="toaskbtn">
                                     <a  href="<%=EbSite.Modules.Wenda.ModuleCore.GetLinks.AskPost(GetSiteID) %>?uid=<%#Eval("UserID")%>">向TA提问</a>
                                </div>						        
							</div>
							<div class="kfright drinfor"  >
								<li><a href="<%#EbSite.Modules.Wenda.ModuleCore.GetLinks.JieDa(GetSiteID,Eval("UserID")) %>"><%# Eval("UserNiName")%></a></li>
								<li>总答疑数: <%# Eval("ExSolveCount")%> </li>
                                <li>擅长领域：<%#Eval("Field") %></li>	
                                <li>擅长品牌：<%#Eval("Brand")%></li>	
                                <li class="scly"></li>			
							</div>					
						</div>

        
    </ItemTemplate>
</asp:Repeater>
