<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetRelatedContent.widget" %>

<asp:Repeater ID="rpRelateContent" runat="server"  >
                             <ItemTemplate>
                                    <li>                                  
                                        <a href="<%#EbSite.Base.Host.Instance.GetContentLink(Eval("id"),Eval("HtmlName"),Eval("classid"))%>"><%# Eval("newstitle")%></a>
                                    </li>
                             </ItemTemplate>
</asp:Repeater>
