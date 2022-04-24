<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.Shop.ModuleCore.Pages.mshoppingcar2" %>

<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.Modules.Shop" Namespace="EbSite.Modules.Shop.ModuleCore.Ctrls"
    TagPrefix="Shop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<link type="text/css" href="<%=base.ThemeCss %>/order.css" rel="stylesheet" />
<body>
    <div class="topbg">
<<<<<<< .mine
    <div class="container">
		 <div class="topbgl">
            <ul>
              <li><a href="#">首页</a></li>
              <li><div class="gbpic starico"></div><a href="#">收藏网站</a></li> 
            </ul> 
         </div>
         <div class="orther">
            <ul>
              <li class="user"><span id="login_info" ></span></li>
              <li class="kefu"><a href="#">客服中心</a></li>
              <li class="weibo"><a href="#">官方微博</a></li>
            </ul>
         </div>
=======
        <div class="container">
            <div class="topbgl">
                <ul>
                    <li><a href="#">��ҳ</a></li>
                    <li>
                        <div class="gbpic starico">
                        </div>
                        <a href="#">�ղ���վ</a></li>
                </ul>
            </div>
            <div class="orther">
                <ul>
                    <li class="user"><span id="login_info"></span></li>
                    <li class="kefu"><a href="#">�ͷ�����</a></li>
                    <li class="weibo"><a href="#">�ٷ�΢��</a></li>
                </ul>
            </div>
        </div>
>>>>>>> .r1725
    </div>
    <div class="clear">
    </div>
    <div class="container">
<<<<<<< .mine
	<div>
	<div style="overflow:hidden;">
		<div class="delogo"><img src="<%=base.ThemeCss %>/images/logo.png"  class="logo" /></div>
		<div  class="gbpic topbnrr"></div>
	</div>
	</div>
</div>
    <div  class="center_x">
	<div class="container">
			<div class="linbg"><li><b>收货人信息</b>&nbsp;&nbsp;&nbsp;<a href="javascript:void(0);" onclick="UserNewAddress(this)">[使用新地址]</a></li></div>
			<div class="raone" id="ulAddress" >
                <asp:Repeater ID="rpAddress"  runat="server">
                                <ItemTemplate>
                                     <li >
                                        <input name="radioAddress" id="radioAddress<%# Eval("id") %>" areaid='<%# Eval("AreaID")%>' parentids="<%# Eval("CountryName")%>" value="<%# Eval("id") %>" type="radio" >
                                        <label for="radioAddress<%# Eval("id") %>">
                                         <b><%# Eval("AddressInfo")%>  收货人:<%# Eval("UserRealName")%>  手机:<%# Eval("Mobile")%></b>
                                         </label>
                                    </li>
                                </ItemTemplate>
                    </asp:Repeater>
=======
        <div>
            <div style="overflow: hidden;">
                <div class="delogo">
                    <img src="<%=base.ThemeCss %>/images/logo.png" class="logo" /></div>
                <div class="gbpic topbnrr">
                </div>
