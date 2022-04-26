<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetData.ascx.cs"
    Inherits="EbSite.Web.AdminHt.dialog.Controls.WidgetData" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <ul id="myTab" class="nav nav-tabs">
                <li class="nav-item ">
                    <a class="nav-link active" href="#tg1" data-toggle="tab">部件类别检索(所有)</a>
                </li>
                <li class="nav-item"><a class="nav-link" href="#tg2" data-toggle="tab">当前站点下的模块部件</a></li>
                <li class="nav-item"><a class="nav-link" href="#tg3" data-toggle="tab">当前站点部件</a></li>
            </ul>
            <div class="tab-content">
                <div id="tg1" class="tab-pane active">

                    <XS:Repeater ID="RepWidgetAll" runat="server">
                        <ItemTemplate>
                            <button type="button" onclick="infield(name)" name='<%#MakeCoder(Eval("DataID").ToString(), Eval("title").ToString())%>' class="btn btn-default waves-effect waves-light m-t-10">
                                <%#Eval("title")%>
                                <span class="btn-label btn-label-right"><i class="fa  fa-plus-square"></i></span>
                            </button>
                        </ItemTemplate>
                    </XS:Repeater>
                </div>
                <div id="tg2" class="tab-pane fade">
                    <XS:Repeater ID="RepWidgetModule" runat="server">
                        <ItemTemplate>
                            <button type="button" onclick="infield(name)" name='<%#MakeCoder(Eval("DataID").ToString(), Eval("title").ToString())%>' class="btn btn-default waves-effect waves-light m-t-10">
                                <%#Eval("title")%>
                                <span class="btn-label btn-label-right"><i class="fa  fa-plus-square"></i></span>
                            </button>
                        </ItemTemplate>
                    </XS:Repeater>
                </div>
                <div id="tg3" class="tab-pane fade">
                    <XS:Repeater ID="RepWidgeteSite" runat="server">
                        <ItemTemplate>
                            <button type="button" onclick="infield(name)" name='<%#MakeCoder(Eval("DataID").ToString(), Eval("title").ToString())%>' class="btn btn-default waves-effect waves-light m-t-10">
                                <%#Eval("title")%>
                                <span class="btn-label btn-label-right"><i class="fa  fa-plus-square"></i></span>
                            </button>
                        </ItemTemplate>
                    </XS:Repeater>
                </div>
            </div>
        </div>
    </div>
</div>

