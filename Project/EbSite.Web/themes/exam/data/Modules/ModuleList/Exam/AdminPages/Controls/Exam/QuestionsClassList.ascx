<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionsClassList.ascx.cs" Inherits="EbSite.Modules.Exam.AdminPages.Controls.Exam.QuestionsClassList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div style="text-align: center; font-size: 18px; font-weight: bold; padding: 8px; background: #E6E5E1; border-top:1px solid #DBDAD7; ">
    <%=GetTitle %>-考题类别[<a style="color: red;" href="javascript:history.go(-1)">返回</a>]
</div>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar> 
<div id="PagesMain">
    <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                   <asp:TemplateField HeaderText="考题类别名称" ItemStyle-CssClass="gvfisrtTD" >
                                         <ItemTemplate>
                                          <%#Eval("ClassName")%>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                  <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                    <XS:EasyuiDialog ID="wbModify"  Title="修改数据" Text="修改" runat="server"/> 
                                    <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                        <ItemTemplate >                                        
                                            <asp:CheckBox ID="Selector"   runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                            </Columns>
             </XS:GridView>
    </div>
    
<XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>