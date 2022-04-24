<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.CustomWord.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改信息</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            常用语:
                        </td>
                        <td>
                            <XS:TextBoxVl   ID="ServiceName" IsAllowNull="false" runat="server"   TextMode="MultiLine"   Width="400px" Height="100"></XS:TextBoxVl>
                        </td>
                        
                    </tr>  
                     <tr>
                        <td>
                            排序:
                        </td>
                        <td>
                            <XS:TextBoxVl   ID="OrderID" IsAllowNull="false" runat="server"     Width="400px" ></XS:TextBoxVl>
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
