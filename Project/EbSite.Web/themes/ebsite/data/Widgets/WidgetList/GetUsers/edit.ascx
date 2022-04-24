<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetUsers.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

调用类别:<XS:DropDownList ID="drpType" runat="server">
            <asp:ListItem Value="1" Text="最新用户"></asp:ListItem>
            <asp:ListItem Value="2" Text="最近来访"></asp:ListItem>
            <asp:ListItem Value="3" Text="我的好友"></asp:ListItem>
            <asp:ListItem Value="4" Text="个人动态(足迹)"></asp:ListItem>
            <asp:ListItem Value="5" Text="好友动态(足迹)"></asp:ListItem>
            <asp:ListItem Value="6" Text="积分达人"></asp:ListItem>
         </XS:DropDownList><br /><br />
调用记录条数:<XS:TextBox ID="txtCount" Width="50" runat="server">10</XS:TextBox>
<br><br>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="9552eabc-b186-432f-8384-f8266d986eef" runat="server"/>
                                    
<br><br>

默认模板为最新用户 <br>

如果选择的最新用户，绑定字段为 UserName<br>
如果选择的是最近来访，绑定的字段为 Visitor<br>
如果选择的是我的好友，绑定字段为 FriendName<br>

个人动态(足迹) 好友动态(足迹) 可绑定字段:<br>
UserName 用户名称 NewsInfo 动态(足迹)内容
