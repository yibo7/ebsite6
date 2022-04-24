<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Upgrade.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.Upgrade" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:CustomTags ID="ucPageTags" CssClass="CustomPageTag"  runat="server"></XS:CustomTags>

    <div class="alert alert-success">升级前请做好备份程序备份及数据备份（系统管理-数据备份），由升级的过程中出现问题与官方无关！"  </div>
<div style=" padding:10px;" >
    <div class="admin_toobar" >
    <fieldset>
        <legend>安装模块 </legend>
            <div style=" padding:10px;" >
    
            当前版本为： <%=Model.Version %> 
             <br />
            <br />
            最新版本为： <%=Model.Version %> 
    
            <br /> <br />
             <XS:Button ID="bntUpdate" OnClick="bntUpdate_Click" runat="server"  Confirm="true" Text=" 在线升级模块 " />
             <br /><br />
                <XS:Notes ID="lbInfo"  </div>
             </div>
        </fieldset>
    </div>
   
     
</div>
<XS:Notes ID="Warning1"  Text="如果您是模块的开发者，如果您没有自己的模块升级包存放空间，请<a target=_blank href='http://www.ebsite.net'>点击这里到我们官方申请</a>"  </div>
