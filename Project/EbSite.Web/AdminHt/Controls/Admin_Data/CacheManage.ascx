<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CacheManage.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Data.CacheManage" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>缓存管理</h3>
            </div>
            <div class="eb-content">
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
				 <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="Text">
                              <Columns>
                                   <asp:TemplateField HeaderText="缓存键" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("Text")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                  <%-- <asp:BoundField HeaderText="缓存值类型"   ReadOnly="true" 
                                       DataField="Value" >
                                   </asp:BoundField>--%>
                                   <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>              
                                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Text") %>' CommandName="DeleteModel"
                                            confirm="true" Text="删除"></XS:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Selector" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
             </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server">    </XS:PagesContrl>
            </div>
    </div>
</div>