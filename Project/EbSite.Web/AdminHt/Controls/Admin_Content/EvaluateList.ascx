<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EvaluateList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.EvaluateList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
	<div  class="row">
    <div class="col-lg-12">
        <div  class="card-box">
            
<XS:ToolBar ID="ucToolBar" runat="server"/>
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="回复内容" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                         <%#Eval("Body")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="用户名" >
                                         <ItemTemplate>
                                            <%#bool.Parse(Eval("IsNiName").ToString()) ? "匿名" : Eval("Username")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="支持" DataField="Support" />
                                   <asp:BoundField HeaderText="反对" DataField="Discourage" />
                                   <asp:BoundField HeaderText="举报" DataField="Information" />
                                   <asp:BoundField HeaderText="IP" DataField="Ip" />
                                   <asp:BoundField HeaderText="日期时间" DataField="DateAndTime" />
                                   <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>
                                             
                                             <XS:LinkButton ID="LinkButton1" Visible='<%#Eval("IsNoAuditing") %>' runat="server" CommandArgument='<%#Eval("id") %>' CommandName="AuditingModel"   Text="通过审核"/>
                                                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"/>
                                                  
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
<XS:PagesContrl ID="pcPage"  Linktype="Aspx" runat="server" />
        </div>
    </div>
</div>