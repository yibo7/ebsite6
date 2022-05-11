<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageCode.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.PageCode" %>
<%@ Import Namespace="EbSite.Base.Configs.ContentSet" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
            <h3>分页设置</h3>
            以下设置只是默认值，如果在模板的分页控件里指定分页数，将会替换掉这里的配置。
        </div>
        <div class="eb-content">
            <table>
                <tr>
                    <td>
                        首页内容列表：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtPageSizeIndex" HintInfo="首页内容列表每页显示数量" ValidateType="匹配正整数" IsAllowNull="false" runat="server" Width="80"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBPageListSize%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtPageSizeClass" ValidateType="匹配正整数" IsAllowNull="false" runat="server" Width="80"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBSpcListPg%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtPageSizeSpecial" ValidateType="匹配正整数" IsAllowNull="false" runat="server" Width="80"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBLblListSize%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtPageSizeTag" ValidateType="匹配正整数" IsAllowNull="false" runat="server" Width="80"></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBTagSearSize%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtPageSizeTagValue"  ValidateType="匹配正整数" IsAllowNull="false" runat="server" Width="80"></XS:TextBoxVl>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div class="text-center mt10">

    <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>" />
</div>
