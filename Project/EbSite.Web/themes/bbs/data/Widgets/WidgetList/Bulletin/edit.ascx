<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.Bulletin.edit" %>
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
                添加公告                          
            </div>
            <div id="tagsdiv1" name="tbSetConfigs">
                部件配置                           
            </div>
        </td>
    </tr>
    <tr>
        <td style=" border:solid 1px #D1D9DE; padding-bottom:30px; vertical-align:top; height:500px; width:800px;">
                <table id="tbAddData">
                     <tr><td colspan="2">公告录入:</td></tr> 
                     
                     <tr>
                        <td >标题:</td>
                        <td >
                            <XS:TextBox ID="txtTitle" runat="server"></XS:TextBox>                                        
                        </td>
                     </tr>
                    
                     <tr>
                        <td >公告信息:</td>
                        <td style="width:500px; height:200px" >
                             <XS:Editor ID="txtInfo"  MenuStatus="Text" runat="server" />                        
                        </td>
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
                                   <asp:BoundField HeaderText="id" DataField="id" />                                 
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
                    <tr>
                        <td >调用记录条数:</td>
                        <td >
                             <XS:TextBox HintInfo="可以为空" ID="txtCount" Visible="false" RequiredFieldType="数据校验"  runat="server"></XS:TextBox>                         
                        </td>
                     </tr>
                      <tr>
                        <td >数据模板:</td>
                        <td >
                            
                        <XS:ExtensionsCtrls ID="drpTemMoreList"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>
                                    
                            (可为空)
                        </td>
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
 


