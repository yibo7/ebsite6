<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="--BaseConfig.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.BaseConfig" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    
    <fieldset>
        <legend>基础设置</legend>
        <div>
            <table class="TableList">
                <tr>
                    <td colspan="2" style="color:Red">
                       注意，此配置为程序安装时生成好的配置参数，非必要的情况下请不要随意改动，
                       否则有可能造成系统不能正常运行。
                    </td>
                    
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBFounderAcc %>：
                    </td>
                    <td>
                        <XS:TextBox ID="FounderuID" runat="server" Width="50" ReadOnly="true" CanBeNull="必填" HintInfo="安装系统时的默认管理员ID"          ></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBSysDataLay%>：
                    </td>
                    <td>
                        <XS:TextBox ID="DataLayerType" runat="server"  CanBeNull="必填" HintInfo="如果更换不同的数据层可以在这里更换，如 mysql"></XS:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBSysDbConnStr%>：
                    </td>
                    <td>
                        <XS:TextBox ID="ConnectionStringSysCms" runat="server" CanBeNull="必填" HintInfo="本系统提供两种数据库连接串，此为系统使用的连接串"></XS:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td> 
                        <%=Resources.lang.EBSysDTabPrefix%>：
                    </td>
                    <td>
                        <XS:TextBox ID="TablePrefix" runat="server"  ></XS:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <%=Resources.lang.EBUsrDLayAssNm%>：
                    </td>
                    <td>
                        <XS:TextBox ID="DataLayerTypeUser" runat="server"  CanBeNull="必填" HintInfo="如果更换不同的数据层可以在这里更换，如 mysql"></XS:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBUsrDConnStr%>：
                    </td>
                    <td>
                        <XS:TextBox ID="ConnectionStringUser" runat="server" CanBeNull="必填" HintInfo="本系统提供两种数据库连接串，此为用户数据库使用的连接串，无须再更改web.config里的membership数据连接串"></XS:TextBox>
                    </td>
                </tr>
               
                 <tr>
                    <td>
                        <%=Resources.lang.EBUsrDtPrefix%>：
                    </td>
                    <td>
                        <XS:TextBox ID="TablePrefixUser" runat="server" ></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>"  />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</div>
