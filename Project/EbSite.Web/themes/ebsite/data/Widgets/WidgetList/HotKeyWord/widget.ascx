<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.HotKeyWord.widget" %>
<asp:Repeater ID="rpList"  runat="server">
            <ItemTemplate>
                <i>  
                    <a href="<%#string.Concat(EbSite.Base.Host.Instance.SearchRw,"?k=",Eval("keyword"),"&site=",GetSiteID)%>" >
                        <%#Eval("keyword")%> 
                    </a>                               
                </i>
            </ItemTemplate>
</asp:Repeater>