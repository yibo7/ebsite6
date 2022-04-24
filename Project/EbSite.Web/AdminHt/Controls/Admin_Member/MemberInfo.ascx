<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberInfo.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.MemberInfo" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" %>
 <XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>
 <div id="tg1">
 <table class="TableList">
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBUserName%>：
                    </td>
                    <td>
                        <XS:TextBox ID="txtUserName" runat="server" ReadOnly=true></XS:TextBox>
                    </td>
                </tr>               
              
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> Email：
                    </td>
                    <td>
                        <XS:TextBox ID="txtEmail" runat="server" RequiredFieldType="电子邮箱" CanBeNull="必填" ></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        手机号码：
                    </td>
                    <td>
                         <XS:TextBoxVl ID="txtMobileNumber" runat="server" RequiredFieldType="手机号"   >0</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户级别：
                    </td>
                    <td>
                         <XSD:UsreLevelList ID="drpUserLv" runat="server"></XSD:UsreLevelList>
                    </td>
                </tr>
               <tr>
                    <td>
                        是否通过审核：
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsApproved" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        是否锁定用户：
                    </td>
                    <td>
                        <XS:CheckBox ID="cbIsLockedOut" HintInfo="锁定后将不能登录"  runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        积分：
                    </td>
                    <td>
                         <XS:TextBoxVl ID="txtCredits" runat="server" RequiredFieldType="整数" CanBeNull="必填" >0</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        昵称：
                    </td>
                    <td>
                         <XS:TextBoxVl ID="txtNiName" runat="server" RequiredFieldType="禁止输入特殊字符" CanBeNull="必填" >0</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        签名：
                    </td>
                    <td>
                         <XS:TextBoxVl ID="txtSign" runat="server" RequiredFieldType="禁止输入特殊字符" CanBeNull="必填" >0</XS:TextBoxVl>
                    </td>
                </tr>
                <tr>
                    <td>
                        注册时间：
                    </td>
                    <td>
                        <asp:Literal ID="llCreateDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                 <tr>
                    <td>
                        最后一次登录时间：
                    </td>
                    <td>
                        <asp:Literal ID="llLastLoginDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                 <tr>
                    <td>
                        最后密码更改时间：
                    </td>
                    <td>
                        <asp:Literal ID="llLastPasswordChangedDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                 <tr>
                    <td>
                        最后被锁定时间：
                    </td>
                    <td>
                        <asp:Literal ID="llLastLockoutDate" runat="server"></asp:Literal>
                    </td>
                </tr>
     
                <tr>
                    <td>
                        TokenKey：
                    </td>
                    <td>
                        <asp:Literal ID="lbToken" runat="server"></asp:Literal>
                    </td>
                </tr>
               
            </table>
 </div>

  <div id="tg2">
  <table class="TableList">
                
                <asp:placeholder id="phDefaultFileds" runat="server"></asp:placeholder>
           
               
            </table>
 </div>

<asp:Literal ID="llTagEnd" runat="server"></asp:Literal>



<div style=" text-align:center; margin:20px;"><XS:Button ID="bntSave" runat="server" Text="修改用户" /></div>