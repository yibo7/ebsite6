<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FieldSearch.ascx.cs"
    Inherits="EbSite.ModulesGenerate.FieldSearch" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div id="PagesMain">
<XS:Warning ID="Notes"  Text="这里是简单查询，请注意所选字段不能和高级查询所选字段重复。"  runat="server"></XS:Warning>
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
           <%-- <asp:TemplateField HeaderText="关联模式">
                <ItemTemplate>
                  <XS:DropDownList runat="server" ID="SelectAssociated" Width="100px">
               <asp:ListItem  value="0">或者</asp:ListItem>
                <asp:ListItem  value="1">与连</asp:ListItem>
                <asp:ListItem  value="2">忽略</asp:ListItem>
               </XS:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="选　择">
                <ItemTemplate>
                <asp:RadioButton  id="Selector"   runat="server" Checked='<%#GetCheckColum(Eval("columnname").ToString()) %>'></asp:RadioButton>     
               
                </ItemTemplate>
            </asp:TemplateField>
            
        </columns>
    </XS:GridView>
</div>
<div style="text-align: center; clear: both; margin-top: 5px;">
    <XS:Button ID="bntOK" runat="server" Text=" 确 认 " onclick="bntOK_Click" />
</div>
<script type="text/javascript">
    var last = null;
    function single(obj) {
        if (last == null)    //第一次选择RadioButton时赋id值给last 
        {
            last = obj.id;
        }
        else            //第一次以后的每一次都在这运行，把上此的RadioButton.Checked=false,记下此次的obj.name 
        {
            var lo = document.getElementById(last);
            lo.checked = false;
            last = obj.id;
        }
        obj.checked = "checked";   //添加checked属性，以便在上边赋值为false 
    } 
    </script> 

