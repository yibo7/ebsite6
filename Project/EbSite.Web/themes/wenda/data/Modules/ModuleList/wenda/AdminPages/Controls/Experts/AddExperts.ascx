<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddExperts.ascx.cs"
    Inherits="EbSite.Modules.Wenda.AdminPages.Controls.Experts.AddExperts" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            选择用户 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XSD:SelectUser Width="300" ID="txtUserInfo" runat="server" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td height="25" width="30%" align="right">
                            职位 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="Postition" runat="server" Width="200px">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            擅长领域 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="Field" runat="server" Width="200px">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            所在地区 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="Area" runat="server" Width="200px">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td height="25" width="30%" align="right">
                            擅长品牌 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl id="Brand" runat="server" Width="200px">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                         <td height="25" width="30%" align="right">
                            是否通过审核 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButton ID="rdoYES" runat="server" GroupName="rdoaudit" Text="是"/><asp:RadioButton ID="rdoNo" runat="server" GroupName="rdoaudit" Text="否" Checked="true"  />
                        </td>
                    </tr>
                     <tr>
                        <td height="25" width="30%" align="right">
                            简介 ：
                        </td>
                        <td height="25" width="*" align="left">
                             <XS:TextBox ID="JianJie" Width="300" Height="100"  TextMode="MultiLine" HintInfo="专家简介"  runat="server" ></XS:TextBox>
                         
                           
                        </td>
                    </tr>
                    
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>
