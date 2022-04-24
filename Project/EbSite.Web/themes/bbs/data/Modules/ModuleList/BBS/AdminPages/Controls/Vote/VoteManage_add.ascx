<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteManage_add.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.VoteManage_add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%--<%@ Register Assembly="EbSite.Web" Namespace="EbOA.Web.CusttomControls" TagPrefix="EB" %>--%>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            投票主题：
                        </td>
                        <td>
                            <XS:TextBoxVl ID="title" runat="server"  IsAllowNull="false"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            选择类型：
                        </td>
                        <td>
                            <XS:DropDownList ID="ddlXZLX" runat="server" Width="200px">
                            <asp:ListItem Text="单选" Value="单选"></asp:ListItem>
                            <asp:ListItem Text="多选" Value="多选"></asp:ListItem>
                            </XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            公开投票：
                        </td>
                        <td>
                           <XS:DropDownList ID="ddlIfOpen" runat="server" Width="200px">
                            <asp:ListItem Text="公开" Value="公开"></asp:ListItem>
                            <asp:ListItem Text="关闭" Value="关闭"></asp:ListItem>
                            </XS:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            允许投票人员：
                        </td>
                        <td>
                           <%-- <EB:SelectUsers ID="sbuTPRY" runat="server" Width="200px"/>--%>
                          
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
