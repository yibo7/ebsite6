<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetRelatedContent.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

调用记录条数:<XS:TextBox ID="txtCount" Width="50" runat="server">10</XS:TextBox>
<br><br>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
<%--<XS:DDLCtrTem   ID="drpTem" runat="server"></XS:DDLCtrTem>--%>
    <br />
  只调用有图片:<asp:CheckBox ID="cbIsSmallImg" runat="server" />                  
<br/>  
  是否随机全部:<asp:CheckBox ID="cbIsRandAll" runat="server" />                  
<br/> 

缓存:<XS:DropDownList ID="drpCacheType" runat="server">
            <asp:ListItem Value="0" Text="不缓存"></asp:ListItem>
            <asp:ListItem Value="1" Text="1分钟"></asp:ListItem>
            <asp:ListItem Value="2" Text="15分钟"></asp:ListItem>
            <asp:ListItem Value="3" Text="30分钟"></asp:ListItem>
            <asp:ListItem Value="4" Text="1小时"></asp:ListItem>
            <asp:ListItem Value="5" Text="3小时"></asp:ListItem> 
            <asp:ListItem Value="6" Text="5小时"></asp:ListItem>
            <asp:ListItem Value="7" Text="1天"></asp:ListItem> 
            <asp:ListItem Value="8" Text="2天"></asp:ListItem>
            <asp:ListItem Value="9" Text="3天"></asp:ListItem>             
         </XS:DropDownList>

<br/><br />