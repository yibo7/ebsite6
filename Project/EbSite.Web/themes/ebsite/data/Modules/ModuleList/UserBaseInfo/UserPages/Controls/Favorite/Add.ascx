<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <table class="link-addtd" cellpadding="0" cellspacing="0" runat="server">
        <tr>
            <td>
                标题:
            </td>
            <td>
                <XS:TextBoxVl ID="txtTitle" IsAllowNull="false" ValidationGroup="bb"  Width="250px" runat="server">
                </XS:TextBoxVl>
            </td>
        </tr>
        <tr>
            <td>
                选择分类:
            </td>
            <td>
                <XS:DropDownList ID="drpClassName" runat="server">
                </XS:DropDownList>
               
                 <a onclick="OpenAddClassDig()"  ><span>创建收藏夹分类 </span></a>
            </td>
        </tr>
      
    </table>

</asp:PlaceHolder>
<div style="text-align: center">
      <XS:Button Style="display: none;" ID="btnAddClass" IsButton="true" runat="server" Text="" OnClick="btnAddClass_Click" ValidationGroup="aa"/>
      <XS:Button  ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="bb"/>
</div>
<div id="divSearchadv" title="创建收藏夹分类" style="width: 250px; height: 150px; display: none">
    <div style="margin-top: 15px; margin-left: 10px;">
        <table cellpadding="0" cellspacing="0" class="CustomTool">
            <tr>
                <td>
                    分类名称:
                </td>
                <td id="trNewClassName">
                    <XS:TextBoxVl ID="txtClassName" IsAllowNull="false"  runat="server"  ValidationGroup="aa">
                    </XS:TextBoxVl>
                </td>
            </tr>
        </table>
    </div>
</div>
<script>
    function OpenAddClassDig() {
        In.ready('dialog', function () {
            OpenDialog_SaveSubmit('divSearchadv', '<%=btnAddClass.ClientID %>', '确认要添加吗?');
        });
        
    } 
</script>
