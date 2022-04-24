<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderRepair.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style type="text/css">
.tabglist {
width:800px;
background-color:#c8c7c7;
border-collapse:separate;
border-spacing:1px;
margin-top:3px;

}
.tabglist thead tr th {
font-size:12px;
font-weight:bold;
text-align:center;
background-color:#fff;
padding:5px;
}
.tabglist tbody tr td {
font-size:12px;
text-align:center;
padding:5px;
background-color:#fff;
}
    .tabglist tbody tr td span {
        color:red;
        font-size:14px;
        font-weight:bold;
    }
    .tabgdetail {
        background-color:#fff;
    }
        .tabgdetail tbody th {
            background-color:#fff;
            text-align:right;
        }
            .tabgdetail tbody th span {
                color:red;
            }
        .tabgdetail tbody td {
            background-color:#fff;
            text-align:left;
        }
    .qustionmsg {
        background-color:#F5F5F5;
        border:1px solid #D8D8D8;
        padding:3px;
        margin-top:3px;
        width:300px;
    }
</style>
<div style="text-align:left;">
    <table class="tabglist">
        <thead>
            <tr>
                <th>商品名称</th><th>商品价格</th><th>商品优惠</th><th>赠送清单</th><th>购买数量</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><asp:Image ID="imgbtngoods" runat="server" Width="50" Height="50" />
                    <asp:Literal ID="labLnkGoods" runat="server"></asp:Literal>
                </td>
                <td><asp:Label ID="labprice" runat="server" Text=""></asp:Label></td>
                <td><asp:Literal ID="labyh" runat="server"></asp:Literal></td>
                <td><asp:Literal ID="labqd" runat="server"></asp:Literal></td>
                <td><span><asp:Literal ID="labcount" runat="server"></asp:Literal></span></td>
            </tr>
        </tbody>
    </table>
    <table class="tabgdetail">
        <tbody>
            <tr>
                <th><span>*</span>服务类型：</th>
                <td>
                    <asp:RadioButtonList ID="rdoServerType" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                        <asp:ListItem Text="换货" Value="0"></asp:ListItem>
                        <asp:ListItem Text="退货" Value="1"></asp:ListItem>
                        <asp:ListItem Text="维修" Value="2"></asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <th><span>*</span>提交数量：</th><td><XS:TextBoxVl ID="txtCount" runat="server" Text="1" Width="50" IsAllowNull="false" ValidateType="正整数"></XS:TextBoxVl></td>
            </tr>
            <tr>
                <th>申请凭据：</th><td>
                    <asp:CheckBox ID="chkYFP" runat="server" Text="有发票" Value="0" />
                    <asp:CheckBox ID="chkYJCBG" runat="server" Text="有检测报告" Value="1" />
                </td>
            </tr>
            <tr>
                <th><span>*</span>问题描述：</th><td><XS:TextBoxVl ID="txtDesc" runat="server" TextMode="MultiLine" Height="80" Width="390"></XS:TextBoxVl>
                    <div class="qustionmsg">请您如实填写申请原因及商品情况，字数在500字内。</div></td>
            </tr>
            <tr>
                <th>上传图片：</th><td><XS:SWFUploadMore ID="MoreUploadImg" runat="server" AllowSize="4000" AllowExt="jpg,png,gif" IsMakeSmallImg="true" SaveFolder="/themes/shop/data/Upload" /><br /><div class="qustionmsg">为了帮助我们更好的解决问题，请您上传图片。</div></td>
            </tr>
        </tbody>
    </table>
</div>
<div style="text-align:center">
    <XS:Button ID="btnSave" runat="server" Text=" 保 存 " onclick="btnSave_Click" OnClientClick="return IsSave()" />
    <input type="button" class="AdminButton" onclick="BackPage()" value=" 返 回 " />
</div>
<script type="text/javascript">
    $(document).ready(function () {
       
    });
    function IsSave()
    {
        //var tmpChk = $("#ctl00_ctphBody_ctl00_rdoServerType").find("input[type=\"checkbox\"]:checked");
        //if (tmpChk != null && tmpChk.length > 0) {
        //    return true;
        //}
        //else {
        //    alert("请选择服务类型，谢谢");
        //    return false;
        //}
        var strdesc = $("#<%=txtDesc.ClientID%>").val();
        strdesc = $.trim(strdesc);
        if (strdesc == undefined || strdesc == ""||strdesc==null) {
            alert("请填写问题描述，谢谢");
            return false;
        }
        else {
            return true;
        }
    }
    function BackPage() {
        window.location.href = "?mukey=13fd55f1-e4d6-41f6-934d-0b436c926d5d";
    }
</script>

