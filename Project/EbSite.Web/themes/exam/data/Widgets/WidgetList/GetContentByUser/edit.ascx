<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetContentByUser.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

获取条数:<XS:TextBox ID="txtTOP" runat="server"></XS:TextBox>  <br /><br />
  用户来源:<XS:DropDownList ID="drpUserFrom" runat="server">
            <asp:ListItem Value="0" Text="当前登录的用户"></asp:ListItem>
            <asp:ListItem Value="1" Text="来自于当前内容"></asp:ListItem>               
         </XS:DropDownList>
         <br /><br />
  调用类别:<XS:DropDownList ID="drpType" runat="server">
            <asp:ListItem Value="" Text="最新数据列表"></asp:ListItem>
            <asp:ListItem Value="h" Text="总点击排行"></asp:ListItem>
            <asp:ListItem Value="w" Text="本周点击排行"></asp:ListItem>
            <asp:ListItem Value="adv" Text="收藏率排行"></asp:ListItem> 
            <asp:ListItem Value="ch" Text="评论最多的内容"></asp:ListItem>
            <asp:ListItem Value="fh" Text="好评(被顶)最多的内容"></asp:ListItem> 
            <asp:ListItem Value="d" Text="今日点击排行"></asp:ListItem>
            <asp:ListItem Value="m" Text="本月点击排行"></asp:ListItem>             
         </XS:DropDownList>
         <br /><br />
标题列表自定义模板:
<XS:ExtensionsCtrls ID="drpTemTitle"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
<br>
<br /><br />
<asp:CheckBox ID="cbIsImage" Text="是否图片内容" runat="server" />

