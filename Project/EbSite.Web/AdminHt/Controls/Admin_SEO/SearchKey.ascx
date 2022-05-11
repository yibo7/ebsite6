<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchKey.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.SearchKey" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>网站搜索关键词</h3>
            </div>
            <div class="eb-content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="关键词" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("keyword")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="搜索次数"   ReadOnly="true" DataField="searchcount" />
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                    <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector"   runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                            </Columns>
             </XS:GridView>
                <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
            </div>
    </div>
</div>