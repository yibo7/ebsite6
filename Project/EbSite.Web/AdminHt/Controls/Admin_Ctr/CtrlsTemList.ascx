<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlsTemList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctr.CtrlsTemList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>模型控件类型</h3>
            您可以查询相应模块下的控件,不输入描述将表出所选模块下的所有控件
            </div>
            <div class="eb-content">
				 <XS:ToolBar ID="ucToolBar" runat="server"/>
                  <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="False"  >
                              <Columns> 
                                    <asp:BoundField HeaderText="<%$Resources:lang,EBCtrCategory %>" ItemStyle-Width="120"  DataField="typename" />
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBcontrDescri %>"  DataField="readme" />
                                   <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>">
                                         <ItemTemplate>
                                                    <XS:LinkButton  ID="LinkButton2" CommandArgument='<%#Eval("typename")%>' CommandName="add" Text="创建一个控件"  runat="server"></XS:LinkButton>
                                                    <XS:LinkButton  ID="LinkButton1" CommandArgument='<%#Eval("typename")%>' CommandName="edittem" Text="编辑默认模板" confirm="false" runat="server"></XS:LinkButton>                                                    
                                         </ItemTemplate>
                                   </asp:TemplateField>                                                             
                                  
                                 
                            </Columns>
                            
</XS:GridView>
            </div>
    </div>
</div>