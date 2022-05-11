<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrInfoAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Log.ErrInfoAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改信息</h3>
            </div>
            <div class="eb-content">
				 <asp:PlaceHolder ID="phCtrList" runat="server">
                <table>
                    <tr>
                        <td>标题:
                        </td>
                        <td>

                            <XS:TextBoxVl ID="Title" IsAllowNull="false" runat="server"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>提示内容:
                        </td>
                        <td>
                            <XS:Editor Width="600px" ID="ErrMsg" Height="200" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>是否可以删除:
                        </td>
                        <td>
                            <XS:CheckBox ID="IsSys" Enabled="false" Checked="true" runat="server" />
                        </td>
                    </tr>

                </table>
            </asp:PlaceHolder>
            </div>
    </div>
</div>
<div class="text-center mt10">    
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " />
</div>