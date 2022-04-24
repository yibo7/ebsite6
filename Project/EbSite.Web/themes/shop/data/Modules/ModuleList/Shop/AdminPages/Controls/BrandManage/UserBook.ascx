<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserBook.ascx.cs" Inherits="EbSite.Modules.Shop.AdminPages.Controls.BrandManage.UserBook" %>
<style type="text/css">
    .divPanel
    {
        width: 700px;
        height: auto;
        font-size: 12px;
    }
    .ubooklist
    {
        width: 700px;
        height:35px;
    }
    .ubooklist div
    {
        float: left;
        height:30px;
        line-height:35px;
        vertical-align:middle;
    }
    .ubooklab
    {
        width: 60px;
        text-align: right;
        height:30px;
        vertical-align:middle;
    }
    .ubooklabex
    {
        width: 50px;
        text-align:left;
        height:30px;
        vertical-align:bottom;
        padding-top:10px;
        margin-left:5px;
    }
    .ubookinput
    {
        width: 260px;
    }
    .ubookinput input
    {
        width: 260px;
    }
    .addEx {
        border:1px solid #808080; width:35px;  height:20px;  display:block;
    }
</style>
<script type="text/javascript">
    function UBookAdd() {
        var strHtml = "<div class=\"ubooklist\" rf=\"a\" rid=\"0\">";
        strHtml += "<div class=\"ubooklab\">标题:</div><div class=\"ubookinput\"><input type=\"text\" class=\"TextBoxDefault\" name=\"ctitle\" /></div>";
        strHtml += "<div class=\"ubooklab\">地址:</div><div class=\"ubookinput\"><input type=\"text\" class=\"TextBoxDefault\" name=\"curl\" /></div>";
        strHtml += "<div class=\"ubooklabex\"><a href=\"javascript:void(0);\" class=\"del\" onclick=\"RemoveUBook(this)\">移除</a></div></div>";
        $(".divPanel").append(strHtml);
    }
    function RemoveUBook(obj) {
        var tid = $(obj).parent("div").parent("div").attr("rid");
        if (tid == "0" || tid == 0) {
            $(obj).parent("div").parent("div[class='ubooklist']").remove();
            return;
        }
        if (window.confirm("确定要删除?")) {

            runws("cfccc599-4585-43ed-ba31-fdb50024714b", "DeleteUserBook", { "id": tid }, function (msg) {
                if (msg.d > 0) {
                    $(obj).parent("div").parent("div[class='ubooklist']").remove();
                }
                else {
                    tips("删除失败,请重新操作!", 1, 2);
                }
            });
        }
    }
    function CreateXml() {
      
        var $items = $(".ubooklist");
        if ($items != null && $items.length > 0) {
            var strItem = "<items>";
            $.each($items, function (i, item) {
                var tmpTitle = $(item).find("input[type='text'][name='ctitle']").val();
                var tmpUrl = $(item).find("input[type='text'][name='curl']").val();
                if (tmpTitle != "" && tmpTitle != undefined&&tmpUrl!=""&&tmpUrl!=undefined) {
                    var tmpId = $(item).attr("rid");
                    var strAction = $(item).attr("rf");
                    strItem += "<item title=\"" + tmpTitle + "\" url=\"" + tmpUrl + "\" rid=\"" + tmpId + "\" flag=\"" + strAction + "\"></item>";
                }
            });
            strItem += "</items>";
            $("#<%=hidXml.ClientID %>").val(strItem);
            return true;
        }
        return true;
    }
    


    
    $(".TabsTitle").hide();

    $(".CustomPageTag").hide();
    

</script>

  
<div style="text-align: center; font-size: 18px; font-weight: bold; padding: 8px; background: #E6E5E1; border-top:1px solid #DBDAD7; ">
    <%=GetTitle %>-最佳组合[<a style="color: red;" href="javascript:history.go(-1)">返回</a>]
</div>
<input type="hidden" runat="server" id="hidXml" />
<div class="divPanel">
    <h2 class="colorE">使用指南</h2>
    <div style="font-size: 14px; color: red; margin-bottom: 5px;">商品使用指南(是该商品的使用性说明文章) <br />
        请添写标题和地址。地址是 写好文章的地址，请粘贴于此。
    </div>

    <div style="width:80%; margin-left:50px;">
       
        <a href="javascript:void(0);" onclick="UBookAdd()" class="addEx" ><span style="margin:3px;">添加</span></a>
           
    </div>

    <asp:Repeater ID="DataList" runat="server">
        <ItemTemplate>
            <div class="ubooklist" rf="u" rid="<%# Eval("id") %>">
                <div class="ubooklab">
                    标题:</div>
                <div class="ubookinput">
                    <input type="text" name="ctitle" class="TextBoxDefault" value="<%# Eval("Title") %>" /></div>
                <div class="ubooklab">
                    地址:</div>
                <div class="ubookinput">
                    <input type="text" name="curl" class="TextBoxDefault" value="<%# Eval("Url") %>" /></div>
                <div class="ubooklabex">
                    <a href="javascript:void(0);" class="del" onclick="RemoveUBook(this)">移除</a></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    

    
</div>
<br/>
<asp:Button ID="BtnAdd" runat="server" Text="保存" OnClick="BtnAdd_Click"  OnClientClick="CreateXml()"/>