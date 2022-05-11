<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Widget.ClassAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改分类</h3>
            </div>
            <div class="eb-content">
				 <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            分类名称:
                        </td>
                        <td>
                            <XS:TextBox ID="txtTile" runat="server" CanBeNull="必填">
                            </XS:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            备注:
                        </td>
                        <td>
                            <XS:TextBox ID="txtDescription" runat="server"  Height="100" TextMode="MultiLine"
                                Width="300">
                            </XS:TextBox>
                        </td>
                    </tr>
                    
                </table>
            </div>
    </div>
</div>
    
</asp:PlaceHolder>
<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server" Text=" 保 存 "></XS:Button>
 <XS:Button ID="btnColseGreyBox" runat="server" Text=" 取 消 "></XS:Button>
</div>
 
<style>td{ padding: 5px;}</style>