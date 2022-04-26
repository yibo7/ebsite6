<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlsList.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctr.CtrlsList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>模型控件管理</h3>
            </div>
            <div>
				<XS:ToolBar ID="ucToolBar" runat="server"/>
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="DataID">
                              <Columns> 
                                  <asp:BoundField  HeaderText = "控件名称" DataField="title" />                                  
                                  <asp:BoundField  HeaderText = "控件类别" DataField="TypeWidget" />
                                   <asp:TemplateField HeaderText="控件调用代码">
                                         <ItemTemplate>
                                            
                                            <textarea onclick="oCopy(this)" title="点击复制代码"  style="width:380px; ">
                                                        <%#MakeCoder(Eval("DataID").ToString())%>
                                    </textarea>
                                            
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                               
                                   <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>
                                         <XS:EasyuiDialog ID="WinBox2" runat="server" Href='<%#ModifyUrl(Eval("TypeWidget"),Eval("DataID")) %>'  IsColseReLoad=false  Text="修改" Title="修改" />
                                                    <a href='Admin_Ctr.aspx?t=9&type=<%#Eval("TypeWidget")%>&id=<%#Eval("DataID")%>'>预览</a>
                                         <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("DataID") %>' CommandName="CopyData"
                        confirm="true" Text="复制"></XS:LinkButton>
                                             <XS:LinkButton ID="lbDelete" Visible='<%#Eval("IsNoSysTem")%>' runat="server" CommandArgument='<%#Eval("DataID") %>' CommandName="DeleteModel"
                        confirm="true" Text="删除"></XS:LinkButton>
                                                                                           
                                         </ItemTemplate>

                                   </asp:TemplateField>  
                                 <asp:TemplateField HeaderText="<input id='chAll' onclick='on_check(this)'  type=checkbox />">
                                    <ItemTemplate>
                                        <asp:CheckBox Visible='<%#Eval("IsNoSysTem")%>' ID="Selector" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                            </Columns>                            
</XS:GridView>
            </div>
    </div>
</div>

<div class="modal fade" id="divPutin" tabindex="-1" role="dialog"  aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" >导入控件</h5>
        <button type="button" class="close" data-dismiss="modal" >
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    安装路径:
                </td>
                <td>
                    <asp:Label ID="SetPathUrl" runat="server" Text="/Datastore/Ctrl/"></asp:Label>
                   
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    选择控件文件:
                </td>
                <td>
                    <XS:SWFUpload HintInfo="控件文件以.zip为后缀的文件" ID="txtMdPath" AllowSize="10024" AllowExt="zip"
                        runat="server"  SaveFolder="temp"></XS:SWFUpload>
                </td>
                <td>
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
 
<script>

    function OnCtrTpChange(ob) {

        var ctp = get_selected_value(ob);
        //var ttp = get_selected_value(document.getElementById("<%=drpTemTp.ClientID %>"));
        location.href = "<% =GetUrl%>&ctp=" + ctp;
    }

</script>