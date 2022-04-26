<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMember.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.AddMember" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>td{ padding: 5px;}</style>
 
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加会员</h3>
            </div>
            <div class="content">
				  <table class="TableList">
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBUserName%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtUserName" runat="server" IsAllowNull="false" ValidateType="匹配由数字和26个英文字母组成的字符串" HintInfo="用户名称，不能为空"  ></XS:TextBoxVl>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBPassword%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="PassWord" runat="server" TextMode="Password" IsAllowNull="false" ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBConfirmPass%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="CfPassWord" runat="server" TextMode="Password" IsAllowNull="false" ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> Email：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="Email" runat="server" ValidateType="电子邮箱email" IsAllowNull="false" ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <XS:Button ID="bntSave" IsTipsButtonRight="true" runat="server" Text="<%$Resources:lang,EBRegister%>" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>