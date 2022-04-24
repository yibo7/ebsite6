<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppErrLog.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Log.AppErrLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>系统异常日志</h3>
            </div>
            <div class="content">
				
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="日志标题" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("Title")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="ID"   ReadOnly="true" DataField="id" ></asp:BoundField>
                                   <asp:TemplateField  HeaderText="描述"  >
                                        <ItemTemplate >
                                            <XS:EasyuiDialog ID="WinBox2" runat="server" Href='<%# string.Concat("?t=3&id=",Eval("id"))%>'
                          Text="查看详细" Title="查看详细" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="IP"   ReadOnly="true" 
                                       DataField="ip" >
                                   </asp:BoundField>
                                   <asp:BoundField HeaderText="登录日期"   ReadOnly="true" 
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