>>>>>>> .r1725
            </div>
        </div>
    </div>
    <div class="center_x">
        <div class="container">
            <div class="linbg">
                <li><b>�ջ�����Ϣ</b>&nbsp;&nbsp;&nbsp;<a href="javascript:void(0);" onclick="UserNewAddress(this)">[ʹ���µ�ַ]</a></li></div>
            <div class="raone" id="ulAddress">
                <asp:Repeater ID="rpAddress" runat="server">
                    <ItemTemplate>
                        <li>
                            <input name="radioAddress" id="radioAddress<%# Eval("id") %>" areaid='<%# Eval("AreaID")%>'
                                parentids="<%# Eval("CountryName")%>" value="<%# Eval("id") %>" type="radio">
                            <label for="radioAddress<%# Eval("id") %>">
                                <b>
                                    <%# Eval("AddressInfo")%>
                                    �ջ���:<%# Eval("UserRealName")%>
                                    �ֻ�:<%# Eval("Mobile")%></b>
                            </label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <form id="fmAdresss">
            <input id="btnSaveAdrress" style="display: none;" type="submit">
            <div id="tabControlPanel" class="tabinfo">
                <ul>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>��ַ��</div>
                        <dl>
                            <script language='javascript' src='/js/drplistbll.js'></script>
                            <span id="alReceiveAreaList">
                                <input type="hidden" name="alReceiveAreaList$hfValue" id="alReceiveAreaList_hfValue" />
                                <input type="hidden" name="alReceiveAreaList$hfValueP" id="alReceiveAreaList_hfValueP" /></span>
                            <script>                                var objal_alReceiveAreaList = InitAreaList("alReceiveAreaList", 5, "alReceiveAreaList_hfValue", "wcf", "GetAlear", "", 1, 3, function (obj) { onReceiveAreaListSel(obj) });</script>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>��ϸ��ַ��</div>
                        <dl style="width: 550px;">
                            <span id="lbReceiveAddress" style="font-size: 14px; color: #999999;"></span>
                            <input type="text" id="txtAddress" name="txtAddress" class="inp_dl" /><div id="errtxtAddress"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtAddress" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            �ʱࣺ</div>
                        <dl style="width: 450px;">
                            <input type="text" id="txtPostCode" name="txtPostCode" class="inp_dl inp_wid170" /></dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>�ջ���������</div>
                        <dl style="width: 425px;">
                            <input type="text" id="txtSHR" name="txtSHR" class="inp_dl inp_wid170" /><div id="errtxtSHR"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtSHR" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            <font color="#FF0000"><b>*</b></font>�ֻ���</div>
                        <dl style="width: 390px;">
                            <input type="text" class="inp_dl" id="txtMobile" name="txtMobile" /><div id="errtxtMobile"
                                class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtMobile" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            ������</div>
                        <dl style="width: 600px;">
                            <input type="text" class="inp_dl" id="txtTel" name="txtTel" />
                            <span class="tabinfospan">����ʽ:010-3688898��</span><div id="errtxtTel" class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtTel" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                    <li>
                        <div class="tablidiv">
                            Email��</div>
                        <dl style="width: 560px;">
                            <input type="text" id="txtEmail" name="txtEmail" class="inp_dl" />
                            <span class="tabinfospan">���������ն���״̬���ѣ�</span><div id="errtxtEmail" class="errmsgdefault">
                            </div>
                            <span id="errmsgtxtEmail" style="color: #CCCCCC"></span>
                        </dl>
                    </li>
                </ul>
            </div>
            <div id="divsaveinfobtn" style="margin-bottom: 10px;">
                <div id="btnSaveReceiveAddress" class="btn_save gbpic" style="float: left; margin-right: 10px;">
                </div>
                <li class="btnsaver">��ȷ������д���ջ�����Ϣ׼ȷ���󣬷��������޷���ʱ�յ����</li>
            </div>
            </form>
            <div class="linbg">
                <li><b>ѡ�����ͷ�ʽ</b></li></div>
            <div style="padding: 20px;">
                <asp:Repeater ID="rpPeiSong" runat="server">
                    <ItemTemplate>
                        <div class="ratwo">
                            <li>
<<<<<<< .mine
                                <div class="tablidiv"><font color="#FF0000"> <b>*</b></font>地址：</div>
                                <dl>
                                    <SCRIPT language='javascript' src='/js/drplistbll.js'></SCRIPT>
                                     <span id="alReceiveAreaList">
                                     <input type="hidden" name="alReceiveAreaList$hfValue" id="alReceiveAreaList_hfValue" />
                                     <input type="hidden" name="alReceiveAreaList$hfValueP" id="alReceiveAreaList_hfValueP" /></span>
                                     <script>var objal_alReceiveAreaList = InitAreaList("alReceiveAreaList", 5, "alReceiveAreaList_hfValue", "wcf", "GetAlear", "", 1, 3, function (obj) { onReceiveAreaListSel(obj) });</script>
                                  
                                </dl>
