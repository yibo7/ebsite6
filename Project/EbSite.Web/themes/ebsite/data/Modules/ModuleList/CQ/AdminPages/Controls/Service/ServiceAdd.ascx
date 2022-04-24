<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ServiceAdd.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Service.ServiceAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改信息</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            客服名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="ServiceName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            客服类别:
                        </td>
                        <td>                        
                            <XS:DropDownList ID="ClassID" runat="server"></XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            职位:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="PostName"    IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电话:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="Phone"  ValidateType="电话号码加区号"  IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            手机:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="Mobile" ValidateType="手机号"    IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="Email" ValidateType="电子邮箱email"  IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>是否启用:</td>
                        <td><asp:CheckBox ID="IsEabled" runat="server" Checked="true" /></td>
                    </tr>
                    <tr>
                        <td>
                            关联登录帐号:
                        </td>
                        <td>                        
                            <XSD:SelectUser Width="300" ID="txtUserInfo" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            客服简介:
                        </td>
                        <td>                        
                            <asp:TextBox TextMode="MultiLine" Height="100" Width="300" ID="Info" runat="server"  />
                        </td>
                    </tr>

                    
                    
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div> 
