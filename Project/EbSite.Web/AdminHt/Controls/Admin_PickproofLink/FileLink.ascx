<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileLink.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PickproofLink.FileLink" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>修改文件防盗配置</h3>
            </div>
            <div class="content">
				<table>
                <tr>
                    <td>                    
                        是否开启：               
                    </td>                
                    <td>
                        <XS:CheckBox ID="cbIsOpenPickproofLink"  runat="server"  ></XS:CheckBox>
                    </td>
               
                </tr>      
               <tr>
                    <td>                    
                        图片后缀：               
                    </td>                
                    <td>
                        <XS:TextBoxVL ID="txtPickproofLinkPre" HintInfo="图片后缀用逗号分开，如 .gif,.png,.jpg" IsAllowNull="false" runat="server" Width="500px"></XS:TextBoxVL>
                    </td>
               
                </tr>
                <tr>
               
                <td colspan="2" style="padding: 10px;">

                        <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>"  />
                </td>
           </tr>
    </table>
            </div>
    </div>
</div>