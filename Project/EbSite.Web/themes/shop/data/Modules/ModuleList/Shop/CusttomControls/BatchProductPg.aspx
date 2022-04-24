<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchProductPg.aspx.cs"
    Inherits="EbSite.Modules.Shop.CusttomControls.BatchProductPg" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <link type="text/css" href="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>/css/ht.css"
        rel="stylesheet" />
    <div id="UserList">
        <div style="overflow: auto;">
            <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div id="div_left">
                        <div class="left_fir_top">
                            <div>
                                <asp:DropDownList ID="ddl_goodtype" runat="server" Width="150px">
                                </asp:DropDownList>
                                <XS:TextBox ID="txtKeyWord" runat="server" Width="100px"></XS:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_OnClick" />
                            </div>
                        </div>
                        <div class="left_fir_bottom">
                            <div class="sec_prolist">
                                <ul class="ptablist" id="left_data_list">
                                    <asp:Repeater ID="repData" runat="server">
                                        <ItemTemplate>
                                            <li id="gid_<%# Eval("id") %>">
                                                <table>
                                                    <tr>
                                                        <td rowspan="2">
                                                            <div id="img<%# Eval("id") %>">
                                                                <image src="<%#Eval("SmallPic") %>" width="35" height="35" />
                                                            </div>
                                                        </td>
                                                        <td colspan="2">
                                                            <div id="tit<%# Eval("id") %>">
                                                                <%# Eval("NewsTitle") %></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            一口价：￥<%# Eval("Annex16") %>
                                                            &nbsp;&nbsp;&nbsp;库存：<%# Eval("Annex12") %>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0);" id="<%# Eval("id") %>" type="<%# Eval("NewsTitle") %>"
                                                                commandtype="1" onclick="MoveGood(this)">添加</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div class="sec_pagesplit">
                                <XS:PagesContrl ID="pcPage" PageSize="5" runat="server" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </form>
            <div id="div_right">
                <div class="left_fir_top">
                    <div>
                        已添加商品
                        <input type="button" value="清空列表" onclick="ClearList()" /></div>
                </div>
                <div class="left_fir_bottomex">
                    <div class="sec_prolistex">
                        <ul class="ptablist" id="right_data_list">
                            <asp:Repeater ID="repDataEx" runat="server">
                                <ItemTemplate>
                                    <li id="gid_<%# Eval("id") %>" a='<%# Eval("id") %>'>
                                        <table border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td rowspan="2">
                                                    <image src="<%#Eval("SmallPic") %>" width="35" height="35" />
                                                </td>
                                                <td colspan="2" valign="bottom">
                                                    <div id="tit<%# Eval("id") %>">
                                                        <%# Eval("NewsTitle") %></div>
                                                </td>
                                            </tr>
                                            <tr valign="middle">
                                                <td>
                                                    一口价：<%# Eval("Annex16") %>
                                                    库存：<%# Eval("Annex12") %>
                                                </td>
                                                <td>
                                                    <a href="javascript:void(0);" id="<%# Eval("id") %>" commandtype="-1" onclick="MoveGood(this)">
                                                        删除</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function MoveGood(obj) {
            var iType = $(obj).attr("commandtype");
            var gID = $(obj).attr("id");   
            var rowObj = $(obj).parent("td").parent("tr").parent("tbody").parent("table").parent("li");
            //添加商品记录
            var params = { "promoID": "<%=PromoID %>", "goodID": gID ,"typeID":<%=OpTypeID %>};
            if (<%=PromoID %> == "-1") {
               
                alert("请先添加商品保存后，再添加商品。");

            } else {
                if (iType == "1" || iType == 1) {
                    //添加
                    if ($("#right_data_list").find("li[id=\"gid_" + gID + "\"]").length == 0) {

                        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "AddPromotionGoods", params, function(msg) {
                            if (msg.d > 0) {
                                $("#right_data_list").append("<li id=\"gid_" + gID + "\">" + rowObj.html().replace(/commandtype=\"1\"/gi, "commandtype=\"-1\"").replace("添加", "删除") + "</li>");
                              
                            }
                        });
                    }
                } else {
                    //移除
                    if (window.confirm("确定要删除吗？")) {
                        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "DeletePromotionGoods", params, function(msg) {
                            if (msg.d > 0) {

                                rowObj.remove();
                            }
                        });
//                    CheckSel();
                    }
                }
            }
        }
        function ClearList() {
            if ($("#right_data_list").children("li").length > 0) {
//                if (window.confirm("确定要清空列表吗？")) {
//                    $("#right_data_list").children("li").remove();
//                    CheckSel();
//                }
                 if (window.confirm("确定要清空列表吗？")) {
                 runws("cfccc599-4585-43ed-ba31-fdb50024714b", "ClearPromotionGoods", { "promoID": "<%=PromoID %>" ,"typeID":<%=OpTypeID %>}, function (msg) {
                    if (msg.d > 0) {
                        $("#right_data_list").children("li").remove();
                    }
                });
            }
            }
            else {
                tips("暂无商品", 3, 1);
            }
        }

        var obIDsBox = parent.$("#" + GetUrlParams("rn"));
        //        var op = parent.$("#" + GetUrlParams("op"));
        //        alert(op.value);
        function CheckSel() {
            var aIDs = [];
            $("#right_data_list").find("li").each(
		                function () {
		                    var id = $(this).attr("a");
		                    var title = $("#tit" + id).html();

		                    var pic = $("#img" + id + ">img").attr("src");

		                    aIDs.push(id + ":" + title + ":" + pic);
		                }
		            );
            obIDsBox.val(aIDs.join(","));

        }
        $(function () {
            CheckSel();
        });   
    </script>
</body>
</html>
