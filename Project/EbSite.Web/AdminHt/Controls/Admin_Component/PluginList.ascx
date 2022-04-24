<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Component.PluginList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader ">
                <h3>动态组件管理</h3>
            动态组件是存放在根目录下App_Code\Plugins里的.cs文件,所以且有动态编译功能
            </div>
            <div class="content">
                    <div id="lblErrorMsg" style="padding:5px; color:Red;" runat="server"></div>
                    <asp:Label ID="lblExtensions" runat="server" Text="未找到"></asp:Label>
            </div>
    </div>
</div>
