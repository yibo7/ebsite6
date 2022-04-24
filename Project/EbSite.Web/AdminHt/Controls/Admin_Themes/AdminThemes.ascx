<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminThemes.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Themes.AdminThemes" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


 
<div class="alert alert-success">为了安全起见,在这里的删除只是删除数据文件，没有真正删除皮肤刷新数据时将可还原，但如果有需要，请到网站根目录下的themes里删除对应的文件夹，然后刷新当前页面 </div>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>标题</b></h4>
            <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
            
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                              <Columns>
                                                   
                                   <asp:TemplateField  HeaderText="皮肤目录"  >
                                        <ItemTemplate >                                        
                                            <%#Eval("ThemePath")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="存放路径"  >
                                        <ItemTemplate >                                        
                                            <%#Eval("FullPath")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:BoundField HeaderText="<%$Resources:lang,EBLoginDate %>"   ReadOnly="true" DataField="AddDate" >
                                   </asp:BoundField>
                                <%--   <asp:TemplateField  HeaderText="是否启用"  >
                                        <ItemTemplate >                                        
                                            <input type="radio" name='rbIsUsed' value="<%#Eval("id") %>" <%# bool.Parse(Eval("IsUsed").ToString())?"checked":""%> />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                     <XS:LinkButton ID="lbDelete"  runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
                                    <%-- <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyData" confirm="true" Text="复制"></XS:LinkButton>
                                    --%> </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Selector"  runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
             </XS:GridView>
    </div>
    <XS:PagesContrl ID="pcPage" runat="server">    </XS:PagesContrl>
         <XS:Jqzoom ID="Jqzoom1"  Width="500" Position="右边"  runat="server"/>
        </div>
    </div>
</div>