<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteManage_XZGL_add.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.VoteManage_XZGL_add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            选项：
                        </td>
                        <td>
                            <XS:TextBoxVl ID="title" runat="server" IsAllowNull="false"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            选项颜色：
                        </td>
                        <td>
                            <XS:ColorPicker ID="cpColor" Color="FF0000" runat="server" />
                        </td>
                       
                    </tr>
                    <tr>
                        <td>
                            票数：
                        </td>
                        <td>
                           <XS:TextBoxVl ID="piaoshu" runat="server" IsAllowNull="false" ValidateType=整数 ></XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            所属主题：
                        </td>
                        <td>
                           <XS:DropDownList ID="ddlSSZT" runat="server" DataTextField="title" DataValueField="id" Width="200px"></XS:DropDownList>
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
