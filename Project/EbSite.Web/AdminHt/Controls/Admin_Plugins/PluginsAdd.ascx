<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginsAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Plugins.PluginsAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>安装插件</h3>
            目前插件的安装包只支持.dll格式！
            </div>
            <div class="eb-content">
                考虑到安全性问题，ebsite 6.0.0后不再提供在后台上传插件。 您可以手动将你的插件放到根目录下的/Plugins/里，系统会自动加载并运行。
                
				 <%--<table cellpadding="0"  cellspacing="0">
                <tr>
                        <td><%=Resources.lang.EBInstallPath%>:</td>
                        <td>
                            /Plugins/
                        </td>
                        <td>
                        </td>
                </tr>  
                <tr>
                    <td><%=Resources.lang.EBSelectPlug%>:</td>
                    <td>
                        <XS:SWFUpload HintInfo="插件文件以.dll为后缀的程序集文件" ID="txtMdPath" AllowSize="10024" AllowExt="dll" runat="server"></XS:SWFUpload>
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
 <style>td{ padding: 5px;}</style>