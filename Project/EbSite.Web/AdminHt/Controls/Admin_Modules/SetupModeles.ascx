<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetupModeles.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.SetupModeles" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>安装模块</h3>
            目前模块的安装包只支持.rar与.zip两种格式，为方便模块开发，也可以单独加载一个.dll文件，可以从 <a href='http://www.ebsite.net' target=_blank><b>官方模块共享平台</b></a>下载更多安装包！
            </div>
            <div class="eb-content">
				 <table cellpadding="0"  cellspacing="0">
                <tr>
                        <td><%=Resources.lang.EBInstallPath %>:</td>
                        <td >
                        &nbsp;
                            <XS:TextBoxVl Width="350"  Enabled="false" ID="txtSetupPath" Msg="安装路径（相对路径，如 shop/），可保持默认"  runat="server"></XS:TextBoxVl>
                        </td>
                </tr> 
                <tr>
                        <td><%=Resources.lang.EBStorFold%>:</td>
                        <td >&nbsp;
                            <XS:TextBoxVl ID="txtFolder" Enabled="false" Msg="将在上面 安装路径 下创建此文件夹"  CanBeNull="必填" runat="server"></XS:TextBoxVl>
                            <asp:CheckBox ID="cbRand" onclick="RandName(this)" Text="随机命名" Checked="true" runat="server" />
                        </td>
                </tr> 
                <tr>
                    <td><%=Resources.lang.EBSelectModu%>:</td>
                    <td>
                       
                    <XS:SWFUpload  SaveFolder="ModeleDLL"  UploadModel="SWFUpload组件"        HintInfo="模块文件以.zip,.dll为后缀的压缩包文件" ID="txtMdPath" AllowSize="10024" AllowExt="zip,dll" runat="server"></XS:SWFUpload>
                    </td>
                </tr>  
                <tr>
                    <td style="text-align:center; padding:10px;" colspan="2">
                        <XS:Button ID="bntSetup" Text="<%$Resources:lang,EBStrtInstall %>" Tips_Msg="正在处理,请不要关闭窗口..."  runat="server" onclick="bntSetup_Click"  />
                    </td>
                </tr>
            </table>
           <script>
               function RandName(ob) {
               //ob.checked
                   $("#<%=txtFolder.ClientID %>").attr("disabled", ob.checked);
                   if (!ob.checked)
                    $("#<%=txtFolder.ClientID %>").focus();
               }
           </script>
            </div>
    </div>
</div>

<style>td{ padding: 5px;}</style>