<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Comment.AddClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加评论页</h3>
            </div>
            <div class="eb-content">
				<table style="width:100%;">
                    <tr>                       
                        <td width="50" >
                           名称：
                        </td>
                        <td style="text-align:left">
                           <XS:TextBox ID="txtClassName" CanBeNull="必填"     runat="server"></XS:TextBox>
                        </td>
                    </tr>
                    <tr>                       
                        <td width="50" >
                           类别：
                        </td>
                        <td style="text-align:left">
                            <XS:DropDownList ID="itype" runat="server">
                                <asp:ListItem Value="1">无限回复式</asp:ListItem>
                                <asp:ListItem Value="2">评价系统</asp:ListItem>
                                <asp:ListItem Value="3">商家问答式</asp:ListItem>
                            </XS:DropDownList>
                        </td>
                    </tr>
                    <%-- <tr>                       
                        <td width="50" >
                           页面：
                        </td>
                        <td style="text-align:left">
                            <asp:DropDownList ID="iPage" runat="server">
                                <asp:ListItem Value="1">分类页面</asp:ListItem>
                                <asp:ListItem Value="2">内容页面</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                     <tr>         
                         <td></td>
                        <td>
                           <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
    </div>
</div>
 <style>td{ padding: 5px;}</style>