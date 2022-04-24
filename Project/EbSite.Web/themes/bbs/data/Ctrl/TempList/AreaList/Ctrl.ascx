<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ctrl.ascx.cs" Inherits="EbSite.ExtensionsCtrls.AreaList.Ctrl" %>
<asp:DropDownList ID="drpArea1" DataTextField="name" DataValueField="id" AppendDataBoundItems="true"  runat="server">
    <asp:ListItem Value="-1" Text="请选择"></asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="drpArea2" DataTextField="name" DataValueField="id" AppendDataBoundItems="true"   runat="server">
    <asp:ListItem Value="-1" Text="请选择"></asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="drpArea3" DataTextField="name" DataValueField="id" AppendDataBoundItems="true"   runat="server">
    <asp:ListItem Value="-1" Text="请选择"></asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="drpArea4" DataTextField="name" DataValueField="id" AppendDataBoundItems="true"   runat="server">
    <asp:ListItem Value="-1" Text="请选择"></asp:ListItem>
</asp:DropDownList>
<asp:HiddenField ID="hfValue" runat="server" />
<script>
    InitAreaList("<%=drpArea1.ClientID %>", "<%=drpArea2.ClientID %>", "<%=drpArea3.ClientID %>", "<%=drpArea4.ClientID %>", "<%=hfValue.ClientID %>");   
</script>