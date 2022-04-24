<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditGoodsType.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.EditGoodsType" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<link type="text/css" href="../css/index.css" rel="stylesheet" />
<style>
    #tablist
    {
        width: 900px;
        padding: 0;
        margin: 0;
    }
    th
    {
        color: #4f6b72;
        letter-spacing: 2px;
        text-transform: uppercase;
        text-align: left;
        padding: 6px 6px 6px 12px;
        background: #CAE8EA no-repeat;
    }
    td
    {
        background: #fff;
        font-size: 11px;
        padding: 6px 6px 6px 12px;
        color: #4f6b72;
    }
</style>
<div style="padding-left: 10px;">
    <XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>
    <asp:PlaceHolder ID="phCtrList" runat="server">
        <div id="tg1">
            <table>
                <tr>
                    <td>
                        商品类型名称:
                    </td>
                    <td>
                        <XS:TextBox Width="150" runat="server" ID="TypeName" IsAllowNull="false" HintInfo="长度限制在1-30个字符之间">
                        </XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        排序编号:
                    </td>
                    <td>
                        <XS:TextBox Width="150" runat="server" ID="OrderID" IsAllowNull="false">
                        </XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        关联品牌:
                    </td>
                    <td>
                        <XS:CheckBoxList ID="tx_BrandIDs" Width="750" runat="server" RepeatDirection="Horizontal">
                        </XS:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        是否关联专题:
                    </td>
                    <td>
                        <asp:CheckBox ID="Ck_IsSpecial" runat="server" />关联专题 在检索时会出现专题的检索条件【只出现包含此分类内容的专题】。选择专题-添加内容，把产品添加到相应的专题中。
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <XS:Button ID="EditType" OnClick="EditType_Click" Text=" 保存" runat="server" />
                        <%--<input type="button" class="AdminButton" onclick="GoTwo()" value="下一步 " />--%>
                    </td>
                </tr>
            </table>
        </div>
    </asp:PlaceHolder>
    <div id="tg2">
        <XS:Notes ID="Notes3" Text="商品类型是一系属性的组合，可以用来向顾客展示某些商品具有的特有的属性，一个商品类型下可添加多种属性.一种是供客户查看的扩展属性,如图书类型商品的作者，出版社等，一种是供客户可选的规格,如服装类型商品的颜色、尺码。"
            runat="server"></XS:Notes>
        <div>
            <table id="tablist">
                <thead>
                    <tr>
                        <th>
                            属性名称
                        </th>
                        <th style="width: 70px;">
                            支持多选
                        </th>
                         <th style="width: 70px;">
                            是否支持检索
                        </th>
                        <th style="width: 400px;">
                            属性值
                        </th>
                        <th>
                            排序
                        </th>
                        <th style="width: 120px;">
                            操作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="DataList" runat="server">
                    <HeaderTemplate>
                        <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id='<%# Eval("id") %>'>
                            <td width="150px">
                                <input type="text" id="txt_pj_<%# Eval("id") %>" name="pjname" class="TextBoxDefault"
                                    style="width: 100px;" value='<%# Eval("ValueName") %>' isinit="0" />
                                <a href="javascript:void(0);" onclick="EditValue(<%# Eval("id") %>)">修改</a>
                            </td>
                            <td>
                                <a href="javascript:void(0);" onclick="EditMoreSel(<%# Eval("id") %>)"><span id="tmore_<%# Eval("id") %>">
                                    <%#Equals(Eval("IsMoreSel").ToString(),"0")?"否":"是"%></span> </a>
                            </td>
                             <td>
                                <a href="javascript:void(0);" onclick="EditSele(<%# Eval("id") %>)"><span id="tsele_<%# Eval("id") %>">
                                    <%#Equals(Eval("IsSele").ToString(), "0") ? "否" : "是"%></span> </a>
                            </td>
                            <td>
                                <%#GetProValue(int.Parse(Eval("id").ToString()))%>
                            </td>
                            <td>
                                <%# Eval("orderid")%>
                            </td>
                            <td>
                                <a href="javascript:void(0)" onclick="addProValue(<%# Eval("id") %>)">添加属性</a> <a
                                    href="GoodsManage.aspx?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=6&attributeid=<%#Eval("id") %>">
                                    编辑</a> <a href="javascript:void(0);" onclick="delTypeName(<%# Eval("id") %>) ">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
        </div>
        <input type="button" class="AdminButton" onclick="ShowAttribute()" value="添加扩展属性 " />
        <div id="layerArea" class="layerArea" style="z-index: 99999; position: absolute;
            display: none; margin-left: 10px; height: 315px; width: 540px;">
            <div class="closeBotton">
                <a style="cursor: pointer" onclick="closeLayerArea()">×</a>
            </div>
            <table>
                <tr>
                    <td>
                        属性名称：
                    </td>
                    <td>
                        <XS:TextBox Width="390" runat="server" ToolTip="扩展属性的名称，最多15个字符。" ID="txt_ValueName">
                        </XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        排序编号:
                    </td>
                    <td>
                        <XS:TextBox Width="150" runat="server" ID="txt_OrderID" IsAllowNull="false">
                        </XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        能否检索:
                    </td>
                    <td>
                        <XS:CheckBox ID="txt_IsSele" runat="server" ToolTip="是否可能在前台分类里检索，如果检索红色,产品." />
                    </td>
                </tr>
                <tr>
                    <td>
                        是否支持多选：
                    </td>
                    <td>
                        <XS:CheckBox ID="txt_IsMoreSel" runat="server" ToolTip="属性值录入方式.在后台展示为单选(下拉)，或多选两种." />
                        支持多选
                    </td>
                </tr>
                <tr>
                    <td>
                        属性值：
                    </td>
                    <td>
                        <XS:TextBox Width="390" runat="server" onkeydown="javascript:this.value=this.value.replace('，',',')"
                            ToolTip="有些属性是可以选择多个属性值的，如“适合人群”，就可能既适合老年人也适合中年人。" ID="txt_DefaultValues">
                        </XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center; padding: 10px; border: 1px solid #ccc; width: 100px;
                            background: #ddd; margin: 0 auto 0 auto;">
                            <a href="#" onclick="addType_ClickJs()">添加</a>
                        </div>
                        <div style="text-align: center; padding: 10px; display: none;">
                            <XS:Button ID="addTypeID" Text=" 添加" runat="server" OnClick="addType_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="AddProValue" class="layerArea" style="z-index: 99999; position: absolute;
            display: none; margin-left: 10px; height: 130px; width: 300px;">
            <div class="closeBotton">
                <a style="cursor: pointer" onclick="closeAddProValue()">×</a>
            </div>
            <table>
                <tr>
                    <td>
                        属性值：
                    </td>
                    <td>
                        <XS:TextBox Width="200" runat="server" onkeydown="javascript:this.value=this.value.replace('，',',')"
                            ToolTip="有些属性是可以选择多个属性值的，如“适合人群”，就可能既适合老年人也适合中年人。" ID="TbProName">
                        </XS:TextBox>
                        <asp:HiddenField ID="TbProPid" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center; padding: 10px; border: 1px solid #ccc; width: 100px;
                            background: #ddd; margin: 0 auto 0 auto;">
                            <a href="#" onclick="addPro_ClickJs()">添加</a>
                        </div>
                        <div style="text-align: center; padding: 10px; display: none;">
                            <XS:Button ID="btnAddPro" Text=" 添加" runat="server" OnClick="btnAddPro_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="tg3">
        <XS:Notes ID="Notes2" Text="内容模型与内容模板是尖对当前分类下的内容而设置，添加内容时会默认使用此设置,更改分类模型需要重新打开此页面载入模型"
            runat="server"></XS:Notes>
        <div>
            <table id="Table1" width="900">
                <thead>
                    <tr>
                        <th>
                            规格名称
                        </th>
                        <th>
                            规格值
                        </th>
                        <th>
                            排序
                        </th>
                        <th style="width: 150px;">
                            操作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="RepPro" runat="server">
                    <HeaderTemplate>
                        <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id='<%# Eval("id") %>'>
                            <td width="150px">
                                规格名[<%#Equals(Eval("isimg"),0)?"文字":"图"%>]：
                                <input type="text" id="txt_pj_sku_<%# Eval("id") %>" name="pjname" class="TextBoxDefault"
                                    style="width: 100px;" value='<%# Eval("NormsName") %>' isinit="0" />
                                <a href="javascript:void(0);" onclick="EditValueSku(<%# Eval("id") %>)">修改</a>
                            </td>
                            <td>
                                <%#GetProValue3(int.Parse(Eval("id").ToString()), Eval("isimg").ToString())%>
                            </td>
                            <td>
                                <%# Eval("orderid")%>
                            </td>
                            <td>
                                <a href="javascript:void(0)" onclick="ShowAddSKUValueDiv(<%# Eval("id") %>,<%#Eval("isimg")%>)">
                                    添加规格值</a> <a href="GoodsManage.aspx?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=9&attributeid=<%#Eval("id") %>&isimg=<%#Eval("isimg") %>">
                                        编辑</a> <a href="javascript:void(0);" onclick="delTypeName3(<%# Eval("id") %>) ">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
        </div>
        <input type="button" class="AdminButton" onclick="ShowAttribute3()" value="添加新规格 " />
        <div id="layerArea3" class="layerArea" style="z-index: 99999; position: absolute;
            display: none; margin-left: 10px; width: 270px; height: 200px;">
            <div class="closeBotton">
                <a style="cursor: pointer" onclick="closeLayerArea3()">×</a>
            </div>
            <table>
                <tr>
                    <td>
                        规格名称：
                    </td>
                    <td>
                        <XS:TextBox Width="120" runat="server" ToolTip="扩展属性的名称，最多15个字符。" ID="txt_NormsName">
                        </XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        显示类型：
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="RaIsImg" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Selected="True"> 文字</asp:ListItem>
                            <asp:ListItem Value="1"> 图片</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center; padding: 10px; border: 1px solid #ccc; width: 100px;
                            background: #ddd; margin: 0 auto 0 auto;">
                            <a href="#" onclick="addNormsNameJs()">添加</a>
                        </div>
                        <div style="text-align: center; padding: 10px; display: none;">
                            <XS:Button ID="addType" Text=" 添加" runat="server" OnClick="addNormsName_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="AddProValue3" class="layerArea" style="z-index: 99999; position: absolute;
            display: none; margin-left: 10px; height: 130px; width: 330px;">
            <div class="closeBotton">
                <a style="cursor: pointer" onclick="closeAddProValue3()">×</a>
            </div>
            <table>
                <tr>
                    <td>
                        规格值名：
                    </td>
                    <td>
                        <XS:TextBox Width="200" runat="server" onkeydown="javascript:this.value=this.value.replace('，',',')"
                            ToolTip="多个规格值可用“,”号隔开，每个值的字符数最多15个字符。" ID="TextBox1">
                        </XS:TextBox>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center; padding: 10px; border: 1px solid #ccc; width: 100px;
                            background: #ddd; margin: 0 auto 0 auto;">
                            <a href="#" onclick="btnAddPro3_ClickJs()">添加</a>
                        </div>
                        <div style="text-align: center; padding: 10px; display: none;">
                            <XS:Button ID="btnAddPro3" Text=" 添加" runat="server" OnClick="btnAddPro3_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="addSKUValue" class="layerArea" style="z-index: 99999; position: absolute;
            display: none; margin-left: 10px; height: 190px; width: 430px;">
            <div class="closeBotton">
                <a style="cursor: pointer" onclick="closeAddSKUValue()">×</a>
            </div>
            <table>
                <tr>
                    <td>
                        图片地址：
                    </td>
                    <td>
                        <XS:SWFUpload ID="fileUpLoad" SaveFolder="/themes/shop/data/Upload" AllowExt="jpg,gif,png"
                            runat="server" />55*55
                    </td>
                </tr>
                <tr>
                    <td>
                        图片描述：
                    </td>
                    <td>
                        <XS:TextBox Width="200" runat="server" ID="PicDescription"> </XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center; padding: 10px;">
                            <XS:Button ID="Button5" Text=" 添加" runat="server" OnClick="btnAddSKU_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Literal ID="llTagEnd" runat="server"></asp:Literal>
</div>
<div style="text-align: center; padding: 10px; display: none;">
    <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
</div>
<script>
    //自动放大
    $(window.parent.document.body).find("div[class='panel-tool-max']").click();

    // 修改 规格
    function EditValueSku(obj) {
        var n = $("#txt_pj_sku_" + obj).val();
        var params = { "id": obj, "name": n };
        runws("EditSkuValue", params, function (result) {
            if (result.d) {
                tips("修改成功！", 1);
            }
        });
    }
    //修改 属性
    function EditValue(obj) {
        var n = $("#txt_pj_" + obj).val();
        var params = { "id": obj, "name": n };
        runws("EditTypeNameValue", params, function (result) {
            if (result.d) {
                tips("修改成功！", 1);
            }
        });
    }
    // 修改 是否多选
    function EditMoreSel(obj) {
        var params = { "id": obj };
        runws("EditMoreSelValue", params, null);

        if ($("#tmore_" + obj).html() == "是") {
            $("#tmore_" + obj).html("否");
        }
        else {
            $("#tmore_" + obj).html("是");
        }
    }

    // 修改 是否支持 检索
    function EditSele(obj) {
        var params = { "id": obj };
        runws("EditSeleValue", params, null);

        if ($("#tsele_" + obj).html() == "是") {
            $("#tsele_" + obj).html("否");
        }
        else {
            $("#tsele_" + obj).html("是");
        }
    }

    function deleteAttributeValue(obj, valueId) {
        var params = { "id": valueId };
        runws("DelProValue", params, function (result) {
            if (result.d) {
                tips("删除成功！", 1);
                Refesh();
                Tags_CustomDataTable.InitOnclick(1);  // =========================================================================刷新 有问题
            }
        });
    }

    function delTypeName(obj) {
        if (confirm('确定要执行该删除操作吗？删除后将不可以恢复！')) {
            var params = { "id": obj };
            runws("DelTypeNameValue", params, null);
            Refesh();
            Tags_CustomDataTable.InitOnclick(1);  //===================================================不能正确定位tab
        }
    }
    function ShowAttribute() {
        $("#layerArea").css("display", "block");
    }
    function closeLayerArea() {
        $("#layerArea").css("display", "none");

    }

    function closeAddProValue3() {
        $("#AddProValue3").css("display", "none");
    }
    function addProValue(obj) {
        $("#AddProValue").css("display", "block");

        $("#<%=TbProPid.ClientID %>").val(obj);
    }
    function closeAddProValue() {
        $("#AddProValue").css("display", "none");
    }
    function ShowAttribute3() {
        $("#layerArea3").css("display", "block");
    }
    function closeLayerArea3() {
        $("#layerArea3").css("display", "none");

    }

    function ShowAddSKUValueDiv(attributeId, useAttributeImage) {

        if (useAttributeImage == "0") {
            $("#AddProValue3").css("display", "block");
        }
        else {
            $("#addSKUValue").css("display", "block");
        }
        $("#<%=TbProPid.ClientID %>").val(attributeId);
    }
    function closeAddSKUValue() {
        $("#addSKUValue").css("display", "none");
    }
    function deleteAttributeValue3(obj, valueId) {
        var params = { "id": valueId };
        runws("DelNormsValue", params, null);
        Refesh();
        //location.reload() return 
    }
    function delTypeName3(obj) {
        if (confirm('确定要执行该删除操作吗？删除后将不可以恢复！')) {
            var params = { "id": obj };
            runws("DelNorms", params, null);
            Refesh();
        }
    }

    function ShowTag(obj) {
        Tags_CustomDataTable.InitOnclick(obj);
    }
    //添加 扩展属性 多个
    function addType_ClickJs() {

        var name = $("#<%=txt_ValueName.ClientID %>").val();
        if (name == "") {
            alert("请添写属性名称");
            $("#<%=txt_ValueName.ClientID %>").focus();
            return false;
        }
        var oid = $("#<%=txt_OrderID.ClientID %>").val();
        if (oid == "") {
            alert("请添写排序号");
            $("#<%=txt_OrderID.ClientID %>").focus();
            return false;
        }
        var val = $("#<%=txt_DefaultValues.ClientID %>").val();
        if (val == "") {
            alert("请添写属性值");
            $("#<%=txt_DefaultValues.ClientID %>").focus();
            return false;
        }
        $("#<%=addTypeID.ClientID %>").click();
    }

    //添加扩展 单个
    function addPro_ClickJs() {
        var name = $("#<%=TbProName.ClientID %>").val();
        if (name == "") {
            alert("请添写属性名称");
            $("#<%=TbProName.ClientID %>").focus();
            return false;
        }
        $("#<%=btnAddPro.ClientID %>").click();
    }
    //添加规格
    function addNormsNameJs() {
        var name = $("#<%=txt_NormsName.ClientID %>").val();
        if (name == "") {
            alert("请添写规格名称");
            $("#<%=txt_NormsName.ClientID %>").focus();
            return false;
        }

        $("#<%=addType.ClientID %>").click();
    }
    //添加 文字规格
    function btnAddPro3_ClickJs() {
        var name = $("#<%=TextBox1.ClientID %>").val();
        if (name == "") {
            alert("请添写规格名称");
            $("#<%=TextBox1.ClientID %>").focus();
            return false;
        }
        $("#<%=btnAddPro3.ClientID %>").click();
    }
</script>
