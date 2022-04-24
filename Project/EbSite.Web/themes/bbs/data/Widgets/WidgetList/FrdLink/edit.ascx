<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.FrdLink.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<table >
                   
                     <tr>
                        <td >调用条数:</td>
                        <td >
                            <XS:TextBox ID="txtTop" runat="server"></XS:TextBox>                                        
                        </td>
                     </tr>
                      <tr>
                        <td >自定义模板:</td>
                        <td >
                             <XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="71579f18-a40c-42fb-aa8c-73ee820ad3f3" runat="server"/>                                 
                        </td>
                     </tr>
                    
                 
</table>