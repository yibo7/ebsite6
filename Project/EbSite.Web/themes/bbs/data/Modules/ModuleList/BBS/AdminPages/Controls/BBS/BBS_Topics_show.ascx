<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BBS_Topics_show.ascx.cs"
    Inherits="EbSite.Modules.BBS.AdminPages.Controls.BBS.BBS_Topics_show" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<script type="text/javascript" src="/js/plugin/highcharts/highcharts.src.js"></script>


<div class="clearfix mod contentBg">
    <h3>
        <a href='bbs.aspx?muid=<%=ppid%>&mid=<%=ssid%>&t=12&ChannelId=<%=Model.ChannelID%>'>
            <%=Model.ChannelName%></a></h3>
    <div class="box clearfix">
        <div class="left boxLeft">
            <div class="hh">
                <div class="userHd clearfix">
                    <a class="left hh" href="javascript:void(0)">
                        <%--<%=users.Realname%>--%></a>
                    <asp:Label ID="lbBZ" runat="server"></asp:Label>
                </div>
                <div class="userBd">
                    <a href="javascript:void(0)">
                        <img src='<%--<%=users.AvatarPath %>--%>' alt=""  /></a>
                </div>
                <div class="clearfix">
                    <label>
                        主题：<a class="highlight" href="#2"><strong><asp:Label ID="lbAllTopic" runat="server"></asp:Label></strong></a></label>
                    <label>
                        精华：<a class="highlight" href="#2"><strong><asp:Label ID="lbgoodTopic" runat="server"></asp:Label></strong></a></label>
                    <br />
                    <br />
                    <div>
                        <XS:EasyuiDialog ID="WinBox2" runat="server" IsColseReLoad="true" Text="[内部邮件]" Title="[内部邮件]" />
                        <XS:EasyuiDialog ID="WinBox1" runat="server" IsColseReLoad="true" Text="[外部邮件]" Title="[外部邮件]" />
                        <br />
                        <XS:EasyuiDialog ID="WinBox3" runat="server" IsColseReLoad="true" Text="[消息]" Title="[消息]" />
                        <XS:EasyuiDialog ID="WinBox4" runat="server" IsColseReLoad="true" Text="[短信]" Title="[短信]" />
                        <a href="javascript:void(0)" onclick="lt(<%--<%=users.Id%>--%>)">[聊天]</a></div>
                </div>
            </div>
        </div>
        <div class="right boxRight">
            <div class="topics">
                <div class="topicHd clearfix">
                    <div class="left">
                        <span>发帖时间：<em><%=Model.CreatedTime%></em></span><span>最后修改：<em><%=Model.UpdatedTime%></em></span></div>
                    <em class="right floor"><strong class="highlight">1</strong>楼</em>
                    <div class="right">
                        <span>浏览：<em class="highlight"><%=Model.ViewCount%></em></span><span>回复：<em class="highlight"><%=Model.ReplyCount%></em></span></div>
                </div>
                <div class="topicBd">
                    <h1 class="topicTitle">
                        <%=Model.TopicTitle%>
                    </h1>
                    <div id="divTp" runat="server" visible="false">
                        <!--[if IE]>
			<script type="text/javascript" src="/js/plugin/highcharts/excanvas.compiled.js"></script>
