<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Frdlink.LinkList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>友情链接</h3>
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
                 <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="网站名称" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                          <%#Eval("SiteName")%>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="审核状况"   >
                                         <ItemTemplate>
                                            <%#bool.Parse(Eval("IsAuditing").ToString()) ? "<font color=#50B204>已通过</font>" : "<font color=#EB2B05>未通过</font>"%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="网站地址"   DataField="Url" />
                                    <asp:TemplateField HeaderText="添加时间"   >
                                         <ItemTemplate>
                                            <%#Eval("AddTime")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>

                                  
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                    <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/> 
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
                <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>