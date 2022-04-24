<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.FilesManager.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<br>
文件类型:
<XS:DropDownList ID="drpFileTpye" runat="server" AutoPostBack="True" 
    onselectedindexchanged="drpFileTpye_SelectedIndexChanged">
    <asp:ListItem  Text="请选择文件类型" Value=""></asp:ListItem> 
    <asp:ListItem Text="js" Value="js"></asp:ListItem> 
    
</XS:DropDownList><br /><br />
文件格式:
<XS:DropDownList ID="drpFileEnCoder" runat="server" >
    <asp:ListItem Text="gb2312" Value="0"></asp:ListItem>
    <asp:ListItem Text="utf-8" Value="1"></asp:ListItem>
    
    
</XS:DropDownList>
<asp:Panel ID="plContent" Visible="false" runat="server"><br /><br /><asp:Panel ID="plHtml" Visible="false" runat="server">
页面引用: 高<XS:TextBox ID="txtHeigth" Width="50"  runat="server"></XS:TextBox>
宽<XS:TextBox ID="txtWidth" Width="50" runat="server"></XS:TextBox></asp:Panel>
<br /><br />内 容:<br /><br />
    <XS:TextBox ID="txtText" Width="800" Height="320" TextMode="MultiLine" runat="server"></XS:TextBox>

</asp:Panel>       
<div>
             
<asp:Label ID="lbUrl" runat="server" ></asp:Label>
</div>

