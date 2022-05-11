<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Frdlink.LinkAdd" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加友情链接</h3>
            </div>
            <div class="eb-content">
				
 <asp:PlaceHolder ID="phCtrList" runat="server">
<table>
                <tr>
                    <td>站点名称:
                    </td>
                    <td>

                        <XS:TextBoxVl ID="SiteName" Width="300" IsAllowNull="false" runat="server"  ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>站点地址:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="Url" Width="300" IsAllowNull="false" ValidateType="网址Url" runat="server"  ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>logo 图片:
                    </td>
                    <td>
                        <XS:UploadImg ID="LogoUrl"    Ext="pg,gif,png"  Size="1024"      SaveFolder="LogoPic"  runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>QQ:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="QQ" Width="300"   ValidateType="QQ号" runat="server" ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>Emal:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="Email" Width="300" ValidateType="电子邮箱email" runat="server"  ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>电话:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="Tel" Width="300"   runat="server" ValidateType="电话号码加区号"  ></XS:TextBoxVl>
                    </td>
                </tr>
                 <tr>
                    <td>手机:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="Mobile" Width="300"   runat="server" ValidateType="手机号"  ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>描述:
                    </td>
                    <td>
                        <XS:TextBoxVl ID="Demo" Width="300" Height="100"   TextMode="MultiLine" runat="server"  ></XS:TextBoxVl>

                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <div style="text-align: center">
                           <XS:Button ID="bntSave" runat="server" Text=" 提 交 数 据 "  />
                        </div>

                    </td>
                </tr>
            </table>
</asp:PlaceHolder>
            </div>
    </div>
</div>