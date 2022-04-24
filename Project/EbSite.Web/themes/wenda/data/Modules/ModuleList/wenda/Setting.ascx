<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="EbSite.Modules.Wenda.Setting" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div id="tg1">
    <div>    
        快速发帖重写:<XS:TextBoxVl ID="txtCatalog" runat="server"  Width="300" ></XS:TextBoxVl>
    </div>
    <div>
    快速回帖重写:<XS:TextBoxVl ID="txtReplay" runat="server"  Width="300" ></XS:TextBoxVl>
    </div>
    <div>
    内容显示连接地址相对重写：<XS:TextBoxVl ID="txtContentPath" runat="server"  Width="300" ></XS:TextBoxVl></div>
    
    
</div>