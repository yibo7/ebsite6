<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.SearchKeepWord.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>
<div id="tagsdiv0" name="tbAddData" >
                <table id="tbAddData">
                     <tr><td colspan="2">输入以下信息:</td></tr> 
                        <tr>
                            <td>标题</td>
                            <td>
                            <XS:TextBox ID="txtTitle" Width="100" HintInfo="可以在绑定列表时调用" runat="server" ></XS:TextBox>
                            
                            </td>
                        </tr>
                        <asp:PlaceHolder ID="phCustomControls" runat="server"></asp:PlaceHolder>
                        <tr>
                            <td>页面名称</td>
                            <td>
                            http://网站域名/<%=DataID%>-(记录唯一编号)-1/
                            <XS:TextBox ID="txtReWritePath" Width="100" HintInfo="带页面后缀，最好是纯英文字母与数字组合，如taobao.aspx" runat="server" ></XS:TextBox>
                           
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
                                                       
                                                       Width="800" onrowediting="gvData_RowEditing" onrowdeleting="gvData_RowDeleting"                  
                                                >                             
                        </XS:GridView>
                                             
 
                        </td></tr>
                        
                         
                </table>                          
            </div>
            <div id="tagsdiv1" name="tbSetConfigs">
                <table id="tbSetConfigs" >
                    <tr>
                        <td>面页模板:</td>
                        <td>
                        <XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>
                                    
                        （您要是一次性列表出来，并且要自定义模板，可以这里设置）
                        </td>
                    </tr>
                     
                    <tr>
                        <td>选择部件:</td>
                        <td>
                            <XS:DropDownList ID="drpWidgets" runat="server"></XS:DropDownList>
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
