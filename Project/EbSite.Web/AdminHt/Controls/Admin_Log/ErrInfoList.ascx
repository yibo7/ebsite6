<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrInfoList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Log.ErrInfoList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>错误日志列表</h3>
            您可以通过定向到/err[id].aspx 来访问这个提示页面,其中 id 为记录的ID，如/err1.aspx
            </div>
            <div class="content">
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
				 <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:lang,EBLogTitle %>" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#Eval("Title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="ID" ReadOnly="true" DataField="id" />
                        <asp:BoundField HeaderText="提示信息" ReadOnly="true" DataField="ErrMsg" />
                        <asp:BoundField HeaderText="发生次数" ReadOnly="true" DataField="ErrCount" />
                        <asp:TemplateField ItemStyle-Width="60" HeaderText="访问页面">
                            <ItemTemplate>
                                <a href="<%# EbSite.Base.Host.Instance.GetErrPageRw(Eval("id").ToString()) %>" target="_blank">访问</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:LinkButton ID="SetCount" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="SetCount" Text="错误归零"></XS:LinkButton>
                                <XS:EasyuiDialog ID="wbModify" Title="修改数据" Text="修改" runat="server" />
                                <XS:LinkButton ID="lbDelete" Visible='<%#Eval("IsSys") %>' runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" Text="删除"></XS:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" Visible='<%#Eval("IsSys") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </XS:GridView>
                
            <XS:PagesContrl ID="pcPage" runat="server"></XS:PagesContrl>
            </div>
    </div>
</div>