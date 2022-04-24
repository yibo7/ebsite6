<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.JsonList.widget" %>
 
<asp:Repeater ID="rpDataList" runat="server"  >
  <ItemTemplate> 
         <li>                                  
         <a href="<%# Eval("OrtherPram")%>"><%# Eval("Name")%></a>
    </li>  
    </ItemTemplate>
</asp:Repeater> 