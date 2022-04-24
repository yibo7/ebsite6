<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Address.AddressList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
                <div class="gdList_title" >
                  <div style="width:40px; ">序号</div> 
                  <div style="width:100px;">收货人姓名</div>
                  <div style="width:80px;">邮编</div>
                  <div style="width:120px;">电话</div>
                  <div style="width:60px;">手机</div>
                  <div style="width:300px;">地址</div>
                  <div style="width:100px;">操作</div>
                </div>         
                 <XS:Repeater ID="gdList" runat="server">            
                <itemtemplate>    
                        <div class="gdListContent" >
                          <div style="width:40px; "><%# Container.ItemIndex+1 %> </div> 
                          <div style="width:100px;"><%# Eval("UserRealName")%></div>
                          <div style="width:80px;">&nbsp;<%# Eval("PostCode")%></div>
                          <div style="width:120px;">&nbsp;<%# Eval("phone")%></div>
                          <div style="width:60px;">&nbsp;<%# Eval("Mobile")%></div>
                          <div style="width:300px;"><%# Eval("AddressInfo")%></div>
                          <div style="width:100px;"><a href="<%#ModifyBoxUrl(Eval("id").ToString()) %>">修改</a>  
                          <a onclick="return confirm('确认要删除所选项吗？');"  href="<%#DelUrl(Eval("id").ToString()) %>">删除</a>
                        </div>    
                     </itemtemplate>
                </XS:Repeater>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
<script type="text/javascript">
    function removeItem(obj) {
        if (confirm('确认要删除所选项吗？')) {
            var id = $(obj).attr("tid");
            runws("DeleteAddress", { "id": id }, function (data) {
                if (data.d == "1") {
                    $(obj).parent("div").parent("div").remove();
                }
                else {
                    tips("删除失败,请重新操作!", 3, 2);
                }
            });
        }
    }
    function OpenAddPage() {
        window.location.href = "?mukey=2517cc88-cbb5-4b00-ac5c-32285c9b9889";
    }
</script>