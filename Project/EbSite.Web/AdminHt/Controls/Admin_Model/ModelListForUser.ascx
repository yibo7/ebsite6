<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModelListForUser.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.ModelListForUser" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理用户模型</h3>
            </div>
            <div class="eb-content">
				<XS:ToolBar ID="ucToolBar" runat="server"/>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">                               
                              <Columns>                            
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBModelName %>" DataField="ModelName" />
                                   <asp:BoundField HeaderText="ID" DataField="ID" />                                    
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />    
                                                 <XS:LinkButton ID="lbCopy" runat="server"  CommandArgument='<%#Eval("id") %>' CommandName="CopyModel"
                        confirm="true" Text="复制"></XS:LinkButton>                      
                    <XS:LinkButton ID="lbDelete" runat="server" Visible='<%#!bool.Parse(Eval("IsSystem").ToString()) %>' CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                        <a class="AdminLinkButton" href="<%#GetEditFiledUrl(Eval("id")) %>">编辑字段</a>
                         <XS:EasyuiDialog ID="edOrder" runat="server" Href='<%#GetOrderUrl(Eval("id")) %>' Text="字段排序" Title="字段排序" /> 
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
