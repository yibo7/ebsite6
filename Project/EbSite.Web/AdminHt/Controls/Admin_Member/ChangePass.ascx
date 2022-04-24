<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.ChangePass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>修改密码ff</h3>
            </div>
            <div class="content">
				 <table class="TableList">
                    <tr>
                        <td>
                            <font color='#E78A29'>*</font> <%=Resources.lang.EBUserName%>：
                        </td>
                        <td>
                            <%=UName %>
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
                        <td colspan="2" style="text-align: center">
                            <XS:Button ID="bntSave" runat="server" Text="修改" />
                        </td>
                    </tr>
                </table>
            </div>
    </div>
</div>
 