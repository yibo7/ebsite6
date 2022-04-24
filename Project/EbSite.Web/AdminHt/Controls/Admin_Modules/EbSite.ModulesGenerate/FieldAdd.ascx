<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FieldAdd.ascx.cs" Inherits="EbSite.ModulesGenerate.FieldAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div id="PagesMain">
<XS:Warning ID="Notes"  Text="请注意：这里添加的模块列表，不能选择主键【id】！"  runat="server"></XS:Warning>
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="colorder"  onrowdatabound="gdList_RowDataBound"  >
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
                    <asp:CheckBox ID="Selector" runat="server"  Checked='<%#GetCheckColum(Eval("columnname").ToString()) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="选择控件">
                <ItemTemplate>
                <XS:DropDownList runat="server" ID="SelectControlID" Width="100px">
               <asp:ListItem  value="1" >文本控件</asp:ListItem>
                <asp:ListItem  value="2" >时间控件</asp:ListItem>
                <asp:ListItem  value="3">文本编辑器</asp:ListItem>
               </XS:DropDownList>
              
                </ItemTemplate>
            </asp:TemplateField>
        </columns>
    </XS:GridView>
</div>
<div style="text-align: center; clear: both; margin-top: 5px;">
    <XS:Button ID="bntOK" runat="server" Text=" 确 认 " onclick="bntOK_Click" />
</div>
