<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pages.frdlinkpost" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        
        <div style="margin: 0 auto; width: 99%;">

            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>站点名称:
                    </td>
                    <td>

                        <XS:TextBoxVl ID="tbSiteName" Width="300" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>站点地址:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tburl" Width="300" ValidateType="网址Url" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>logo 图片:
                    </td>
                    <td>
                        <XS:SWFUpload ID="upTest" AllowExt="jpg,gif,png"  UploadModel="SWFUpload组件"  AllowSize="1024" Width="300"  HintInfo="上传文件只允许上传图片文件哦，并且只能上传jpg,gif,png格式的图片" SaveFolder="LogoPic"  runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>QQ:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbQQ" Width="300" IsAllowNull="false" ValidateType="QQ号" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>Emal:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbemail" Width="300" IsAllowNull="false" ValidateType="电子邮箱email" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>电话:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbtel" Width="300" IsAllowNull="false" runat="server" ValidateType="电话号码加区号" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                 <tr>
                    <td>手机:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbmobile" Width="300" IsAllowNull="false" runat="server" ValidateType="手机号" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>描述:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="tbdemo" Width="200" Height="100" IsAllowNull="false" TextMode="MultiLine" runat="server" ValidationGroup="BB"></XS:TextBoxVl>

                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                            <XS:Button ID="bntSave" runat="server" Text=" 提交申请 " ValidationGroup="BB"  OnClick="bntSave_Click"/>
                        </div>

                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
