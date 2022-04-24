<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ad3GoodsType.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.GoodsManage.Ad3GoodsType" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<link type="text/css" href="../css/index.css" rel="stylesheet" />
<DIV class="Steps Pg_45"><UL>
<LI class="fui">第一步：添加类型名称 </LI>
<LI class="iocns "></LI>
<LI class="fui">第二步：添加扩展属性 </LI>
<LI class="iocns "></LI>
<LI class="huang">第三步：添加规格 </LI></UL></DIV>

<div id="tg2">
    <XS:Notes ID="Notes3" Text="商品类型是一系属性的组合，可以用来向顾客展示某些商品具有的特有的属性，一个商品类型下可添加多种属性.一种是供客户查看的扩展属性,如图书类型商品的作者，出版社等，一种是供客户可选的规格,如服装类型商品的颜色、尺码。"
        runat="server"></XS:Notes>
    <div>
        <table id="tablist" width="900">
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
                    <th style="width:150px;">
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
                           规格名[<%#Equals(Eval("isimg"),0)?"文字":"图"%>]： 
                            <input type="text" id="txt_pj_sku_<%# Eval("id") %>" name="pjname" class="TextBoxDefault"
                                style="width: 100px;" value='<%# Eval("NormsName") %>' isinit="0" />
                            <a href="javascript:void(0);" onclick="EditValueSku(<%# Eval("id") %>)">修改</a>
                        </td>
                        <td>
                     <%#GetProValue(int.Parse(Eval("id").ToString()), Eval("isimg").ToString())%>       
                        </td>
                        <td>
                            <%# Eval("orderid")%>
                        </td>
                        <td>
                           <a href="javascript:void(0)" onclick="ShowAddSKUValueDiv(<%# Eval("id") %>,<%#Eval("isimg")%>)" > 添加规格值</a> <a href="GoodsManage.aspx?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=9&attributeid=<%#Eval("id") %>&isimg=<%#Eval("isimg") %>">编辑</a>  <a href="javascript:void(0);" onclick="delTypeName(<%# Eval("id") %>) ">删除</a>
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
<input type="button" class="AdminButton" onclick="ShowAttribute()" value="添加新规格 " />
<div id="layerArea" class="layerArea" style="z-index: 99999; position: absolute;
    display: none; margin-left: 10px; width:350px; height:190px;">
    <div class="closeBotton">
        <a style="cursor: pointer" onclick="closeLayerArea()">×</a>
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
                <div style="text-align: center; padding: 10px; display: none;">
                    <XS:Button ID="bntSave" Text=" 添加111" runat="server"  />
                </div>
                 <div style="text-align: center; padding: 10px; border: 1px solid #ccc; width: 100px;
                            background: #ddd; margin: 0 auto 0 auto;">
                            <a href="#" onclick="addNormsNameJs()">添加</a>
                        </div>
                <div style="text-align: center; padding: 10px; display:none;">
                    <XS:Button ID="addType" Text=" 添加" runat="server" OnClick="addNormsName_Click" />
                </div>
            </td>
        </tr>
    </table>
</div>
<div id="AddProValue" class="layerArea" style="z-index: 99999; position: absolute;
    display: none; margin-left: 10px; height:130px; width:330px;">
    <div class="closeBotton">
        <a style="cursor: pointer" onclick="closeAddProValue()">×</a>
    </div>
    <table>
        <tr>
            <td>
                规格值名：
            </td>
            <td>
                <XS:TextBox Width="200" runat="server" onkeydown="javascript:this.value=this.value.replace('，',',')"
                    ToolTip="多个规格值可用“,”号隔开，每个值的字符数最多15个字符。" ID="TbProName">
                </XS:TextBox>
                <asp:HiddenField ID="TbProPid" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
              <div style="text-align: center; padding: 10px; border: 1px solid #ccc; width: 100px;
                            background: #ddd; margin: 0 auto 0 auto;">
                            <a href="#" onclick="btnAddPro3_ClickJs()">添加</a>
                        </div>
                <div style="text-align: center; padding: 10px; display:none;">
                    <XS:Button ID="btnAddPro" Text=" 添加" runat="server" OnClick="btnAddPro_Click" />
                </div>
            </td>
        </tr>
    </table>
</div>

<div id="addSKUValue" class="layerArea" style="z-index: 99999; position: absolute;
    display: none; margin-left: 10px; height:200px; width:430px;">
    <div class="closeBotton">
        <a style="cursor: pointer" onclick="closeAddSKUValue()">×</a>
    </div>
    <table>
        <tr>
            <td>
                图片地址：
            </td>
            <td>
                <XS:SWFUpload ID="fileUpLoad" SaveFolder="/themes/shop/data/Upload"  AllowExt ="jpg,gif,png" runat="server" />55*55
               
            </td>
        </tr>
        <tr>
            <td>
                图片描述：
            </td>
            <td>
                <XS:TextBox Width="200" runat="server"  ID="PicDescription"> </XS:TextBox>
               
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="text-align: center; padding: 10px;">
                    <XS:Button ID="Button1" Text=" 添加" runat="server" OnClick="btnAddSKU_Click" />
                </div>
            </td>
        </tr>
    </table>
</div>
<A onclick=javascript:history.go(-1);>返回</A>
<script>
    function delTypeName(obj) {
        if (confirm('确定要执行该删除操作吗？删除后将不可以恢复！')) {
            var params = { "id": obj };
            runws("DelNorms", params, null);
            Refesh();
        }
    }

    function ShowAddSKUValueDiv(attributeId, useAttributeImage) {

        if (useAttributeImage == "0") {
            $("#AddProValue").css("display", "block");
        }
        else {
            $("#addSKUValue").css("display", "block");
        }
        $("#<%=TbProPid.ClientID %>").val(attributeId);
    }
    function closeAddProValue() {
        $("#AddProValue").css("display", "none");
    }

    function deleteAttributeValue(obj, valueId) {
        var params = { "id": valueId };
        runws("DelNormsValue", params, null);
        Refesh();
        //location.reload() return 
    }


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
//    function EditValue(obj) {
//        var n = $("#txt_pj_" + obj).val();
//        var params = { "id": obj, "name": n };
//        runws("EditNorms", params, null);
//    }
    function ShowAttribute() {
        $("#layerArea").css("display", "block");
    }
    function closeLayerArea() {
        $("#layerArea").css("display", "none");

    }
    function closeAddSKUValue() {
        $("#addSKUValue").css("display", "none");
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
        var name = $("#<%=TbProName.ClientID %>").val();
        if (name == "") {
            alert("请添写规格名称");
            $("#<%=TbProName.ClientID %>").focus();
            return false;
        }
        $("#<%=btnAddPro.ClientID %>").click();
    }
</script>
