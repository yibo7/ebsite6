<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs"  Inherits="EbSite.Widgets.RemarkAskPg.widget" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<form id="form1" runat="server">
<div class="dp_main" style="width: 765px; margin-left: 20px;">
    <div class="qa">
        <asp:Repeater runat="server" ID="rpComment" EnableViewState="false">
            <ItemTemplate>
                <div class="qa_con<%#Equals((Container.ItemIndex + 1)%2,0)?"2":"" %> clearfix">
                    <div>
                        <p class="question">
                            问：
                            <%#Eval("Body") %></p>
                        <span class="time">
                            <%#Eval("dateandtime")%></span>
                    </div>
                    <div>
                        <p class="answer">
                            <span>商家：</span>
                            <%#Eval("Quote")%></p>
                            <span class="time">
                            <%#Eval("dateasktime")%></span>
                        
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <br>   
                                               
    <a href="/"
        target="_blank">
        <div class="moreque ">
        </div>
    </a>
    <div runat="server" id="SendPost">
        <table style="width: 100%; background-color: #F3F3F3;">
            <tr>
                <td colspan="5">
                    <% if (string.IsNullOrEmpty(EbSite.Base.AppStartInit.UserName))
                       {%>
                    <table style="width: 100%; margin-left: 10px;">
                        <tr>
                            <td>
                                用户帐号:
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" Width="80" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                登录密码:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPass" TextMode="Password" Width="80" runat="server"></asp:TextBox>
                                <asp:Button ID="btnLogIn" runat="server" Width="50" Height="23" Text="登录" OnClick="btnLogIn_Click" />
                                <a target="_blank" href="<%=EbSite.Base.Host.Instance.RegRw %>">注册用户</a>
                            </td>
                        </tr>
                    </table>
                    <%}
                       else
                       { %>
                    您好,<a target="_blank" href="<%=EbSite.Base.Host.Instance.GetUserHomePage() %>"><%=EbSite.Base.AppStartInit.UserNiName%></a>
                    <%} %>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <input type="text" style="display: none" id="quote" name="quote" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    向商家提问：<span>(问题提交后显示可能会延迟，请耐心等待。)</span> 小提示
                    <asp:TextBox Width="80%" Height="100" ID="txtContent" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
                <td style="width: 180px;">
                    <table>
                        <tr id="IsOpenSafeCoder" runat="server">
                            <td>
                                <asp:Image ID="ImageCheck" runat="server" onClick="this.src+=Math.random()" Style="cursor: pointer;"
                                    ImageUrl="/ValidateCode.ashx?" ToolTip="图片看不清？点击重新得到验证码,不区分大小写!红色数字,黑色字母!"></asp:Image>
                                <br />
                                验证码:
                                <asp:TextBox ID="txtSafeCoder" runat="server" Width="80" CanBeNull="必填"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                匿名发表:<asp:CheckBox ID="cbNiName" Text="是" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPl" Width="80" Height="23" BorderColor="#000" runat="server" Text="我要留言"
                                    OnClick="btnPl_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; color: ThreeDFace" colspan="5">
                    网友评论仅供网友表达个人看法，并不表明本站同意其观点或证实其描述
                </td>
            </tr>
        </table>
        <a name="AddPost"></a>
    </div>
</div>
</form>
