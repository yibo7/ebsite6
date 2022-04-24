<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.TemAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<script type="text/javascript">

    $(document).ready(function () {
        //自动放大
        $(window.parent.document.body).find("div[class='panel-tool-max']").click();
        $("#btnAddRow").click(function () {
            $("#arDiv").show();
            var $lastTrID = $("#tablist").children("tbody").children("tr").last().attr("id");
            if ($lastTrID != "" && $lastTrID != undefined) {
                $lastTrID = parseInt($lastTrID) + 1;
            }
            else {
                var $tmpList = GetPjList();
                $lastTrID = $tmpList.length + 1;
            }
            $("#tablist").children("tbody").append(CreateElement($lastTrID));
        });
    })
    //获取配件列表
    function GetPjList() {
        return $("#tablist").children("tbody").children("tr");
    }
    //创建元素
    function CreateElement(index) {
        var rowhtml = "<tr id=\"" + index + "\" ttid=\"\" ><td width=\"300px\"><input type=\"text\" id=\"txt_pj_" + index + "\" sID=\"txt_pjIDS_" + +index + "\" name=\"txt_pj_" + index + "\"  autocomplete=\"off\" style=\"width:250px;\" class=\"TextBoxDefault\" isinit=\"0\" onclick=\"checkexBox(this)\" />";
        rowhtml += "<input type=\"text\" id=\"txt_pjIDS_" + index + "\" name=\"txt_pjIDS_" + index + "\"  autocomplete=\"off\" style=\"width:30px;display:none;\" class=\"TextBoxDefault\" isinit=\"0\"  />";
        rowhtml += "</td><td><input type=\"text\"  id=\"txt_regionprice_" + index + "\ id=\"txt_regionprice_" + index + "\  class=\"TextBoxDefault\" style=\"width:50px;\" /></td>";
        rowhtml += "<td><input type=\"text\" name=\"txt_addprice_" + index + "\ id=\"txt_addprice_" + index + "\  class=\"TextBoxDefault\" style=\"width:50px;\" /></td>";
        rowhtml += "<td><input type=\"text\" name=\"txt_fullprice_" + index + "\ id=\"txt_fullprice_" + index + "\ class=\"TextBoxDefault\" style=\"width:50px;\" /></td>";
        rowhtml += "<td><a href=\"javascript:void(0);\" pjid=\"0\" onclick=\"DeleteRow(this)\">删除</a></td></tr>";
        return rowhtml;
    }

    //删除一行数据
    function DeleteRow(obj) {
        if (window.confirm("是否要删除?")) {
            var isDelete = $(obj).attr("pjid") == "0" ? true : false;

            var id = $(obj).attr("id");
            if (isDelete) {
                //删除DOM元素
                $(obj).parent("td").parent("tr").remove();
                var prams = { "id": id };
                runebws("DelPeiSongAreaPrice", prams, null);

            }
        }
    }

    var curentShipperId;
    var curentShipperIdIDS;
    //反选部分;
    function checkexBox(thisObject) {

        curentShipperId = thisObject.id;
        curentShipperIdIDS = thisObject.sID;
        var txtBoxValue = new Array();
        var areaItemsValue = new Array();
        var checkedItems = new Array();
        txtBoxValue = thisObject.value.split(",");
        $_getID("layerArea").style.display = "block";


    }
    function displayAreaLayer(thisInputBoxID) {
        $_getID("layerArea").style.top = getTop(thisInputBoxID) + 25 + "px";
        $_getID("layerArea").style.left = getLeft(thisInputBoxID) - 200 + "px";
        $_getID("layerArea").style.display = "block";
    }
    function getTop(e) {
        var offset = e.offsetTop;
        if (e.offsetParent != null) offset += getTop(e.offsetParent);
        return offset;
    }
    function getLeft(e) {
        var offset = e.offsetLeft + 15;
        if (e.offsetParent != null) offset += getLeft(e.offsetParent);
        return offset;
    }

    function $_getID(id) {
        return document.getElementById(id);
    }
    function closeLayerArea() {
        $_getID("layerArea").style.display = "none";
    }

