<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSX.ascx.cs" Inherits="EbSite.Modules.Shop.ExtContent.ProductSX" %>
<div>
    <div >
        <ul>
            <li id="attributeRow" style="display: none">
                <h2 class="colorE">
                    商品属性</h2>
                <div id="attributeContent" class="attributeContent" />
                <asp:HiddenField ID="ctl00_contentHolder_txtAttributes" runat="server" />
            </li>
        </ul>
    </div>
</div>
<script>

    jQuery(function ($) {
         key1=<%=SID %>;
         if(key1>0)
         { ctl00_contentHolder_txtAttributes = ($("#<%=ctl00_contentHolder_txtAttributes.ClientID %>").val());}
    });

    function loadAttributes() {
        var attributesXml = "<xml><attributes>";

        $.each($(".attributeItem"), function (i, att) {
            var attributeId = $(att).attr("attributeId");
            var usageMode = $(att).attr("usageMode");
            var itemXml = String.format("<item attributeId=\"{0}\" usageMode=\"{1}\">", attributeId, usageMode);

            if (usageMode == "1") {
                //多选属性
                $.each($("input[name='vallist" + attributeId + "']:checked"), function () {
                    itemXml += String.format("<attValue valueId=\"{0}\" \/>", $(this).attr("valueId"));
                });
            }
            else {
                itemXml += String.format("<attValue valueId=\"{0}\" \/>", $("#attribute" + attributeId).val());
            }

            itemXml += "<\/item>";
            attributesXml += itemXml;
        });

        attributesXml += "<\/attributes><\/xml>";
       
        $("#<%=ctl00_contentHolder_txtAttributes.ClientID %>").val(attributesXml);
    }


</script>
