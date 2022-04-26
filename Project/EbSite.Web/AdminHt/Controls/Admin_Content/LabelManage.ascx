<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabelManage.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.LabelManage" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

            <XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
            <div class="mt10">
     
 <XS:Notes ID="txtLab" runat="server" />
 </div>
            <div class="table-responsive" id="PagesMain">
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField HeaderText="标签名称">
                            <ItemTemplate>
                                <a target="_blank" href="<%#EbSite.Base.Host.Instance.TagsSearchList(int.Parse(Eval("id").ToString()),1 ) %>"><%#Eval("TagName") %></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="关联内容数量" DataField="Num" />

                        <asp:BoundField HeaderText="标签ID" DataField="ID" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>

                                <XS:EasyuiDialog ID="wbModify" runat="server" Text="修改" Title="修改" />
                                <XS:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DeleteModel" confirm="true" Text="删除"></XS:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="30" HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                            <ItemTemplate>
                                <asp:CheckBox ID="Selector" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </XS:GridView>
            </div>
            <XS:PagesContrl ID="pcPage" Linktype="Aspx" runat="server" />
            <div>
                <asp:Label ID="lbInfo" runat="server"></asp:Label>
            </div>
        </div>
    </div>

<div class="modal fade" id="divMerge" tabindex="-1" role="dialog"  aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" >合并标签</h5>
        <button type="button" class="close" data-dismiss="modal" >
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <table>

                    <tr>
                        <td colspan="4">把两标签及内容合并为一个,将保留目标标签名称
                        </td>
                    </tr>
                    <tr>
                        <td>源标签ID
                        </td>
                        <td>
                            <XS:TextBox ID="txtID" Width="50" runat="server">0</XS:TextBox>
                        </td>
                        <td>目标标签ID
                        </td>
                        <td>
                            <XS:TextBox ID="txtTargetID" Width="50" runat="server">0</XS:TextBox>
                        </td>
                    </tr>
                </table>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">关闭</button>
        <button type="button" class="btn btn-primary">保存</button>
      </div>
    </div>
  </div>
</div>
         
<%--<div class="modal" id="divMerge" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog" style="width: 350px;">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">合并标签</h4>
            </div>
            <div style="height: 100px;" class="modal-body">
                
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                <button type="button"  class="btn btn-primary">提交更改</button>
            </div>
        </div>
    </div>
</div>--%>


<XS:Button Style="display: none;" ID="btnMerge" IsButton="true" runat="server" Text="" OnClick="btnMerge_Click" />

<script>
    function OnMerge() {

        if (confirm('确认要合并标签吗？')) {
            $("#<%=btnMerge.ClientID %>").click();

            }
        }
        
</script>
