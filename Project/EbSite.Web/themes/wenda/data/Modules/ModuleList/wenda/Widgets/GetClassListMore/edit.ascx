<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.GetClassListMore.edit" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>



调用记录条数:<XS:TextBox ID="txtCount" Width="50" runat="server">0</XS:TextBox>(0表示全部)<br><br>
使用固定父ID：<XS:TextBox ID="txtPid" Width="50" runat="server">0</XS:TextBox>(0表示父ID随参数变动，-1表示除一级分类外始终使用当前分类的父ID)
<br><br>
数据模板(分类):
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>
                                    
<br><br>
树形子分类模板(分类):
<XS:ExtensionsCtrls ID="drpSubTem"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>

<br><br>
注:制作树形子分类列表，些部件不能调用一级分类,要调用一级分类列表请使用ClassList部件