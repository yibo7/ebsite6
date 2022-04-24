<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Corde.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.UseCorde.Corde" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
    <div class="admin_toobar">
        <fieldset>
            <legend>飘浮代码，请将以下代码放到需要展示客服的页面底部</legend>
            <div>
                <asp:TextBox  ID="txtCorde" TextMode="MultiLine" Width="500" Height="100"    runat="server"   ></asp:TextBox>
            </div>
        </fieldset>
    </div>

        <div class="admin_toobar">
        <fieldset>
            <legend>连接地址</legend>
            <div>
                <asp:TextBox  ID="txtChatLink" TextMode="MultiLine" Width="500" Height="100"    runat="server"   ></asp:TextBox>
            </div>
        </fieldset>
    </div>