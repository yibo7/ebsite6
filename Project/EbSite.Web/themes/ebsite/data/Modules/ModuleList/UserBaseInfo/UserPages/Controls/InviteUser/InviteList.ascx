<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InviteList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.InviteUser.InviteList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<script type="text/javascript">
    var gMsg = "听别人说起北迈网  @  一下就爱上了，赶紧来看看，推荐给你们 ";
    var friendArr = new Array();
    $(document).ready(function () {
        $("div[name='myfriend']").click(function () {
            var $obj = $(this);
            var tn = $obj.attr("title");
            var keyIndex = FindKey(tn);
            if (keyIndex < 0) {
                friendArr.push(tn); //添加到数组中
                AddFlag(this,true);
            }
            else {
                friendArr.splice(keyIndex, 1); //移除
                AddFlag(this, false);
            }
            
            BindContent(); //重新绑定数据
        });
    });
    function AddFlag(obj,flag) {
        var $Obj = $(obj);
        var aa = $Obj.offset();
        if (flag) {
            var l = aa.left + $Obj.width() - 24;
            var t = aa.top + $Obj.height() - 24;
            $Obj.append("<span style='position:absolute;left:" + l + "px;top:" + t + "px;'><img src='" + $("#<%=hdPath.ClientID %>").val() + "/icon_check.png'/></span>");
        }
        else {
            $Obj.find("span").remove();
        }
    }
    function BindContent() {
        var inviteHtml ="";
        if (friendArr != null && friendArr != undefined && friendArr.length > 0) {
            for (var i = 0; i < friendArr.length; i++) {
                inviteHtml += " @" + friendArr[i];
            }
        }
        else {
            inviteHtml = "";
        } 
        var $handObj = $("#<%=txtWeiboMsg.ClientID %>");
        $handObj.val(gMsg + inviteHtml);
    }
    function FindKey(key) {
        for (var i = 0; i < friendArr.length; i++) {
            if (key == friendArr[i]) {
                return i;
            }
        }
        return -1;
    }
</script>
<style type="text/css">
    .vfLeft{ width:500px;   float:left;margin-bottom:10px; }
    .vfLeft .uList{ width:100%; height:600px; border:1px solid #ccc;background:#F5F5F5;}
    .vfLeft .uList div{ text-align:left; padding-left:10px;}
    .vfLeft .uList .title{border-left:5px solid #748F25; text-align:left;  margin:8px;  padding-left:3px; font-size:15px; font-weight:bold;}

    .vfRgiht{width:300px; float:right; text-align:right;margin-bottom:10px;}
   .cover div{ width:50px; height:50px; float:left; cursor:pointer; margin:10px;  }
   .uList .pg ul{ float:right; }
  .uList .pg li{ padding-right:10px; float:left;}
 .weibosendbox{ border:1px solid #ccc;margin:10px; height:150px; clear:both; background:#fff;}
 .weibosendbox textarea{ border-style:none; color:#ccc;}
  .weibosendbox span{ color:#ccc;}
  .uInvite{width:90%; height:300px; border:1px solid #ccc;background:#F5F5F5; float:right; }
   .uInvite .title{border-left:5px solid #748F25; text-align:left;  margin:8px;  padding-left:3px; font-size:15px; font-weight:bold;}
</style>
<input type="hidden" runat="server" id="hdPath" />
<div class="divtagbox"> 
        <ul class="divtagbox-ul">
            <XS:Repeater ID="gdList" runat="server"  >         
                <ItemTemplate>
                    <li >
                    <a <%#GetCss(Eval("ApiName")) %>  href="?api=<%#Eval("ApiName")%>"  >
                        <%#Eval("ShowName")%>
                    </a>
                </li>
                </ItemTemplate>
            </XS:Repeater>
        </ul><div class="clear"></div>
        </div>
<div style=" margin-top:10px;">
          <div  class="vfLeft">
              <asp:PlaceHolder ID="phIsBind" runat="server">
                    <div class="uList">
                        <div class="title">
                            发送邀请
                        </div>
                        <div>
                            选择你要推荐的好友 @ 他们一下吧
                        </div>
                       <div class="pg">    
                            <XS:PagesContrl ID="pcPage" runat="server" />
                       </div>
                        <div class="clear"></div> 
                         <div class="cover" >
                             <asp:Repeater ID="DataListMyFriend" runat="server">
                                <ItemTemplate>
                                    <div style='background-image: url(<%# Eval("emailAddress") %>/50)' name="myfriend" title='<%# Eval("UserName") %>' id='<%# Eval("Sign") %>'></div>
                                </ItemTemplate>
                             </asp:Repeater>
                        </div>
                     
                     <div class="clear"></div>
                         <div class="weibosendbox">
                                <div style=" padding:0px; margin-top:10px;margin-right:10px;">
                                    <XS:TextBox ID="txtWeiboMsg" runat="server" Width="100%" Height="100px" TextMode="MultiLine" Text="听别人说起北迈网  @  一下就爱上了，赶紧来看看，推荐给你们"></XS:TextBox>
                                    <br/>
                                    <span>
                                    <asp:Literal ID="litRegUrl" runat="server"></asp:Literal>
                                    </span>
                                    
                                </div>
                                <div></div>
                         </div>                 
                         <div>
                                <div>
                                    <XS:Button ID="btnSendWeibo" runat="server" Text=" 发送邀请 " onclientclick="SendWeibo()" onclick="btnSendWeibo_Click"/>
                                </div>
                         </div>
                    </div>
                    </asp:PlaceHolder>
                     <asp:PlaceHolder ID="phNoBind" runat="server">
                         <XS:Notes BgColor="#EBF2D5" Height="35" ID="ntShowInfo"  runat=server></XS:Notes>
                         <br />
                         <XS:Button ID="btnToBind" runat="server"  onclick="btnToBind_Click"/>
                     </asp:PlaceHolder>
          </div>
          <div class="vfRgiht">
           

           <div class="uInvite" style=" margin-top:10px;">
                        <div class="title">
                            已经成功邀请的好友
                        </div>
           </div>
          </div>

          </div>