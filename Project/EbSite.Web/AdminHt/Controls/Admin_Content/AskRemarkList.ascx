<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskRemarkList.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.AskRemarkList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
             <XS:Repeater ID="rpRemarkClass" runat="server" >
                        <ItemTemplate>
                             <li class="<%#GetCurrentClass(Eval("id")) %> tab">
                        <a href="?t=6&remarkclass=<%#Eval("itype") %>&cid=<%#Eval("id") %>">
                            <span class="visible-xs"><i class="fa fa-comment-o"></i></span>
                            <span class="hidden-xs"><%#Eval("ClassName") %></span>
                        </a>
                    </li>
                        </ItemTemplate>
 </XS:Repeater>
             
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                
<XS:ToolBar ID="ucToolBar" runat="server" />

<div class="table-responsive" id="PagesMain">
     <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="提问" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                         <%#Eval("Body")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="回答" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                         <%#Eval("quote")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>

                                   <asp:TemplateField HeaderText="用户名" >
                                         <ItemTemplate>
                                         <%#bool.Parse(Eval("IsNiName").ToString()) ? "匿名" : Eval("Username")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                  
                                   <asp:BoundField HeaderText="IP" DataField="Ip" />
                                   <asp:BoundField HeaderText="提问时间" DataField="DateAndTime" />
                                    <asp:BoundField HeaderText="回复时间" DataField="DateAskTime" />
                                   <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>
                                                     <a  href='<%#EbSite.BLL.Remark.PageUrl(Convert.ToInt32( Eval("classid")),Convert.ToInt32( Eval("contentid"))) %>' target="_blank">进入页面</a>
                                                   
                                                <a  href='<%#string.Format("?t=13&id={0}",Eval("id"))%>'>回答</a> 
                                              
                                             <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"/>
                                             
                                             <XS:LinkButton ID="LinkButton1" Visible='<%#Eval("IsNoAuditing") %>' runat="server" CommandArgument='<%#Eval("id") %>' CommandName="AuditingModel"   Text="通过审核"/>

                                         </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Selector" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                  
                            </Columns>
             </XS:GridView>
</div>
<XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
            </div> 
        </div>
    </div>
</div>
 

