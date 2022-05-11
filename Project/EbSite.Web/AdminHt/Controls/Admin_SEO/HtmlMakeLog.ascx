<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HtmlMakeLog.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.HtmlMakeLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>自动缓存生成文件错误日志</h3>
            生成静态页面时如果发生未能成功生成的情况，将在这里记录下来，您可以再次生成
            </div>
            <div class="eb-content">
				<XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="日志标题" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("Title")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="ID"   ReadOnly="true" 
                                       DataField="id" >
                                   </asp:BoundField>
                                  
                                   <asp:TemplateField  HeaderText="操作"  >
                                        <ItemTemplate >
                                              <XS:EasyuiDialog ID="WinBox2" runat="server" Href='<%# string.Concat("Admin_Log.aspx?t=3&type=2&id=",Eval("id"))%>' Text="查看详细" Title="查看详细" />
                                            <XS:LinkButton  ID="LinkButton2" CommandArgument='<%#Eval("id") %>' CommandName="deletelog" Text="删除"  runat="server"></XS:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:BoundField HeaderText="日期"   ReadOnly="true" 
                                       DataField="AddDate" >
                                   </asp:BoundField>
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