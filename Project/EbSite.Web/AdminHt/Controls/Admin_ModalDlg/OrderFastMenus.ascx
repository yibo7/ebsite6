<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderFastMenus.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_ModalDlg.OrderFastMenus" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    .Items ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        margin-bottom: 10px;
    }

    .Items li {
        margin: 5px;
        padding: 5px;
        width: 150px;
        cursor: move;
    }
</style>
<script>


    In.ready('jqui', function () {
        //执行代码
        $("#sortable").sortable({
            revert: true
        });
    });
    function SaveFrame() {

        var aFields = [];
        $("#sortable").find("li").each(
            function (i) {
                aFields.push(this.id);
            }
        );

        if (aFields.length > 0) {
            // alert(aFields.join("|"));
            var Urls = "ajaxget/FastMenusOrder.ashx?sort=" + aFields.join("|") + "&time=" + Math.random();
            //alert(Urls);
            run_ajax_async(Urls, "", SaveCom);
        }

    }

    function SaveCom(msg) {

        if (msg == "ok") {
            RefeshParent1();
        }
        else { alert("更新失败！"); }
    }
</script>
<XS:Notes ID="Notes7" Text="上下拖动字段，确认排列好后点保存即可" runat="server"></XS:Notes>
<table>
    <tr>
        <td>

            <div class="Items">

                <ul id="sortable">
                    <asp:Repeater ID="rpList" runat="server">
                        <ItemTemplate>
                            <li id="<%#Eval("id")%>" class="ui-state-default"><%#Eval("Title")%></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

            </div>
        </td>

    </tr>
</table>
