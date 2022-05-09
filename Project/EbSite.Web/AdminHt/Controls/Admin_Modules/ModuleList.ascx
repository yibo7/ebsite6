<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.ModuleList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>已安装模块管理</h3>
            </div>
            <div class="content">
                
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
				    <XS:GridView ID="gdList" runat="server"   AutoGenerateColumns="false" DataKeyNames="ID">
                        <columns>
                         <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                <ItemTemplate>
                                   <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="模块名称" ItemStyle-CssClass="gvfisrtTD">
                                <ItemTemplate>
                                    <%#Eval("ModuleName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:BoundField DataField="Version" HeaderText="版本" ></asp:BoundField>  
                           <asp:BoundField DataField="SetupPath" HeaderText="安装目录" ></asp:BoundField>
                           <asp:BoundField DataField="Author" HeaderText="开发单位" ></asp:BoundField>            
                              <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>                
                                <a class="AdminLinkButton" target="_blank" href='main_module.aspx?mid=<%#Eval("id")%>'>管理模块</a>
                                <XS:EasyuiDialog ID="WinBox2" runat="server" Href='<%# string.Concat("?t=7&mid=",Eval("id"))%>'  Text="导出模块" Title="导出模块" />
                                 <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"  Tips_Msg="模块删除中,请勿关闭窗口!" confirm="true" Text="卸载"></XS:LinkButton>
                                  <%#Equals(Eval("IsClose").ToString(), "True")?"<font color=red>模块已经关闭</font>":""%>
                                </ItemTemplate>
                            </asp:TemplateField>                
                        </columns>
                    </XS:GridView>
                <XS:PagesContrl ID="pcPage" runat="server" />
            </div>
    </div>
</div>


 
