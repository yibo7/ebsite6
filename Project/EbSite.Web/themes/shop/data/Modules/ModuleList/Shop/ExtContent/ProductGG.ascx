<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductGG.ascx.cs" Inherits="EbSite.Modules.Shop.ExtContent.ProductGG" %>
<link type="text/css" href=" <%= EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>Css/GoodsType.css" rel="stylesheet" />
<div>
    <div >
        <ul>
           
            <li style="display: none" id="skuTitle">
                <h2 class="colorE">
                    商品规格</h2>
            </li>
            <li style="display: none" id="enableSkuRow"><span class="formitemtitle Pw_198">规格：</span><input
                id="btnEnableSku" value="开启规格" type="button" >
                开启规格前先填写以上信息，可自动复制信息到每个规格 </li>
            <li style="display: none" id="skuRow">
                <p id="skuContent">
                    <input id="btnGenerateAll" value="生成所有规格" type="button">
                    <input id="btnshowSkuValue" value="生成部分规格" type="button">
                    <input id="btnAddItem" value="增加一个规格" type="button">
                    <input id="btnCloseSku" value="关闭规格" type="button">
                    <input id="btnCheck"  style="display:none;" value="检验" type="button">
                </p>
                <p style="margin: 0px auto; display: none" id="skuFieldHolder">                                           
                </p>
                <div id="skuTableHolder">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
                <asp:HiddenField ID="ctl00_contentHolder_txtSkus" runat="server" />
                <span style="display: none;">
                    <input id="ctl00_contentHolder_chkSkuEnabled" type="checkbox" value="on" name="ctl00_contentHolder_chkSkuEnabled" /></span>
            </li>
        </ul>
    </div>
</div>
<div class="Pop_up" id="skuValueBox" style="display: none;">
    <h1>
        <span>选择要生成的规格</span>
    </h1>
    <div class="img_datala">
        <img src=" <%= EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>css/icon_dalata.gif" alt="关闭"
            width="38" height="20" />
    </div>
    <div class="mianform ">
        <div id="skuItems">
        </div>
        <div style="margin-top: 10px; text-align: center;">
            <input type="button" value="确定" id="btnGenerate" />
        </div>
    </div>
</div>
<script src="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>js/shop-core.js" type="text/javascript"></script>
<script src="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>js/jQuery-powerFloat-min.js"
    type="text/javascript"></script>
<script src="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>js/jQuery.Hashtable.js" type="text/javascript"></script>
<script src="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>js/GoodsType.js" type="text/javascript"></script>


<script>

   
    jQuery(function ($) {
      
        attributeRow = document.getElementById("attributeRow");

        skuTitle = document.getElementById("skuTitle");
        attributeContentHolder = $("#attributeContent"); //扩展属性区域容器
        enableSkuRow = document.getElementById("enableSkuRow");
        skuRow = document.getElementById("skuRow");
        skuCodeRow = document.getElementById("skuCodeRow");

        attributeContentHolder = $("#attributeContent");
        skuTableHolder = $("#skuTableHolder");
        skuFieldHolder = $("#skuFieldHolder");
        productTypeSelector.bind("change", function () { reset(); });


        $("#btnEnableSku").bind("click", function () {
            enableSku();
            $("html,body").animate({
                    scrollTop: $(skuTitle).offset().top
                }
                , 500);
        });
        $("#btnAddItem").bind("click", function () {
            addItem();
        });
        $("#btnCloseSku").bind("click", function () {
            closeSku();
        });
        $("#btnGenerateAll").bind("click", function () {
            generateAll();
        });
        $("#btnshowSkuValue").bind("click", function () {
            showSkuValue();
        });
        $("#btnGenerate").bind("click", function () {
            generateSku();
        });
        $("#btnCheck").bind("click", function () {
            doCheck();
        });
        key=<%=SID %>;
       
        if(key>0)
        {
            contentHolder_txtSkus=($("#<%=ctl00_contentHolder_txtSkus.ClientID %>").val());  
        }
        sDataId=<%=DataId %>;
        init();

    });


    function loadSkus() {
        var skusXml = "<xml><productSkus>";
        $.each($(".SpecificationTr"), function (i, valitem) {
            var rowIndex = $(valitem).attr("rowindex");
            var skuCode = $("#skuCode_" + rowIndex).val();
            var salePrice = $("#salePrice_" + rowIndex).val();
            var costPrice = $("#costPrice_" + rowIndex).val();
            var qty = $("#qty_" + rowIndex).val();
            var weight = $("#weight_" + rowIndex).val();
            var itemXml = String.format("<item skuCode=\"{0}\" salePrice=\"{1}\" costPrice=\"{2}\" qty=\"{3}\" weight=\"{4}\">", skuCode, salePrice, costPrice, qty, weight);
            itemXml += "<skuFields>";
            for (i = 0; i < cellFields.length; i++) {
                itemXml += String.format("<sku attributeId=\"{0}\" valueId=\"{1}\" \/>", cellFields[i], $(String.format("#skuDisplay_{0}_{1}", rowIndex, cellFields[i])).attr("valueId"));
            }
            itemXml += "<\/skuFields>";

          
            itemXml += "<\/item>";
            skusXml += itemXml;
        });
        skusXml += "<\/productSkus><\/xml>";
        //   alert(skusXml);
        $("#<%=ctl00_contentHolder_txtSkus.ClientID %>").val(skusXml);
    }

</script>
