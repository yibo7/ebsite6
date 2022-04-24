<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Inherits="EbSite.Modules.Wenda.ModuleCore.Pages.mobileaskpost" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
    <title></title>
    <style>
        .bor
        {
            border-top: #bedeaa 1px solid;
            border-right: #bedeaa 1px solid;
            border-bottom: #bedeaa 1px solid;
            border-left: #bedeaa 1px solid;
        }
        .w2
        {
            width: 98%;
        }
        .bt2
        {
            border: #b3df88 1px solid;height: 220px;
        }
        .bg1
        {
            background-color: #e6f9d5;
        }
        .slist
        {
            padding-bottom: 6px;
            padding-top: 6px;
            padding-left: 5px;
            padding-right: 5px;
        }
        .dropdownlist{ left: -2px; top: -2px; width: 99%;height: 39px;  line-height: 14px; color: #909993;margin-top: 10px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div id="page">
        <div class="cont">
            <!--#include file="header.inc" -->
            <div class="w-navigator">
                <a href="<%=HostApi.MGetIndexHref() %>">首页</a><b>|</b> <a href="<%=HostApi.MGetSpecialHref() %>">
                    专题</a><b>|</b> <a href="<%=HostApi.MUccIndexRw %>">我的中心<span class="unread"></span></a>
            </div>
            
            <div style="padding: 10px;">
                <div class="bt2 bg1 slist">
                    <div class="radiusbox">
                        <div class="ebinput">
                            <asp:TextBox ID="txTitle" class="bor w2" runat="server" MaxLength="50" placeholder="请一句话描述您的问题..."></asp:TextBox>
                        </div>
                        <div class="linesolid">
                        </div>
                        <div class="ebinput" style="height: 95px;">
                            <asp:TextBox ID="txCtent" class="bor w2" runat="server" Height="85" TextMode="MultiLine"
                                placeholder="补充详细说明"></asp:TextBox>
                        </div>
                        <div class="linesolid">
                        </div>
                    </div>
                   <div style="margin-top: 5px;">
                    <div style="margin-top: 5px; float: left;">
                         <a onclick="togglePanel()"><span style="color: #1F85D3;"> 选择分类</span></a> <span id="iCheckClass"></span>
                    </div>
                    
                     <div style="float: right; margin-right: 10px;">
                          <span id="s_score" ></span>
                        
                        <asp:DropDownList ID="DrpScore" runat="server" CssClass="c_autoask_icon_score c_widht">
                            <asp:ListItem Value="0"> 0 </asp:ListItem>
                            <asp:ListItem Value="5"> 5 </asp:ListItem>
                            <asp:ListItem Value="15"> 15 </asp:ListItem>
                            <asp:ListItem Value="20"> 20</asp:ListItem>
                            <asp:ListItem Value="30"> 30 </asp:ListItem>
                            <asp:ListItem Value="50"> 50 </asp:ListItem>
                            <asp:ListItem Value="100"> 100 </asp:ListItem>
                        </asp:DropDownList>
                       
                    </div>
                </div>
                </div>
                <br />
                <asp:LinkButton ID="btnAddAsk" runat="server" Text="提 问" OnClick="btnAddAsk_Click"
                    OnClientClick="return subitfun();">
                     <div style="width:100%;" class="button btngreen2 btnbig"  > 提 问 </div>
                </asp:LinkButton>
            </div>
            
            <!--#include file="foot.inc" -->
            <div id="dialog4" class="vote-dialog">
            </div>
            
         
        </div>
       
    </div>
    <div id="SelClass" style="display:none ;">    
       <div class="toolbar " id="toolbar"><span class="button fr" onclick="togglePanel2()">返回</span><h2  style="text-align:center;color: #fff;padding: 8px;" > 选择分类</h2></div>
             <div style="padding: 10px;">
               <asp:DropDownList ID="DrpBigClass" runat="server" CssClass="dropdownlist" > </asp:DropDownList>
               <br>
                <asp:DropDownList ID="DrpSmallClass" runat="server" CssClass="dropdownlist">
                    <asp:ListItem Value="0"> 请选择汽车车型 </asp:ListItem>
                </asp:DropDownList>
                </div>
       <div style="width:100%;" class="button btngreen2 btnmiddle" onclick="SuitClass()" > 确 定 </div>
    
    </div>
     <asp:HiddenField ID="HidClass" runat="server" />

     </form>
    <script>
        m_dialog("dialog4", "200", "130");

        function subitfun() {
            
             var stitle = $("#<%=txTitle.ClientID%>").val();
            if (stitle === null || stitle === "") {
                $("#dialog4").html("请您将问题输入完整");
                $('#dialog4').dialog('open', 20, 20);
                return false;
            }
            if (stitle.length < 8) {
                $("#dialog4").html("标题太短");
                $('#dialog4').dialog('open', 20, 20);
                return false;
            }
           
            var iCredits = <%=EbSite.Base.Host.Instance.UserCredits %>;
            
            var obj = document.getElementById('DrpScore');
            var $iScore = obj.options[obj.selectedIndex].value; //获取分数的value
           
           if ($iScore > iCredits) {
                $("#dialog4").html("您的分数不足");
                $('#dialog4').dialog('open', 20, 20);
               return false;
           }
            
           if ($("#HidClass").val() == "") {
                $("#dialog4").html("请选择分类");
                $('#dialog4').dialog('open', 20, 20);
                return false;
          }
             var iUserID = <%=EbSite.Base.Host.Instance.UserID%>;
             if (iUserID < 1) {
                   $("#dialog4").html("先登录");
                $('#dialog4').dialog('open', 20, 20);
                return false;
            }

        }

    </script>
      <script type="text/javascript" src="<%= base.MThemePage%>askpost.js"></script>
</body>
</html>
