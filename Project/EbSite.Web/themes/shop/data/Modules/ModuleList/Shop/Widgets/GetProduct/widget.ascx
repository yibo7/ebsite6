<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.GetProduct.widget" %>

<asp:Repeater ID="rpList" runat="server" EnableViewState="False" >
    <ItemTemplate>
        
           <li class="<%#Equals(Container.ItemIndex+1,1)?"fore":"" %> fore<%#Container.ItemIndex+1 %>"><span><%#Container.ItemIndex+1 %></span>
                            <div class="p-img">
                                <a title="<%#Eval("newstitle") %>" href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>"
                                    target="_blank">
                                    <img width="50" height="50" alt="<%#Eval("newstitle") %>"
                                        src="<%#Eval("smallpic") %>"></a></div>
                            <div class="p-name">
                                <a title="<%#Eval("newstitle") %>" href="<%#EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID,Eval("classid"))%>"
                                    target="_blank"><%#Eval("newstitle") %></a></div>
                            <div class="p-price" >
                                <strong>￥<%#Eval("annex16") %></strong>
                            </div>
                        </li>

       
    </ItemTemplate>
</asp:Repeater>
