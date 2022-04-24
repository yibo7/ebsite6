<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.GetTags.widget" %>
<asp:Repeater ID="rpList"  runat="server">
            <ItemTemplate>
                <li>  
                    <a href="<%#EbSite.Base.Host.Instance.TagsSearchList(Eval("ID"),1)%>" target="_blank"   >
                 <%#Eval("TagName")%> 
                    </a>
                    (<font color="#FF0000"><%#Eval("num")%></font>)                                  
                </li>
            </ItemTemplate>
</asp:Repeater>