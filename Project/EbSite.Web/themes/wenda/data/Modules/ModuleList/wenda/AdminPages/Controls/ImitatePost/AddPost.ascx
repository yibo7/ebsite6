<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddPost.ascx.cs" Inherits="EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost.AddPost" %>
<%@ Import Namespace="EbSite.Modules.Wenda" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>



<div style=" font-size:15px; margin-left:10px; margin-top:10px; background-color:#DAF3BE; height:50px;">
 页面在系统设置中配置，<a href='/adminht/Admin_Modules.aspx?t=2&mid=4e0edb7e-1b30-41ad-9f74-d63c80458c35'> 进入</a> 。
 <br>
 为了系统的安全，建议修改，<a  target="_blank" href='/<%=Configs.Instance.Model.txtCatalog %>'> 快速进入模拟发帖！</a>

</div>
<div style=" display:none;">
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加信息</legend>
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            标题 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtTT" IsAllowNull="false" runat="server" ValidationGroup="BB">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            内容 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtCT" IsAllowNull="false" runat="server" ValidationGroup="BB">
                            </XS:TextBoxVl>
                        </td>
                    </tr>

                    <tr>
                        <td height="25" width="30%" align="right">
                            选择模拟用户 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList runat="server" ID="DrpPostUser" AutoPostBack="true" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            发帖人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtSend"   IsAllowNull="false" runat="server" ValidationGroup="BB">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td height="25" width="30%" align="right">
                            发帖人ID ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtSendID"   IsAllowNull="false" runat="server" ValidationGroup="BB">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            回答人 ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtAnswer" IsAllowNull="false" runat="server" ValidationGroup="BB">
                            </XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td height="25" width="30%" align="right">
                            回答人ID ：
                        </td>
                        <td height="25" width="*" align="left">
                            <XS:TextBoxVl ID="txtAnswerID" IsAllowNull="false" runat="server" ValidationGroup="BB">
                            </XS:TextBoxVl>
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
</div>