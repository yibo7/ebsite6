<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Web404Log.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.Web404Log" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>网页访问错误记录</h3>
            要记录404日志请将404错误页面定向到网根目录下的errhttp.aspx页面,默认.net托管的404已经在web.config里开户,静态页请到iis里设置
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