<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MsgList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.MyMsg.MsgList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server">
</XS:ToolBar>
<div class="gdList_title">
    <div style="width: 100px;">发送人</div>
    <div style="width: 500px;">
        &nbsp;消息标题 (共<%=iLoadCount%>条)</div>
    <div style="width: 100px;">
        日期
    </div>
    <div style="width: 100px;">
        操作
    </div>
</div>
<XS:Repeater ID="gdList" runat="server">
    <ItemTemplate>
        <div class="gdListContent" style=" height:100%;">
            <div style="width: 100px;">
                <%# Eval("senderniname")%>
            </div>
            <div style="width: 500px;">
                <%#Eval("title") %></div>
            <div style="width: 100px;">
                <%#string.Format("{0:g}",Eval("senddate"))%></div>
            <div style="width: 100px;">
                <a href="javascript:selmsg(<%# Eval("id")%>);">查看</a>
                <a onclick="return confirm('确认要删除所选项吗？');"  href="<%#DelUrl(Eval("id").ToString()) %>">删除</a>
            </div>
            <div class="msgt" id='msg<%# Eval("id")%>' style=" clear:both; text-align: left;  padding-left:15px;
                background: #ECEDE9; width:100%; height:100%; display:none;">
            </div>
        </div>
    </ItemTemplate>
</XS:Repeater>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
<script>
    function selmsg(obj) {
        var k = "msg" + obj;
        $(".msgt").html("");
        $(".msgt").hide();
        var pram = { "id": obj };
        $("#msg" + obj).show();
        runebws( "GetMsgModel", pram, function (result) {
            if (result.d != "") {
                $("#" + k).html(result.d);
            }
        });
    }
  
</script>
