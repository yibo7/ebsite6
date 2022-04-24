<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskClassSelect.aspx.cs" Inherits="EbSite.Modules.Wenda.CustomPage.AskClassSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>请选择车型</title>
    <base target="_self"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr valign="top">
                <td>
                    <asp:ListBox ID="OneListBox" runat="server"  Height="260px" Width="135px" 
                        onselectedindexchanged="OneListBox_SelectedIndexChanged" SelectionMode="Single" AutoPostBack="True"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="TwoListBox" runat="server" Height="260px" Width="135px" 
                        onselectedindexchanged="TwoListBox_SelectedIndexChanged" SelectionMode="Single" AutoPostBack="True"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="ThreeListBox" runat="server" Height="260px" Width="135px" 
                        onselectedindexchanged="ThreeListBox_SelectedIndexChanged" SelectionMode="Single" AutoPostBack="True"></asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Button ID="okButton" runat="server" Text="确定" onclick="okButton_Click" />
    </div>
    <div style="display:none" >
        <asp:TextBox ID="oneNameAndIDTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="twoNameAndIDTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="threeNameAndIDTextBox" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
