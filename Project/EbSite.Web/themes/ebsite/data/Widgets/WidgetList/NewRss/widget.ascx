<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.NewRss.widget" %>
<asp:Repeater ID="rpRssNewsContent"  runat="server">
            <ItemTemplate>
                <li>  
                
                   <%# this.rpRssNewsContent.Items.Count + 1%>.<a title="<%#Eval("Title.Text")%>" href="<%#Eval("Links[0].Uri.AbsoluteUri").ToString()%>" target=_blank><%#Eval("Title.Text")%></a>   
                                  
                </li>
            </ItemTemplate>
</asp:Repeater> 
