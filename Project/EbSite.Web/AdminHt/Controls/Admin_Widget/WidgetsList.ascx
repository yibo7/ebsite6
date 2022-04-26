<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetsList.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Widgets.WidgetsList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>部件管理</h3>
            </div>
            <div>
				<XS:ToolBar ID="ucToolBar" runat="server" />
                <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="DataID">
        <Columns>
            <asp:BoundField HeaderText="部件名称" DataField="title" />
            <asp:BoundField HeaderText="部件类别" DataField="TypeWidget" /> 
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <XS:EasyuiDialog ID="wbModify" runat="server" Href='<%#ModifyUrl(Eval("TypeWidget"),Eval("DataID")) %>' LinkOnly="True"
                        Text="修改" Title="修改" />
                    <XS:LinkButton ID="lbDelete" runat="server" Visible='<%#Eval("IsNoSysTem")%>' CommandArgument='<%#Eval("DataID") %>'
                        CommandName="DeleteModel" Text="删除"></XS:LinkButton>
                         <XS:LinkButton ID="lbCopy" runat="server" CommandArgument='<%#Eval("DataID") %>' CommandName="CopyData"
                        confirm="true" Text="复制"></XS:LinkButton>
                     <a target="_blank" href="<%# string.Concat(IISPath,"custompages/getctrhtml.aspx?widgetid=",Eval("DataID"))%>">实时预览</a>
                    <a target="_blank" href="<%# string.Concat(IISPath,"widget/js/",Eval("DataID"),"/")%>">JsApi</a>
                    <a target="_blank" href="<%# string.Concat(IISPath,"widget/txt/",Eval("DataID"),"/")%>">TxtApi</a>
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

<%--<div id="divPutin" title="导入部件"  style="display:none;" >
    <div style=" margin:5px ;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    安装路径:
                </td>
                <td>
                    <asp:Label ID="SetPathUrl" runat="server" Text="/Datastore/widgets/"></asp:Label>
                   
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    选择部件文件:
                </td>
                <td>
                    <XS:SWFUpload HintInfo="部件文件以.zip为后缀的文件" ID="txtMdPath" AllowSize="10024" AllowExt="zip"
                        runat="server"  SaveFolder="temp"></XS:SWFUpload>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
</div>--%>
<script>

    function OnTemTpChange(ob) {

        var ttp = get_selected_value(ob);
        var wtp = get_selected_value(document.getElementById("<%=drpWidgetTp.ClientID %>"));
        location.href = "<% =GetUrl%>&ttp=" + ttp + "&wtp=" + wtp;
    }

    function OnWidgetTpChange(ob) {

        var wtp = get_selected_value(ob);
        var ttp = get_selected_value(document.getElementById("<%=drpTemTp.ClientID %>"));
        location.href = "<% =GetUrl%>&wtp=" + wtp + "&ttp=" + ttp;
    }
    function OnThemeTpChange(ob) {

       
    }
    
</script>
