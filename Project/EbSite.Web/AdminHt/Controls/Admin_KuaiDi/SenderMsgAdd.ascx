<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SenderMsgAdd.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_KuaiDi.SenderMsgAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改 发货人信息</h3>
            </div>
            <div class="content">
				<asp:PlaceHolder ID="phCtrList" runat="server">
   
                <table>
                    <tr>
                        <td>
                            发货点:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="ShipperTag" IsAllowNull="false" runat="server" Width="300" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            网店名称:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="ShopName" IsAllowNull="false" runat="server" Width="300" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            发货人姓名:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="ShipperName" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            发货地区:
                        </td>
                        <td>
                            <XS:AreaList ID="alReceiveAreaList" BackFun="onReceiveAreaListSel" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            发货详细地址:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="Address" IsAllowNull="false" runat="server" Width="350" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            手机号码:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="CellPhone"  ValidateType="手机号" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电话号码:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="TelPhone" ValidateType="电话号码加区号" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            邮政编码:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="Zipcode"  ValidateType="邮政编码" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr id="hi">
                        <td>
                            设为默认:
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadKey" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Value="True" Selected="True">是</asp:ListItem>
                                <asp:ListItem Value="False">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            备注:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="Remark" TextMode="MultiLine" Width="300" Height="100" runat="server"
                                ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                </table>
            
</asp:PlaceHolder> 
            </div>
    </div>
</div>
 
<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="BB" />
</div>

    
 
<script>
jQuery(function ($) {
      var i=<%=SSID %>;
      if(i>0)
      {
       $("#hi").css("display","none");
      }
});
   
</script>
