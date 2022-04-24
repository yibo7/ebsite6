<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetParentSubSpecial.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:RadioButtonList ID="rblParentType" RepeatColumns="2" runat="server" 
    AutoPostBack="True" onselectedindexchanged="rblParentType_SelectedIndexChanged">
    <asp:ListItem Value="0" Text="指定分类的子分类为父级分类"></asp:ListItem>
    <asp:ListItem Value="1" Text="父级分类手动选择"></asp:ListItem>
</asp:RadioButtonList>
选择要显示的专题:<br>
<asp:ListBox ID="cblSpecial"  AppendDataBoundItems="true"  Height="200" runat="server">
    <asp:ListItem Text="自动获取父专题ID" Value="0"></asp:ListItem>
</asp:ListBox>
<br>
<br>
父模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="1cc0fd08-8ffa-4eb6-902e-811f2253af83" runat="server"/><br>
子模板:
<XS:ExtensionsCtrls ID="drpTemSub"   ModelCtrlID="1cc0fd08-8ffa-4eb6-902e-811f2253af83" runat="server"/><br>

获取数据条数(子):<asp:TextBox runat="server" ID="txtSubTop" ></asp:TextBox><br>
<br>
<br />

注：如果选择自动获取父专题ID,那么传入参数格式为?sid=父专题ID,不传入将默认获取一级专题
                                    