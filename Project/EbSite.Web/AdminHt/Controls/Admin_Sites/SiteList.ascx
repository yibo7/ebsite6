<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Sites.SiteList" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
            <h3>管理站群</h3>
        </div>
        <div class="content">
            <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
            <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                
                                   <asp:TemplateField HeaderText="站点名称"  >
                                         <ItemTemplate>
                                            <%#Eval("SiteName")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="站点ID"  ItemStyle-CssClass="gvfisrtTD">
                                         <ItemTemplate>
                                            <%#Eval("id")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField   HeaderText="访问目录">
                                        <ItemTemplate >                                        
                                            <%#Eval("SiteFolder")%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                   <asp:TemplateField   HeaderText="首页模板">
                                        <ItemTemplate >                                        
                                            <%#Eval("IndexTemID") %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField   HeaderText="前台皮肤">
                                        <ItemTemplate >                                        
                                            <%#Eval("PageTheme")%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField   HeaderText="手机皮肤">
                                        <ItemTemplate >                                        
                                            <%#Eval("MobileTheme")%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField   HeaderText="访问PC版首页">
                                        <ItemTemplate >                                        
                                          <a target="_blank" href='<%# GetHref(Eval("id"),0)%>'>
                                            实时首页
                                          </a>
                                           <a target="_blank" href='<%# GetHref(Eval("id"),1)%>'>
                                            静态首页
                                          </a>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField   HeaderText="访问移动版首页">
                                        <ItemTemplate >                                        
                                          <a target="_blank" href='<%# MGetHref(Eval("id"),0)%>'>
                                            移动首页
                                          </a>
                                           <a target="_blank" href='<%# MGetHref(Eval("id"),1)%>'>
                                            分类列表
                                          </a>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                    <XS:EasyuiDialog ID="wbModify" LinkOnly="True"  Title="修改数据" Text="修改" runat="server"/> 
                                    <XS:LinkButton ID="lbDelete" Visible='<%#Eval("IsNoSys") %>' runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                    <XS:LinkButton ID="lbSetMainSite" Visible='<%#Equals(Eval("ID").ToString(),"1")?false:true %>' runat="server" CommandArgument='<%#Eval("id") %>' confirm="True" title="请三思,设置后将替换当前主站点" CommandName="SetMainSite"  Text="设为主站点"></XS:LinkButton> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector"  Visible='<%#Eval("IsNoSys") %>' runat="server" />
                                        </ItemTemplate>
                               </asp:TemplateField> 
                            </Columns>
             </XS:GridView>
        </div>
    </div>
</div>
 