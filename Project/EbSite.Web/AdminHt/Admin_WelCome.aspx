<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Admin_WelCome.aspx.cs" Inherits="EbSite.Web.AdminHt.Admin_WelCome" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ctphBody" runat="Server">
     

    <div class="container-fluid main-title">
        管理首页 ->┊ <a href="http://www.ebsite.net" target="_blank">EbSite 正式版 <% =EbSite.Base.AppStartInit.ASSEMBLY_VERSION%></a> ┊  数据库类型:<% =EbSite.Base.Host.Instance.GetCMSDbType%>  ┊ 
         <a href="http://www.ebsite.net" target="_blank">官方网站</a>   ┊
                                                <a href="<%=IISPath %>" target="_blank"><%=Resources.lang.EBOpenIndex%></a>
    </div>

    <style>
        body {
            background-color: #ffffff !important;
        }
    </style>

    <div class="container-fluid mt10">
        <div class="row-fluid">
            <ul class="nav nav-tabs">
                <XS:Repeater ID="rpMenus" runat="server">
                    <ItemTemplate>
                        <li class="nav-item">
                            <a class="nav-link <%#GetCurrentClass(Eval("id")) %>" href="<%#Eval("value") %>">
                                <span class="visible-xs"><i class="<%#Eval("Ico") %>"></i></span>
                                <span class="hidden-xs"><%#Eval("text") %></span>
                            </a>
                        </li>
                    </ItemTemplate>
                </XS:Repeater>


            </ul>
            <div class="tab-content cbrowbox-tab">

                <asp:PlaceHolder ID="phBodyControls" runat="server"></asp:PlaceHolder>


            </div>

        </div>
    </div>

    <div class="row cbrowbox">
        <div class="col-sm-12 col-md-12 ">
            <div class="boxheader">
                <h3><i class="icon-spinner4 spinner"></i>系统运行状况</h3>
            </div>
            <div class="eb-content"> 
                <asp:Label runat="server" ID="lbLastErr"></asp:Label>
            </div>
        </div>
    </div> 
     
</asp:Content>
