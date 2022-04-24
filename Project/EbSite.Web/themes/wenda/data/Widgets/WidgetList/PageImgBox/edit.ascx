<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.PageImgBox.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
                <table >
                      <tr >
                        <td >区域元素ID:</td>
                        <td ><XS:TextBox ID="txtObjID" HintInfo="为空，表示整个页面" Width="50" runat="server"></XS:TextBox></td>
                     </tr>
                     <tr >
                        <td >图片长度:</td>
                        <td ><XS:TextBox ID="txtWidth" HintInfo="为0表示不设置，保留默认,可以是 100%" Width="50" runat="server">0</XS:TextBox></td>
                     </tr>
                     <tr >
                        <td >图片高度:</td>
                        <td ><XS:TextBox ID="txtHeight" HintInfo="为0表示不设置，保留默认" Width="50" runat="server">0</XS:TextBox></td>
                     </tr>
                    
                 </table>
