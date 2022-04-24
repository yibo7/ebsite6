<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.TextBox.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
文本框类型：
<asp:DropDownList ID="drpBoxType" runat="server"   
    onselectedindexchanged="drpBoxType_SelectedIndexChanged" 
    AutoPostBack="True">
    <asp:ListItem Value="0">HTML编辑器</asp:ListItem>    
    <asp:ListItem Value="1">单行文本框</asp:ListItem>
     <asp:ListItem Value="2">多行文本框</asp:ListItem>
</asp:DropDownList>
<br><br>
内容:<br>

<div >
    <XS:Editor ID="txtText"   MenuStatus="Text" ExtImg="png,jpg,gif"  ExtFlash="swf,fv" ExtMedia="wmv,aiv" ExtLink="rar,txt,png,jpg,zip"  runat="server" />
    <asp:TextBox ID="txtContent" Visible="false" runat="server"></asp:TextBox>
</div>
