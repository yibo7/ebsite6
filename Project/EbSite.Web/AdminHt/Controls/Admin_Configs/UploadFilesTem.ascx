<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFilesTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.UploadFilesTem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>文件上传但未提交的记录</h3>
            这些记录为用户异步上传文件后，还没真正提交的数据，可视为垃圾文件，可定期清理
            </div>
            <div class="eb-content">
				 <XS:ToolBar ID="ucToolBar" runat="server" />
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:lang,EBFileName %>" ItemStyle-CssClass="gvfisrtTD">
                            <ItemTemplate>
                                <%#Eval("FileOldName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="存放路径" DataField="FileNewName" />
                        <asp:BoundField HeaderText="上传时间" DataField="AddDate" />

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel"
                                    confirm="true" Text="删除"></XS:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
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