</script>
<style>
    #tablist
    {
        width: 700px;
        padding: 0;
        margin: 0;
    }
    
    th
    {
        font: bold 11px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
        color: #4f6b72;
        border-right: 1px solid #C1DAD7;
        border-bottom: 1px solid #C1DAD7;
        border-top: 1px solid #C1DAD7;
        letter-spacing: 2px;
        text-transform: uppercase;
        text-align: left;
        padding: 6px 6px 6px 12px;
        background: #CAE8EA no-repeat;
    }
    td
    {
        border: 1px solid #C1DAD7;
        background: #fff;
        font-size: 11px;
        padding: 6px 6px 6px 12px;
        color: #4f6b72;
    }
    
    .layerArea
    {
        z-index: 1001;
        border-bottom: #ccc 1px solid;
        position: absolute;
        border-left: #ccc 1px solid;
        margin-top: -220px;
        width: 480px;
        background: #f2f2f2;
        height: 200px;
        margin-left: -200px;
        border-top: #ccc 1px solid;
        border-right: #ccc 1px solid;
        top: 50%;
        left: 50%;
    }
    .layerArea .closeBotton
    {
        text-align: right;
        padding-right: 10px;
        clear: both;
    }
    .layerArea .areaItems
    {
        padding-left: 10px;
        width: 480px;
        height: 50px;
        clear: both;
    }
    .layerArea .areaItems UL LI
    {
        width: 70px;
        float: left;
    }
    .layerArea .lines
    {
        border-bottom: #ccc 1px solid;
        margin: 10px;
        height: 2px;
    }
    .layerArea .mainCheckBoxList
    {
        margin-left: 10px;
    }
    .layerArea .mainCheckBoxList UL LI
    {
        width: 142px;
        float: left;
    }
    .layerArea .submitTj
    {
        text-align: right;
        padding-bottom: 10px;
        margin: 0px auto;
        padding-left: 10px;
        width: 450px;
        padding-right: 10px;
        clear: both;
        padding-top: 12px;
    }
</style>

<asp:PlaceHolder ID="phCtrList" runat="server">
    
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改运费模板</h3>
            </div>
            <div class="content">
				  <table>
                    <tr>
                        <td>
                            模板名称:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="TemplateName" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                            <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            起步重量:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="StartWeight" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>(克)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            加价重量:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="AddWeight" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>(克)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            默认起步价
                        </td>
                        <td>
                            <XS:TextBoxVl ID="StartPrice" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>(元)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            默认加价:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="AddPrice" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>(元)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            地区价格：
                        </td>
                        <td>
                            <a href="javascript:void(0);" id="btnAddRow">点击添加地区价格</a>
                        </td>
                    </tr>
                    <tr id="arDiv">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <div>
                                <table id="tablist">
                                    <thead>
                                        <tr>
                                            <th>
                                                到达地区
                                            </th>
                                            <th>
                                                起步价
                                            </th>
                                            <th>
                                                加价
                                            </th>
                                            <th>
                                                满多少免运费
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
                                            <tr id='<%# Eval("id") %>' ttid='<%# Eval("id") %>'>
                                                <td width="300px">
                                                    <input type="text" id="txt_pj_<%# Eval("id") %>" sID="txt_pjIDS_<%# Eval("id") %>" name="pjname" autocomplete="off"
                                                        class="TextBoxDefault" style="width: 250px;" value='<%# Eval("Region") %>' isinit="0"
                                                        onclick="checkexBox(this)" />
                                                    <input type="text" id="txt_pjIDS_<%# Eval("id") %>" name="pjIDs" 
                                                        class="TextBoxDefault" style=" display:none; width: 30px;" value='<%# Eval("RegionIDS") %>' />
                                                </td>
                                                <td>
                                                    <input type="text" id="txt_regionprice_<%# Eval("id") %>" class="TextBoxDefault"
                                                        value='<%# Eval("RegionPrice") %>' style="width: 50px;" />
                                                </td>
                                                <td>
                                                    <input type="text" name="txt_addprice_<%# Eval("id") %>" id="txt_addprice_<%# Eval("id") %> "
                                                        value='<%# Eval("AddRegionPrice") %>' class="TextBoxDefault" style="width: 50px;" />
                                                </td>
                                                <td>
                                                    <input type="text" name="txt_fullprice_<%# Eval("id") %>" id="txt_fullprice_<%# Eval("id") %>"
                                                        value='<%# Eval("FullMoney") %>' class="TextBoxDefault" style="width: 50px;" />
                                                </td>
                                                <td>
                                                    <a href="javascript:void(0);" pjid="0" id="<%# Eval("id") %>" onclick="DeleteRow(this)">
                                                        删除</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            <div style="z-index: 99999; position: absolute; display: none; margin-left: -300px;"
                id="layerArea" class="layerArea">
                <div class="closeBotton">
                    <a style="cursor: pointer" onclick="closeLayerArea()">×</a>
                </div>
                <div id="mainCheckBoxList">
                    <div style="float: left; margin-left: 10px;">
                        <XS:AreaList ID="ddl_address" Size="8" runat="server"></XS:AreaList></div>
                    <div style="float: left;">
                        <br />
                        <input id="btnMoveRight" class="btn01" name="btnMoveRight" onclick="addValue();"
                            value="添加>>" type="button">
                        <p>
                            <input id="btnMoveLeft" class="btn01" name="btnMoveLeft" value="<<移除" onclick="removeValue();"
                                type="button">
                        </p>
                    </div>
                    <div style="float: left;">
                        <select id="AreaList" name="AreaList" style="width: 80px;" size="8">
                        </select></div>
                </div>
                <div class="submitTj">
                    <input id="Button1" class="submit_queding" onclick="submitAllValue();" value="确定"
                        type="button">
                    <input id="Button2" class="submit_queding" onclick="closeLayerArea();" value="取消"
                        type="button">
                </div>
            </div>
            </div>
    </div>
