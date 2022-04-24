<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ctrl.ascx.cs" Inherits="EbSite.ExtensionsCtrls.CtrTemListBox.Ctrl" %>
 <asp:DropDownList  ID="drpTemList" AppendDataBoundItems="true" runat="server">
    <asp:ListItem Text="默认列表" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
 </asp:DropDownList><span>编辑模板</span> 

<script>

    $("#<%=drpTemList.ClientID%>").next().click(function () {
        var selv = get_selected_value(<%=drpTemList.ClientID%>);
        if (selv != "00000000-0000-0000-0000-000000000000") {
            location.href = "Admin_WidgetsTem.aspx?mpid=6637d926-1a3d-4cde-95f6-c79a3524e04a&msid=7e0a42b7-a7ee-4762-bc98-fadcb58a0b99&t=3&id=" + selv;
        } else {
            var wgTypeV = $("#wgType").text();
            location.href = "Admin_Widgets.aspx?t=3&id="+wgTypeV+"&zone=WidgetsZoneList&type="+wgTypeV+"&modulid=0";
        }
            

    });

   
</script>
 