<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Wenda.ModuleCore.Pages.maskpost" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
</head>
<body>
    <!--#include file="header.inc"-->
    <div class="eb-content" style="width: 990px; margin: 8px auto;">
        <div class="c_left">
            <form id="Form1" runat="server">
                <div class="l_top" style="padding: 10px; width: 731px;">
                    <asp:PlaceHolder ID="phExpert" runat="server">
                        <!--专家代码-->
                        <div class="zjinfo">
                            <div class="zjphoto">
                                <img src='<%=EbSite.Base.Host.Instance.AvatarBig(Convert.ToInt32(mdExpert.UserID.ToString()))%>' width="180" />
                            </div>
                            <div class="zjmes">
                                <div class="zjname">
                                    <li><span><%=mdExpert.UserNiName%></span></li>
                                    <li>擅长领域：<font color="#6D9520"><%=mdExpert.Field%></font></li>
                                    <li>擅长品牌：<font color="#6D9520"><%=mdExpert.Brand%></font></li>
                                </div>
                                <div class="zjintro">
                                    <span>专家简介：</span>
                                    <li><%=mdExpert.JianJie%></li>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phUser" runat="server">
                        <!--普通用户代码-->
                        <div class="zjinfo">
                            <div class="zjphoto">
                                <img src='<%=mdUser.AvatarBig %>' width="180" />
                            </div>
                            <div class="zjmes">
                                <div class="zjname">
                                    <li><span><%=mdUser.NiName%></span></li>
                                    <li>级别：<font color="#6D9520"><%=mdUser.UserLevelName%></font></li>
                                    <li>积分：<font color="#6D9520"><%=mdUser.Credits%></font></li>
                                </div>
                                <div class="zjintro">
                                    <span>签名：</span>
                                    <li><%=string.IsNullOrEmpty(mdUser.Sign) ? "作者很忙，还没有时间更新签名" : mdUser.Sign%></li>
                                </div>
                            </div>
                        </div>

                    </asp:PlaceHolder>
                    <br />
                    <div style="width: 100%; height: 5px;"></div>
                    <XS:ExtensionsCtrls ID="WendaClassType" ModelCtrlID="fb1e199a-f588-4d2a-9d0f-9c5eb98fc5d5"
                        runat="server" />
                    <div class="wthinputtitle">

                        <textarea id="NewsTitle" name="NewsTitle">请输入您问题的简单描述，如超过30个字请在补充问题里填写</textarea>
                    </div>
                    <div id="btnshowhide" style="cursor: pointer;" class="wtbc">
                        <img src="<%=base.ThemeCss %>images/23_1.png" />
                        问题补充（选填）
                    </div>
                    <div id="panelex" style="display: none;">
                        <XS:ExtensionsCtrls ID="ContentInfo" ModelCtrlID="42be44b3-0062-470e-b341-0fc474ef221c" runat="server" />
                        <div class="tool-ask">
                            <div class="tool-ask-areaex">
                                您还可以输入<span id="labWordEx">1000</span> 个字
                            </div>
                        </div>
                    </div>
                    <div class="wtbtn">
                        <div>
                            <span id="ScoreDDList" style="float: left;">
                                <XS:ExtensionsCtrls ID="ExtensionsCtrls2" ModelCtrlID="f1c6998e-c0b2-4a18-9d27-c937ef367e5d"
                                    runat="server" />
                            </span><span style="float: left; padding-top: 10px; padding-left: 10px;">您目前的财富值：<span id="scoref">0 </span>
                            </span>
                        </div>


                        <div class="wdcontf">
                            你还可以输入<span style="font-size: 16px;" id="labWord">30</span> 字
                        </div>

                        <div style="clear: both; visibility:visible; " id="Dvem">

                            <input id="tbEmail" type="text" style="width: 300px; height: 25px; border: 1px solid #ccc;" /><span style="color: #ccc; font-size: 15px; margin-left: 20px;"> 请输入邮箱地址，有人回答时方便及时邮箱提醒您。</span>
                        </div>
                        <div style="text-align:right;">
                            <table width="400px"><tr>
                                <td align="right">验证码：</td>
                                <td><input type="text" name="reg_yzm" id="reg_yzm" class="inp_yzm2" style="float:left" /> </td>
                                <td> <img class="ValidateCode" src="/ValidateCode.ashx?" onclick="this.src+=Math.random()"     style="float:left; cursor: pointer; height:30px;" />
                                <a onclick="$('.ValidateCode').click();" style="color:#076FA2;cursor: pointer;">看不清？<span style="text-decoration:underline">换一张</span></a>
                                </td>
                                </tr>
                            </table>
                        </div>
                        <div class="fbbtn allpic" style="cursor: pointer;" type="button" value="" onclick="subitfun()">
                        </div>
                    </div>
                </div>
            </form>
            <div class="line">
            </div>
        </div>
        <div class="c_right">
            <div class="bor_c" style="margin-top: 0px;">
                <div class="Expertsonline">
                    <div class="zjzx">专家在线</div>
                    <XS:Widget ID="Widget3"  WidgetName="问答首页专家" WidgetID="c3caec92-9bcd-4a05-b804-1dc915cc65dd" runat="server" />


                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="<%= base.ThemePage%>post.js"></script>
    <!--#include file="footer.inc"-->
    <span runat="server" id="datacount"></span>
</body>
</html>
<script>
    var SiteConfigsY = {askuseridY:  <%=base.UserID %> };
</script>