<![endif]-->
                        <script type="text/javascript">
    var chart;
    $(document).ready(function () {
        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container',
                margin: [100, 0, 0, 0]
            },
            title: {
                text: ""

            },
            plotArea: {
                shadow: null,
                borderWidth: null,
                backgroundColor: null
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.point.name + '</b>: ' + this.y + ' %';
                }
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            if (this.y > 5) return this.point.name;
                        },
                        color: 'white',
                        style: {
                            font: '13px Trebuchet MS, Verdana, sans-serif'
                        }
                    }
                }
            },
            legend: {
                layout: 'vertical',
                style: {
                    left: 'auto',
                    bottom: 'auto',
                    right: 'auto',
                    top: 'auto'
                }
            },
            series: [{
                type: 'pie',
                name: 'Browser share',
                data: [
                <%=tpxx%>           
         ]
            }]
        });
    });
                        </script>
                        <table>
                            <tr>
                                <td>
                                    <div id="container">
                                    </div>
                                </td>
                                <td>
                                    投票人数:<font style="color: Red"><%=Rs%></font>
                                    <XS:GridView ID="gvXZ" runat="server" AutoGenerateColumns="False" CssClass="GridView"
                                        EnableModelValidation="True">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <XS:CheckBox ID="cbXZ" runat="server" onclick="IfDX()" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="选项">
                                                <ItemTemplate>
                                                    <%# Eval("OptionName")%>
                                                    <asp:Label ID="lbId" runat="server" Text='<%# Eval("id")%>' Style="display: none"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="60px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="票数">
                                                <ItemTemplate>
                                                    <%# Eval("VoteCount")%>
                                                </ItemTemplate>
                                                <HeaderStyle Width="60px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </XS:GridView>
                                    <XS:LinkButton ID="lbTP" runat="server" Text="投票" IsButton="true" OnClick="lbTP_Click"></XS:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="content clearfix">
                        <%=Model.TopicContent%>
                    </div>
                </div>
                <div class="topicFt">
                    <XS:EasyuiDialog ID="WinBoxHf" runat="server" Text="回复" Title="回复" IsColseReLoad="true" />
                    <XS:EasyuiDialog ID="WinBoxBj" runat="server" Text="编辑" Title="编辑" IsColseReLoad="true" />
                    <XS:LinkButton ID="lbSC" runat="server" Text="删除" confirm="true" OnClick="lbSC_Click"></XS:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <XS:Repeater ID="rpHF" runat="server">
        <ItemTemplate>
            <div class="box clearfix">
                <div class="left boxLeft">
                    <div class="hh">
                        <div class="userHd clearfix">
                            <a class="left hh" href="javascript:void(0)">
                               <%-- <%# GetUsers(Eval("UserID").ToString()).Realname%>--%></a>
                            <asp:Label ID="lbIsBZ" runat="server" Text='<%# IsBZ(Eval("UserID").ToString())%>'></asp:Label>
                        </div>
                        <div class="userBd">
                            <a href="javascript:void(0)">
                                <img src='<%--<%# GetUsers(Eval("UserID").ToString()).AvatarPath%>--%>'  /></a>
                        </div>
                        <div class="clearfix">
                            <label>
                                主题：<a class="highlight" href="#2"><strong><%# GetTopicsCountByUid(Eval("UserID").ToString(),"")%></strong></a></label>
                            <label>
                                精华：<a class="highlight" href="#2"><strong><%# GetTopicsCountByUid(Eval("UserID").ToString(),"GoodFlag")%></strong></a></label>
                            <br />
                            <br />
                            <div>
                                <XS:EasyuiDialog ID="WinBox2787" runat="server" Href='<%# string.Concat("Email.aspx?t=6","&uId=",Eval("UserID"))%>'
                                    IsColseReLoad="true" Text="[内部邮件]" Title="[内部邮件]" />
                                <XS:EasyuiDialog ID="WinBox1433" runat="server" Href='<%# string.Concat("Email.aspx?t=2","&uId=",Eval("UserID"))%>'
                                    IsColseReLoad="true" Text="[外部邮件]" Title="[外部邮件]" />
                                <br />
                                <XS:EasyuiDialog ID="WinBox34234" runat="server" Href='<%# string.Concat("Email.aspx?t=4","&uId=",Eval("UserID"))%>'
                                    IsColseReLoad="true" Text="[消息]" Title="[消息]" />
                                <XS:EasyuiDialog ID="WinBox442343" runat="server" Href='<%# string.Concat("sms.aspx?t=1","&uId=",Eval("UserID"))%>'
                                    IsColseReLoad="true" Text="[短信]" Title="[短信]" />
                                <a href="javascript:void(0)" onclick="lt(<%# Eval("UserID")%>)">[聊天]</a></div>
                        </div>
                    </div>
                </div>
                <div class="right boxRight">
                    <div class="topics">
                        <div class="topicHd clearfix">
                            <div class="left">
                                <span>发帖时间：<em><%# Eval("CreatedTime")%></em></span><span>最后修改：<em><%# Eval("UpdatedTime")%></em></span></div>
                            <em class="right floor"><strong class="highlight">
                                <%# Louc()%></strong>#</em> 
                        </div>
                        <div class="topicBd">
                            <div class="content clearfix">
                                <%# Eval("ReplyContent")%>
                            </div>
                        </div>
                        <div class="topicFt">
                            <XS:EasyuiDialog ID="WinBox8" runat="server" IsColseReLoad="true" Href='<%# string.Concat("BBS.aspx?t=15&num=1&mid="+ModuleID,"&tId=",Eval("TopicID"),"&rId=",Eval("id"))%>'
                                Text="引用" Title="引用" />
                            <a id='<%# Eval("id")%>' href='javascript:void(0)' onclick='delete_Click(this)'>
                                <asp:Label ID="sc" runat="server" Text='<%# ifSc(Eval("TopicID").ToString())%>'></asp:Label></a>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </XS:Repeater>
    <div class="box clearfix">
        <div class="left boxLeft">
        </div>
        <div class="right boxRight">
            <table>
                <tr>
                    <td>
                        <XS:Editor ID="ebHT" runat="server" EditorTools="全功能模式" ExtImg="jpg,JPG,png,PNG,gif,GIF"
                            Width="600" Height="300" />
                    </td>
                    <td>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <XS:Button ID="btnFT" runat="server" Width="80" Height="50" Text="提  交" OnClick="btnFT_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="divAddCtrCustom" title="回复信息" align="center">
        <iframe name="hhhfdf" src="BBS.aspx?t=15" style="width: 600px; height: 400px"></iframe>
    </div>
    <input id="hId" name="hName" type="hidden" />
    <XS:Button ID="btn" runat="server" OnClick="btn_Click" Style="display: none" />
    </div>
    <script>
        function delete_Click(obj) {
            document.getElementById("hId").value = obj.id;
            document.getElementById("<%=btn.ClientID%>").click();
        }
    </script>
    <script type="text/javascript">
        function IfDX() {
            var num = 0;
            var xz = "<%=xx%>";
            if (xz == 0) {
                var checks = document.getElementsByTagName("input");
                for (var i = 0; i < checks.length; i++) {
                    if (checks[i].type == "checkbox" && checks[i].checked) {
                        num = num + 1
                    }
                    if (num > 1) {
                        checks[i].checked = false;
                    }
                }
            }
        }

        function lt(uid) {
            OpenWinCenter("../../../CustomPages/TM.aspx?uid=" + uid, 678, 536);
        }


        $(function () {

            // Dialog			
            $('#divAddDtp').dialog({
                autoOpen: false,
                width: 350,
                show: 'blind',
                hide: 'explode'


            });
            $('#divAddCtrCustom').dialog({
                autoOpen: false,
                width: 630,
                show: 'explode'
            });

        });

        function OpenAddCtrCustom() {

            $("#divAddCtrCustom").dialog('open');
        }

        function CloseAddCtrCustom() {
            $("#divAddCtrCustom").dialog('close');
        }
    </script>
    <script>
        var Mar = document.getElementById("MarqueeR");
        var MarL = document.getElementById("MarqueeL");
        var child_div = Mar.getElementsByTagName("div");
        var child_divL = MarL.getElementsByTagName("div");
        var picH = 60; //移动高度 
        var scrollstep = 3; //移动步幅,越大越快 
        var scrolltime = 20; //移动频度(毫秒)越大越慢 
        var stoptime = 3000; //间断时间(毫秒) 
        var tmpH = 0;
        Mar.innerHTML += Mar.innerHTML;
        MarL.innerHTML += MarL.innerHTML;
        function start() {
            if (tmpH < picH) {
                tmpH += scrollstep;
                if (tmpH > picH) tmpH = picH;
                Mar.scrollTop = tmpH;
                MarL.scrollTop = tmpH;
                setTimeout(start, scrolltime);
            } else {
                tmpH = 0;
                Mar.appendChild(child_div[0]);
                Mar.scrollTop = 0;
                MarL.appendChild(child_divL[0]);
                MarL.scrollTop = 0;
                setTimeout(start, stoptime);
            }
        }
        onload = function () { setTimeout(start, stoptime) }; 
    </script>