=======
                                <input type="radio" name="rdoDelivery" iscod="<%# Eval("IsCod")%>" temid="<%# Eval("ShippingTemplatesId") %>"
                                    id="radioPeiSong<%# Eval("id") %>" value="<%# Eval("id") %>" />
                                <label for="radioPeiSong<%# Eval("id") %>">
                                    <b>
                                        <%# Eval("ModeName")%></b>&nbsp;&nbsp; �Ƿ�֧���������<font color="red"><%# Eval("IsCod").ToString() == "True"?"��":"��"%></font></label>
>>>>>>> .r1725
                            </li>
<<<<<<< .mine
                            <li>
					        <div class="tablidiv"><font color="#FF0000"> <b>*</b></font>详细地址：</div>
					        <dl style="width:550px;"><span  id="lbReceiveAddress" style="font-size:14px; color:#999999;"></span><input type="text" id="txtAddress" name="txtAddress" class="inp_dl"   /><div id="errtxtAddress" class="errmsgdefault" ></div><span id="errmsgtxtAddress" style="color:#CCCCCC"></span></dl>
				            </li>
				            <li>
					            <div class="tablidiv">邮编：</div>
					            <dl style="width:450px;"><input type="text" id="txtPostCode" name="txtPostCode" class="inp_dl inp_wid170"   /></dl>
				            </li>
				            <li>
					            <div class="tablidiv"><font color="#FF0000"> <b>*</b></font>收货人姓名：</div>
					            <dl style="width:425px;"><input type="text" id="txtSHR" name="txtSHR" class="inp_dl inp_wid170"   /><div id="errtxtSHR" class="errmsgdefault" ></div><span id="errmsgtxtSHR" style="color:#CCCCCC"></span></dl>
				            </li>
				            <li>
					            <div class="tablidiv"><font color="#FF0000"> <b>*</b></font>手机：</div>
					            <dl style="width:390px;"><input type="text" class="inp_dl" id="txtMobile" name="txtMobile"   /><div id="errtxtMobile" class="errmsgdefault" ></div><span id="errmsgtxtMobile" style="color:#CCCCCC"></span></dl>
				            </li>
				            <li>
					            <div class="tablidiv">座机：</div>
					            <dl style="width:600px;"><input type="text" class="inp_dl" id="txtTel" name="txtTel"    />
					            <span class="tabinfospan">（格式:010-3688898）</span><div id="errtxtTel" class="errmsgdefault" ></div><span id="errmsgtxtTel" style="color:#CCCCCC"></span></dl>
				            </li>
				            <li>
					            <div class="tablidiv">Email：</div>
					            <dl style="width:560px;"><input type="text" id="txtEmail" name="txtEmail"  class="inp_dl"    />
					            <span class="tabinfospan">（用来接收订单状态提醒）</span><div id="errtxtEmail" class="errmsgdefault" ></div><span id="errmsgtxtEmail" style="color:#CCCCCC"></span></dl>
				            </li>
                       
=======
                        </div>
                        <div id="DeliveryDemo<%# Eval("id") %>" class="tabptkd">
                            <ul>
                                <li>֧��������<%# Eval("PsCompanys")%></li>
                                <li>��ϸ˵����<%# Eval("Content")%></li>
                                <li>�˷Ѽ��㣺<font id="FreightTotal<%# Eval("id") %>" size="5" color="#ff0000">������...</font>Ԫ</li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="tabsfkd">
                    �ͻ�ʱ�䣺
                    <select name="drpSendDateTime" id="drpSendDateTime">
                        <option value="0">�ͻ�ʱ�䲻��</option>
                        <option value="1">ֻ�ڹ������ͻ���˫���ա����ղ��ͻ����ʺ��ڰ칫��ַ��</option>
                    </select>
                    <li><span>���ѣ�</span>����Ϣ��ӡ�ڿ���浥�ϣ���Ϊ��ݹ�˾�ͻ��Ĳο����ݣ�����������Ϳ��ܻ����������½⡣</li>
                </div>
            </div>
            <div class="linbg">
                <li><b>ѡ��֧����ʽ</b></li></div>
            <div style="padding: 20px;">
                <div class="ratwo">
                    <li>
                        <input type="radio" id="rdo_payonline1" name="rdoPayment" value="0" />
                        <label for="rdo_payonline1">
                            <b>����֧��</b>
                        </label>
                </div>
                <div id="PaymentDemo0" class="tabptkd">
                    <ul>
                        <li>֧�� ֧���������������ÿ������֧��</li>
