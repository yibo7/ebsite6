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
                        <XS:TextBox ID="txtUserName" runat="server" CanBeNull="必填" HintInfo="用户名称，不能为空" HintShowType="down"
                            HintTitle="提示" MaxLength="100"></XS:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBPassword%>：
                    </td>
                    <td>
                        <XS:TextBox ID="PassWord" runat="server" TextMode="Password" CanBeNull="必填" ></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBConfirmPass%>：
                    </td>
                    <td>
                        <XS:TextBox ID="CfPassWord" runat="server" TextMode="Password" CanBeNull="必填" ></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> Email：
                    </td>
                    <td>
                        <XS:TextBox ID="Email" runat="server" RequiredFieldType="电子邮箱" CanBeNull="必填" ></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBRegister%>" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>