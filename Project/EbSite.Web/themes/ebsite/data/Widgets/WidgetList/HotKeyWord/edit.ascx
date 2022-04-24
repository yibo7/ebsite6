<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.HotKeyWord.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
       
 
         
调用数据条数:<XS:TextBox ID="txtCount" Width="50" runat="server"></XS:TextBox>
 

<br /><br />
自定义模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>
    <br />
                                
<br><br />
使用说明:<br>
 如果您想更改数据展示方式,请自定义数据模板,自定义模板这里使用相对路径,<br />
         