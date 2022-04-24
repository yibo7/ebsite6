<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomItemAdd.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.Options.CustomItemAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改信息</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            父级选项:
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true" ID="ParentID" runat="server">
                                <asp:ListItem Value="0" Text="一级选项"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                    </tr>  
                    
                    <tr>
                        <td>
                            选项名称:
                        </td>
                        <td>
                            <XS:TextBoxVl   ID="ItemName" IsAllowNull="false" runat="server"      Width="300px" ></XS:TextBoxVl>
                        </td>
                        
                    </tr>  
                     <tr>
                        <td>
                            排序:
                        </td>
                        <td>
                            <XS:TextBoxVl   ID="OrderID" IsAllowNull="false" runat="server"     Width="50px" ></XS:TextBoxVl>
                        </td>                        
                    </tr>  
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div> 
