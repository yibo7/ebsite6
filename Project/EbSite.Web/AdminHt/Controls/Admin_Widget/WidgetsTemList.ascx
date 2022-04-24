<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetsTemList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Widgets.WidgetsTemList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>添加新部件</h3>
            选择以下部件类型,选择部件来源后选择查询，也可以在描述里写点关键词，然后点查询，可以检索不同来源的部件数据 
            </div>
            <div class="content">
				<XS:ToolBar ID="ucToolBar" runat="server"/>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="typename"
                                   
                                  
                            >
                              <Columns> 
                                   <asp:BoundField HeaderText="部件类别" ItemStyle-Width="120"  DataField="typename" />
                                   <asp:BoundField HeaderText="部件说明" ItemStyle-Width="500" DataField="readme" />
                                   <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>
                                                    <XS:LinkButton  ID="LinkButton2" CommandArgument='<%#Eval("typename")%>' CommandName="add" Text="创建一个部件"  runat="server"></XS:LinkButton>
                                                    <XS:LinkButton  ID="LinkButton1" CommandArgument='<%#Eval("typename")%>' CommandName="edittem" Text="编辑默认模板" confirm="false" runat="server"></XS:LinkButton>                                                    
                                         </ItemTemplate>
                                   </asp:TemplateField>                                                             
                                  
                                 
                            </Columns>
                            
                          </XS:GridView>
            </div>
    </div>
</div>
