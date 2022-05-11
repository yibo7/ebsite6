<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormContent.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.FormContent" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>表单模型内容管理</h3>
            </div>
            <div class="eb-content">
				  <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
				    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>                            
                                 
                                   <asp:BoundField HeaderText="ID" DataField="ID" />                                    
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                 <a target="_blank"  href="<%#GetFormPageUrl(Eval("id"))%>">查看与修改</a>
                                                 <a   onclick="return confirm('确认要删除?');"  href="<%#GetDelUrl(Eval("id"))%>">删除</a>
                                         </ItemTemplate>
                                   </asp:TemplateField> 
                                  
                                 
                            </Columns>
    </XS:GridView>
                
<XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
            </div>
    </div>
</div>