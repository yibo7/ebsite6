<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MobileThemesAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Themes.MobileThemesAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>td{ padding: 5px;}</style>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>手机皮肤修改</h3>
            </div>
            <div class="eb-content">
				<table>
                <tr>
                    <td>
                        皮肤名称:
                    </td>
                    <td>
                        <XS:TextBox ID="ThemesName" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        皮肤目录:
                    </td>
                    <td>
                        <XS:TextBox ID="ThemePath" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        存放目录:
                    </td>
                    <td>
                         <XS:TextBox ID="FullPath" runat="server" ReadOnly=true></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        登录时间:
                    </td>
                    <td>
                         <XS:TextBox ID="AddDate" runat="server" ReadOnly=true></XS:TextBox>
                    </td>
                </tr>
                <%-- <tr>
                    <td>
                        适合站群:
                    </td>
                    <td>
                          <asp:DropDownList ID="drpSites" runat="server" AutoPostBack="true" >
                           </asp:DropDownList>
                    </td>
                </tr>--%>
            </table>
            </div>
    </div>
</div>
<div class="text-center mt10">    
    <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" ValidationGroup="savedata" />
</div>