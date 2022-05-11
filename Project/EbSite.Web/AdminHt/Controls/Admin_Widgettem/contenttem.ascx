<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contenttem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Widgettem.contenttem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>后台内容管理列表模板</h3>
             在后台的内容管理列表绑定出来的结果有时需要与相关的内容模型相关，比如商品类的内容模式需要在列表绑定出来商品图片与价格等信息，这样默认的列表模板不能满足时可以在这里定制
            </div>
            <div class="eb-content">
				
                <XS:ToolBar ID="ucToolBar" runat="server"/>
                 <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                             
                              <Columns>                             
                                                                                                     
                                   <asp:BoundField HeaderText="模板名称" DataField="Title" />
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                   
                                                    <XS:EasyuiDialog ID="wbModify" LinkOnly="True" runat="server" Text="修改" Title="修改" />                    
                                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Text="删除"></XS:LinkButton>
                                    
                                         </ItemTemplate>
                                   </asp:TemplateField>   
                                   <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Selector"  runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                 
                            </Columns>
                            
                          </XS:GridView>
            </div>
    </div>
</div>