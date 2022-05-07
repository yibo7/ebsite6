<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassManage.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.ClassManage" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 
<div style="background:#FAFAFA" class="container-fluid main-title">
    <div  class="row">
    <div class="col-sm-12">
        <h3 class="page-title">管理分类-表格模式</h3>
        <p class="text-muted page-title-alt">提示：您也可以切换到<a href="admin_Class.aspx?mpid=bb33d5ce-094a-420c-8bf7-dccb77524a6a&msid=e93a5109-8da7-4342-9a97-288323a49379">列表模式来管理分类</a></p>
    </div>
</div>
</div>

 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        
				 <ul id="tagModels" class="nav nav-tabs">

                    <asp:Repeater ID="repWebModel" runat="server">
                        <ItemTemplate>
                            <li class="<%#Equals(Guid.Parse(Eval("id").ToString()),ModelID)?"active":"" %> tab">
                                <a href="<%#GetUrl %>&modelid=<%#Eval("id") %>">
                                    <span class="visible-xs"><i class="fa fa-tag"></i></span>
                                    <span class="hidden-xs"><%#Eval("ModelName")%></span>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                    <div class="tab-content cbrowbox-tab">
                    <div id="tg1" class="tab-pane active">
                            
                    <div   id="listP">
                        <div id="divNavClassToContent" visible="false" style="height: 28px; line-height: 28px; border: 1px solid #fff; background-color: #FDF4E3; font-size: 14px; font-weight: bold; width: 100%;" runat="server"></div>
                    
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                        <XS:GridView ID="gdList" runat="server" DataKeyNames="id" AutoGenerateColumns="False">
                            <Columns>


                                <asp:TemplateField ItemStyle-CssClass="gvfisrtTD">
                                    <HeaderTemplate>
                                        <%=Resources.lang.EBClassName%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href='<%#EbSite.Base.Host.Instance.GetClassHref(Eval("id"),Eval("htmlname"),1)%>'
                                            target="_blank">
                                            <%#Eval("ClassName")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="操作">
                                    <HeaderTemplate>
                                        <%=Resources.lang.EBOperation%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <XS:LinkButton ID="lbAddsubclass" CommandArgument='<%#Eval("id") %>' CommandName="addsubclass" Text="添加子分类" confirm="false" runat="server"></XS:LinkButton>
                                        <XS:LinkButton ID="lbShowsubclass" CommandArgument='<%#Eval("id") %>' CommandName="showsubclass" Text="查看子分类" confirm="false" runat="server"> </XS:LinkButton>
                                        <a href='<%#string.Format("{0}&id={1}&pid={2}",GetMenuLink(3),Eval("id"),Eval("parentid"))%>'>
                                            <img title="编辑" src="<%=IISPath %>images/edit.gif" /></a>
                                        <XS:LinkButton ID="lbAddcontent" CommandArgument='<%#Eval("id") %>' CommandName="addcontent" Text="添加内容" confirm="false" runat="server">
                            <img title="添加内容" src="<%=IISPath %>images/addcontent.gif" />
                                        </XS:LinkButton>
                                        <XS:LinkButton ID="lbShowcontent" CommandArgument='<%#Eval("id") %>' CommandName="showcontent" Text="查看内容" confirm="false" runat="server">
                            <img title="查看内容" src="<%=IISPath %>images/vcontent.gif" />
                                        </XS:LinkButton>

                                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除">
                            <img title="删除分类" src="<%=IISPath %>images/delete.gif" />
                                        </XS:LinkButton>
                                        <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyClass"
                                            confirm="true" Text="复制"><img title="复制分类" src="<%=IISPath %>images/copy.gif" /></XS:LinkButton>

                                        <a href="javascript:configs(<%#Eval("id") %>)"><img title="设置分类" src="<%=IISPath %>images/configs.gif" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:BoundField HeaderText="分类ID" ItemStyle-Width="100" ReadOnly="true" DataField="id" />
                                <asp:TemplateField HeaderText="排序ID">
                                    <HeaderTemplate>
                                        <%=Resources.lang.EBSortID%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#Eval("orderid") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="源页">
                                    <ItemTemplate>
                                        <a href='<%#EbSite.BLL.GetLink.LinkClass.Instance.GetAspxInstance(GetSiteID).GetClassHref(Eval("id"),Eval("htmlname"),0)%>' target="_blank">查看</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Selector" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px"></ItemStyle>
                                </asp:TemplateField>

                            </Columns>
                        </XS:GridView>
                    </div>
                         <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
                    </div> 
                </div>
     
    </div>
</div>

<div class="modal" id="divMakeHtml" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog" style="width: 350px;">
        <!--设置窗口宽-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">窗口标题</h4>
            </div>
            <div style="height: 100px;" class="modal-body">
                <!--设置窗口高-->
                <table>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lbInfo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">你可以输入以下内容ID范围，也可以选择指定内容(可多选)
                        </td>
                    </tr>
                    <tr>
                        <td>开始ID
                        </td>
                        <td>
                            <XS:TextBox ID="txtStarID" RequiredFieldType="数据校验" CanBeNull="必填" Width="50" runat="server">0</XS:TextBox>
                        </td>
                        <td>结束ID
                        </td>
                        <td>
                            <XS:TextBox ID="txtEndID" RequiredFieldType="数据校验" CanBeNull="必填" Width="50" runat="server"></XS:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary">提交更改</button>
            </div>
        </div>
    </div>
</div>

<XS:Button ID="btnMake" Style="display: none;" Text="生成" runat="server" OnClick="btnMake_Click" />
<script>
    $(function () {
        var objTags = $("#tagModels li");
        if (objTags.length == 1) {
            objTags.remove();
        }

    });
    function OnMakeClassHtml() {

        if (confirm('确认要生成页面吗？')) {
            $("#<%=btnMake.ClientID %>").click();
        }
    }
    function configs(cid) {
        OpenIframe("?t=6&id=" + cid, "请选择分类设置后保存", "保存设置")
    }
</script>
