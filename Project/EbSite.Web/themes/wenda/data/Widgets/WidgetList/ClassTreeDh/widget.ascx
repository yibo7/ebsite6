<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.ClassTreeDh.widget" %>



<asp:Repeater ID="rpAllClass" runat="server" OnItemDataBound="rpAll_ItemBound" EnableViewState="False" >
  <ItemTemplate>   
 <div class="indexclasslist">
                        <div class="title">
                              <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>" class="<%#GetCurrentClass(Eval("ID"))%>"><%# Eval("ClassName")%></a>
                        </div>         
      <asp:Repeater ID="rpSubList" runat="server">
                                            <HeaderTemplate>
                                                <div class="subtitle">                                            
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                     <a href="<%#EbSite.Base.Host.Instance.GetClassHref(Eval("ID"),Eval("HtmlName"),1)%>" class="<%#GetCurrentClass(Eval("ID"))%>">   <%# Eval("ClassName")%>  </a>                                                
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </div>
                                            </FooterTemplate>
                                        </asp:Repeater>    
  </div>  
    </ItemTemplate>
</asp:Repeater> 