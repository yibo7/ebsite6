<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditFileds.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.EditFileds" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    td {
        padding: 5px;
    }
</style>
<div id="divsteptips" runat="server" class="container-fluid main-title"></div>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>模型字段管理</h3>
            </div>
            <div class="content">
				<table style="width: 100%">
                <tr>

                    <td colspan="2" style="text-align: left; font-size: 18px; font-weight: bold; text-align: center;">[<asp:Literal runat="server" ID="ltModelName"></asp:Literal>]字段列表
                    </td>

                </tr>
                <tr>
                    <td colspan="2" style="font-weight: bold; text-align: right;">
                        <input onclick="AddFileds()" type="button" class="btn btn-primary" value=" 添加字段 " />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="table-responsive">
                        <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ColumFiledName">
                            <Columns>

                                <asp:TemplateField HeaderText="显示名称" ItemStyle-Width="120">
                                    <ItemTemplate>
                                        <%#Eval("ColumShowName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--
                                     <asp:TemplateField  HeaderText="页面模板绑定-简易方式" >
                                         <ItemTemplate>
                                        <%#Eval("BindCoreForPageTemEsy")%>
                                         </ItemTemplate>
                                   </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="模板调用方式">
                                    <ItemTemplate>
                                        <%#Eval("BindCoreForPageTemAdv")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="数据集控件模板绑定方式">
                                    <ItemTemplate>
                                        <%#Eval("BindCoreForCtrTem")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="展示控件">
                                    <ItemTemplate>
                                        <%#GetCtrName(Eval("FieldControlTypeID"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:lang,EBOperation %>" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <a onclick="ModifyFileds('<%#Eval("ColumFiledName")%>','<%#Eval("ColumShowName")%>','<%#Eval("FieldControlTypeID")%>','<%#Eval("IsShowUser")%>','<%#Eval("PlaceHolderID")%>','<%#Eval("IsOutFiled")%>','<%#Eval("IsReadOnly")%>','<%#Eval("DataTypeLen")%>','<%#Eval("DataType")%>')" href="#">修改</a>
                                        <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ColumFiledName") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </XS:GridView>
                            </div>
                    </td>
                </tr>


                <tr>
                    <td colspan="2" style="text-align: center; height: 50px; display: none;">

                        <asp:Button ID="bntSaveFileds" OnClick="bntSaveFileds_Click" Text="保存" runat="server" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>

<div class="modal" id="mdeditefi" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog" style="width: 800px;">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">添加字段</h4>
            </div>
            <div style="height: 500px;" class="modal-body">
                <ul id="myTab" class="nav nav-tabs">
                    <li class="active">
                        <a href="#tg1" data-toggle="tab">字段参数
                        </a>
                    </li>
                    <li><a href="#tg2" data-toggle="tab">其他参数</a></li>
                </ul>
                <div id="myTabContent" class="tab-content">
                    <div class="tab-pane fade in active" id="tg1">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>字段类型:</td>
                                <td>
                                    <XS:DropDownList onchange="drpFiledType_Change(this)" HintInfo="自带字段是系统表字段，具有查询速度快，绑定简单的特点，建议优先使用" runat="server" ID="drpFiledType">
                                        <asp:ListItem Text="自带字段" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="自定义字段" Value="1"></asp:ListItem>
                                    </XS:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>展示标题:</td>
                                <td>
                                    <XS:TextBox ID="txtFiledTitle" Width='200' runat="server"></XS:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>绑定控件:</td>
                                <td>
                                    <XS:DropDownList HintInfo="将以什么控件来接收用户输入" runat="server" ID="drpCtrType"></XS:DropDownList>
                                </td>
                            </tr>
                            <tr id="trDefaultFiled">
                                <td>选择自带字段:</td>
                                <td>

                                    <XS:DropDownList HintInfo="在前台调用数据时要用到的字段名称" runat="server" ID="drpFiles"></XS:DropDownList>
                                </td>
                            </tr>
                            <tr id="trFiledName" style="display: none;">
                                <td>字段名称:</td>
                                <td>
                                    <XS:TextBox ID="txtFileName" HintInfo="在前台调用数据时要用到的字段名称" Width='150' runat="server"></XS:TextBox>
                                </td>
                            </tr>
                            <tr id="trFiledDataType">
                                <td>字段类型:</td>
                                <td class="form-inline">
                                    <div class="form-group">
                                        <XS:DropDownList runat="server" ID="drpFiledDataType">
                                        </XS:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputfile">长度</label>
                                        <XS:TextBoxVl ID="txtDataTypeLen" Width='50' ValidateType="整数" runat="server"></XS:TextBoxVl>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tab-pane fade" id="tg2">
                        <div class="alert alert-warning">注:以下参数如果不清楚，请不要修改</div>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>输出容器:</td>
                                <td>
                                    <XS:TextBox ID="txtPlaceHolderID" HintInfo="这可以更加灵活地安排控件输出的位置" Width='150' runat="server">phDefaultFileds</XS:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>用户可见:</td>
                                <td>
                                    <XS:CheckBox ID="cbUserDis" Checked="true" HintInfo="如果模型应用于前台用户录入，这个就显得非常有用,因为有些字段不必让前台用户来编辑，如模板，模型等" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfModifyKey" runat="server" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button" onclick="OnSaveFileds()" class="btn btn-primary">提交更改</button>
            </div>
        </div>
    </div>
