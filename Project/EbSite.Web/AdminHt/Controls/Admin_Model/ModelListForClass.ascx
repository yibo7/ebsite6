<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModelListForClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.ModelListForClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>分类模型</h3>
            </div>
            <div>
				
                <XS:ToolBar ID="ucToolBar" runat="server"/>
                    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">                             
                              <Columns>                            
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBModelName %>" DataField="ModelName" />
                                   <asp:BoundField HeaderText="ID" DataField="ID" />                                    
                                     <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>">
                                         <ItemTemplate>       
                                                  <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />         
                                                   <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyModel"
                        confirm="true" Text="复制"></XS:LinkButton>                 
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' Visible='<%#!bool.Parse(Eval("IsSystem").ToString()) %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                        <a href="<%#GetEditFiledUrl(Eval("id")) %>">编辑字段</a>
                         <XS:EasyuiDialog ID="edOrder" runat="server" Href='<%#GetOrderUrl(Eval("id")) %>' SaveText="保存排序设置" Text="字段排序" Title="分类字段排序" /> 
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