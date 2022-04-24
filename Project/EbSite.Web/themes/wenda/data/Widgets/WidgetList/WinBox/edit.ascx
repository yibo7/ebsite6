<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.WinBox.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <style>
  .CTDTTabs{ border-left:solid 1px #ccc; text-align:center; height:23px; line-height:23px;
            border-top:solid 1px #ccc; cursor:pointer; background-color:#FEFFBF; border-right:solid 1px #ccc; margin-left:5px; padding-right:5px; }
 
 .CTDTTabs_On{ border-left:solid 1px #ccc; text-align:center; height:23px; line-height:23px;
            border-top:solid 1px #ccc; background-color:#fff; border-right:solid 1px #ccc; margin-left:5px; padding-right:5px; }
 
 
 </style>
<table width="100%" border="0"  cellpadding=0 cellspacing=0 >
    <tr>
        <td id="CustomDataTableTags"  style=" height:30px; vertical-align:bottom">
            <div id="tagsdiv0" name="tbAddData" >
                添加数据                          
            </div>
            <div id="tagsdiv1" name="tbSetConfigs">
                部件配置                           
            </div>
        </td>
    </tr>
    <tr>
        <td style=" border:solid 1px #D1D9DE; padding-bottom:30px; vertical-align:top; height:500px; width:800px;">
                <table id="tbAddData">
                     <tr><td colspan="2">添加表单:</td></tr> 
                     <tr>
                        <td >标题:</td>
                        <td >
                            <XS:TextBox ID="txtTitle" runat="server"></XS:TextBox></td>
                     </tr> 
                     <tr>
                        <td >连接地址:</td>
                        <td ><XS:TextBox ID="txtUrl" runat="server"></XS:TextBox></td>
                     </tr>
                     <tr runat="server" id="trUrlPic">
                        <td >连接图片:</td>
                        <td ><XS:TextBox ID="txtUrlPic" runat="server"></XS:TextBox></td>
                     </tr>
                     <tr>
                        <td colspan="2" style="height:50px; line-height:50px; padding-left:150px; ">
                            <XS:Button ID="bntAddOne" runat="server" Text=" 添 加 " 
                            onclick="bntAddOne_Click" />
                        </td>
                      </tr> 
                        
                        <tr><td colspan="2">
                        
                        
                        <XS:GridView ID="gvData" runat="server"                            
                                    DataKeyNames="id"                                                                   
                                  AutoGenerateColumns="False" 
                                  EnableViewState="true"
                                   IsShowSWPages="false"    
                                   onrowcommand="gvData_RowCommand"  
                                    Width="800"                 
                            >                             
                              <Columns>                            
                                   <asp:BoundField HeaderText="标题" DataField="Title" />
                                    <asp:BoundField HeaderText="连接地址" DataField="Url" /> 
                                    <asp:BoundField HeaderText="连接图片" DataField="UrlPic" />                                 
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>       
                                                    <XS:LinkButton  ID="LinkButton2" CommandArgument='<%#Eval("id") %>' CommandName="modifymodel" Text="修改" confirm="false" runat="server"></XS:LinkButton>
                                                    <XS:LinkButton  ID="LinkButton1" CommandArgument='<%#Eval("id") %>' CommandName="deletemodel" Text="删除" runat="server"></XS:LinkButton>
                                    
                                         </ItemTemplate>
                                   </asp:TemplateField>     
                                 
                            </Columns>                           
                            
                        </XS:GridView>
                                             
 
                        </td></tr>
                        
                         
                </table>
                
                
                <table id="tbSetConfigs" >
                      <tr >
                        <td >窗口名称:</td>
                        <td ><XS:TextBox ID="txtWindowsTitle" HintInfo="可以为空，将以连接的标题为窗口名称" runat="server"></XS:TextBox></td>
                     </tr>
                    <tr>
                        <td>展示模板:</td>
                        <td>
                            <XS:DDLCtrTem   ID="drpTem" runat="server"></XS:DDLCtrTem>
                        </td>
                    </tr>
                     <tr>
                         <td>
                            打开的文件类型:
                         </td>
                         <td >
                         <XS:DropDownList ID="drpType" runat="server">
                            <asp:ListItem Value="1" Text="图片"></asp:ListItem>
                            <asp:ListItem Value="2" Text="页面"></asp:ListItem>
                         </XS:DropDownList>
                         </td>
                     </tr>
                     <tr>
                         <td>
                            展示组:
                         </td>
                         <td >
                         <XS:DropDownList ID="drpGroup" runat="server">
                            <asp:ListItem Value="1" Text="显示所有连接"></asp:ListItem>
                            <asp:ListItem Value="2" Text="只列一个连接"></asp:ListItem>
                         </XS:DropDownList>
                         (显示所有连接,则每条记录将显示一个连接)
                         </td>
                     </tr>
                   
                    <tr>
                        <td>超连接模式:</td>
                        <td>
                             <XS:DropDownList ID="drpHrefModel" runat="server">                             
                                <asp:ListItem Value="0" Text="文本连接"></asp:ListItem>
                                <asp:ListItem Value="1" Text="图片连接"></asp:ListItem>
                                <asp:ListItem Value="2" Text="按钮连接"></asp:ListItem>                                
                            </XS:DropDownList>
                            (如果选择图片连接，请添加数据时输入"连接图片")
                        </td>
                    </tr>
                    <tr>
                         <td>
                            是否全屏显示:
                         </td>
                         <td >
                             <asp:CheckBox ID="cbIsFull" runat="server" />
                         </td>
                     </tr>
                     <tr >
                        <td >窗口长:</td>
                        <td ><XS:TextBox ID="txtWidth" Width="50" runat="server"></XS:TextBox></td>
                     </tr>
                     <tr >
                        <td >窗口高:</td>
                        <td ><XS:TextBox ID="txtHeight" Width="50" runat="server"></XS:TextBox></td>
                     </tr>
                     <tr>
                        <td colspan="2" style="text-align:center">
                             <XS:Button ID="bntSave" runat="server" Text=" 保 存 " onclick="bntSave_Click" />
                        </td>
                     </tr>
                 </table>
        </td>
    </tr>
</table>
 
 <script>
 var Tags_CustomDataTable = new CustomTags();

function InitCustomDataTableTags()
{
      Tags_CustomDataTable.ParentObjName = "CustomDataTableTags";
      Tags_CustomDataTable.SubObj = "div";
      Tags_CustomDataTable.CurrentClassName = "CTDTTabs_On";
      Tags_CustomDataTable.ClassName = "CTDTTabs";   
      Tags_CustomDataTable.fun = function(){OnTags_Tags_CustomDataTable(this)};   
      Tags_CustomDataTable.InitOnclickInTags();
      
      Tags_CustomDataTable.InitOnclick(0);
}
function OnTags_Tags_CustomDataTable(obj)
{  
    Tags_CustomDataTable.OnclickTags(obj);  
    
     
   // $(MenuTile).text(obj.innerText);
}
 InitCustomDataTableTags();
 </script>
 

