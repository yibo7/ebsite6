<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FreeItems.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.BrandManage.FreeItems" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div style="text-align: center; font-size: 18px; font-weight: bold; padding: 8px; background: #E6E5E1; border-top:1px solid #DBDAD7; ">
    <%=GetTitle %>-最佳组合[<a style="color: red;" href="javascript:history.go(-1)">返回</a>]
</div>
<div style="font-size: 14px; color: red; margin-bottom: 5px;">
    商品费用选项(可以是一些延期服务费，特殊包装费等) </div>
<div style="display: none;" id="step1">
    <div>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td height="25" width="30%" align="right">
                    订单可选项名称：
                </td>
                <td height="25" width="*" align="left">
                    <input type="text" id="txtItemName" style="width: 200px">
                </td>
            </tr>
            <tr>
                <td height="25" width="30%" align="right">
                    描述 ：
                </td>
                <td height="25" width="*" align="left">
                    <input type="text" id="Description" style="width: 200px; height: 100px;">
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input id="Button2" type="button" value="取  消" onclick="btnCancel()" />
                    <input id="btnBigAdd" type="button" value="添  加" onclick="btnNextStep()" />
                    <input id="btnBigUpdate" type="button" value="修  改" onclick="BigUpdate()" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div style="" id="step2">
    <input id="Button7" type="button" value="添  加" onclick="setp1()" />
    <div>
        <div class="gdList_title">
            <div style="width: 50px">
                序号
            </div>
            <div style="width: 120px">
                选项名称
            </div>
            <%-- <div style="width: 100px">
                选择方式
            </div>--%>
            <div style="width: 350px">
                备注
            </div>
            <div style="width: 150px">
                操作
            </div>
        </div>
        <div id="iOptionInfo">
        </div>
    </div>
</div>
<div style="display: none;" id="step3">
    <input id="Button5" type="button" value="返  回" onclick="setp3goto()" />
    <input id="Button6" type="button" value="添  加" onclick="setp3add()" />
    <div>
        <div class="gdList_title">
            <div style="width: 50px">
                序号
            </div>
            <div style="width: 120px">
                属性值名称
            </div>
            <div style="width: 100px">
                是否赠送
            </div>
            <div style="width: 100px">
                类型
            </div>
            <div style="width: 100px">
                附加金额
            </div>
            <div style="width: 150px">
                备注
            </div>
            <div style="width: 150px">
                操作
            </div>
        </div>
        <div id="iOptionItemsInfo">
        </div>
    </div>
</div>
<div style="display: none;" id="step4">
    <div>
        <table cellspacing="0" cellpadding="0" width="100%" border="0" class="tblist">
            <tr>
                <td height="25" width="30%" align="right">
                    可选项内容名称：
                </td>
                <td height="25" width="*" align="left">
                    <input type="text" id="TitleName" style="width: 200px">
                </td>
            </tr>
            <tr>
                <td height="25" width="30%" align="right">
                    是否赠送：
                </td>
                <td height="25" width="*" align="left">
                    <input id="IsCk" name="IsCk" type="checkbox" />   品商费用选项中，只有一个可做为赠送。
                </td>
            </tr>
            <tr>
                <td height="25" width="30%" align="right">
                    附加金额计算方式：
                </td>
                <td height="25" width="*" align="left">
                    <select id="rdoMonType">
                        <option value="0">固定金额</option>
                        <option value="1">当前商品的百分比</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td height="25" width="30%" align="right">
                    附加金额：
                </td>
                <td height="25" width="*" align="left">
                    <span id="appendFir">固定金额</span>
                    <input type="text" id="txtMoney" style="width: 200px;">
                    <span id="appendSec">元</span>
                </td>
            </tr>
            <tr>
                <td height="25" width="30%" align="right">
                    备注：
                </td>
                <td height="25" width="*" align="left">
                    <input type="text" id="txtRemark" style="width: 200px">
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input id="Button3" type="button" value="取  消" onclick="setp4goto()" />
                    <input id="btnsmalladd" type="button" value="添  加" onclick="setp4Add()" />
                    <input id="btnsmallupdate" type="button" value="修  改" onclick="smallupdate()" />
                </td>
            </tr>
        </table>
    </div>
