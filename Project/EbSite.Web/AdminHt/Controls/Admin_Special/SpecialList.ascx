<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.SpecialList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div >
                <h3>管理专题</h3>
            </div>
            <div  style="padding:0px !important">
                
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
				<XS:GridView ID="gdList" runat="server"
                    DataKeyNames="id"
                    AutoGenerateColumns="False">
                    <Columns>

                        <asp:BoundField HeaderText="ID" ItemStyle-Width="50" ReadOnly="true" DataField="id" />
                        <asp:TemplateField HeaderText=" 专题名称 " ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <a href="<%#EbSite.Base.Host.Instance.GetSpecialHref(int.Parse(Eval("id").ToString()),1)%>" target="_blank"><%#Eval("SpecialName")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <a href="<%# string.Concat("Admin_Special.aspx?t=0","&pid=",Eval("id"))%>">
                                    <img title="添加子分类" src="<%=IISPath %>images/addsub.gif" />
                                </a>
                                <XS:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("id") %>' CommandName="modify" Text="修改" confirm="false" runat="server">
                                            <img title="编辑" src="<%=IISPath %>images/edit.gif" />
                                </XS:LinkButton>

                                <XS:LinkButton ID="LinkButton4" CommandArgument='<%#Eval("id") %>' CommandName="showcontent" Text="查看内容" confirm="false" runat="server">
                                             <img title="查看内容" src="<%=IISPath %>images/vcontent.gif" />
                                </XS:LinkButton>
                                <XS:LinkButton ID="LinkButton3" CommandArgument='<%#Eval("id") %>' CommandName="addcontent" Text="添加内容" confirm="false" runat="server">
                                              <img title="添加内容" src="<%=IISPath %>images/addcontent.gif" />
                                </XS:LinkButton>

                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" onfirm="true" Text="删除">
                                             <img title="删除" src="<%=IISPath %>images/delete.gif" />
                                </XS:LinkButton>

                                <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyClass" confirm="true" Text="复制">
                                             <img title="复制" src="<%=IISPath %>images/copy.gif" />
                                </XS:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                      
                        <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </XS:GridView>
                
             <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
            </div>
    </div>
</div>