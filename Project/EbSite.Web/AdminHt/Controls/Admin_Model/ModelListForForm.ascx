<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModelListForForm.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.ModelListForForm" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理表单模型</h3>
            </div>
            <div>
                <XS:ToolBar ID="ucToolBar" runat="server"/>
				 <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">                               
                              <Columns>                            
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBModelName %>" DataField="ModelName" />
                                   <asp:BoundField HeaderText="ID" DataField="ID" />  
                                    <asp:TemplateField HeaderText="表单输入页面">
                                         <ItemTemplate>           
                                          <a target="_blank"  href="<%#GetFormPageUrl(Eval("id"))%>">添加数据</a>
                                         </ItemTemplate>
                                   </asp:TemplateField>                             
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                <a href="?t=6&mid=<%#Eval("id") %>">管理内容</a>
                                                 <a href="?t=8&id=<%#Eval("id") %>">编辑模板</a>
                                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />    
                                                 <XS:LinkButton ID="lbCopy" runat="server"  CommandArgument='<%#Eval("id") %>' CommandName="CopyModel"
                        confirm="true" Text="复制"></XS:LinkButton>                      
                    <XS:LinkButton ID="lbDelete" runat="server" Visible='<%#!bool.Parse(Eval("IsSystem").ToString()) %>' CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                        <a href="<%#GetEditFiledUrl(Eval("id")) %>">编辑字段</a>
                                                 </ItemTemplate>
                                   </asp:TemplateField>  
                                    <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector" Visible='<%#!bool.Parse(Eval("IsSystem").ToString()) %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>    
                                 
                            </Columns>
</XS:GridView>
            </div>
    </div>
</div>