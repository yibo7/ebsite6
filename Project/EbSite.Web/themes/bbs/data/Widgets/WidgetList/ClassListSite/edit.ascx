<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.ClassListSite.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

显示的分类:<br>
<asp:ListBox ID="cblClass" AppendDataBoundItems="true"  Height="200"  runat="server">
    <asp:ListItem Value="0" Text="首页"></asp:ListItem>
</asp:ListBox>
<br>
数据模板:
<XS:ExtensionsCtrls ID="drpTemMoreList"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
                                    
<br />
<%--首页显示名称:
<XS:TextBox ID="txtIndexText" Text="首页" runat="server"/>--%>
<br>
此部件不能制作树形分类列表，要制作树形分类列表请用ClassTreeDh部件