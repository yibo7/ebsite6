<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FastPrint.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_KuaiDi.FastPrint" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>快速打印</h3>
            </div>
            <div class="content">
				<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <fieldset> 
                <div style="padding: 5px 0px 5px 12px;" class="title  m_none td_bottom">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td> <em><img src="/images/kuaidi/04.gif" width="32" height="32"></em></td>
                                <td width="100%">
                                    <h5>收货人信息</h5>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="padding-bottom: 1px;" class="datafrom">
                    <table class="PrintDataTable" border="0" cellspacing="1" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <th>
                                    <span>收货人姓名：<em>*</em></span>
                                </th>
                                <td>
                                    <XS:TextBoxVl ID="txtShipName" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                                </td>
                                <th class="leftb">
                                    <span>E-Mail：</span>
                                </th>
                                <td>
                                    <XS:TextBoxVl ID="txtEmail"  Width="250" ValidateType="电子邮箱email"
                                        runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <span>省区：<em>*</em></span>
                                </th>
                                <td >
                                    <XS:AreaList ID="alReceiveAreaList" BackFun="onReceiveAreaListSel" runat="server" />
                                </td>
                                 <th class="leftb" width="15%">
                                    <span>单号：</span>
                                </th>
                                <td width="35%">
                                    <XS:TextBoxVl ID="txtNumber"   runat="server"
                                        ValidationGroup="BB"></XS:TextBoxVl>
                                </td>
                            </tr>
                            <tr>
                                <th width="15%">
                                    <span>详细地址：<em>*</em></span>
                                </th>
                                <td width="35%">
                                    <XS:TextBoxVl ID="txtAddress" Width="290" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                                </td>
                                <th class="leftb" width="15%">
                                    <span>邮 编：</span>
                                </th>
                                <td width="35%">
                                    <XS:TextBoxVl ID="txtZipcode"  ValidateType="邮政编码" runat="server"
                                        ValidationGroup="BB"></XS:TextBoxVl>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <span>联系电话：</span>
                                </th>
                                <td>
                                    <XS:TextBoxVl ID="txtTelphone" ValidateType="电话号码加区号"  runat="server"
                                        ValidationGroup="BB"></XS:TextBoxVl>
                                </td>
                                <th class="leftb">
                                    <span>手 机：</span>
                                </th>
                                <td>
                                    <XS:TextBoxVl ID="txtCellphone" ValidateType="手机号" IsAllowNull="false" runat="server"
                                        ValidationGroup="BB"></XS:TextBoxVl>
                                </td>
                            </tr>
                            <%-- <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3">
                                <a class="linkSub float">
                                    <input id="btnUpdateAddrdss" onclick="return DoValid();" name="btnUpdateAddrdss"
                                        value="修改订单地址" type="submit">
                                </a><span class="fonts colorB">(您可以将编辑过的收货人信息更新到订单)</span>
                            </td>
                        </tr>--%>
                        </tbody>
                    </table>
                </div>
                <div style="padding: 5px 0px 5px 12px;" class="title  m_none td_bottom">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td>
                                    <em>
                                        <img src="/images/kuaidi/04.gif" width="32" height="32"></em>
                                </td>
                                <td width="100%">
                                    <h5>
                                        发货人信息</h5>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="padding-bottom: 1px;" class="datafrom">
                    <div id="pnlSender">
                        <asp:Label ID="LabMsg" runat="server" Text=""></asp:Label>
                        <asp:Panel ID="PanSend" runat="server">
                            <table class="PrintDataTable" border="0" cellspacing="1" cellpadding="0" width="100%">
                                <tbody>
                                    <tr>
                                        <th>
                                            <span>发货点选择：</span>
                                        </th>
                                        <td >
                                            <XS:DropDownList ID="ddlShoperTag" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShoperTag_SelectedIndexChanged">
                                            </XS:DropDownList>
                                        </td>
                                        <th class="leftb" width="15%">
                                            <span>网点名称：</span>
                                        </th>
                                        <td width="35%">
                                            <asp:Label ID="LbShopName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th width="15%">
                                            <span>发件人姓名：</span>
                                        </th>
                                        <td width="35%">
                                            <asp:Label ID="LbShipperName" runat="server" Text=""></asp:Label>
                                        </td>
                                        <th class="leftb" width="15%">
                                            <span>地区：</span>
                                        </th>
                                        <td width="35%">
                                            <asp:Label ID="LbRegionId" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <span>邮 编：</span>
                                        </th>
                                        <td>
                                            <asp:Label ID="LbZipcode" runat="server" Text=""></asp:Label>
                                        </td>
                                        <th class="leftb">
                                            详细地址：<span></span>
                                        </th>
                                        <td>
                                            <asp:Label ID="LbAddress" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <span>手 机：</span>
                                        </th>
                                        <td>
                                            <asp:Label ID="LbCellPhone" runat="server" Text=""></asp:Label>
                                        </td>
                                        <th class="leftb">
                                            <span>联系电话：</span>
                                        </th>
                                        <td>
                                            <asp:Label ID="LbTelPhone" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </div>
                </div>
                <div style="padding: 5px 0px 5px 12px;" class="title  m_none td_bottom">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td>
                                    <em>
                                        <img src="/images/kuaidi/10.gif" width="32" height="32"></em>
                                </td>
                                <td width="100%">
                                    <h5>
                                        选择快递单模板</h5>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="padding-bottom: 1px;" class="datafrom">
                    <div id="pnlTemplates">
                        <table class="PrintDataTable" border="0" cellspacing="1" cellpadding="0" width="100%">
                            <tbody>
                                <tr>
                                    <th width="15%">
                                        <span>客户所选配送方式：</span>
                                    </th>
                                    <td colspan="3">
                                        XXXXXX
                                    </td>
                                </tr>
                                <tr>
                                    <th width="15%">
                                        <span>选择模版：<em>*</em></span>
                                    </th>
                                    <td colspan="3">
                                        <div class="selectTem">
                                            <ul class="ul1">
                                                <XS:DropDownList runat="server" ID="ddlTemplates" >
                                                </XS:DropDownList>
                                            </ul>
                                            <ul class="ul2">

                                                <XS:Button ID="BtnPrint" runat="server" CssClass="printSub"  ValidationGroup="BB" OnClick="BtnPrint_Click" />
                                               
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="PrintPanel" runat="server" Width="100%" Visible="false">
            <div class="listborder">
                <table bgcolor="#dddddd">
                    <tbody>
                        <tr>
                            <td>
                                <div id="dly_printer" style="width: 907px; height: 560px">  
                                   <%-- <object id="dly_printer_flash" height="100%" width="100%" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
                                   codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,5,0,0">
                                        <param value="high" name="quality" />
                                        <param value="always" name="allowScriptAccess" />
                                        <param value="true" name="swLiveConnect" />
                                        <param value="<%=ItemContent %>" name="flashVars" />
                                        <param value="/adminht/Controls/Admin_KuaiDi/printermode.swf" name="src" /> 
                                    </object>--%>
                                    <script language="javascript" charset="utf-8">
                                        document.write('<object id="dly_printer_flash" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,5,0,0" height="100%" width="100%">');
                                        document.write('<param name="flashvars" value="<%=ItemContent %>"/>');
                                        document.write(' <param value="high" name="quality" />');
                                        document.write(' <param value="always" name="allowScriptAccess" />');
                                        document.write(' <param value="true" name="swLiveConnect" />');
                                        document.write('<param name="src" value="/images/kuaidi/printermode.swf"/>');
                                        document.write('<embed name="flexApp" pluginspage="http://www.macromedia.com/go/getflashplayer" src="/images/kuaidi/printermode.swf" height="100%" width="100%" flashvars="<%=ItemContent %>"/>');
                                        document.write('</object>');
			                      </script>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:PlaceHolder>
            </div>
    </div>
</div>

<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="BB" />
</div>
 
<link type="text/css" href="/images/kuaidi/kuaidi.css" rel="stylesheet" />
 
    
 
