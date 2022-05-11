<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetupPlugin.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Component.SetupPlugin" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>安装组件</h3>
            </div>
            <div class="eb-content">
                考虑到安全性问题，ebsite 6.0.0后不再提供在后台上传动态组件。
                您可以手动将你的组件放到根目录下的App_Code里，系统会自动加载并运行。
				 <%--<table cellpadding="0"  cellspacing="0">
                <tr>
                        <td>安装路径:</td>
                        <td>
                            /App_Code/Plugins/
                        </td>
                        <td>
                        </td>
                </tr>  
                <tr>
                    <td>选择插件文件:</td>
                    <td>
                        <XS:SWFUpload HintInfo="组件是一种C#代码文件，所以组件要以.cs为后缀" ID="txtMdPath" AllowSize="300" AllowExt="cs" runat="server"></XS:SWFUpload>
                    </td>
                    <td>
                        
                    </td>
                </tr>  
                <tr>
                    <td style="text-align:center; padding:10px;" colspan="2">
                        <XS:Button ID="bntSetup" Text="<%$Resources:lang,EBStrtInstall %>" runat="server" onclick="bntSetup_Click"  />
                    </td>
                </tr>
            </table>--%>
            </div>
    </div>
</div>