</div>
</asp:PlaceHolder>
<div >
    <span style="display: none;">
        <XS:Button ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="BB" /></span>
    <input type="button" class="AdminButton" onclick="SaveTem()" value=" 保 存 " />
</div>
<script>
    function addValue() {
        var $addressID = $("#<%=ddl_address.ClientID %>_hfValue").val();
        var pram = { "id": $addressID };
        runebws("GetAreaName", pram, function (result) {
            if (result.d != "") {
                var content = "<option value='" + $addressID + "'>" + result.d + "</option>"; // 填充右侧的值  
                $("#AreaList").append(content);
            }
        });
    }
    function removeValue() {
        $("#AreaList option:selected").remove();
    }
    function submitAllValue() {
       
        var areaNams = "";
        var areaIDS = "";
        $("#AreaList").find("option").each(
            function () {
                areaIDS += $(this).val() + ",";
                areaNams += $(this).text() + ",";
            }
          );
        if (areaNams.length > 0) {
            areaNams = areaNams.substr(0, areaNams.length - 1);
        }
        if (areaIDS.length > 0) {
            areaIDS = areaIDS.substr(0, areaIDS.length - 1);
        }
        $("#" + curentShipperId).val(areaNams);
        $("#" + curentShipperIdIDS).val(areaIDS);
        
        $("#layerArea").fadeOut();

    }
    function SaveTem() {
        var tag = true;
        var key = $("#<%= HiddenField1.ClientID %>").val();
        var tname = $("#<%=TemplateName.ClientID %>").val();
        var sweight = $("#<%=StartWeight.ClientID %>").val();
        var aweight = $("#<%=AddWeight.ClientID %>").val();
        var sprice = $("#<%=StartPrice.ClientID %>").val();
        var aprice = $("#<%=AddPrice.ClientID %>").val();

        var $tmpList = GetPjList();
        var pram = { "strFlag": key, "templateName": tname, "startWeight": sweight, "addWeight": aweight, "startPrice": sprice, "addPrice": aprice };


        if (tname == "" || sweight == "" || aweight == "" || sprice == "" || aprice == "") {
            alert("请添加主信息!");
            tag = true;
            return false;
        }

        // alert($tmpList.length);
        if ($tmpList != null && $tmpList.length > 0) {
            var params = null;
            $.each($tmpList, function (i, obj) {
                var txRegion = $(obj).children("td:eq(0)").find("input").val(); //到达地区
                var txRegionPrice = $(obj).children("td:eq(1)").find("input").val(); //起步价   
                var txAddRegionPrice = $(obj).children("td:eq(2)").find("input").val(); // 
                var txFullMoney = $(obj).children("td:eq(3)").find("input").val(); //满多少免运费
                if (txRegion == "" || txRegionPrice == "" || txAddRegionPrice == "" || txFullMoney == "") {
                    alert("请添加!");
                    tag = false;
                    return false;
                }
            });
        }
        else {
            tag = true;
        }

        if (tag) {
            runebws("AddPeiSongTem", pram, function (result) {
                if ($tmpList != null && $tmpList.length > 0) {
                    SaveAreaList(result.d); alert("操作成功");
                }
                else {
                    alert("操作成功");
                }
            });
        }

    }

    function SaveAreaList(obj) {
        var $tmpList = GetPjList();
        if ($tmpList != null && $tmpList.length > 0) {
            var params = null;
            $.each($tmpList, function (i, item) {
                SavePjByObj(item, obj);
            });
            return true;
        }
        else {
            // alert("请添加!");
            return false;
        }
    }

    //保存
    function SavePjByObj(obj, pid) {
        var flag = $(obj).attr("ttid");
        if (flag == "" || flag == undefined || flag == null) {
            flag = 0;
        }

        var txRegion = $(obj).children("td:eq(0)").find("input").val(); //到达地区
        var txRegionIDS = $(obj).children("td:eq(0)").find("input:eq(1)").val();//find("input").get(1).val(); //到达地区IDs
        
        var txRegionPrice = $(obj).children("td:eq(1)").find("input").val(); //起步价   
        var txAddRegionPrice = $(obj).children("td:eq(2)").find("input").val(); //加价
        var txFullMoney = $(obj).children("td:eq(3)").find("input").val(); //满多少免运费
        var params = { "strFlag": flag, "pid": pid, "Region": txRegion, "RegionIDS": txRegionIDS, "RegionPrice": txRegionPrice, "AddRegionPrice": txAddRegionPrice, "FullMoney": txFullMoney };

        if (txRegion == "" || txRegionPrice == "" || txAddRegionPrice == "" || txFullMoney == "") {
            alert("请添加!");
            return false;
        }
        else {
            runebws("AddPeiSongAreaPrice", params, null);

        }
    }
</script>
