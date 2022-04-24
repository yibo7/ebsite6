<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctrtem.ClassList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
  
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>管理部件模板分类</h3>
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"/>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                             
                              <Columns>                             
                                                                                                     
                                   <asp:BoundField HeaderText="分类名称" DataField="Title" />
                                   <asp:BoundField HeaderText="分类ID" DataField="ID" />
                                   <asp:BoundField HeaderText="分类说明" DataField="Description" />
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                    <XS:LinkButton  ID="LinkButton4" CommandArgument='<%#Eval("id") %>' CommandName="addtem" Text="添加模板" confirm="false" runat="server"></XS:LinkButton>
                                                    <XS:LinkButton  ID="LinkButton3" CommandArgument='<%#Eval("id") %>' CommandName="showtem" Text="查看模板" confirm="false" runat="server"></XS:LinkButton>
                                                    <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />                    
                    <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Visible='<%# IsSys(Eval("id").ToString()) %>' Text="删除"></XS:LinkButton>
                                    
                                         </ItemTemplate>
                                   </asp:TemplateField>   
                                   <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Selector" Visible='<%# IsSys(Eval("id").ToString()) %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                 
                            </Columns>
                            
                          </XS:GridView>
            </div>
    </div>
</div>