</div>
<script>
    var ikey=0;
    jQuery(function ($) {

        $("#rdoMonType").change(function() {
            var str = "";
            $("#rdoMonType option:selected").each(function () {
                str = $(this).val() ;
                if(str==1)
                {
                    $("#appendFir").html("当前商品的百分比");
                    $("#appendSec").html("%");
                }
                else{
                    $("#appendFir").html("固定金额");
                    $("#appendSec").html("元");
                }
            });
        });


        ikey=<%=FreeSID %>;
        if(ikey==0)
        {
            $("#step2").hide();
        }
        else{
            var pram = { "id": ikey};
            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetProductOptionList", pram, function (resultData) {
                $.each(resultData.d, function (i, skuItem) {
                    var temp = $(String.format(" <div id=\"op{3}\" style=\"height: 30px\" class=\"gdListContent\"> <div style=\"width: 50px\"> {2}</div><div style=\"width: 120px\"> {0}</div>  <div style=\"width: 370px\"> {1}</div><div style=\"width: 150px\"> <a href=\"#\" onclick=\"editItemList({3})\">编辑选项列表 </a> <a href=\"#\" onclick=\"edit({3})\"> 修改</a> <a href=\"#\" onclick=\"del({3})\"> 删除</a></div> </div>", skuItem.title, skuItem.Description,i+1,skuItem.id));
                    $("#iOptionInfo").append(temp);
                })
            });
        }

        
      
    });
    // 打开 添加 大类窗口
    function setp1() {
        $("#txtItemName").val("");
        $("#Description").val("");
        $("#step1").show();
        $("#step2").hide();
        $("#btnBigUpdate").hide();
        $("#btnBigAdd").show();
    }
    function btnCancel()
    {
        $("#step1").hide();
        $("#step2").show();
    }
    //添加 大项
    function btnNextStep() {
        var ititle=$("#txtItemName").val();
        var idescription=$("#Description").val();
        if(ititle=="")
        {
            alert("标题不能为空！");
        }
        else
        {
            var pram = { "title": ititle ,"ProductID":ikey,"Description":idescription,"opid":0};
            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "OpProductOptions", pram, function (resultData) {
                var temp = $(String.format(" <div id=\"op{3}\" style=\"height: 30px\" class=\"gdListContent\"> <div style=\"width: 50px\"> {2}</div><div style=\"width: 120px\"> {0}</div>  <div style=\"width: 100px\">     </div> <div style=\"width: 350px\"> {1}</div><div style=\"width: 150px\"> <a href=\"#\" onclick=\"editItemList({3})\">编辑选项列表 </a> <a href=\"#\" onclick=\"edit({3})\"> 修改</a> <a href=\"#\" onclick=\"del({3})\"> 删除</a></div> </div>", ititle, idescription,resultData.d.icount,resultData.d.id));
                $("#iOptionInfo").append(temp);
            });
            $("#step1").hide();
            $("#step2").show();
        }
    }
    var bigId=0;
    //修改 商品可选项
    function edit(obj)
    {
       
        bigId=obj;
        $("#step1").show();
        $("#step2").hide();
        $("#btnBigUpdate").show();
        $("#btnBigAdd").hide();
        

        var pram = { "opid":obj};
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetProductOptions", pram, function (resultData) {
            $("#txtItemName").val(resultData.d.title);
            $("#Description").val(resultData.d.Description);
        });
    }
    //修改大项
    function BigUpdate()
    {  
        var ititle=$("#txtItemName").val();
        var idescription=$("#Description").val();
        if(ititle=="")
        {
            alert("标题不能为空！");
        }
        else
        {
            var pram = { "title": ititle ,"ProductID":ikey,"Description":idescription,"opid":bigId};
            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "OpProductOptions", pram, function (resultData) {
                
                var pram = { "id": ikey};
                runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetProductOptionList", pram, function (resultData) {
                    $("#iOptionInfo").html("");
                    $.each(resultData.d, function (i, skuItem) {
                        var temp = $(String.format(" <div id=\"op{3}\" style=\"height: 30px\" class=\"gdListContent\"> <div style=\"width: 50px\"> {2}</div><div style=\"width: 120px\"> {0}</div>  <div style=\"width: 100px\">     </div> <div style=\"width: 350px\"> {1}</div><div style=\"width: 150px\"> <a href=\"#\" onclick=\"editItemList({3})\">编辑选项列表 </a> <a href=\"#\" onclick=\"edit({3})\"> 修改</a> <a href=\"#\" onclick=\"del({3})\"> 删除</a></div> </div>", skuItem.title, skuItem.Description,i+1,skuItem.id));
                        $("#iOptionInfo").append(temp);
                    })
                });
            });
            $("#step1").hide();
            $("#step2").show();
        }
    }

    //删除 商品可选项
    function del(obj)
    {
        if(confirm("是否将此信息删除,同时删除子项列表?"))
        {
            var pram = { "id": obj };
            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "DelOption", pram, function (resultData) {
                $("#op"+obj).hide();
            });
            return true;
        }
        else{
            return false;
        } 

    }
    //编辑列表 商品可选项
    var iProductID=0;
    function editItemList(obj)
    {
        $("#iOptionItemsInfo").html("");
        iProductID=obj;
       
        var pram = { "id": iProductID };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetProductItem", pram, function (resultData) {
            $.each(resultData.d, function (i, skuItem) {
                var temp = $(String.format(" <div id=\"childItem{3}\" style=\"height: 30px\" class=\"gdListContent\">  <div style=\"width: 90px\"> {2}</div> <div style=\"width: 100px\"> {0}</div>  <div style=\"width: 100px\">{4}</div><div style=\"width: 100px\">  {5}   </div>  <div style=\"width: 150px\"> {6}</div> <div style=\"width: 150px\"> {7}</div>  <div style=\"width: 120px\"> <a href=\"#\" onclick=\"editItem({3})\"> 编辑</a><a href=\"#\" onclick=\"delItem({3})\"> 删除</a></div> </div>",
                 skuItem.ItemName, skuItem.Description,i+1,skuItem.id,skuItem.IsGive,skuItem.CalculateMode,skuItem.AppendMoney,skuItem.Remark));
                $("#iOptionItemsInfo").append(temp);
            })
        });

        $("#step1").hide();
        $("#step2").hide();
        $("#step3").show();

        checkGiveItme(obj);
       
    }

    function setp3goto()
    {
        $("#step1").hide();
        $("#step2").show();
        $("#step3").hide();
    }
    //子项的 添加
    function setp3add()
    {
        $("#TitleName").val("");
        $("#IsCk").removeAttr("checked");
        $("#txtMoney").val("");
        $("#txtRemark").val("");

        $("#btnsmalladd").show();
        $("#btnsmallupdate").hide();

        $("#step1").hide();
        $("#step2").hide();
        $("#step3").hide();
        $("#step4").show();
          checkGiveItme(iProductID);
       

    }
    function setp4goto()
    {
        $("#step1").hide();
        $("#step2").hide();
        $("#step3").show();
        $("#step4").hide();

    }
    
    function setp4Add()
    {
        var iname=$("#TitleName").val(); 
        var isCk=false;
        var isCkEx="否";
        var itypeEx="固定金额";
        if($("input[name='IsCk']").attr("checked"))
        {   				
            isCk=true;isCkEx="是";
        }
        var itype= $("#rdoMonType option:selected").val();
        if(itype=="1")
        {
            itypeEx="购物车金额百分比";
        }
        var iMoney=$("#txtMoney").val(); 
        var iRemark=$("#txtRemark").val();

        if(iname==""||iMoney=="")
        {
            alert("选项名称或附加金额不能为空！")
        }
        else{
            var pram = { "pid": iProductID ,"ititle":iname,"IsGive":isCk,"AppendMoney":iMoney,"CalculateMode":itype,"Remark":iRemark,"opid":0};
            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "OpProductOptionItems", pram, function (resultData) {
                var temp = $(String.format(" <div id=\"childItem{3}\" style=\"height: 30px\" class=\"gdListContent\">  <div style=\"width: 90px\"> {2}</div> <div style=\"width: 100px\"> {0}</div>  <div style=\"width: 100px\">{4}</div><div style=\"width: 100px\">  {5}   </div>  <div style=\"width: 150px\"> {6}</div> <div style=\"width: 150px\"> {7}</div>  <div style=\"width: 120px\"> <a href=\"#\" onclick=\"editItem({3})\"> 编辑</a><a href=\"#\" onclick=\"delItem({3})\"> 删除</a></div> </div>",           
                      iname, iRemark,resultData.d.icount,resultData.d.id,isCkEx,itypeEx,iMoney,iRemark));

                $("#step1").hide();
                $("#step2").hide();
                $("#step3").show();
                $("#step4").hide();
                $("#iOptionItemsInfo").append(temp);
            });
        }
    }
    function delItem(obj)
    {
        var pram = { "id": obj };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "DelProductItem", pram, function (resultData) {
            $("#childItem"+obj).hide();
        });
      
    }
    var smallid=0;
    //编辑子项内容
    function editItem(obj)
    {
        smallid=obj;
        $("#step1").hide();
        $("#step2").hide();
        $("#step3").hide();
        $("#step4").show();
        $("#btnsmalladd").hide();
        $("#btnsmallupdate").show();
        var pram = { "id": obj };
        runws("cfccc599-4585-43ed-ba31-fdb50024714b", "GetEntityProductItem", pram, function (resultData) {
            
            $("#TitleName").val(resultData.d.ItemName);
          
            if(resultData.d.IsGive=="False")
            {
               checkGiveItme(iProductID)
                $("#IsCk").removeAttr("checked");
            }
            else
            {   
                alert(2);
                $("input[name='IsCk']").removeAttr("disabled");
                $("#IsCk").attr("checked","true");
            }
            $("#rdoMonType").val(resultData.d.CalculateMode);
            $("#txtMoney").val(resultData.d.AppendMoney);
            $("#txtRemark").val(resultData.d.Remark);
        });
    }

    function smallupdate()
    {
        var iname=$("#TitleName").val(); 
        var isCk=false;
        var isCkEx="否";
        var itypeEx="固定金额";
        if($("input[name='IsCk']").attr("checked"))
        {   				
            isCk=true;isCkEx="是";
        }
        var itype= $("#rdoMonType option:selected").val();
        if(itype=="1")
        {
            itypeEx="购物车金额百分比";
        }
        var iMoney=$("#txtMoney").val(); 
        var iRemark=$("#txtRemark").val();

        if(iname==""||iMoney=="")
        {
            alert("选项名称或附加金额不能为空！")
        }
        else{
            var pram = { "pid": iProductID ,"ititle":iname,"IsGive":isCk,"AppendMoney":iMoney,"CalculateMode":itype,"Remark":iRemark,"opid":smallid};
            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "OpProductOptionItems", pram, function (resultData) {
               
                $("#step1").hide();
                $("#step2").hide();
                $("#step3").show();
                $("#step4").hide();
                //$("#iOptionItemsInfo").append(temp);
                editItemList(iProductID);
            });
        }
    }


    function checkGiveItme(obj)
    {
     //要检测 只能有一个是赠送
       var pram = { "id": obj };
       runws("cfccc599-4585-43ed-ba31-fdb50024714b", "CheckGiveGetProductItem", pram, function (resultData) {
            
            if(resultData.d)
            {
             
              $("input[name='IsCk']").attr("disabled","disabled");
            }
            else
            {          
              $("input[name='IsCk']").removeAttr("disabled");
              $("#IsCk").bind("click", function () {
                 
                 if($("input[name='IsCk']").attr("checked"))
                 {
                   $("#txtMoney").val("0");
                   $("#txtMoney").attr("disabled","disabled");
                 }
                 else{
                   $("#txtMoney").val("");
                   $("#txtMoney").removeAttr("disabled");
                 }            
             });
            }
       });
    }
    

    
    $(".TabsTitle").hide();

    $(".CustomPageTag").hide();
    

</script>
