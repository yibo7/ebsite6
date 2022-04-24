<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bbsconfigs_ChannelManer_a.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement.Bbsconfigs_ChannelManer_a" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%--<%@ Register Assembly="EbSite.Modules.BBS" Namespace="EbSite.Modules.BBS.ExtensionsCtrls" TagPrefix="EB" %>--%>

<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加版主</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            版块分类：
                        </td>
                        <td>
                            <XS:DropDownList ID="drpPatentID" AppendDataBoundItems=true runat="server">
                                
                            </XS:DropDownList> 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            版主名称：
                        </td>
                        <td>
                         <XS:TextBoxVl  ID="txtUserName" runat="server" IsAllowNull="false"></XS:TextBoxVl >
                       </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保 存 " />
    <XS:Button ID="btnColseGreyBox" runat="server" Text=" 取 消 " />
</div>
