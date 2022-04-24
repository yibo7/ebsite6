<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.CheckBoxList.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
下拉列表项(每行一个):<br>
<XS:TextBox ID="txtItems" TextMode="MultiLine" Height="100" Width="200" runat="server"></XS:TextBox>
<br />
每行显示多少个:
<XS:TextBox ID="txtRepeatColumns"  Width="50" runat="server"></XS:TextBox><br /><br />
控件长:
<XS:TextBox ID="txtWidth"  Width="50" runat="server"></XS:TextBox><br /><br />
控件高:
<XS:TextBox ID="txtHeigth"  Width="50" runat="server"></XS:TextBox><br /><br />
默认选择项:<XS:TextBox ID="txtDefaultSelect" HintInfo="每个项用逗号分开"  Width="100" runat="server"></XS:TextBox><br /><br />
