<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddContent.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.AddContent" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<style>
    td {
        padding: 5px;
    }

    .ModuleCtrs {
        width: 100%;
    }

        .ModuleCtrs .tagext div {
            text-align: center;
            padding: 10px;
            clear: both;
            cursor: pointer;
            max-width: 130px;
        }

        .ModuleCtrs .tagext .current {
            background: #F4F8FB;
            border: 1px solid #EEF2F5;
        }
        .form-control{
            width:auto;/*不让下拉表单100%*/
        }
</style>

<div id="divsteptips" runat="server" class="container-fluid main-title">第二步:添加内容</div>

 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="#tg1" data-bs-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa  fa-file-word-o"></i></span>
                    <span class="hidden-xs">编辑内容</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg2" data-bs-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-gear"></i></span>
                    <span class="hidden-xs">初始设置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg3" data-bs-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-gears"></i></span>
                    <span class="hidden-xs">相关设置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg4" data-bs-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-magic"></i></span>
                    <span class="hidden-xs">扩展功能</span>
                </a>
            </li>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <%=Resources.lang.EBSubClass%>:
                        </td>
                        <td>

                            <asp:Label ID="llClassName" ForeColor="#CC0000" Font-Bold="true" runat="server"></asp:Label>
                            <span onclick="reselclass()" style="color: #2963B8; cursor: pointer;">重选分类</span>
                        </td>
                    </tr>

                    <asp:PlaceHolder ID="phDefaultFileds" runat="server"></asp:PlaceHolder>
                    <tr>
                        <td style="width:130px">标签:
                        </td>
                        <td>
                            <XS:TextBox Width="300" runat="server" ID="TagIDs"></XS:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="cbUpdateModifyDate" Visible="false" Text="同时更新修改日期" runat="server" />
                        </td>
                    </tr>
                </table>

            </div>
            <div class="tab-pane" id="tg2">
                <XS:Notes ID="Notes1" Text="排序为权重，以下参数可以为空或正整数，不填写将默认为0," </div>
                <table>
                    <tr>
                        <td>排序:
                        </td>
                        <td>
                            <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server" ID="OrderID">0</XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>总点击率:
                        </td>
                        <td>
                            <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server" ID="hits">0</XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>天点击率:
                        </td>
                        <td>
                            <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server" ID="dayHits">0</XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>本周点击:
                        </td>
                        <td>
                            <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server" ID="weekHits">0</XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>本月点击:
                        </td>
                        <td>
                            <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server" ID="monthhits">0</XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td >收藏率:
                        </td>
                        <td>
                            <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server" ID="Advs">0</XS:TextBoxVl>
                        </td>
                    </tr>


                    <asp:PlaceHolder ID="phInitSeting" runat="server"></asp:PlaceHolder>
                </table>
            </div>

            <div class="tab-pane" id="tg3">

                <table>

                    <tr>
                        <td>关键词(Keywords)：
                        </td>
                        <td>
                            <XS:TextBox Width="500" Height="100" TextMode="MultiLine" runat="server" ID="Keywords"></XS:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>描述(Description)：
                        </td>
                        <td>
                            <XS:TextBox Width="500" Height="200" TextMode="MultiLine" runat="server" ID="Description"></XS:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>是否推荐：
                        </td>
                        <td>
                            <XS:CheckBox runat="server" ID="IsGood"></XS:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td>是否可评论：
                        </td>
                        <td>
                            <XS:CheckBox runat="server" ID="IsComment"></XS:CheckBox>
                        </td>
                    </tr>
                    <asp:PlaceHolder ID="phOrtherConfigs" runat="server"></asp:PlaceHolder>

                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="cbIsContinu" Text="操作完毕定向到列表页" runat="server" />
                        </td>
                    </tr>
                </table>

            </div>
            <div class="tab-pane" id="tg4">
                <div class="ModuleCtrs">
                    <asp:PlaceHolder ID="ModuleCtrs" runat="server"></asp:PlaceHolder>
                </div>

            </div>
        </div>
    </div>



<div style="text-align: center; padding: 10px;">
    <XS:Button ID="bntSave" Width="200" Text=" <%$Resources:lang,EBSave%> " runat="server" ValidationGroup="savedata" />
</div>

<script>


    jQuery(function ($) {

    });

    function InitTags() {
        In.ready('customtags', function () {
            var TagsModuleCtrs = new CustomTags();
            TagsModuleCtrs.ParentObjName = ".tagext";
            TagsModuleCtrs.SubObj = "div";
            TagsModuleCtrs.CurrentClassName = "current";
            TagsModuleCtrs.ClassName = "";
            TagsModuleCtrs.InitOnclickInTags();
            TagsModuleCtrs.InitOnclick(0);
        });
    }
    function reselclass() {
        if (confirm("重新选择将离开当前页面，数据可能丢失，确认离开吗?")) {
            location.href = "?t=0";
        }
    }
</script>
