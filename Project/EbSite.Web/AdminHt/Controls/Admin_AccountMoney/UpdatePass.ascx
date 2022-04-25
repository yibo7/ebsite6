<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdatePass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_AccountMoney.UpdatePass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>后台修改交易密码</h3>
            </div>
            <div class="content">
				       
<asp:PlaceHolder ID="phCtrList" runat="server">
                <table>
                    <tr>
                         <td>
                            用户名:
                        </td>
                        <td>
                           <asp:Label ID="lbUName" runat="server"
                                Text="Label"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td>
                            新交易密码:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtPassWord" IsAllowNull="False" TextMode="Password"  MinimumValue="6"  MaximumValue="20" HintInfo="交易密码不能为空,长度限制在6-20个字符之间"    runat="server"></XS:TextBoxVl> 
                           
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            重复输入一次:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtCfPassWord" IsAllowNull="False"  HintInfo="重复确认交易密码" TextMode="Password"  runat="server"></XS:TextBoxVl>
                            
                        </td>
                    </tr>
                   
                </table>
             
</asp:PlaceHolder>
            </div>
    </div>
</div>
<div style="display: none">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="BB" />
</div>
<script>
    function SaveFrame() {
        $("#<%=bntSave.ClientID%>").click();
    }
</script>