<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.GetProduct.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


         调用类别:<XS:DropDownList ID="drpType" runat="server">
            <asp:ListItem Value="1" Text="热卖"></asp:ListItem>
            <asp:ListItem Value="2" Text="爆款"></asp:ListItem>
            <asp:ListItem Value="3" Text="惊爆价"></asp:ListItem>
            <asp:ListItem Value="4" Text="特价"></asp:ListItem>
            <asp:ListItem Value="5" Text="直降"></asp:ListItem> 
                       
         </XS:DropDownList>

<br /><br />
是否调用子分类下的数据:<asp:CheckBox ID="cbIsGetSub" runat="server" />
<br /><br />
标题列表自定义模板:
<XS:ExtensionsCtrls ID="drpTemTitle"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
                                    
(可以为空)
<br /><br />

<br /><br />
标题列表条数:<XS:TextBox ID="txtCountTitle" CanBeNull="必填" RequiredFieldType="数据校验" Width="50" runat="server">12</XS:TextBox>
<br><br />