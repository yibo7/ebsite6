<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.CustomDataTable.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>
<div id="tagsdiv0"  >
                 <table >
                         <tr><td colspan="2">数据录入:</td></tr> 
                        <asp:PlaceHolder ID="phCustomControls" runat="server"></asp:PlaceHolder>
                     <tr>
                        <td colspan="2" style="height:50px; line-height:50px; padding-left:150px; ">
                            <XS:Button ID="bntAddOne" runat="server" Text=" 添 加 " 
                            onclick="bntAddOne_Click" />
                            
                            <asp:CheckBox ID="cbIsUpdateDate" Visible="false" Text="是否更新日期" runat="server" />
                        </td>
                      </tr> 
                        
                        <tr><td colspan="2">
                        
                        <XS:GridView ID="gvData" runat="server"                            
                                                       DataKeyNames="id"                                                                   
                                                       AutoGenerateColumns="False" 
                                                       EnableViewState="true"
                                                       IsShowSWPages="false"    
                                                       
                                                       Width="800" onrowediting="gvData_RowEditing" onrowdeleting="gvData_RowDeleting"                  
                                                >                             
                        </XS:GridView>
                                             
 
                        </td></tr>
                        
                         
                </table>                          
            </div>
            <div id="tagsdiv1" name="tbSetConfigs">
                 <table id="tbSetConfigs" >
                    <tr>
                        <td>数据模板:</td>
                        <td>
                        <XS:ExtensionsCtrls ID="drpTemList"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>
                                    
                        </td>
                    </tr>
                     <tr><td colspan="2">数据表字段设置:<br>注,每行表示一列的配置，格式为：字段展示名称|字段调用名称|控件ID|是否只读（可选）</td></tr>
                     <tr><td colspan="2">
                     <XS:TextBox ID="txtFileds" Width="500" TextMode="MultiLine" Height="200"  
                             runat="server" ></XS:TextBox>

                     </td>
                     </tr>
                     <tr>
                        <td colspan="2" style="text-align:center">
                             <XS:Button ID="bntSave" runat="server" Text=" 保 存 " onclick="bntSave_Click" />
                        </td>
                     </tr>
                 </table>                           
            </div>
<asp:Literal ID="llTagEnd" runat="server"></asp:Literal>
