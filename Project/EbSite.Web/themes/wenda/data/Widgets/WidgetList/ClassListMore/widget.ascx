<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.ClassListMore.widget" %>

<asp:Repeater ID="rpSubClass" runat="server" OnItemDataBound="rpSubClass_ItemBound" EnableViewState="False" >
  <ItemTemplate>
        
          <li><span class="classttl"><a href="<%#EbSite.Base.Host.Instance.GetClassHref(Convert.ToInt32( Eval("ID").ToString()),1,Convert.ToInt32( Eval("siteid").ToString()))%>"><%#Eval("classname")%></a></span>
							<div class="leftmenu">
                               <asp:PlaceHolder ID="phList" runat="server"></asp:PlaceHolder>
                             </div>
						</li>
       
    </ItemTemplate>
</asp:Repeater>                       
 