<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MergeSpecialBak.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.MergeSpecialBak" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:Notes Text="合并专题后将删除源专题与它下的子分类"   runat=server></XS:Notes>
<br />
<XS:Notes ID="Notes1" Text="专题的合并包括源专题下的所有数据及其子专题下所有数据"   runat=server></XS:Notes>
<br />
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>合并专题</legend>
            <div style=" height:30px;  line-height:30px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                              选择源专题: 
                            <XS:DropDownList ID="drpSoure" runat="server">
                            </XS:DropDownList>
                          
                        </td>
                        <td>
                            目标专题:  
                            
                             <XS:DropDownList ID="drpTarget" runat="server">
                            </XS:DropDownList>
                        </td>
                    </tr>
                 
                  
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server" Text=" 保 存 "></XS:Button>
</div>