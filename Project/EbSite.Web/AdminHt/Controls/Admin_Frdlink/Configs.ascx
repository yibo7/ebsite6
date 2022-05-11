<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Configs.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Frdlink.Configs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>修改友情链接配置</h3>
            </div>
            <div class="eb-content">
				<table>       
     
            
           <tr>
                 <td>
                   友情连接展示页描述：            
                </td>
                <td>                  
                    <XS:Editor ID="txtFrdLinkDemo" ExtImg="png,jpg,gif"       Width="500" Height="300"  runat="server" />  
                </td>             
           </tr>   
           
           <tr>
                 <td>
                   是否允许申请友情连接：            
                </td>
                <td>                  
                    <XS:CheckBox ID="cbIsAllowApplyFrdLink" HintInfo="选择否，前台无法提交连接连接申请"  runat="server" />
                </td>             
           </tr>   
           <tr>
               
                <td colspan="2" style="text-align: center">

                        <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>"  />
                </td>
           </tr>
    </table>
            </div>
    </div>
</div>
 