<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MergeClass.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.MergeClass" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:Notes runat="server" Text="合并分类后将删除源分类与它的子分类" />
<br />
<XS:Notes runat="server" ID="Notes1" Text="分类的合并包括源分类下的所有数据及其子分类下所有数据" />
<br />
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>合并分类</legend>
            <div style="height: 30px; line-height: 30px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <%-- <%=Resources.lang.EBSourceClass%>: <XS:ExtensionsCtrls ID="mdClassListSour"   ModelCtrlID="5c125a7b-d5f1-4c7a-aecd-03955c982529" runat="server"/>
                          
                            --%>
                            选择源分类:
                            <XS:DropDownList ID="drpSoure" runat="server">
                            </XS:DropDownList>
                        </td>
                        <td>
                            <%-- <%=Resources.lang.EBTargetClass%>:  <XS:ExtensionsCtrls ID="mdClassListTarget"   ModelCtrlID="5c125a7b-d5f1-4c7a-aecd-03955c982529" runat="server"/>
                            --%>
                            目标分类:
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
    <XS:Button ID="bntSave" runat="server" Text=" <%$Resources:lang,EBSave%> "></XS:Button>
</div>
