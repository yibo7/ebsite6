<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_Topics_gl.ascx.cs"
    Inherits="EbSite.Modules.BBS.UserPages.Controls.BBS.BBS_Topics_gl" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div>
    <table>
        <tr align="left">
            <td rowspan="12">
                <XS:RadioButtonList ID="rbXX" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="删除"></asp:ListItem>
                    <asp:ListItem Value="2" Text="标题变色"></asp:ListItem>
                    <asp:ListItem Value="3" Text="加粗"></asp:ListItem>
                    <asp:ListItem Value="4" Text="板块置顶"></asp:ListItem>
                    <asp:ListItem Value="5" Text="取消板块置顶"></asp:ListItem>
                    <asp:ListItem Value="6" Text="全站置顶"></asp:ListItem>
                    <asp:ListItem Value="7" Text="取消全站置顶"></asp:ListItem>
                    <asp:ListItem Value="8" Text="加精"></asp:ListItem>
                    <asp:ListItem Value="9" Text="取消加精"></asp:ListItem>
                    <asp:ListItem Value="10" Text="推荐"></asp:ListItem>
                    <asp:ListItem Value="11" Text="取消推荐"></asp:ListItem>
                    <asp:ListItem Value="12" Text="帖子转移至"></asp:ListItem>
                </XS:RadioButtonList>
            </td>
            <td>
              
            </td>
        </tr>
        <tr  align="left">
            <td>
                <XS:ColorPicker ID="cpColor"  runat="server" />
            </td>
        </tr>
        <tr  align="left">
            <td>
              
            </td>
        </tr>
        <tr  align="left">
            <td>
               
            </td>
        </tr>
        <tr  align="left">
            <td>
              
            </td>
        </tr>
        <tr align="left">
            <td>
               
            </td>
        </tr>
        <tr align="left">
            <td>
               
            </td>
        </tr>
        <tr align="left">
            <td>
               
            </td>
        </tr>
        <tr align="left">
            <td>
              
            </td>
        </tr>
        <tr align="left">
            <td>
               
            </td>
        </tr>
        <tr align="left">
            <td>
               
            </td>
        </tr>
        <tr align="left">
            <td>
              <XS:DropDownList ID="ddlBKFL" runat="server" DataTextField="ChannelName" DataValueField="id" Width="200px"></XS:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div style="text-align: center">
    <XS:Button ID="btnBC" runat="server" Text=" 保 存 " OnClick="btnBC_Click"/>   
     <XS:Button ID="btnClose" runat="server" Text=" 关 闭 " OnClick="btnClose_Click"/>   
</div>
