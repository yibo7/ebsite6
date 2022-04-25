<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.AddClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<div id="divsteptips" runat="server" style="background:#FAFAFA" class="container-fluid main-title">
    第二步:添加分类
</div>
<style>
    .form-control{
            width:auto;/*不让下拉表单100%*/
        }
</style>
 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="active tab">
                <a href="#tg1" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-database"></i></span>
                    <span class="hidden-xs">基本数据</span>
                </a>
            </li>
            <li class="tab">
                <a href="#tg2" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-paw"></i></span>
                    <span class="hidden-xs">SEO优化设置</span>
                </a>
            </li>
            <li class="tab">
                <a href="#tg3" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-qrcode"></i></span>
                    <span class="hidden-xs">可选设置</span>
                </a>
            </li>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <table>
                    <tr>
                        <td>
                            <%=Resources.lang.EBParentClass%>:
                        </td>
                        <td>
                            <asp:Label ID="lbClassName" ForeColor="#CC0000" Font-Bold="true" runat="server">一级分类</asp:Label>
                            <span onclick="reselclass()" style="color: #2963B8; cursor: pointer;">重选父分类</span>
                            <asp:CheckBox ID="cbMore" onclick="checkmoreadd(this)" Text="启用批量添加" runat="server" />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>批量名称
                        </td>
                        <td>每行代表一个分类名称
                    <br />
                            <XS:TextBox Width="500" Height="200" TextMode="MultiLine" runat="server" ID="txtClassNames"></XS:TextBox>
                        </td>
                    </tr>

                    <asp:PlaceHolder ID="phDefaultFileds" runat="server"></asp:PlaceHolder>
                </table>
            </div>
            <div id="tg2" class="tab-pane">
                <XS:Notes ID="Notes3" Text="如果seo标题不为空，将不使用全局seo设置，注意这里不能使用替换变量" />
                <table>
                    <tr>
                        <td>Seo标题：
                        </td>
                        <td>
                            <XS:TextBox Width="390" runat="server" ID="SeoTitle"></XS:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>seo关键词：
                        </td>
                        <td>
                            <XS:TextBox Width="300" Height="50" TextMode="MultiLine" runat="server" ID="SeoKeyWord"></XS:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>Seo描述：
                        </td>
                        <td>
                            <XS:TextBox Width="300" Height="50" TextMode="MultiLine" runat="server" ID="SeoDescription"></XS:TextBox>

                        </td>
                    </tr>

                    <tr>
                        <td>分类目录(相对)：
                        </td>
                        <td>
                            <XS:TextBox HintInfo="不要在前面加上/,如 填写ebsite/,分类访问路径为:http://域名/ebsite/" runat="server" Width="200" ID="HtmlName"></XS:TextBox>
                            <asp:CheckBox ID="IsHtmlNameReWrite" HintInfo="默认情况重写连接模式下只调用seo里的设置,也可以到静态地址里批量生成这个设置,需要重启iis才能生效" Text="开启重写" runat="server" />
                        </td>
                    </tr>


                    <tr>
                        <td>内容目录(相对)：
                        </td>
                        <td>
                            <XS:TextBox HintInfo="不要在前面加上/ 如 填写ebsite/,分类访问路径为:http://域名/ebsite/内容页面名称" runat="server" Width="200" ID="ContentHtmlPath"></XS:TextBox>
                            <asp:CheckBox ID="IsHtmlNameReWriteContent" HintInfo="默认情况重写连接模式下只调用seo里的设置,开启后规则为:内容目录-id.html,需要重启iis才能生效" Text="开启重写" runat="server" />
                        </td>


                        <tr>
                            <td>外部连接：
                            </td>
                            <td>
                                <XS:TextBox runat="server" Width="380" ID="OutLike"></XS:TextBox>

                            </td>
                        </tr>

                    <%--<tr>
                        <td colspan="2" style="text-align:center; height:50px;">
                            <asp:CheckBox ID="cbIsContinu"   Text="操作完毕是否返回列表" runat="server" />
                        </td>
                    </tr>--%>


                    <asp:PlaceHolder ID="phSeoSet" runat="server"></asp:PlaceHolder>



                </table>
            </div>
            <div id="tg3" class="tab-pane">

                <table>


                    <tr>
                        <td>总点击率：
                        </td>
                        <td>
                            <XS:TextBoxVl Width="50" ValidateType="大于等于0整数包括0" runat="server" ID="hits">0</XS:TextBoxVl>

                        </td>
                    </tr>
                    <tr>
                        <td>天点击率：
                        </td>
                        <td>
                            <XS:TextBoxVl Width="50" ValidateType="大于等于0整数包括0" runat="server" ID="dayHits">0</XS:TextBoxVl>

                        </td>
                    </tr>
                    <tr>
                        <td>本周点击：
                        </td>
                        <td>
                            <XS:TextBoxVl Width="50" ValidateType="大于等于0整数包括0" runat="server" ID="weekHits">0</XS:TextBoxVl>

                        </td>
                    </tr>
                    <tr>
                        <td>本月点击：
                        </td>
                        <td>
                            <XS:TextBoxVl Width="50" ValidateType="大于等于0整数包括0" runat="server" ID="monthhits">0</XS:TextBoxVl>

                        </td>
                    </tr> 

                    <asp:PlaceHolder ID="phOrtherFileds" runat="server"></asp:PlaceHolder>

                </table>
            </div>
        </div>
    </div>
 
<div style="padding-left: 10px;">
    <div style="text-align: center; padding: 10px;">
        <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" ValidationGroup="savedata" />
    </div>

</div>
<script>


    function reselclass() {
        if (confirm("重新选择将离开当前页面，数据可能丢失，确认离开吗?")) {
            location.href = "?t=2";
        }
    }

    function checkmoreadd(obj) {
        if (obj.checked) {
            $(obj).parent().parent().next().show();
            $("#tdClassName").parent().hide();
            var inpu = $("#tdClassName input")[0];
            $(inpu).attr("isnull", "1");
        }
        else
        {
            $(obj).parent().parent().next().hide();
            $("#tdClassName").parent().show();
            var inpu = $("#tdClassName input")[0];
            $(inpu).attr("isnull", "0");
        }
    }

</script>
<style>
    td{ padding: 5px;}
</style>