<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectProductPg.aspx.cs"
    Inherits="EbSite.Modules.Shop.CusttomControls.SelectProductPg" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link type="text/css" href="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>/css/ht.css"
        rel="stylesheet" />
    <style type="text/css">
        #div_left
        {
            width: 99%;
            float: left;
            height: 420px;
            overflow: auto;
            border: 1px solid #A1C295;
            background-color: #E9FBE7;
        }
    </style>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="UserList">
                <div style="overflow: auto;">
                    <div id="div_left">
                        <div class="left_fir_top">
                            <asp:DropDownList ID="ddl_goodtype" runat="server" Width="100px">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtKeyWord" runat="server" Width="50px" Height="16px"></asp:TextBox>
                          
                            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_OnClick" />
                        </div>
                        <div class="left_fir_bottom">
                            <div class="sec_prolist">
                                <ul class="ptablist" id="left_data_list">
                                    <asp:Repeater ID="repData" runat="server">
                                        <ItemTemplate>
                                            <li id="gid_<%# Eval("id") %>" style="border-bottom: solid 1px #006699;">
                                                <table border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td rowspan="2">
                                                            <image src="<%#Eval("SmallPic") %>" width="35" height="35" />
                                                        </td>
                                                        <td colspan="2" valign="bottom">
                                                            <%# Eval("NewsTitle") %>
                                                        </td>
                                                    </tr>
                                                    <tr valign="middle">
                                                        <td>
                                                            <%# Eval("id") %>
                                                            一口价：￥<%# Eval("Annex16") %>
                                                            &nbsp;&nbsp;&nbsp;库存：<%# Eval("Annex12") %>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0);" id="<%# Eval("id") %>" type="<%# Eval("NewsTitle") %>"
                                                                p="<%# Eval("Annex16") %>" t="<%# Eval("NewsTitle") %>" s="<%#Eval("SmallPic") %>"
                                                                commandtype="1" onclick="CheckUser(this)">添加</a>
                                                        </td>
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script>
        var sSplit = ",";
        var obRealNameBox = parent.$("#" + GetUrlParams("rn"));
        var obUserIDsBox = parent.$("#" + GetUrlParams("ids"));
        var obNorms = parent.$("#" + GetUrlParams("isnor"));
        
        function CheckUser(obj) {
            var aUserIDs = [];
            var aRealNames = [];
            obRealNameBox.text($(obj).attr("type"));
            obUserIDsBox.val($(obj).attr("id"));


            //添加新项
            var objTitle = window.parent.$("#ctl00_ctphBody_ctl00_Title");
            var objPrice = window.parent.$("#ctl00_ctphBody_ctl00_Price");
            var objSmallImg = window.parent.$("#ctl00_ctphBody_ctl00_SmallImg");
            if (objTitle != null) {
                objTitle.val($(obj).attr("t"));
            }
            if (objPrice != null) {
                objPrice.val($(obj).attr("p"));
            }
            if (objSmallImg != null) {
                objSmallImg.val($(obj).attr("s"));
            }
            //自动放大
            $(window.parent.document.body).find("div[class='panel-tool-close']").click();
        }
        $(function () {
            // DataInit();
        });   
    </script>
</body>
</html>