>>>>>>> .r1725
                    </ul>
                </div>
                <div class="ratwo">
                    <li>
                        <input type="radio" disabled="disabled" id="rdo_payoffline2" name="rdoPayment" value="1" /><label
                            for="rdo_payoffline2">
                            <b>��������</b></label>
                        <span style="display: none; color: red;">����ѡ������ͷ�ʽ��֧�ֻ������</span></li>
                </div>
                <div id="PaymentDemo1" class="tabptkd">
                    <ul>
                        <li>�����ֵ���֧��</li>
                        <li>�����ѣ�<font id="CODTotal" size="5" color="#ff0000">������...</font>Ԫ<span style="font-size: 12px;
                            color: #ccc;">(��ʾ���˷ѵĻ���������׷�ӵķ���)</span></li>
                    </ul>
                </div>
            </div>
<<<<<<< .mine
             
			<div id="divsaveinfobtn" style=" margin-bottom:10px;">
				<div id="btnSaveReceiveAddress" class="btn_save gbpic" style="float:left; margin-right:10px;"></div>
				<li  class="btnsaver" >请确保您填写的收货人信息准确无误，否则导致您无法及时收到货物。</li>
			</div>
            </form>
            <form id="fmgotobuy" method="get"  onsubmit="return vlorderinfo(this)" action="<%=EbSite.Modules.Shop.ModuleCore.GetLinks.GoToPayUrl(GetSiteID) %>" >
				<div class="linbg"><li><B>选择配送方式</B></li></div>
				<div style="padding:20px;">
                        <asp:Repeater ID="rpPeiSong" runat="server">
                            <ItemTemplate>
                                <div class="ratwo">
                                    <li>
                                        <input type="radio" name="rdoDelivery" iscod="<%# Eval("IsCod")%>" temid="<%# Eval("ShippingTemplatesId") %>" id="radioPeiSong<%# Eval("id") %>" value="<%# Eval("id") %>" /> 
                                        <label for="radioPeiSong<%# Eval("id") %>"><B><%# Eval("ModeName")%></B>&nbsp;&nbsp; 是否支付货到付款：<font color="red"><%# Eval("IsCod").ToString() == "True"?"是":"否"%></font></label> 
                                    </li>
                                 </div>
                                <div id="DeliveryDemo<%# Eval("id") %>" class="tabptkd">
                                    <ul>
						            <li>支持物流：<%# Eval("PsCompanys")%></li>
                                    <li>详细说明：<%# Eval("Content")%></li>
                                    <li>运费计算：<font id="FreightTotal<%# Eval("id") %>" size="5" color="#ff0000">加载中...</font>元</li>
						            </ul>
