<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemMethodList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Data.TemMethodList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>函数管理</h3>
            函数库主要应用在页面模板与部件模板当中，方便制作模板时调用,如果是您自己开发的函数也应加到这里以方便调用
            </div>
            <div class="content">
				 <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="id">
                              <Columns>
                                   <asp:TemplateField HeaderText="方法名称" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <%#Eval("Title")%>    
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="作者"   ReadOnly="true" 
                                       DataField="Author" >
                                   </asp:BoundField>
                                   <asp:BoundField HeaderText="调用代码"   ReadOnly="true" 
                                       DataField="GetCode" >
                                   </asp:BoundField>
                                   <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>  
                                    <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />                   
                                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
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
  
 
