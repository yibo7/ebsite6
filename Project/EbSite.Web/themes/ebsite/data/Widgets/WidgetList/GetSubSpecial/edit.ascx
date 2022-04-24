<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetSubSpecial.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

选择要显示的专题:<br>
<asp:ListBox ID="cblSpecial"  AppendDataBoundItems="true"  Height="200" runat="server">
    <asp:ListItem Text="自动获取父专题ID" Value="0"></asp:ListItem>
</asp:ListBox>
<br>
<asp:CheckBox runat="server" ID="cbIsKeepParentID" Text="是否始终保持当前父级专题下的子专题" />
<br>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="1cc0fd08-8ffa-4eb6-902e-811f2253af83" runat="server"/>

<br>
<br />

注：如果选择自动获取父专题ID,那么传入参数格式为?sid=父专题ID,不传入将默认获取一级专题
                                    