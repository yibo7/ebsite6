<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminLogInLog.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Log.AdminLogInLog" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理员登录日志</h3>
            </div>
            <div class="eb-content">
				
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
                                    <asp:TemplateField  HeaderText="IP"  >
                                        <ItemTemplate >                                        
                                            <%# GetIPAndAear(Eval("ip").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBLoginDate %>"   ReadOnly="true" 
                                       DataField="AddDate" >
                                   </asp:BoundField>
                               
                            </Columns>
             </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server">    </XS:PagesContrl>
            </div>
    </div>
</div>