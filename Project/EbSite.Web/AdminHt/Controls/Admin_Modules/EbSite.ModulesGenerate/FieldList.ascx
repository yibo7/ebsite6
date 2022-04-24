<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FieldList.ascx.cs" Inherits="EbSite.ModulesGenerate.FieldList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div id="PagesMain">

<XS:Warning ID="Notes"  Text="请注意：这里显示列表的模块列表，不能选择主键【id】！"  runat="server"></XS:Warning>
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="colorder">
        <columns>
            
            <asp:TemplateField HeaderText="字段名称">
                <ItemTemplate>
                  <asp:Label runat="server" id="columID" Text='<%#Eval("columnname") %>'></asp:Label>  
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="字段类型">
                <ItemTemplate>
                    <%#Eval("typename") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server"  Checked='<%#GetCheckColum(Eval("columnname").ToString()) %>'  />
                </ItemTemplate>
            </asp:TemplateField>
            
        </columns>
    </XS:GridView>
</div>
<div style="text-align: center; clear: both; margin-top: 5px;">
    <XS:Button ID="bntOK" runat="server" Text=" 确 认 " onclick="bntOK_Click" />
</div>
