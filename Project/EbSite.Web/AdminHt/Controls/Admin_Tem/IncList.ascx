<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.IncList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b> 您当前编辑的公共文件来自皮肤<font color="red">[<%=CurrentThemeName %>]</font></b></h4>
            
<XS:ToolBar ID="ucToolBar" runat="server"/>
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                             
                              <Columns>                             
                                                                    
                                   <asp:BoundField HeaderText="ID" DataField="id" />                                   
                                      <asp:TemplateField HeaderText="<%$Resources:lang,EBFileName %>">
                                    <ItemTemplate>              
                                      <%#Eval("TemName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                                    
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBPath %>" DataField="TemPath" /> 
                                    
                                     <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>">
                                    <ItemTemplate>              
                                        <XS:EasyuiDialog ID="wbModify" LinkOnly="True" IsFull="True" runat="server" Text="修改" Title="修改" />                    
                                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                                            confirm="true" Text="删除"></XS:LinkButton>
                                             <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyClass"
                        confirm="true" Text="复制"></XS:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Selector" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 
                            </Columns>
                            
                          </XS:GridView>
</div>
        </div>
    </div>
</div>