=======
            <div class="linbg">
                <li><b>��Ʒ����</b></li></div>
            <div class="tablist">
                <div class="tablistone tablistbg">
                    <li class="tablist107">��Ʒ���</li>
                    <li class="tablist519">��Ʒ����</li>
                    <li class="tablist101">��������</li>
                    <li class="tablist162">�۸�</li>
                </div>
                <asp:Repeater ID="repShoppingCart" runat="server">
                    <ItemTemplate>
                        <div class="tablistone color66">
                            <li class="tablist107">
                                <%# Eval("SKU")%></li>
                            <li class="tablist519"><span><a target="_blank" href='<%# HostApi.GetContentLink(Eval("ProductId"))%>'>
                                <%# Eval("ProductName")%></a></span></li>
                            <li class="tablist101">
                                <%# Eval("Quantity") %></li>
                            <li class="tablist162">&yen;<%# Eval("TotalMemberPrice")%>
                            </li>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="tabbill">
                <div class="billleft">
                    <div>
                        <a href="javascript:void(0);" listid="listyhqid" class="otherfree">+ʹ���Żݾ�</a>
                        <li id="listyhqid" style="display: none;">
                            <%-- <select name="ddlCoupon" id="ddlCoupon">
	                            <option value="0">dsf8f8sdffsd</option>
	                            <option value="1">hdg3t4tgdgfd</option>
                            </select> --%>
                            <span class="combo" >
                                <input id="txtTick" style="width: 125px" class="combo-text validatebox-text" autocomplete="off"><span>
                                <span class="combo-arrow"  onclick="opFun()"></span></span>
                               <%-- <input class="combo-value" value="cd065e091b6c4e1" type="hidden">--%></span>
                            <input id="btnCoupon" class="youhui_btn_sub" value="ʹ���Ż�ȯ" onclick="ckTicket()" type="button">
                            <div id="yhdiv" style="z-index: 9002; border:1px; position: absolute; width: 125px; display:none; top: 725px;
                                left: 365px" class="panel ">
                               <div style="width: 120px; height: 158px" class="combo-panel panel-body panel-body-noheader " title="" >
                                    <div class="combobox-item combobox-item-selected" value="0" >��ǣ������ֲ��Ӫ  </div>
>>>>>>> .r1725
                                </div>
<<<<<<< .mine
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="tabsfkd">
							送货时间：
                          <select name="sendtime" >
	                        <option value="0">送货时间不限</option>
	                        <option value="1">只在工作日送货（双休日、假日不送货，适合于办公地址）</option>
                        </select>  							
                            <li><span>提醒：</span>此信息打印在快递面单上，作为快递公司送货的参考依据，个别地区配送可能会有延误，请谅解。</li>
					</div>
				</div>
				<div class="linbg"><li><B>选择支付方式</B></li></div>
				<div style="padding:20px;">
					<div class="ratwo">
                        <li><input type="radio" id="rdo_payonline1" name="rdoPayment" value="0"  /> <label for="rdo_payonline1"> <B >在线支付</B> </label>
                     </div>
					<div id="PaymentDemo0" class="tabptkd">
						<ul>
						<li>支持 支付宝、网银、信用卡、储蓄卡支付</li>
						</ul>				
					</div>
					<div class="ratwo">
					    <li><input  type="radio" disabled="disabled" id="rdo_payoffline2" name="rdoPayment" value="1"/><label for="rdo_payoffline2">  <B>货到付款</B></label> <span style="display:none;color:red;">（您选择的配送方式不支持货到付款）</span></li>
=======
                            </div>
                        </li>
>>>>>>> .r1725
                    </div>
<<<<<<< .mine
                    <div id="PaymentDemo1" class="tabptkd">
						<ul>
						<li>仅部分地区支持</li>
                        <li>手续费：<font id="CODTotal" size="5" color="#ff0000">加载中...</font>元<span style="font-size:12px; color:#ccc;" >(表示在运费的基础上另外追加的费用)</span></li>
						</ul>				
					</div>
				</div>
				<div class="linbg"><li><B>商品订单</B></li></div>
				<div class="tablist" >
					<div class="tablistone tablistbg">
						<li class="tablist107">商品编号</li>
						<li  class="tablist519">商品名称</li>
						<li class="tablist101">购买数量</li>
                        <li class="tablist162">价格</li>
					</div>
                    <asp:Repeater ID="repShoppingCart" runat="server">
=======
                    <asp:Repeater ID="rpOrderOptions" runat="server">
