<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CusttomLog.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Log.CusttomLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>常规日志</h3>
            此类日志为综合日志，在模块开发里调用的写日志接口写入的日志当归为此类
            </div>
            <div class="content">
				
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                 <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="<%$Resources:lang,EBLogTitle %>" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("Title")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="ID"   ReadOnly="true" 
                                       DataField="id" >
                                   </asp:BoundField>
                                  
                                   <asp:TemplateField  HeaderText="<%$Resources:lang,EBDescription %>"  >
                                        <ItemTemplate >                                        
                                            <%#Eval("Description")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="IP"   ReadOnly="true" 
                                       DataField="ip" >
                                   </asp:BoundField>
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBLoginDate %>"   ReadOnly="true" 
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
 