</div>
<script>




    var drpFiledDataType = $("#<%=drpFiledDataType.ClientID %>");
    var txtDataTypeLen = $("#<%=txtDataTypeLen.ClientID %>");

    var drFiledType = $("#<%=drpFiledType.ClientID %>");
    var txFiledTitle = $("#<%=txtFiledTitle.ClientID %>");
    var drCtrType = $("#<%=drpCtrType.ClientID %>");
    var drFiles = $("#<%=drpFiles.ClientID %>");
    var txFileName = $("#<%=txtFileName.ClientID %>");
    var txPlaceHolderID = $("#<%=txtPlaceHolderID.ClientID %>");

    var cUserDis = $("#<%=cbUserDis.ClientID %>");

    var hfModifyKey = $("#<%=hfModifyKey.ClientID %>");

    //            $(document).ready(function () {



    //            });

    function OnSaveFileds() {


        $("#<%=bntSaveFileds.ClientID%>").click();

    }
    function drpFiledType_Change(ob) {

        var t = get_selected_value(ob);

        if (t == 0) {
            $("#trDefaultFiled").show();
            $("#trFiledName").hide();
            $("#trFiledDataType").hide();

        }
        else {
            $("#trDefaultFiled").hide();
            $("#trFiledName").show();
            $("#trFiledDataType").show();
        }

    }
    function AddFileds() {

        hfModifyKey.val("");
        drFiledType.attr("disabled", false);
        drpFiledDataType.attr("disabled", false);
        txtDataTypeLen.attr("disabled", false);
        drFiles.attr("disabled", false);
        drCtrType.attr("disabled", false);
        set_selected_value(drFiledType, 0);
        drFiledType.change();
        txFiledTitle.val("");
        $('#mdeditefi').modal('toggle');
        //OpenFiledsWin();
    }
    //function OpenFiledsWin() {
    //    OpenDialog_SavePost("filedsedit", OnSaveFileds, true)
    //}

    function ModifyFileds(FiledName, ShowTitle, CtrID, UserShow, PlaceHolderID, IsOutFiled, IsReadOnly, DataTypeLen, DataType) {

        hfModifyKey.val(FiledName);
        //                //初始化字段
        if (IsOutFiled == "True") {
            set_selected_value(drFiledType, 1);

        }
        else {
            set_selected_value(drFiledType, 0);
        }
        $("#trDefaultFiled").hide();
        $("#trFiledName").hide();
        drFiledType.attr("disabled", true);

        drpFiledDataType.attr("disabled", true);
        txtDataTypeLen.attr("disabled", true);


        drFiles.attr("disabled", true);

        txFiledTitle.val(ShowTitle);
        txtDataTypeLen.val(DataTypeLen);
        drpFiledDataType.val(DataType);
        set_selected_value(drCtrType, CtrID);

        if (IsReadOnly == "True") {
            drCtrType.attr("disabled", true);
        }
        else {
            drCtrType.attr("disabled", false);
        }

        if (UserShow == "True") {
            cUserDis.attr("checked", true);
        }
        else {
            cUserDis.attr("checked", false);
        }

        txPlaceHolderID.val(PlaceHolderID);
        $('#mdeditefi').modal('toggle');
        //OpenFiledsWin();

    }
</script>
