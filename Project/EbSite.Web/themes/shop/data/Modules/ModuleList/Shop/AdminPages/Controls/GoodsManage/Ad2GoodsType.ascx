<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ad2GoodsType.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.Ad2GoodsType" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="../css/index.css" rel="stylesheet" />
<div class="Steps Pg_45">
    <ul>
        <li class="fui">第一步：添加类型名称 </li>
        <li class="iocns "></li>
        <li class="huang">第二步：添加扩展属性 </li>
        <li class="iocns "></li>
        <li class="fui">第三步：添加规格 </li>
    </ul>
</div>
<div id="tg2">
    <XS:Notes ID="Notes3" Text="商品类型是一系属性的组合，可以用来向顾客展示某些商品具有的特有的属性，一个商品类型下可添加多种属性.一种是供客户查看的扩展属性,如图书类型商品的作者，出版社等，一种是供客户可选的规格,如服装类型商品的颜色、尺码。"
        runat="server"></XS:Notes>
    <div>
        <table id="tablist" style="width: 1200px;">
            <thead>
                <tr>
                    <th>
                        属性名称
                    </th>
                    <th>
                        支持多选
                    </th>
                     <th>
                        是否支持检索
                    </th>
                    <th>
                        属性值
                    </th>
                    <th>
                        排序
                    </th>
                    <th>
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
                        <td width="150">
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
</div>
<input type="button" class="AdminButton" onclick="ShowAttribute()" value="添加扩展属性 " />
<div id="layerArea" class="layerArea" style="z-index: 99999; position: absolute;
    display: none; margin-left: 10px;">
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
                <div style="text-align: center; padding: 10px; display: none;">
                    <XS:Button ID="bntSave" Text=" 添加111" runat="server" />
                </div>
                <div style="text-align: center; padding: 10px; border: 1px solid #ccc; width: 100px;
                    background: #ddd; margin: 0 auto 0 auto;">
                    <a href="#" onclick="addType_ClickJs()">添加</a>
                </div>
                <div style="text-align: center; padding: 10px; display: none;">
                    <XS:Button ID="addType" Text=" 添加" runat="server" OnClick="addType_Click" />
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
                <div style="text-align: center; padding: 10px; display:none;">
                    <XS:Button ID="btnAddPro" Text=" 添加" runat="server" OnClick="btnAddPro_Click" />
                </div>
            </td>
        </tr>
    </table>
</div>
<div>
    <XS:Button ID="GoThree" Text=" 下一步" runat="server" OnClick="GoThree_Click" />
     <A onclick=javascript:history.go(-1);>返回</A>
</div>
<script>
    function EditValue(obj) {
        var n = $("#txt_pj_" + obj).val();
        var params = { "id": obj, "name": n };
     
        runws("EditTypeNameValue", params, function (result) {
            if (result.d) {
                tips("修改成功！", 1);
            }
        });
    }
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
        runws("DelProValue", params, null);
        Refesh();
        //location.reload() return 
    }

    function delTypeName(obj) {
        if (confirm('确定要执行该删除操作吗？删除后将不可以恢复！')) {
            var params = { "id": obj };
            runws("DelTypeNameValue", params, null);
            Refesh();
        }
    }
    function ShowAttribute() {
        $("#<%=txt_ValueName.ClientID %>").val("");
        $("#layerArea").css("display", "block");
    }
    function closeLayerArea() {
        $("#layerArea").css("display", "none");

    }
    function addProValue(obj) {
        $("#AddProValue").css("display", "block");

        $("#<%=TbProPid.ClientID %>").val(obj);
    }
    function closeAddProValue() {
        $("#AddProValue").css("display", "none");
    }
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
        $("#<%=addType.ClientID %>").click();
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
</script>
