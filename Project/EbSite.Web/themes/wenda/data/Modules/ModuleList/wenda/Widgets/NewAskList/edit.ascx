<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.NewAskList.edit" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

获取条数:<XS:TextBox ID="txtTOP" runat="server"></XS:TextBox>  <br /><br />

开始：<XS:TextBox ID="txtBegin" runat="server"></XS:TextBox>  <br /><br />

结束：<XS:TextBox ID="txtEnd" runat="server"></XS:TextBox>  <br /><br />

状态：<asp:CheckBoxList ID="ChBk" runat="server">
<asp:ListItem Value="1"> 未解决</asp:ListItem>
<asp:ListItem  Value="2">已解决</asp:ListItem>
<asp:ListItem Value="3">无满意答案</asp:ListItem>
</asp:CheckBoxList>
