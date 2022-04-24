<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FieldSearchAdv.ascx.cs" Inherits="EbSite.ModulesGenerate.FieldSearchAdv" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div id="PagesMain">
<XS:Warning ID="Notes"  Text="这里是高级查询，请注意所选字段不能和简单查询所选字段重复。"  runat="server"></XS:Warning>
    <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false" DataKeyNames="colorder" onrowdatabound="gdList_RowDataBound">
        <columns>
            
            <asp:TemplateField HeaderText="字段名称">
                <ItemTemplate>
                  <asp:Label runat="server" id="columID" Text='<%#Eval("columnname") %>'></asp:Label>  
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="字段类型">
                <ItemTemplate>
                   <asp:Label runat="server" id="columType" Text='<%#Eval("typename") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <%-- <asp:TemplateField HeaderText="选择控件">
                <ItemTemplate>
                <XS:DropDownList runat="server" ID="SelectControlID" Width="100px">
               <asp:ListItem  value="1">文本控件</asp:ListItem>
                <asp:ListItem  value="2">时间控件</asp:ListItem>
               </XS:DropDownList>
              
                </ItemTemplate>
            </asp:TemplateField>--%>
             <asp:TemplateField HeaderText="匹配模式">
                <ItemTemplate>
                   <XS:DropDownList runat="server" ID="SelectMatch" Width="100px">
               <asp:ListItem  value="0">相等匹配</asp:ListItem>
                <asp:ListItem  value="1">模糊匹配</asp:ListItem>
                <asp:ListItem  value="2">大于</asp:ListItem>
                 <asp:ListItem  value="3">小于</asp:ListItem>
                
               </XS:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="关联模式">
                <ItemTemplate>
                  <XS:DropDownList runat="server" ID="SelectAssociated" Width="100px">
               <asp:ListItem  value="1">与连</asp:ListItem>
               <asp:ListItem  value="0">或者</asp:ListItem>            
               <asp:ListItem  value="2">忽略</asp:ListItem>
               </XS:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)">
                <ItemTemplate>
                    <asp:CheckBox ID="Selector" runat="server" Checked='<%#GetCheckColum(Eval("columnname").ToString()) %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
        </columns>
    </XS:GridView>
</div>
<div style="text-align: center; clear: both; margin-top: 5px;">
    <XS:Button ID="bntOK" runat="server" Text=" 确 认 " onclick="bntOK_Click" />
</div>
