<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassShow.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite.ClassShow" %>
<div class="u_tipsbox">
    查看记录明细[<a onclick="javascript:history.go(-1);">返回</a>]
</div>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            分类名称：
        </td>
        <td>
            <%=Model.ClassName %>
        </td>
    </tr>
    <tr>
        <td>
            添加日期：
        </td>
        <td>
            <%=Model.Adddatetime %>
        </td>
    </tr>
</table>