<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Configs.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_DataReport.Configs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>重新生成报表菜单</h3>
            报表来自于网站根目录下的Datastore/ReportConfigs里的json文件，可以复制修改成自己的数据报表
            </div>
            <div class="eb-content">
				 <XS:Button ID="bntMakeMenu" width="300" runat="server" Text=" 确认生成 " Confirm="True" onclick="bntMakeMenu_Click"  />
  <asp:Label ID="lbInfo" runat="server"></asp:Label>
            </div>
    </div>
</div>