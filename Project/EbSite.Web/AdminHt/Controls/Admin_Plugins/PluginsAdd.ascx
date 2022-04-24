<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginsAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Plugins.PluginsAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>安装插件</h3>
            目前插件的安装包只支持.dll格式，可以从 <a href='http://www.ebsite.net' target=_blank><b>官方插件共享平台</b></a>下载更多插件！
            </div>
            <div class="content">
				 <table cellpadding="0"  cellspacing="0">
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
            </table>
            </div>
    </div>
</div>
 <style>td{ padding: 5px;}</style>