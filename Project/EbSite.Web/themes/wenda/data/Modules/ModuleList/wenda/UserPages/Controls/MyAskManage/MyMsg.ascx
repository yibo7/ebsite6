<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyMsg.ascx.cs" Inherits="EbSite.Modules.Wenda.UserPages.Controls.MyAskManage.MyMsg" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>


<%--<div style="margin-left: 15px;">
    未读消息(0)| 个人消息(2)| 系统消息(4)</div>--%>
<div id="PagesMain">
    <div class="ListLine">
        <ul>
            <XS:Repeater ID="gdList" runat="server">
                <headertemplate>
                <div class="queslist"  style=" height:40px; margin-top:15px;border-bottom: 1px dashed silver;">
                  <div class="divL" style="width:20px;"><input id='Checkbox1' onclick='on_check(this)'  type=checkbox /> </div>
                  <div class="divL" style="width:100px;">  状态</div>
                  <div class="divL" style="width:80px;">  发件人</div>
                  <div class="divL" style="width:360px;">  &nbsp;消息标题 (共<%=iLoadCount%>条)</div>
                  <div class="divL" style="width:100px;">日期  </div>

                </div>    
               </headertemplate>
                <itemtemplate>
                 <div class="queslist1"  style="  margin-left:19px; padding-top:3px;">
                  <div class="divL" style="width:20px;"><asp:CheckBox ID="Selector" runat="server" /><asp:HiddenField ID="hf" runat="server" Value=<%#Eval("ID")%>> </asp:HiddenField> </div>
                  <div class="divL" style="width:100px;">   <%#Eval("IsNewMsg").ToString()%></div>
                  <div class="divL" style="width:80px;">  <%# Eval("senderniname")%></div>
                  <div class="divL" style="width:360px;">   <%#Eval("title") %></div>
                  <div class="divL" style="width:100px;"> <%#string.Format("{0:g}",Eval("senddate"))%>  </div>
                  <div class="divL" style="width:100px;">  <a href="javascript:selmsg(<%# Eval("id")%>);"> 查看</a></div>
                </div>
                <div class="msgt" id='msg<%# Eval("id")%>' style=" text-align:left; margin-left:5px; background:#cccccc;"></div>
                </itemtemplate>
                <footertemplate>                    
                </footertemplate>
            </XS:Repeater>
        </ul>
    </div>
    <div class="lanB">
        <span class="fL"><a href="javascript:delmsg();">删除</a></span> <span class="fR"></span>
    </div>
    <div class="zhu">
        注：消息太多，可手动删除无用消息!</div>
</div>
<XS:Button ID="btnDel" Style="display: none;" Text="删除" runat="server" OnClick="btnDel_Click" />

<script>
    function selmsg(obj) {
        var k = "msg" + obj;
        $(".msgt").html("");
        var pram = { "id": obj };
        runws("4e0edb7e-1b30-41ad-9f74-d63c80458c35", "GetMsgModel", pram, function (result) {
            if (result.d != "") { 
                $("#" + k).html(result.d);
            }
        });     
    }
    function delmsg() {
        if (confirm('确认要删除吗？')) {
            $("#<%=btnDel.ClientID %>").click();
        }
    }
</script>
