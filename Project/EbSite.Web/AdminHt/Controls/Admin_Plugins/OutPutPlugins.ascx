<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutPutPlugins.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Plugins.OutPutPlugins" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>导出插件</b></h4>
            <table  >
            <tr>
                <td><b>插件名称:</b></td>
                <td>
                   <%=Model.Name%>
                </td>
            </tr>
            <tr>
                <td><b>插件状态:</b></td>
                <td>
                   <%=bool.Parse(Model.Enabled.ToString()) ? " 启用 " : " <font color=red>禁用</font> "%>
                </td>
            </tr>
            <tr>
                <td><b>类型</b></td>
                <td>
                    <%=Model.TypeName%>
                </td>
            </tr>
            <tr>
                <td><b>单位</b></td>
                <td>
                    <%=Model.Author%>
                </td>
            </tr>
            <tr>
                <td><b>版本号:</b></td>
                <td>
                   <%=Model.Version %>
                </td>
            </tr>
           
            <tr>
                <td colspan="2" >
                    <asp:Label ID="llInfo" runat="server" ForeColor="Red" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style=" text-align:center">
                    <XS:Button ID="bntOut" OnClick="bntOut_Click" runat="server" Text=" 确认导出插件 " />   
                </td>
            </tr>
        </table> 
        </div>
    </div>
</div>
 <style>td{ padding: 5px;}</style>