<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Address.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
 <div style="text-align:left;">
<table id="tabControlPanel" class="link-addtd" cellpadding="0" cellspacing="0" style="text-align:left;">
                    <tr>
                        <td>
                            收货人姓名:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtUserName" IsAllowNull="false" runat="server" HintInfo="用户姓名不能为空"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;省&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;份:</td>
                        <td>
                           <XS:AreaList ID="ddl_address" runat="server"></XS:AreaList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址:</td>
                        <td><span id="labCountry" style="font-size: 14px; color: #999999;"></span>
                            <span id="labPri" style="font-size: 14px; color: #999999;"></span>
                            <span id="labCity" style="font-size: 14px; color: #999999;"></span>
                            <span id="labArea" style="font-size: 14px; color: #999999;"></span>
                            <XS:TextBoxVl ID="txtAddress" runat="server" IsAllowNull="false"></XS:TextBoxVl></td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;手机号码:</td>
                        <td><XS:TextBoxVl ID="txtPhone" runat="server" IsAllowNull="false" ValidateType="手机号"></XS:TextBoxVl></td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;固定电话:</td>
                        <td><XS:TextBoxVl ID="txtTelnum" runat="server"></XS:TextBoxVl></td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;邮政编码:</td>
                        <td><XS:TextBoxVl ID="txtZipCode" runat="server" IsAllowNull="true" ValidateType="邮政编码"></XS:TextBoxVl></td>
                    </tr>
                     <tr>
                        <td>&nbsp;&nbsp;&nbsp;Email:</td>
                        <td><XS:TextBoxVl ID="txtMail" runat="server" IsAllowNull="true" ValidateType="电子邮箱email"></XS:TextBoxVl></td>
                    </tr>
                </table>
     </div>
</asp:PlaceHolder>
<div style="text-align:center">
    <XS:Button ID="btnSave" runat="server" Text=" 保 存 " onclick="btnSave_Click"  />
    <input type="button" class="AdminButton" onclick="BackPage()" value=" 返 回 " />
</div>
<script type="text/javascript">
    $(document).ready(function () {
        //国家
        $("#ctl00_ctphBody_ctl00_ddl_address1Select").change(function () {
            var lab = $(this).find("option:selected").text();
            if (lab == "请选择")
            {
                lab = "";
                $("#labArea").text(lab);
                $("#labCity").text(lab);
                $("#labPri").text(lab);
            }
            $("#labCountry").text(lab);
        });
        //省
        $("#ctl00_ctphBody_ctl00_ddl_address2Select").change(function () {
            var lab = $(this).find("option:selected").text();
            if (lab == "请选择") {
                lab = "";
                $("#labArea").text(lab);
                $("#labCity").text(lab);
            }
            $("#labPri").text(lab);
        });
        //市
        $("#ctl00_ctphBody_ctl00_ddl_address3Select").change(function () {
            var lab = $(this).find("option:selected").text();
            if (lab == "请选择") {
                lab = "";
                $("#labArea").text(lab);
            }
            $("#labCity").text(lab);
            
        });
        //县
        $("#ctl00_ctphBody_ctl00_ddl_address4Select").change(function () {
            var lab = $(this).find("option:selected").text();
            if (lab == "请选择") {
                lab = "";
            }
            $("#labArea").text(lab);
        });
    });

    function BackPage() {
        window.location.href = "?mukey=a20e4ef2-6061-4813-ab67-d5a932586309";
    }
</script>

