<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitInfo.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Spider.VisitInfo" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>来访明细统计</h3>
            </div>
            <div class="eb-content">
				<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="搜索引擎名称" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("SpiderName")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="访问地址">
                                         <ItemTemplate>
                                            <a href="<%#Eval("Url")%>" target="_blank"><%#Eval("Url")%></a>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="请求状态"   ReadOnly="true" DataField="HttpState" />
                                   <asp:BoundField HeaderText="目录"   ReadOnly="true" DataField="UrlPath" />
                                  <asp:BoundField HeaderText="访问时间"   ReadOnly="true" DataField="AddDateTime" />
                                  
                            </Columns>
             </XS:GridView>
                <XS:PagesContrl ID="pcPage" Linktype="Aspx" PageSize="50" runat="server" />
            </div>
    </div>
</div>