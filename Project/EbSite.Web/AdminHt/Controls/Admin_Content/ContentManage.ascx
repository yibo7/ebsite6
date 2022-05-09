<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentManage.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.ContentManage" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="container-fluid mt10">
    <div class="row-fluid">
        <ul id="tagModels" class="nav nav-tabs">
            <asp:Repeater ID="repWebModel" runat="server">
                <ItemTemplate>
                    <li class="nav-item">
                        <a class="<%#Equals(Guid.Parse(Eval("id").ToString()),ModelID)?"active":"" %> nav-link" href="<%#GetUrl %>&modelid=<%#Eval("id") %>">
                            <span class="visible-xs"><i class="fa fa-cube"></i></span>
                            <span data-toggle="tooltip" title="[表:<%#Equals(Eval("tablename"),null) ? "默认表" : Eval("tablename")%>]" class="hidden-xs"><%#Eval("ModelName")%></span>

                        </a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>

        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <div id="PagesMain">
                    <table class="table table-hover">
                        <XS:Repeater ID="rpList" runat="server">
                            <HeaderTemplate>
                                <tr>
                                    <th scope="col">ID</th>
                                    <th scope="col">标题
                                    </th>
                                    <th scope="col">分类
                                    </th>
                                    <th scope="col">总访问</th>
                                    <th scope="col">评论</th>
                                    <th scope="col">收藏</th>
                                    <th scope="col">好评</th>
                                    <th scope="col">推荐</th>
                                    <th scope="col">源页</th>
                                    <th scope="col">发布人</th>
                                    <th scope="col">发布时间</th>
                                    <th scope="col">操作</th>
                                    <th scope="col">
                                        <input id='chAll' onclick='on_check(this)' type="checkbox" /></th>
                                </tr>

                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 50px;"><%#Eval("ID")%></td>
                                    <td class="gvfisrtTD">
                                        <a href='<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("htmlname"),Eval("classid"))%>' target="_blank"><%#Eval("newstitle")%></a>
                                    </td>
                                    <td><%#Eval("classname")%></td>
                                    <td><%#Eval("hits")%></td>
                                    <td><%#Eval("commentnum")%></td>
                                    <td><%#Eval("Advs")%></td>
                                    <td><%#Eval("favorablenum")%></td>
                                    <td><%#Eval("isgood").ToString()=="False"?"否":"<font color='red'>已推荐</font>"%></td>
                                    <td>
                                        <a href='<%#EbSite.BLL.GetLink.LinkContent.Instance.GetAspxInstance(GetSiteID).GetContentLink(Eval("id"),Eval("htmlname"),Eval("classid"),0)%>' target="_blank">查看</a>
                                    </td>
                                    <td><%#Eval("UserNiName")%></td>
                                    <td><%#Eval("AddTime")%></td>
                                    <td>
                                        <a class="AdminLinkButton" href='<%#string.Format("?t=4&id={0}&&modelid={1}",Eval("id"),ModelID)%>'>编辑</a>
                                        <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="CopyModel" confirm="true" Text="复制" />
                                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定要删除该项么?')" CommandName="DeleteModel" Text="删除" />
                                    </td>
                                    <td>
                                        <input name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" /></td>

                                </tr>

                            </ItemTemplate>
                        </XS:Repeater>
                    </table>
                </div>

                <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />


            </div>
        </div>
    </div>
</div>


<div class="modal" id="divMakeHtml" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog" style="width: 350px;">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">生成静态页面</h4>
            </div>
            <div style="height: 100px;" class="modal-body">
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
                            <XS:TextBox ID="txtID" Width="50" runat="server">0</XS:TextBox>
                        </td>
                        <td>结束ID
                        </td>
                        <td>
                            <XS:TextBox ID="txtEndID" Width="50" HintInfo="如果不选择任何内容，将按起始ID生成" runat="server"></XS:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary">生成(html静态页)</button>
            </div>
        </div>
    </div>
</div>

<div class="modal" id="divSearh" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog" style="width: 500px;">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">生成静态页面</h4>
            </div>
            <div style="height: 300px;" class="modal-body">
                没有扩展高级搜索
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" class="btn btn-primary">搜索</button>
            </div>
        </div>
    </div>
</div>


<XS:Button Style="display: none;" ID="btnMake" IsButton="true" runat="server" Text="生成(html静态页)"
    OnClick="btnMake_Click" />

<script>

    $(function () {
        var objTags = $("#tagModels li");
        if (objTags.length == 1) {
            objTags.remove();
        }

    });

    function OnMakeHtml() {

        if (confirm('确认要生成页面吗？')) {
            $("#<%=btnMake.ClientID %>").click();

        }
    }

    function OnTopChange(ob) {

        var vl = get_selected_value(ob);
        ////        var scid = get_selected_value(document.getElementById("<=drpContentClass.ClientID %>"));
        location.href = "<% =GetUrl%>&modelid=<%=ModelID %>&cls=" + vl; //  +  "&cid=" + scid;

    }

    //    function OnClassChange(ob) {

    //        var cid = get_selected_value(ob);
    //        var toptype = get_selected_value(document.getElementById("<%=drpTopType.ClientID %>"));
    //        location.href = "<% =GetUrl%>&cid=" + cid + "&cls=" + toptype;

    //    }

    function OnSearch() {



    }
    function OnMoveClass() {

        var ids = [];
        var obHtml = $("#PagesMain");
        obHtml.find("input[type=checkbox]").each(
            function (i) {
                if (this.checked) {

                    //ids.push($($(this).next()).val());
                    ids.push($(this).val());
                }
            }
        );

        if (ids.length > 0) {
            location.href = "?t=5&modelid=<%=ModelID %>&ids=" + ids.join(",");
        }
        else {
            tb_err("请选择要移动的内容");
        }


    }


</script>
