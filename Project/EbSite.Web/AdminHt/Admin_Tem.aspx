<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Admin_Tem.aspx.cs" Inherits="EbSite.Web.AdminHt.Admin_Tem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:Content ID="Content1"  ContentPlaceHolderID="ctphBody"  Runat="Server">
       <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            
             <XS:Repeater ID="rpMenus" runat="server" >
                        <ItemTemplate>
                            <li class="nav-item">
                <a class="nav-link <%#GetCurrentClass(Eval("id")) %>" href="<%#Eval("value") %>" >
                    <span class="visible-xs"><i class="fa <%#Eval("Ico") %>"></i></span>
                    <span class="hidden-xs"><%#Eval("text") %></span>
                </a>
            </li>
                        </ItemTemplate>
                    </XS:Repeater>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <asp:PlaceHolder   id="phBodyControls" runat="server"></asp:PlaceHolder>
            </div>
            
        </div>
    </div>
</div>
 <br /><br />   
 <style>td{ padding: 5px;}</style>

 </asp:Content>
