<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mtradecomment" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品评价</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <!--#include file="header.inc"-->
    <div class="content">
        <div class="container">
            <div class="commpanel">
                <div class="o-mt">
                    <h2>商品评价</h2>
                    <div class="extra">&nbsp;<span class="ftx-03">对商品质量进行评价</span></div>
                </div>
                <table border="0" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <th width="510">商品信息</th>
                            <th width="100">购买时间</th>
                            <th width="100">评价</th>
                            <th width="100">晒单</th>
                        </tr>
                        <asp:Repeater ID="rptDataList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td colspan="4">
                                        <ul class="pro-info">
                                            <li class="fore1"><a href="#">
                                                <img width="50" height="50" src='<%# Eval("thumbnailsurl") %>' /></a></li>
                                            <li class="fore2"><a><%# Eval("productname") %></a></li>
                                            <li class="fore3"><span><%# Eval("adddatetime") %></span></li>
                                            <li class="fore4 "><a href="javascript:void(0);" mk="<%# Eval("productid") %>" onclick="ShowPC(this)">评价</a></li>
                                            <li class="fore5 "></li>
                                        </ul>
                                        <div class="pc">
                                             <div>
                                                <ul>
                                                    <li><span><em>*</em>评分：</span></li>
                                                    <li><div><input type="radio" name="point" value="5" class="radio"><span class="i5"></span></div></li>
                                                    <li><div><input type="radio" name="point" value="4" class="radio"><span class="i4"></span></div></li>
                                                    <li><div><input type="radio" name="point" value="3" class="radio"><span class="i3"></span></div></li>
                                                    <li><div><input type="radio" name="point" value="2" class="radio"><span class="i2"></span></div></li>
                                                    <li><div><input type="radio" name="point" value="1" class="radio"><span class="i1"></span></div></li>
                                                </ul>
                                            </div>
                                            <div>
                                                <ul>
                                                    <li><span><em>*</em>心得：</span></li>
                                                    <li><textarea id="txtremark_<%# Eval("productid") %>" class="markinfo" onfocus="changetxt(this,0)" onblur="changetxt(this,1)">配件质量如何？用着是否正常？快写下评价吧！</textarea>
                                                        <div class="wordsmsg">输入10-100个字</div>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div mk="<%# Eval("productid") %>">
                                                <ul>
                                                    <li style="margin-left:40px;"><input type="button" value=" 评 价 " onclick="submitcomm(this,0)" class="btnpingjia" /></li>
                                                    <li>评价后可以获得积分：<%=labScore %></li>
                                                </ul>
                                            </div>
                                        </>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <!--#include file="footer.inc" -->
</body>
</html>
<script type="text/javascript">
    function ShowPC(obj) {
        var params = { "contentid": $(obj).attr("mk"), "userid": "<%=base.UserID %>" };
        alert($(obj).attr("mk"));
        runebws("CheckSendRemark", params, function (data) {
            if (data.d == "false" || data.d == false) {
                $(obj).parent("li").parent("ul").siblings("div[class=\"pc\"]").slideToggle();
            }
            else {
                alert("您已经对此商品评价过，不能重复评价！");
            }
        });
    }
    function submitcomm(obj)
    {
        var mk = $(obj).parent("li").parent("ul").parent("div").attr("mk");
        var s = $("div[class=\"pc\"]").find("input[type=\"radio\"][name=\"point\"]:checked").val();
        var tmark = $.trim($("textarea[id^=\"txtremark\"]").val());
        if (s == null || s == undefined||s=="") {
            alert("请选择评分，你的评分是偶们前进的动力！");
            return;
        }
        if (tmark == "" || tmark == undefined || tmark == null)
        {
            alert("评价心得不能为空！");
            return;
        }
        if (tmark.length <= 10 || tmark.length > 100)
        {
            alert("评价心得字数应在10-100字之间！");
            return;
        }

        PjAddPost("", mk, tmark, "c2daaf44-7cec-4bb7-9ce3-8ea96e7c3b8b", s, "2");
    }
    function changetxt(obj,action)
    {
        var t = $(obj).val();
        if (action > 0) {
            if (t == "")
            {
                $(obj).val("配件质量如何？用着是否正常？快写下评价吧！").css({ "color": "#CCCCCC" });
            }
        }
        else {
            if (t == "配件质量如何？用着是否正常？快写下评价吧！") {
                $(obj).val("").css({ "color": "#000000" });;
            }
        }
    }
</script>
