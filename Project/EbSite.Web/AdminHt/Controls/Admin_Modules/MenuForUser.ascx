<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuForUser.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.MenuForUser" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div class="row m-t-15">
    <div class="col-lg-12">
        <ul class="nav nav-tabs">
            <li class="tab">
                <a href="Admin_Modules.aspx?t=1&mid=<%=GetModuleID %>" >
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">后台管理菜单</span>
                </a>
            </li>
            <li class="active tab">
                <a href="#tg2" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">用户中心菜单</span>
                </a>
            </li> 
        </ul>
        <div class="tab-content">
            <div id="tg2" class="tab-pane active">
                
<XS:ToolBar ID="ucToolBar"  runat="server"></XS:ToolBar>
 
<div class="table-responsive" id="PagesMain">
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" onrowcommand="gdList_RowCommand" >
        <Columns>       
        
 <asp:TemplateField HeaderText="序号"  ItemStyle-Width="50"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                <ItemTemplate>
                   <div style=" text-align:center;">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="菜单名称" ItemStyle-CssClass="gvfisrtTD">
                <ItemTemplate>
                    <%#Eval("PageName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="菜单路径">
                <ItemTemplate>
                    <%#Eval("FileName")%>
                </ItemTemplate>
            </asp:TemplateField>             
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                 <a data-code='<%#MakeCoder(Eval("ParentID").ToString(), Eval("ID").ToString())%>' >链接代码</a>
                  
                 <XS:LinkButton  Visible='<%#IsParentMenu(Eval("ParentID").ToString()) %>' runat="server" CommandArgument='<%#Eval("id") %>'  CommandName="AddToUserMenus"
                        confirm="true" Text="加入用户菜单" ConfirmMsg="确认要加入到用户菜单吗?" />
               
                 <XS:LinkButton  Visible='<%#IsParentMenu(Eval("ParentID").ToString()) %>' runat="server" CommandArgument='<%#Eval("id") %>'  CommandName="RemoveFromUserMenus"
                        confirm="true" Text="移出用户菜单" ConfirmMsg="此操作将从用户菜单表中移出,请谨慎操作。" />
                   
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </XS:GridView>
</div>
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
            </div> 
        </div>
    </div>
</div>
<div class="modal" id="identifier" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog" style="width: 500px;"><!--设置窗口宽-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">复制以下代码到需要引用的地方</h4>
            </div>
            <div style="height: 100px;"  class="modal-body"><!--设置窗口高-->
                 <!--窗体内容-->
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button> 
            </div>
        </div>
    </div>
</div>
<script>
    $(function() {
        $('a[data-code]')
            .click(function() {
                var c = $(this).data("code");
                $(".modal-body").text(c);
                $('#identifier').modal('toggle');
            });
    });
     
</script>