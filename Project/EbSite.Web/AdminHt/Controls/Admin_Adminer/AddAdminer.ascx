<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAdminer.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Adminer.AddAdminer" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>td{ padding: 5px;}</style>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>添加管理员</h3>
            管理员的添加会同时生成一个注册会员
            </div>
            <div class="content">
				 <table class="TableList">
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> 
                        <%=Resources.lang.EBUserName%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtUserName" runat="server" IsAllowNull="False" ValidateType="匹配由数字和26个英文字母组成的字符串" HintInfo="用户名称，不能为空" ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color='#E78A29'>*</font>
                         <%=Resources.lang.EBPassword%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="PassWord" runat="server"    TextMode="Password" IsAllowNull="False" ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color='#E78A29'>*</font>
                         <%=Resources.lang.EBConfirmPass%>：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="CfPassWord" runat="server" TextMode="Password" IsAllowNull="False" ></XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color='#E78A29'>*</font>
                         Email：
                    </td>
                    <td>
                        <XS:TextBoxVl ID="Email" runat="server"  ValidateType="电子邮箱email"    ></XS:TextBoxVl>
                    </td>
                </tr> 
                     
            </table>
              
            </div>
    </div>
</div>  
<div class="text-center mt10">
                    
<XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> "  runat="server" />
                </div>