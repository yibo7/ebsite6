<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_WelCome.Index" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div>
    <div class="btn-group float-right" role="group" aria-label="Basic example">
    <button type="button" data-toggle="modal" data-target="#addMenu" class="btn btn-success">
        <i class="bi bi-plus-square"></i> 添加菜单
    </button>
         <button type="button"  onclick="paixi()" class="btn btn-secondary">
        <i class="bi bi-filter-circle"></i> 排序
    </button>
    <button type="button" id="menuok" onclick="editmenu()" class="btn btn-warning">
        <i class="bi bi-x-square"></i> 删除菜单
    </button>
        
</div>
</div>

<div id="ulFastMenu" class="row row-cols-3">
            <XS:Repeater ID="rpList" runat="server">
                <ItemTemplate>
                    <div style="padding:8px;" class="col" >
                        <span style="font-size:16px;cursor:pointer">
                            <span id="<%#Eval("id") %>" t="<%#Eval("title")%>" url="<%#Eval("url") %>" ta="<%#Eval("Target") %>"><%#Eval("title")%></span>
                            <i style="display:none" onclick='gc_del("<%#Eval("id") %>")' class="bi bi-x-square"></i> 
                        </span>
                    </div>
                </ItemTemplate>
            </XS:Repeater> 
    </div>

 
<div class="modal fade"  id="addMenu" tabindex="-1"  aria-hidden="true">
  <div  class="modal-dialog " >
    <div  class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">添加菜单</h5>
        <button type="button" class="close" data-dismiss="modal" ><span aria-hidden="true">&times;</span></button>
      </div>
      <div  class="modal-body">
                <form class="form-inline">
                    <label>菜单名称</label>
                    <XS:TextBoxVl ValidateType="禁止输入特殊字符" Width="200" IsAllowNull="false" ID="txtName" runat="server"></XS:TextBoxVl>
                    <label>菜单地址:</label>
                    <XS:TextBoxVl IsAllowNull="false" ID="txtUrl" Width="300" runat="server"></XS:TextBoxVl>
                    <label>打开方式:</label>
                    <XS:DropDownList Width="130" ID="drpTarget" runat="server">
                        <asp:ListItem Value="0" Text="内部打开"></asp:ListItem>
                        <asp:ListItem Value="1" Text="外部打开"></asp:ListItem>
                    </XS:DropDownList> 
                </form>
      </div>
      <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">关闭</button> 
          <XS:Button ID="btnAddMenuAdd" Text="添加菜单" class="btn btn-primary" runat="server" OnClick="btnAddMenu_Add"></XS:Button>        
      </div>
    </div>
  </div>
</div>
<script>
    $(document).ready(function () {
        $("#ulFastMenu>div>span>span").bind('click', function (event) {
            event.stopPropagation();
            if ($(this).attr("ta") == "1") { //外部打开
                window.open($(this).attr("url"));
            }
            else {
                window.location = $(this).attr("url");
            }

        });
    }); 
    //编辑
    function editmenu() {

        $("#ulFastMenu>div>span>i").toggle();
    }

    function gc_del(obj) {
        <%--$("#ulFastMenu>li").unbind();
        $("#ulFastMenu>li").bind('click', function (event) {
            $("#<%=txtName.ClientID%>").val($(this).attr("t"));
            $("#<%=txtUrl.ClientID%>").val($(this).attr("class"));
            $("#<%=drpTarget.ClientID%>").val($(this).attr("ta"));


        });--%>
        var result = confirm('确定要删除吗?');
        if (result) {
            var pram = { "id": obj };
            runadminws("DelFastMenus", pram, delecomp);

        }
    }
    function delecomp(result) {
        var rt = result.d;
        if (rt.Success) {
            //alert("删除成功!");

            Refesh();
        }
        else
            alert("删除失败!" + rt.Message);
    }
    function paixi() {
        OpenIframe('Admin_ModalDlg.aspx?t=0','排序菜单','保存')
    }
</script>
