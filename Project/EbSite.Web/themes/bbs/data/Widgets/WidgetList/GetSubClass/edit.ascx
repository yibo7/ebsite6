<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetSubClass.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

选择要显示的分类:<br>
<asp:ListBox ID="cblClass" AppendDataBoundItems="true"  Height="200"  runat="server">   
    <asp:ListItem Text="自动适应父ID" Value="0"></asp:ListItem> 
</asp:ListBox>
<br />
或指定分类ID:
<XS:TextBox HintInfo="超过500个分类时，不能列表出来，只能指定子分类ID" ID="txtIDs" Width="50" runat="server"></XS:TextBox>(多个ID用逗号分开)
<br /><br />
调用类别:<XS:DropDownList ID="drpType" runat="server">
            <asp:ListItem Value="z" Text="按排序ID排序"></asp:ListItem>
            <asp:ListItem Value="n" Text="最新数据列表"></asp:ListItem>
            <asp:ListItem Value="a" Text="总点击率排行"></asp:ListItem>
            <asp:ListItem Value="d" Text="今天点击率排行"></asp:ListItem>
            <asp:ListItem Value="w" Text="本周点击率排行"></asp:ListItem>
            <asp:ListItem Value="m" Text="本月点击率排行"></asp:ListItem>
         </XS:DropDownList>
         <br />
调用数据条数:<XS:TextBox ID="txtTop" Width="80" CanBeNull="必填" RequiredFieldType="数据校验" runat="server">0</XS:TextBox>
<br>
自定义模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
   <br>                            