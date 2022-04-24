<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.AddClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加部件模板分类</h3>
            </div>
            <div class="content">
				<table>
                    <tr>
                        <td>
                            分类名称:
                        </td>
                        <td>
                            <XS:TextBox ID="txtClassTitle" runat="server"></XS:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            分类说明:
                        </td>
                        <td>
                            <XS:TextBox ID="txtClassInfo"  TextMode="MultiLine" Width="200" runat="server"></XS:TextBox>
                        </td>
                        
                    </tr>
                    
                    <tr>
                        <td colspan="2" style="text-align:center; height:50px;">
                            <XS:Button ID="bntSave" Text=" 保 存 " runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
    </div>
</div>