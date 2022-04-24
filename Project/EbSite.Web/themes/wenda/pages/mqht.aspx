<%@ Page Language="C#" AutoEventWireup="true" Inherits=" EbSite.Modules.Wenda.ModuleCore.Pages.mqht" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta name="viewport" content="width=256, initial-scale=1.25, maximum-scale=1.25, minimum-scale=1.25, user-scalable=no, target-densityDpi=low-dpi" />
    <title>快速模拟回帖</title>
    <style>
        body,button,input,select,textarea
            {font:12px/1.5em Tahoma,Verdana}
            div,form,h1,h2,h3,h4,h5,h6,iframe,label,p,ul,ol
            {background:0;border:0;margin:0;padding:0}
            .box div{ text-align:left;}
    </style>
</head>
<body style="text-align:center;">
  <div class="box">
        <form id="form1" runat="server">

         <asp:ListBox ID="LbQuestion" runat="server" AutoPostBack="true" Rows=10 OnSelectedIndexChanged="LbQuestion_SelectedIndexChanged"></asp:ListBox>
         <div>
           标题 ：</div>
        <div>
            <asp:TextBox ID="txtTT" Width="100%"  ReadOnly="true" Height="50" runat="server"></asp:TextBox>
        </div>
         <div>
           内容 ：</div>
        <div>
            <asp:TextBox ID="txtNR" TextMode="MultiLine" Width="100%"  ReadOnly="true" Height="50" runat="server"></asp:TextBox>
        </div>
        <div>
           回复 内容 ：</div>
        <div>
            <asp:TextBox ID="txtCT" TextMode="MultiLine" Width="100%" Height="50" runat="server"></asp:TextBox>
        </div>
        
        
            <asp:TextBox ID="txtAskID" Width="100%"  Visible=false runat="server"></asp:TextBox>
       
        <div style="text-align: center">
            <asp:Button ID="btnSave" runat="server" Text=" 保存 " /></div>
        </form>
    </div>
</body>
</html>
