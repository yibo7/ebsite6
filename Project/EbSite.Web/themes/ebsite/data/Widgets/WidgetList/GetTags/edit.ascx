<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetTags.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
         
         选择分类:<XS:DropDownList ID="drpClass" AppendDataBoundItems="true" runat="server">
            <asp:ListItem Value="0">全站</asp:ListItem>
            <asp:ListItem Value="-1">分类适应</asp:ListItem>
             <asp:ListItem Value="-2">内容适应</asp:ListItem>
         </XS:DropDownList>
         <br /> <br />
         数据类别:
          <XS:DropDownList ID="drpListModel" runat="server">
            <asp:ListItem Value="1" Text="最新标签"></asp:ListItem>
            <asp:ListItem Value="2" Text="热门标签"></asp:ListItem>
         </XS:DropDownList>
<br /><br />
         
调用数据条数:<XS:TextBox ID="txtCount" Width="50" runat="server"></XS:TextBox>

<br /><br />
         
标签内容不能小于:<XS:TextBox ID="txtNum" Width="50" runat="server">0</XS:TextBox>(0表示不限)

<br /><br />
自定义模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>
    <br />
                                
<br><br />
使用说明:<br>
 如果您想更改数据展示方式,请自定义数据模板,自定义模板这里使用相对路径,<br />
         