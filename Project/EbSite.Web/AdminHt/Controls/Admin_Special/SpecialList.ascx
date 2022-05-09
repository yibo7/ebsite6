<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.SpecialList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
       <div class="boxheader">
                <h3>专题管理</h3> 
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
                                <a class="AdminLinkButton"  href="<%# string.Concat("Admin_Special.aspx?t=0","&pid=",Eval("id"))%>">添加子专题</a>

                                <XS:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("id") %>' CommandName="modify" Text="修改"  runat="server" /> 

                                <XS:LinkButton ID="LinkButton4" CommandArgument='<%#Eval("id") %>' CommandName="showcontent" Text="查看内容" runat="server" /> 
                                <XS:LinkButton ID="LinkButton3" CommandArgument='<%#Eval("id") %>' CommandName="addcontent" Text="添加内容" runat="server" /> 

                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除" /> 

                                <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopySpecial" confirm="true" Text="复制" /> 

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