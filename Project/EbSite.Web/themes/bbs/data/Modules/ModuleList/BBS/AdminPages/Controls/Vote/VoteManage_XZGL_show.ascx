<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VoteManage_XZGL_show.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.VoteManage_XZGL_show" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    <fieldset>
        <legend>投票详细信息 </legend>
        <div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        选项：
                    </td>
                    <td>
                        <%=Model.title%>
                    </td>
                </tr>
                <tr>
                    <td>
                        选项颜色：
                    </td>
                    <td>
                        <%=Model.color%>
                    </td>
                </tr>
                <tr>
                    <td>
                        所属主题：
                    </td>
                    <td>
                     <%=Model.bigtitle%>
                    </td>
                </tr>
                 <tr>
                    <td>
                        投票人员：
                    </td>
                    <td>
                     <%=Model.TpRealname%>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</div>
<div style="text-align: center">
    <XS:Button ID="btnColse" runat="server" OnClientClick="btnClose_click()" Text=" 关 闭 窗 口 " />
</div>
