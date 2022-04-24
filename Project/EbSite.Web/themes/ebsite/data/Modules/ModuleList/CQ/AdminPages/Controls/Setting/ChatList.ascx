<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatList.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Setting.ChatList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<br><br>
<div class="txt-c">
<div class="box" style="height:200px; width:500px; padding-top:20px;">
 <div style="font-size:14px; color:#ff0000;">客服名称:<%=mdServer.ServiceName%></div>
 <br>
总计接待客户数:<span id="spCutomerCount">0</span>

<br><br>
<asp:RadioButtonList ID="rblOnline" Visible="false" RepeatColumns="5" runat="server" 
        AutoPostBack="True" onselectedindexchanged="rblOnline_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="1">在线</asp:ListItem>
        <asp:ListItem Value="2">离开</asp:ListItem>
        <asp:ListItem Value="3">离线</asp:ListItem>
        <asp:ListItem Value="4">方便</asp:ListItem>
        <asp:ListItem Value="5">吃饭</asp:ListItem>
</asp:RadioButtonList>
</div>

</div>

<script>
    var obService = {id:<%=mdServer.id%>,Name:"<%=mdServer.ServiceName%>",UserID:<%=base.UserID%>,UserName:"<%=base.UserName%>",UserNiName:"<%=base.UserNiname%>"};

jQuery(function ($) {
       UpdateCustomerList();
         //离开时设为离线
//        $(window).unload(function () {
//            alert("1")
//            var dto = {
//                "suid": obService.id
//            };
//            runws("ServiceOffLine", dto, null);
//            alert("2")
//        });
});
function window.onbeforeunload() {

    var dto = {
                "suid": obService.id
            };
            runws("ServiceOffLine", dto, null);
    return ("退出页面将变为离线状态，确认要退出吗？");
    
}


    //定时更新客户列表
function UpdateCustomerList() {
    
    setInterval(function (xx) {
        var dto = {
            "suid": obService.id,
            "rand": Math.random()+""
        };
        runws("CustomersOnline", dto, UpdateCustomerListEnd);

    }, 5000);

}
var CustomerIDs = [];
function UpdateCustomerListEnd(msg) {
    var lst = msg.d;
    
    if (lst.length > 0) {
        var htmls = "";
        for (var i = 0; i < lst.length; i++) {
            var md = lst[i];
            if (!CustomerIDs.contains(md.CustomerUserName)) {
                
//                md.CustomerIp = "123.121.114.142";
                var url = "../dialog/chatadmin.htm?ip="+md.CustomerIp+"&uid="+md.CustomerUserID+"&uname="+md.CustomerUserName+"&niname="+md.CustomerNiName;
                
                var winname = "win"+md.CustomerUserName.replace("游客-","");
                wo_href(url, 800, 600, 1, 1, winname);
                
                CustomerIDs.push(md.CustomerUserName);
            }
        }
       $("#spCutomerCount").html(CustomerIDs.length);
    }
}
//在子页面调用
function RemoveCustomerID(CustomerUserName){   
    //CustomerUserName 如游客-5656
    
    for(var i=0;i<CustomerIDs.length;i++)
    {
        var value = CustomerIDs[i];
        if(value==CustomerUserName)
        { 
            CustomerIDs.removedAt(i);
            var dto = {"suid": obService.id,"cid":CustomerUserName};            
            runws("SetOffLine2", dto, null);
        }
    }
    
}

function SaveChatList(strJson){
    var params = { "strJson":strJson };
    runws("SaveChatRecord", params, function (data) {
        if (data.d > 0) {
            //alert("聊天记录保存成功！");
        }
    });
}

</script>
