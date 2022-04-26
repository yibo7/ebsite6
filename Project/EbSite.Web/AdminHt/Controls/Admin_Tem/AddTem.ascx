<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTem.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Tem.AddTem" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    <fieldset>
        <legend><asp:Label runat="server" ID="tlName"></asp:Label></legend>
        <div>
            <table>
                <tr>
                    <td>
                        <%=Resources.lang.EBTmeplateName%>:
                    </td>
                    <td>
                        <XS:TextBoxVl IsAllowNull="false" ID="txtTemName" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <%=Resources.lang.EBTemClass%>:
                    </td>
                    <td>
                        <asp:DropDownList ID="drpClass" AppendDataBoundItems="true" runat="server">
                            <asp:ListItem Text="<%$Resources:lang,EBAll%>" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBAppType%>:
                    </td>
                    <td>
                        <div style="float: left;">
                            <XS:DropDownList ID="drpTemClass"  AppendDataBoundItems="true" runat="server"   ValidationGroup="AA">
                            </XS:DropDownList>
                        </div>
                       <%-- <div id="DModel" style="float: left; ">
                            <asp:DropDownList ID="drpModel" AppendDataBoundItems="true" runat="server"  Visible=false>
                            </asp:DropDownList>
                        </div>--%>
                   
                    </td>
                </tr>
                <div id="ModifyDiv" runat="server">
                
                <tr>
                    <td>
                        <%=Resources.lang.EBTempFileName%>：
                    </td>
                    <td>
                        <XS:TextBox Width="150" HintInfo="不带后缀,如index.aspx,只写 index" Visible="false" ID="txtTemFileName"
                            runat="server"></XS:TextBox>
                        <asp:CheckBox ID="cbRandName" Checked="true" AutoPostBack="true" Text="<%$Resources:lang,EBRandomName%>"
                            runat="server" OnCheckedChanged="cbRandName_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBBaseDefTem%>：
                    </td>
                    <td>
                        <asp:CheckBox ID="cbDefualtTem" runat="server" />
                    </td>
                </tr>
                </div>
                <tr>
                    <td colspan="2" style="text-align: center; height: 50px;">
                        <XS:Button ID="bntSave" runat="server" Text=" <%$Resources:lang,EBSave%> " ValidationGroup="BB"/>
                        <asp:CheckBox ID="cbAddToEdit" Checked="true" Text="<%$Resources:lang,EBAftAdded%>"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</div>
<%--<script>

    window.onLoad = new function () {
        $("#DModel").css("visibility", "hidden");
        $("#DMClass").css("visibility", "hidden");
    }


</script>--%>
