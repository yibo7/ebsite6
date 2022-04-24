<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PromoAddProduct.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.Promotions.PromoAddProduct" %>


<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.CusttomControls" TagPrefix="XE" %>
<link type="text/css" href="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>/css/ht.css" rel="stylesheet" />
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
          <%--  <div>
                <div id="div_left">
                    <div class="left_fir_top">
                        <div>需要添加的商品</div>
                        <div>
                        <asp:DropDownList ID="ddl_goodtype" runat="server" Width="150px"></asp:DropDownList>
                        <asp:TextBox ID="txtKeyWord" runat="server" Width="100px"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_OnClick" />
                        </div>
                    </div>
                    <div class="left_fir_bottom">
                        <div class="sec_prolist">
                             <ul class="ptablist" id="left_data_list">
                            <asp:Repeater ID="repData" runat="server" OnItemDataBound="repData_ItemDataBound">
                                <ItemTemplate>
                                <li id="gid_<%# Eval("id") %>">
                                <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td rowspan="2">
                                        <asp:Image ID="imgGoodPic"  runat="server" Width="60px" Height="60" ToolTip='<%# Eval("id") %>' /></td>
                                    <td colspan="2" valign="bottom"><%# Eval("NewsTitle") %></td>
                                </tr>
                                <tr valign="middle">
                                    <td>一口价：￥<%# Eval("Annex16") %> &nbsp;&nbsp;&nbsp;库存：<%# Eval("Annex12") %></td>
                                    <td><a href="javascript:void(0);" id="<%# Eval("id") %>" commandtype="1" onclick="MoveGood(this)">添加</a></td>
                                </tr>
                                </table>
                                </li>
                                </ItemTemplate>
                            </asp:Repeater>
                             </ul>
                        </div>
                        <div class="sec_pagesplit">
                        <XS:PagesContrl ID="pcPage" runat="server" CssClass="goodPage" />
                        </div>
                    </div>
                </div>
                <div id="div_right">
                 <div class="left_fir_top">
                    <div>已添加商品</div>
                    <div><input type="button" value="清空列表" onclick="ClearList()" /></div>
                 </div>
                    <div class="left_fir_bottomex">
                       <div class="sec_prolistex">
                             <ul class="ptablist" id="right_data_list">
                            <asp:Repeater ID="repDataEx" runat="server" OnItemDataBound="repDataEx_ItemDataBound">
                                <ItemTemplate>
                                <li id="gid_<%# Eval("id") %>">
                                <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td rowspan="2"><asp:Image ID="imgGoodPicEx"  runat="server" Width="60px" Height="60" ToolTip='<%# Eval("ID") %>' /></td>
                                    <td colspan="2" valign="bottom"><%# Eval("NewsTitle") %></td>
                                </tr>
                                <tr valign="middle">
                                    <td>一口价：<%# Eval("Annex16") %>	 库存：<%# Eval("Annex12") %></td>
                                    <td><a href="javascript:void(0);" id="<%# Eval("id") %>" commandtype="-1" onclick="MoveGood(this)">删除</a></td>
                                </tr>
                                </table>
                                </li>
                                </ItemTemplate>
                            </asp:Repeater>
                             </ul>
                        </div>
                    </div>
                </div>
            </div>--%>
            
            <XE:BatchProduct runat="server" ID="BestParts" OpTools="买几送几"></XE:BatchProduct>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <span style="display:none;"><XS:Button ID="bntSave" runat="server" Text=" 添加 " /></span>
    <input type="button" class="AdminButton" onclick="CloseForm()" value=" 关闭 " />
</div>
<script type="text/javascript">
    function CloseForm() {
        $(window.parent.document.body).find("div[class='panel-tool-close']").click();
    }
    function MoveGood(obj) {
        var iType = $(obj).attr("commandtype");
        var gID = $(obj).attr("id");
        var rowObj = $(obj).parent("td").parent("tr").parent("tbody").parent("table").parent("li");
        //添加商品记录
        var params = { "promoID": "<%=PromoID %>", "goodID": gID };
        if (iType == "1" || iType == 1) {
            //添加
            if ($("#right_data_list").find("li[id=\"gid_" + gID + "\"]").length == 0) {
                runws("AddPromotionGoods", params, function (msg) {
                    if (msg.d > 0) {
                        $("#right_data_list").append("<li id=\"gid_" + gID + "\">" + rowObj.html().replace(/commandtype=\"1\"/gi, "commandtype=\"-1\"").replace("添加", "删除") + "</li>");
                    }
                });
            }
        }
        else {
            //移除
            if (window.confirm("确定要删除吗？")) {
                runws("DeletePromotionGoods", params, function (msg) {
                    if (msg.d > 0) {
                        rowObj.remove();
                    }
                });
            }
        }
    }
    function ClearList() {
        if ($("#right_data_list").children("li").length > 0) {
            if (window.confirm("确定要清空列表吗？")) {
                runws("ClearPromotionGoods", { "promoID": "<%=PromoID %>" }, function (msg) {
                    if (msg.d > 0) {
                        $("#right_data_list").children("li").remove();
                    }
                });
            }
        }
        else {
            tips("暂无商品",3,1);
        }
    }

    $(document).ready(function () {
        $("fieldset>legend").html("<%=NewTitle %>");
        //panel-tool-max
        $(window.parent.document.body).find("div[class='panel-tool-max']").click();
    });
</script>
