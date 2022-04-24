<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiveUserInfo.ascx.cs"
    Inherits="EbSite.Modules.Shop.UserPages.Controls.Buy.ReceiveUserInfo" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table width="100%" border="0" cellspacing="0">
    <tr>
        <td width="85" align="right" valign="middle">
            <font color="red">*</font>收货人姓名：
        </td>
        <td align="left" valign="middle">
            <XS:TextBoxVl ID="txtUserName"  runat="server"  />
            <span />
        </td>
    </tr>
    <tr>
        <td width="85" align="right" valign="middle">
            称呼：
        </td>
        <td align="left" valign="middle">
            <asp:RadioButtonList ID="rblCH" RepeatColumns="3" runat="server">
                <asp:ListItem Selected=True Text="先生" Value="1"></asp:ListItem>
                <asp:ListItem Text="女士" Value="2"></asp:ListItem>
                <asp:ListItem Text="保密" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
   <%-- <tr>
        <td align="right" valign="middle">
            <font color="red">*</font>选择城市：
        </td>
        <td align="left" valign="middle">
            <XS:AreaList ID="alAreaList" runat="server"  />
        </td>
    </tr>--%>
    <tr>
        <td align="right" valign="middle">
            <font color="red">*</font>地 址：
        </td>
        <td align="left" valign="middle">
            <XS:TextBoxVl ID="txtAress" HintInfo="填写您好的收货地址" width="250"   runat="server"  />
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            邮政编码：
        </td>
        <td align="left" valign="middle">
            <XS:TextBoxVl ID="txtPostCode" width="80" HintInfo="有助于快速确定送货地址"   runat="server"  />
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            固定电话：
        </td>
        <td align="left" valign="middle">
            <XS:TextBoxVl ID="txtTel" HintInfo="固话与手机至少填写一项，如021-55520018"   runat="server"  />
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            手机号码：
        </td>
        <td align="left" valign="middle">
             <XS:TextBoxVl ID="txtMobile" HintInfo="填写手机号便于接收发货通知短信及送货前确认" ValidateType="手机号"   runat="server"  />
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            电子邮件：
        </td>
        <td align="left" valign="middle">
            <XS:TextBoxVl ID="txtEmail" HintInfo="用来接收订单提醒邮件，便于您及时了解订单状态"  ValidateType="电子邮箱email" runat="server"  />
        </td>
    </tr>
    <tr>
        <td colspan="2" style=" padding-left:30px;">
        <br />
        <XS:Button   Text="返回上一步" OnClientClick="gotoup();return false;"   runat="server"  />
        <XS:Button ID="bntSave2" Text=" 下一步 " OnClick="bntSave2_OnClick"   runat="server"  />
        </td>
    </tr>
</table>
<br/>

<script>
    $(document).ready(function () {
        InitShopingCar();
    });
    function gotonext(oid) {
        location.href = "?mukey=579ce925-18b0-4060-a7ec-eb35f5df51b5&oid=" + oid;
    }
    function gotoup() {
        location.href = "?mukey=6cb84f01-7c5c-4588-b01f-d9c8af36fff6";
    }
</script>