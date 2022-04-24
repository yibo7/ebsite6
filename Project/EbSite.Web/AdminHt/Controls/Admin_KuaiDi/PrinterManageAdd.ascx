<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrinterManageAdd.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_KuaiDi.PrinterManageAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
                <h3>添加信息</h3>
            </div>
            <div class="content">
				<asp:PlaceHolder ID="phCtrList" runat="server">
   <div id="content">
                    <div style="font-size: 16px; margin-left:300px; margin-bottom: 5px; color: red; width:100%;">[请在IE中编辑]</div>
                    <div style="padding-right: 25px; padding-left: 25px; padding-bottom: 3px; color: #4b6888;
                        padding-top: 3px; border-bottom: #cccccc 1px solid; height: 80px;">
                        添加打印项：
                        <select id="selectPrintObj">
                            <option>请选择要插入的打印项</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_name','收货人-姓名');">
                                收货人-姓名</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_area_0','收货人-地区1级')">
                                收货人-地区1级</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_area_1','收货人-地区2级')">
                                收货人-地区2级</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_area_2','收货人-地区3级')">
                                收货人-地区3级</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_addr','收货人-地址')">
                                收货人-地址</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_tel','收货人-电话')">
                                收货人-电话</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_mobile','收货人-手机')">
                                收货人-手机</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_zip','收货人-邮编')">
                                收货人-邮编</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_name','发货人-姓名')">
                                发货人-姓名</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_area_0','发货人-地区1级')">
                                发货人-地区1级</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_area_1','发货人-地区2级')">
                                发货人-地区2级</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_area_2','发货人-地区3级')">
                                发货人-地区3级</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_address','发货人-地址')">
                                发货人-地址</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_tel','发货人-电话')">
                                发货人-电话</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_mobile','发货人-手机')">
                                发货人-手机</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('dly_zip','发货人-邮编')">
                                发货人-邮编</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('date_y','当日日期-年')">
                                当日日期-年</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('date_m','当日日期-月')">
                                当日日期-月</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('date_d','当日日期-日')">
                                当日日期-日</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_id','订单-订单号')">
                                订单-订单号</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_price','订单总金额')">
                                订单总金额</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_weight','订单物品总重量')">
                                订单物品总重量</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_count','订单-物品数量')">
                                订单-物品数量</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('order_memo','订单-备注')">
                                订单-备注</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('ship_time','订单-送货时间')">
                                订单-送货时间</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('shop_name','网店名称')">
                                网店名称</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('tick','对号 - √')">
                                对号 - √</option>
                            <option value="javascript:document.getElementById('dly_printer_editor_flash').addElement('text','自定义内容')">
                                自定义内容</option>
                        </select>
                        <input type="button" value="插入" onclick="window.location.href=document.getElementById('selectPrintObj').options[document.getElementById('selectPrintObj').options.selectedIndex].value" />
                        <input type="button" value="删除项" onclick="dly_printer_editor_flash.delItem()" />
                        &nbsp;&nbsp; 快递单名称：<asp:TextBox ID="txtName" runat="server" Width="100px" MaxLength="50"></asp:TextBox>
                        <span class="NeedMsg">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"
                            ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                        单据宽：
                        <asp:TextBox ID="txtWidth" runat="server" Width="40px" />
                        单据高：
                        <asp:TextBox ID="txtHeight" runat="server" Width="40px" />
                        是否启用：<asp:CheckBox ID="txtIsAct" runat="server" CssClass="checkbox" />
                        <br />
                        <div style="float: left;">
                            <XS:SWFUpload runat="server" ID="sLogo" SaveFolder="/images/kuaidi/express"
                                IsMakeSmallImg="true" AllowExt="jpg,gif,png" AllowSize="2024" />
                        </div>
                        <div style="float: left;">
                            <input type="button" value="设置背景" onclick="setBg()" /></div>
                        <select id="jianju2" style="height: 20px" onchange="if(this.value!='--')document.getElementById('dly_printer_editor_flash').setFontSize(this.value);"
                            name="font">
                            <option value="--">大小</option>
                            <option value="10">10</option>
                            <option value="12">12</option>
                            <option value="14">14</option>
                            <option value="18">18</option>
                            <option value="20">20</option>
                            <option value="24">24</option>
                            <option value="27">27</option>
                            <option value="30">30</option>
                            <option value="36">36</option>
                        </select>
                        <select onchange="if(this.value!='--')document.getElementById('dly_printer_editor_flash').setFont(this.value);">
                            <option value="--">字体</option>
                            <option value="宋体">宋体</option>
                            <option value="黑体">黑体</option>
                            <option value="Arial">Arial</option>
                            <option value="Verdana">Verdana</option>
                            <option value="Serif">Serif</option>
                            <option value="Cursive">Cursive</option>
                            <option value="Fantasy">Fantasy</option>
                            <option value="Sans-Serif">Sans-Serif</option>
                        </select>
                        <select id="jianju" style="height: 20px" onchange="if(this.value!='--')document.getElementById('dly_printer_editor_flash').setFontSpace(this.value);" name="jianju">
                            <option value="--">间距</option>
                            <option value="-4">-4</option>
                            <option value="-2">-2</option>
                            <option value="0">0</option>
                            <option value="2">2</option>
                            <option value="4">4</option>
                            <option value="6">6</option>
                            <option value="8">8</option>
                            <option value="10">10</option>
                            <option value="12">12</option>
                            <option value="14">14</option>
                            <option value="16">16</option>
                            <option value="18">18</option>
                            <option value="20">20</option>
                            <option value="22">22</option>
                            <option value="24">24</option>
                            <option value="26">26</option>
                            <option value="28">28</option>
                            <option value="30">30</option>
                        </select>
                        <input type="button" value="B" onclick="document.getElementById('dly_printer_editor_flash').setBorder()" />
                        <input type="button" value="I" onclick="document.getElementById('dly_printer_editor_flash').setItalic()" />
                        <input type="button" value="居左" onclick="document.getElementById('dly_printer_editor_flash').setAlign('left')" />
                        <input type="button" value="居中" onclick="document.getElementById('dly_printer_editor_flash').setAlign('center')" />
                        <input type="button" value="居右" onclick="document.getElementById('dly_printer_editor_flash').setAlign('right')" />
                        <asp:HiddenField ID="HbflashData" runat="server" />
                        <input id="flashData" name="flashData" type="hidden" /></div>
                    <br />
                    <div class="listborder" runat="server" >
                        <table bgcolor="#dddddd">
                            <tbody>
                                <tr>
                                    <td>
                                        <div id="dly_printer_editor" style="border-right: #999 1px solid; border-top: #999 1px solid;
                                            border-left: #999 1px solid; width: 831px; border-bottom: #999 1px solid; height: 615px;
                                            border-solid: 1px 1px 0 0">
                                            
                                            <script language="javascript" charset="utf-8">
                                                document.write('<object id="dly_printer_editor_flash" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,5,0,0" height="100%" width="100%">');
                                                document.write('<param value="high" name="quality" />');
                                                document.write('<param value="always" name="allowScriptAccess" />');
                                                document.write('<param value="opaque" name="wMode" />');


                                                document.write('<param name="flashvars" value="<%=ItemContent %>"/>');
                                                document.write('<param name="src" value="/images/kuaidi/printer.swf"/>');
                                                document.write('<embed name="flexApp" pluginspage="http://www.macromedia.com/go/getflashplayer" src="/images/kuaidi/printer.swf" height="100%" width="100%" flashvars="<%=ItemContent %>"/>');
                                                document.write('</object>');
			                               </script>
                                            

                                           <%-- <object id='dly_printer_editor_flash' height="100%" width="100%" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000">
                                              
                                                <param value="always" name="allowScriptAccess" />
                                                <param value="opaque" name="wMode" />
                                                <param value="true" name="swLiveConnect" />
                                                <param value="<%=ItemContent %>" name="flashVars" />
                                                <param value="/adminht/Controls/Admin_KuaiDi/printer.swf" name="movie" />
                                            </object>--%>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
</asp:PlaceHolder>
            </div>
    </div>
</div>

<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " OnClientClick="saveData()" ValidationGroup="BB" />
</div>
 

<script type="text/javascript">
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();

    function setBg() {
        var k = $("#ctl00_ctphBody_ctl00_sLogo_spctl00_ctphBody_ctl00_sLogo").val();
        alert(k);
        document.getElementById('dly_printer_editor_flash').setBg(k);
    }
    function saveData() {
        //alert(0);

        var k = $("#ctl00_ctphBody_ctl00_sLogo_spctl00_ctphBody_ctl00_sLogo").val();
      //  alert(k);
        var obj = document.getElementById('dly_printer_editor_flash');
        alert(escape(obj.getData()));
       
        $("#<%=HbflashData.ClientID %>").val('data=' + escape(obj.getData()) + '&bg=' + k + '&copyright=shopex');
      //  alert($("#<%=HbflashData.ClientID %>").val());
    }

</script>