>>>>>>> .r1725
                        <ItemTemplate>
                            <div>
                                <a href="javascript:void(0);" listid="listyhqid<%# Eval("id")%>" class="otherfree">+<%# Eval("OptionName")%></a><span
                                    style="color: #ccc;">(<%# Eval("Description")%>)</span>
                                <dl id="listyhqid<%# Eval("id")%>" style="display: none;">
                                    <Shop:OrderOptions ID="optionitems" runat="server"></Shop:OrderOptions>
                                </dl>
                                <asp:Repeater ID="rpUserInput" runat="server">
                                    <ItemTemplate>
                                        <dl id="UserInput<%# Eval("id")%>" class="optionitems">
                                            <span>
                                                <%# Eval("UserInputTitle")%>:</span><span><input type="text" style="width: 350px;" /></span>
                                            <br />
                                            <span style="line-height: 20px; color: #ccc;">˵����<%# Eval("Remark")%></span>
                                        </dl>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
<<<<<<< .mine
				</div>
				<div  class="tabbill">
					<div class="billleft">
						<div >
							<a href="javascript:void(0);" listid="listyhqid"  class="otherfree" >+使用优惠卷</a>
							<li id="listyhqid" style="display:none;">
                             <select name="ddlCoupon" id="ddlCoupon">
	                            <option value="0">dsf8f8sdffsd</option>
	                            <option value="1">hdg3t4tgdgfd</option>
                            </select>                            
                            </li>
						</div>
						<asp:Repeater ID="rpOrderOptions" runat="server">
                                <ItemTemplate>
                                    <div >
                                        <a href="javascript:void(0);" listid="listyhqid<%# Eval("id")%>" class="otherfree" >+<%# Eval("OptionName")%></a><span style="color:#ccc;">(<%# Eval("Description")%>)</span>
                                        <dl id="listyhqid<%# Eval("id")%>"  style="display:none;">
                                          <Shop:OrderOptions ID="optionitems" runat=server></Shop:OrderOptions>
                                        </dl>
                                        <asp:Repeater ID="rpUserInput" runat="server">
                                            <ItemTemplate>
                                                 <dl id="UserInput<%# Eval("id")%>" class="optionitems" >
                                                    <span><%# Eval("UserInputTitle")%>:</span><span><input name="opv<%# Eval("id")%>" type="text" style="width: 350px;" /></span>
                                                    <br/>
                                                    <span style=" line-height:20px; color:#ccc;" >说明：<%# Eval("Remark")%></span>
                                                </dl>
                                             </ItemTemplate>
                                        </asp:Repeater>
                                       
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
						<div class="billtwo color66">
							<div class="billtwoline1"><li>订单留言(请不要超过300字)</li><li></div>
                            <textarea name="txtRemark" rows="2" cols="20" id="txtRemark" class="orderRemakInfo">收货信息、配送方式、支付方式等以上述选定值为准，在此备注无效</textarea>
							<br />
							<span>(如果您有其他需求，请在此填写备注，我们会尽力为您服务。)</span>
						</div>
					</div>
					<div class="billright">
						<div class="tabproinfo color66">
                           <li><div class=tabprotitle>商品数量：</div><span class=color654><asp:Literal ID="ltlCount" runat="server" EnableViewState="false"></asp:Literal></span></li>
                            <li><div class=tabprotitle>商品金额：</div><span class=color654>&yen;<asp:Literal ID="ltlTotal" runat="server" EnableViewState="false"></asp:Literal> 元</span></li>
                            <li><div class=tabprotitle>满额打折活动：</div><span class=color654>暂无</span></li>
                            <li><div class=tabprotitle>满额免费用活动：</div><span class=color654>暂无</span></li>
                            <li><div class=tabprotitle>优惠券抵扣金额：</div><span class=color654>&yen;{0} 元</span></li>
                            <li><div class=tabprotitle>运费：</div><span class=color654>&yen;<font id="ltlTrans" >...</font>元</span></li>
                            <li><div class=tabprotitle>支付手续费：</div><span class=color654>&yen;<font id="ltlShouXu" >...</font>元</span></li>
                            <li><div class=tabprotitle>订单选项费用：</div><span class=color654>&yen;{0} 元</span></li>
                            <li style=margin-top:5px;><div class=tabprotitle><span class=tabpro_1>订单总价格：</span></div>
                            <span class=tabpro_1>&yen;<font id="ltlsummoney" >...</font> 元</span></li>
                            <div style='margin-top:-5px;float:left; width:130px;'><font color=#FF0000 style=margin-left:20px;>(可得积分：{0}分)</font></div>
                            <input type="submit" name="btnSaveOrder" value="" id="btnSaveOrder" class="btnsave" />
						</div>	
					</div>
				</div>
                <input id="optionitemids" name="optionitemids" type="hidden" runat="server" />
                
         </form>
        
				<div class="clear"></div>
		<div class="linbg" style="border-bottom:none"></div>
		</div>
        
	</div>
    
<!--footer--->
<div class="clear"></div>
<div class="footer">
   <div class="container">
 

=======
                    <div class="billtwo color66">
                        <div class="billtwoline1">
                            <li>��������(�벻Ҫ����300��)</li><li>
                        </div>
                        <textarea name="txtRemark" rows="2" cols="20" id="txtRemark" class="orderRemakInfo">�ջ���Ϣ�����ͷ�ʽ��֧����ʽ��������ѡ��ֵΪ׼���ڴ˱�ע��Ч</textarea>
                        <br />
                        <span>(������������������ڴ���д��ע�����ǻᾡ��Ϊ������)</span>
                    </div>
                </div>
                <div class="billright">
                    <div class="tabproinfo color66">
                        <li>
                            <div class="tabprotitle">
                                ��Ʒ������</div>
                            <span class="color654">
                                <asp:Literal ID="ltlCount" runat="server" EnableViewState="false"></asp:Literal></span></li>
                        <li>
                            <div class="tabprotitle">
                                ��Ʒ��</div>
                            <span class="color654">&yen;<asp:Literal ID="ltlTotal" runat="server" EnableViewState="false"></asp:Literal>
                                Ԫ</span></li>
                        <li>
                            <div class="tabprotitle">
                                ������ۻ��</div>
                            <span class="color654">����</span></li>
                        <li>
                            <div class="tabprotitle">
                                ��������û��</div>
                            <span class="color654">����</span></li>
                        <li>
                            <div class="tabprotitle">
                                �Ż�ȯ�ֿ۽�</div>
                            <span class="color654">&yen;<font id="ltlTicket">0.00</font> Ԫ</span></li>
                        <li>
                            <div class="tabprotitle">
                                �˷ѣ�</div>
                            <span class="color654">&yen;<font id="ltlTrans">0.00</font>Ԫ</span></li>
                        <li>
                            <div class="tabprotitle">
                                ֧�������ѣ�</div>
                            <span class="color654">&yen;<font id="ltlShouXu">0.00</font>Ԫ</span></li>
                        <li>
                            <div class="tabprotitle">
                                ����ѡ����ã�</div>
                            <span class="color654">&yen;0.00 Ԫ</span></li>
                        <li style="margin-top: 5px;">
                            <div class="tabprotitle">
                                <span class="tabpro_1">�����ܼ۸�</span></div>
                            <span class="tabpro_1">&yen;<font id="ltlsummoney">0.00</font> Ԫ</span></li>
                        <div style='margin-top: -5px; float: left; width: 130px;'>
                            <font color="#FF0000" style="margin-left: 20px;">(�ɵû��֣�{0}��)</font></div>
                        <input type="submit" name="btnSaveOrder" value="" id="btnSaveOrder" class="btnsave" />
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="linbg" style="border-bottom: none">
            </div>
        </div>
    </div>
>>>>>>> .r1725
	 <div class="clear"></div>
      <div class="youlian copy" style=" margin-top:15px;">
         <%=EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.Copyright %>
      </div>
	 
	 
      
   </div>
</div>

<!--footer--->
    <script>

        var alReceiveAreaListID = "alReceiveAreaList", hfReceiveAreaValueID = "alReceiveAreaList_hfValue", hfReceiveValueParentIDs = "alReceiveAreaList_hfValueP", alcObj = objal_alReceiveAreaList;
        //购物车里的商品重量，克
        var sumweight = <%=TotalWeight %>;
        var summoney=<%=TotalMoney %>;
    </script>
    <script type="text/javascript" src="<% =ThemePage%>mshoppingcar2.js"></script>
</body>
</html>
