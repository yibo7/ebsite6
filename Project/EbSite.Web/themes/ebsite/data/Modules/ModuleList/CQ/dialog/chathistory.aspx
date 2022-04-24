<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chathistory.aspx.cs" Inherits="EbSite.Modules.CQ.dialog.chathistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    * {PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 0px}
HTML {BACKGROUND-COLOR: #edf1f4; HEIGHT: 100%; FONT-SIZE: 12px; OVERFLOW: hidden}
BODY {BACKGROUND-COLOR: #edf1f4; HEIGHT: 100%; FONT-SIZE: 12px; OVERFLOW: hidden}
UL {LIST-STYLE-TYPE: none; LIST-STYLE-IMAGE: none}
A {TEXT-DECORATION: none}
.divmsgbox{ padding-left:10px; }
.divmsgbox div{ width:100%;}
.divmsgbox  .userspeak .title{ color:#008200;line-height:20px;}
.divmsgbox  .userspeak .msg{ color:#363636;  padding-left:25px; width:90%; line-height:20px;}
.divmsgbox  .myspeak .title{ color:#0000FF; line-height:20px;}
.divmsgbox  .myspeak .msg{ color:#363636; padding-left:25px; width:90%; line-height:20px;}
</style>
</head>

<body style="background:#fff;">
    <div class="divmsgbox">
        <asp:Repeater ID="DataList" runat="server">
            <ItemTemplate>
                 <div class='<%# Eval("IsSalerSay").ToString().Equals("0")?"userspeak":"myspeak" %>'>
                    <div class="title"><%# Eval("IsSalerSay").ToString().Equals("0") ? Eval("UserNiName") :"我"%>说:(<%# Eval("DateTime") %>)</div>
                    <div class="msg"><%# Eval("Msg") %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</body>
</html>
