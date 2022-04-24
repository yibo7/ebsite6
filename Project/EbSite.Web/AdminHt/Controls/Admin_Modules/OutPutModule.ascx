<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutPutModule.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.OutPutModule" %>
<%@ Import Namespace="Resources" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <table  >
            <tr>
                <td><b><%=Resources.lang.EBModelName%>:</b></td>
                <td>
                   <%=Model.ModuleName %>
                </td>
            </tr>
            <tr>
                <td><b>出品单位:</b></td>
                <td>
                    <%=Model.Author %>
                </td>
            </tr>
            <tr>
                <td><b>单位主页:</b></td>
                <td>
                    <%=Model.AuthorUrl %>
                </td>
            </tr>
            <tr>
                <td><b>版本号:</b></td>
                <td>
                   <%=Model.Version %>
                </td>
            </tr>
            <tr>
                <td><b>模块简介:</b></td>
                <td>
                    <%=Model.Demo %>
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:Label ID="llInfo" runat="server" ForeColor="Red" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style=" text-align:center">
                    <XS:Button ID="bntOut" OnClick="bntOut_Click" runat="server" Text=" 确认导出模块 "  IsTipsButtonRight="true" Tips_Msg="正在打包模块..."  />   
                </td>
            </tr>
        </table> 
        </div>
    </div>
</div>
 <style>td{ padding: 5px;}</style>