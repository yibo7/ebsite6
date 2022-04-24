<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Chathistorys.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.MsgHistorys.Chathistorys" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style type="text/css">
    .chatlist{width:100%;}
    .chatlist li.mysay{ list-style:none; text-align:left; height:20px; line-height:20px; vertical-align:middle;background-color:#F8FFEB; padding-left:10px; margin-top:1px;}
    .chatlist li.tsay{ list-style:none; text-align:left; height:20px; line-height:20px; vertical-align:middle;background-color:#E2EDFF;padding-left:10px;margin-top:1px;}
    
    .chatlist li.mysaycontent{list-style:none; text-align:left; padding-left:30px; background-color:#F8FFEB; padding-bottom:5px;}
    .chatlist li.tsaycontent{list-style:none; text-align:left; padding-left:30px; background-color:#E2EDFF;padding-bottom:5px;}
    
    .chatlist li span.tspan{ color:#006EFE; float:left;}
    .chatlist li span.mspan{ color:#42B475;float:left;}
    .chatlist li span.tcspan{ color:#2C3D5B;}
    .chatlist li span.mcspan{ color:red;}
    .chatlist div:hover{background-color:#ff0000;}
    .ebcheckboxname{ float:right; margin-top:10px;}
</style>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div id="alllist" style="text-align:center;">
    <ul class="chatlist">
    <XS:Repeater ID="rpList" runat="server">
        <ItemTemplate>
            
            <li class="<%# Eval("issalersay").ToString().Equals("0")?"tsay":"mysay"%>">
            <%# Eval("issalersay").ToString().Equals("0") ? "<span class='tspan'>" + Eval("userniname"):"<span class='mspan'>"+Eval("salername") %>&nbsp;<%#Eval("DateTime")%></span>
            <span class="ebcheckboxname">
            <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('您确定要删除该项么?')"  CommandName="DeleteModel"  Text="删除"></XS:LinkButton>
            &nbsp;&nbsp;
            <input  name="ebcheckboxname" value="<%#Eval("ID")%>" type="checkbox" />
            </span>
            </li>
            <li class="<%# Eval("issalersay").ToString().Equals("0")?"tsaycontent":"mysaycontent"%>"><%# Eval("issalersay").ToString().Equals("0") ?"<span class='tcspan'>"+Eval("msg") :"<span class='mcspan'>"+Eval("msg")%></span></li>
        
           
        </ItemTemplate>
    </XS:Repeater>
    </ul>
</div>
<div><XS:PagesContrl ID="pcPage" runat="server" /></div>

<script>
    function checkall() {
        on_checkback(document.getElementById("alllist"));
    }
</script>