<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TagColor.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.TagColor" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="alert alert-success">前台标签的颜色来自以下颜色，随机调用"  </div>

<div class="box" style="margin: 10px; padding:10px; ">
    颜色:<XS:ColorPicker ID="txtShowColor" Width="50"   runat="server" />
    允许最大次数:<XS:TextBoxVL ID="txtMaxShowNum" IsAllowNull="false" ValidateType="正整数" Width="30"  runat="server">10</XS:TextBoxVL>
    <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " OnClick="btnAdd_Click" Height="28"  runat="server" />
</div>

<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="日志标题" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                            <div class="box" style="background-color:#<%#Eval("ColorName")%>; margin-right:5px;">
                                            <%#Eval("ColorName")%>
                                            </div>
                                             
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="允许最大出现次数"    ReadOnly="true" 
                                       DataField="MaxShowNum" >
                                   </asp:BoundField>
                                  
                                 <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"     confirm="true" Text="删除"></XS:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
             </XS:GridView>

             </div>
             <XS:PagesContrl ID="pcPage" runat="server">    </XS:PagesContrl>