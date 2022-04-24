<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.SpecialDh.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

选择要显示的专题:<br>
<asp:ListBox ID="cblSpecial"  AppendDataBoundItems="true"  Height="200" SelectionMode="Multiple" runat="server">
     <asp:ListItem Text="自动适应分类ID" Value="-1"></asp:ListItem>
    <asp:ListItem Text="自动适应内容ID" Value="-2"></asp:ListItem>
    <asp:ListItem Text="全部" Value="0"></asp:ListItem>
</asp:ListBox>
<br>
获取条数:<XS:TextBoxVl ID="txtCount" Width="80" CanBeNull="必填" RequiredFieldType="数据校验" runat="server">100</XS:TextBoxVl>
<br/>
数据类型:
 <XS:DropDownList ID="drpDataType"     runat="server">
       <asp:ListItem Value="0">所有</asp:ListItem>
       <asp:ListItem Value="1">有图片的专题</asp:ListItem>
       <asp:ListItem Value="2">有专题介绍的专题</asp:ListItem> 
       <asp:ListItem Value="3">有图片且有专题介绍的专题</asp:ListItem> 
      <%-- <asp:ListItem Value="4">有归属文章的专题</asp:ListItem> --%>
</XS:DropDownList> 
<br/>
排序方式：
 <XS:DropDownList ID="drpOrderBy"     runat="server">
       <asp:ListItem Value="0">最新添加越靠前</asp:ListItem>
       <asp:ListItem Value="1">排序ID越大越靠前</asp:ListItem>
       <asp:ListItem Value="2">排序ID越大越靠后</asp:ListItem>   
</XS:DropDownList> 
<br/>
数据模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="1cc0fd08-8ffa-4eb6-902e-811f2253af83" runat="server"/>
<br />
注：<br />
1.自动适应分类ID为，应用于分类模板，查询所有与此分类相关的专题(归属于此专题)<br />
2.自动适应内容ID为，应用于内容模板,查询所有与此内容相关的专题(归属于此专题)<br />
3.如果你选择了指定专题，获取条数将不起作用<br />
4.如果你选择了全部，获取条数将不起作用
<br>           