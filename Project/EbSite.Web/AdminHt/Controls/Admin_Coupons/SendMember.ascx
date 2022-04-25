<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendMember.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Coupons.SendMember" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>发送给会员</h3>
            </div>
            <div class="content">
				<asp:PlaceHolder ID="phCtrList" runat="server">
                       <table >
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                发送对象：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <asp:RadioButtonList ID="RdoName" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"  OnSelectedIndexChanged="RdoName_SelectedIndexChanged" >
                                                    <asp:ListItem Value="0" Selected="True">发送给指定的会员</asp:ListItem>
                                                    <asp:ListItem Value="1">发送给指定的会员等级</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                会员等级 ：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <XS:DropDownList ID="rank" runat="server" Enabled="false">
                              
                                                </XS:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                会员名 ：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <XS:TextBoxVl ID="txtMemberNames" runat="server"  onkeydown="javascript:this.value=this.value.replace('，',',')" TextMode="MultiLine" Height="100px"
                                                    Width="400px"></XS:TextBoxVl>
                                                <br />
                                                请用用逗号分开添写
                                            </td>
                                        </tr>
                                    </table>
                    </asp:PlaceHolder> 
            </div>
    </div>
</div> 
<div class="text-center mt10">    
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>
 