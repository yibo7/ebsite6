<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Vote.VoteList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="投票名称" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                          <%#Eval("VoteName")%>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="总共投票数"   DataField="VoteCount" />
                                    <asp:TemplateField HeaderText="开始时间"   >
                                         <ItemTemplate>
                                            <%#GetDateTime(Eval("StartDate"))%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="结束时间" >
                                         <ItemTemplate>
                                            <%#GetDateTime(Eval("EndDate"))%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                  
                                   <asp:TemplateField HeaderText="前台"  >
                                         <ItemTemplate>
                                             
                                            <a target="_blank" href="<%#EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetVoteView(Eval("id"))%> ">查看投票结果</a> |
                                            <a target="_blank" href="<%#EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetVotePost(Eval("id"))%> ">去投票</a>
                                            
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                    <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/> 
                                    <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                    <a href="?t=2&vid=<%#Eval("id") %>">管理投票选项</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector"   runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                            </Columns>
             </XS:GridView>
    </div>
    
<XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>