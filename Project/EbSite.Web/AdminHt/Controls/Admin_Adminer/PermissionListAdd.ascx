<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermissionListAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Adminer.PermissionListAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>td{ padding: 5px;}</style>
 


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改权限</h3>
            </div>
            <div class="eb-content">
				 <table class="TableList">
               <tr>
                    <td>
                        <font color='#E78A29' >*</font> 
                            上级权限：
                    </td>
                    <td>
                       <XS:DropDownList ID="drpPatentID" AppendDataBoundItems=true runat="server">
                                <asp:ListItem Value="0" Selected="True">一级权限</asp:ListItem>
                        </XS:DropDownList>  
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> 权限名称：
                    </td>
                    <td>
                        <xs:TextBoxVL  IsAllowNull="false"    ID="txtPermissionName" runat="server"></xs:TextBoxVL>
                            
                    </td>
                </tr>                
                
               
            </table>
            </div>
    </div>
</div>
 <div class="text-center mt10">
     
    <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " Width="150" runat="server" />

 </div>