<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="EbSite.ExtensionsCtrls.ClassListBox.Edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

父级分类:
<asp:DropDownList ID="drpParentClass" AppendDataBoundItems="true" runat="server">
    <asp:ListItem Text="全部" Value="0"></asp:ListItem>
</asp:DropDownList>
                                    
<br/>

调用分类条数:<XS:TextBox ID="txtClassNum" Width="50" runat="server"></XS:TextBox>(0表示全部)<br />


<br />
在分类前插入自定义选项:<br>
<XS:TextBox ID="txtCustomItems" Width="200" runat="server"></XS:TextBox>
(格式为 选项名称1,选项值1|选项名称2,选项值2)
<br />
<br />
值替换规则:<XS:TextBox ID="txtValueRule" HintInfo="可以为空,格式为:其他文本{0}{1}其他文本2,{0}为分类ID,{1}为分类名称"  Width="300" runat="server"></XS:TextBox><br /><br />
文本替换规则:<XS:TextBox ID="txtTextRule" HintInfo="可以为空,格式为:其他文本{0}{1}其他文本2,,{0}为分类ID,{1}为分类名称"  Width="300"  runat="server"></XS:TextBox><br /><br />

Onchange函数:<XS:TextBox ID="txtOnchange" HintInfo ="可以为空" Width="200"   runat="server"></XS:TextBox><br /><br />
