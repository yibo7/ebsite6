<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.CustomSearch.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="DC" %>
<XS:CustomTagsBox ID="ctbTag" runat="server"></XS:CustomTagsBox>
            <div id="tagsdiv0" name="tbAddData" >
                <table id="tbAddData">
                     <tr><td colspan="2">添加表单:</td></tr> 
                     <tr>
                        <td >表单名称:</td>
                        <td >
                            <XS:TextBox ID="txtFormName" runat="server"></XS:TextBox></td>
                     </tr> 
                     <tr>
                        <td >展示控件:</td>
                        <td >
                            <DC:ModelCtr ID="ExtensionsCtrls"    runat="server"/>
                                         
                        </td>
                     </tr>
                     <tr>
                        <td >搜索对象:</td>
                        <td >
                              表名: <XS:DropDownList ID="drpTableName" runat="server" AutoPostBack="True" 
                                  onselectedindexchanged="drpTableName_SelectedIndexChanged"></XS:DropDownList> 
                               字段:<XS:DropDownList ID="drpColumnList" runat="server"></XS:DropDownList>
                                类型:
                                <XS:DropDownList ID="drpDataType" runat="server">
                                <asp:ListItem Value="0" Text="字符型"></asp:ListItem>
                                <asp:ListItem Value="1" Text="数值类型"></asp:ListItem>
                                <asp:ListItem Value="2" Text="是否型"></asp:ListItem>
                                <asp:ListItem Value="3" Text="日期型"></asp:ListItem>                                
                             </XS:DropDownList>                                 
                        </td>
                     </tr>
                     <tr>
                        <td >搜索条件:</td>
                        <td >
                            <XS:DropDownList ID="drpWhere" HintInfo="选择两者之间，控件的值格式为:值1|值2,text文本则随意，如200元-500元，value值应该为200|500" runat="server">
                                <asp:ListItem Value="0" Text="等于"></asp:ListItem>
                                <asp:ListItem Value="1" Text="大于"></asp:ListItem>
                                <asp:ListItem Value="2" Text="小于"></asp:ListItem>
                                <asp:ListItem Value="3" Text="包含"></asp:ListItem>
                                <asp:ListItem Value="4" Text="两者之间"></asp:ListItem>                                
                             </XS:DropDownList>
                             
                                <XS:DropDownList ID="drpAndOr" HintInfo="此项可以选" runat="server">
                                <asp:ListItem Value="0" Text="选择连接方式"></asp:ListItem>
                                <asp:ListItem Value="1" Text="或者(or)"></asp:ListItem>
                                <asp:ListItem Value="2" Text="与(and)"></asp:ListItem>                               
                             </XS:DropDownList>   
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
                                   <asp:BoundField HeaderText="表单名称" DataField="FormName" />
                                   <asp:BoundField HeaderText="表 名 称" DataField="TableName" />
                                    <asp:BoundField HeaderText="控件ID" DataField="ModelCtrlID" /> 
                                    <asp:BoundField HeaderText="搜索字段" DataField="SearchFiled" />
                                    <asp:BoundField HeaderText="搜索条件" DataField="Where" />                                  
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
            </div>

             <div id="tagsdiv1" name="tbSetConfigs">
                <table id="tbSetConfigs" >
                    <tr>
                        <td>搜索结果页模板:</td>
                        <td>
                        <XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="bdec2947-cc6b-4e9a-abf2-56cb7d77387e" runat="server"/>
                                    
                        </td>
                    </tr>
                     
                     <tr>
                        <td>搜索结果页面:</td>
                        <td>
                            <XS:TextBox ID="txtSoPage" HintInfo="默认为空，但您可以复制多分searchcustom.aspx页面，从而实现不同结果模板"  runat="server"></XS:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>每页显示记录数:</td>
                        <td>
                            <XS:TextBox ID="txtPageSize" Width="80" Text="15" runat="server"></XS:TextBox>
                            条
                        </td>
                    </tr>
                    <tr>
                        <td>窗口打开方式:</td>
                        <td>
                            <XS:DropDownList ID="drpTarget" runat="server">
                                <asp:ListItem Value="_blank" Text="_blank"></asp:ListItem>
                                <asp:ListItem Value="_parent" Text="_parent"></asp:ListItem>
                                <asp:ListItem Value="_search" Text="_search"></asp:ListItem>
                                <asp:ListItem Value="_self" Text="_self"></asp:ListItem>
                                <asp:ListItem Value="_top" Text="_top"></asp:ListItem>
                             </XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>提交按钮类别:</td>
                        <td>
                            <XS:DropDownList ID="drpSubmitType" runat="server">
                                <asp:ListItem Value="submit" Text="按钮"></asp:ListItem>
                                <asp:ListItem Value="image" Text="图片"></asp:ListItem>
                             </XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>提交按钮文本或图片:</td>
                        <td>
                            <XS:ExtensionsCtrls ID="mdSubMitTextOrImgUrl"   ModelCtrlID="f8edab0f-fb25-4d82-ad7d-b84d94ef0434" runat="server"/>
                             <br /> (注,如果上面设置按钮类别为文本，则只输入文本就可以,否则上传图片)      
                        </td>
                    </tr>
                    <tr>
                        <td>提交方式:</td>
                        <td>
                            <XS:DropDownList ID="drpMethod" runat="server">
                                <asp:ListItem Value="get" Text="get"></asp:ListItem>
                                <asp:ListItem Value="post" Text="post"></asp:ListItem>
                             </XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>提交前处理函数:</td>
                        <td>
                            <XS:TextBox ID="txtOnSubmit" HintInfo="可以为空，不处理" runat="server"></XS:TextBox>
                        （js函数）
                        </td>
                    </tr>
                    <tr>
                         <td>
                            搜索数据表配置:
                         </td>
                         <td >
                            格式:<br>
                            表1中文名称|表1英文名称<br>
                            字段1,字段2,字段3...<br>
                            ...<br>
                            表2中文名称|表2英文名称<br>
                            字段1,字段2,字段3...<br>
                            ...<br>
                            <XS:TextBox ID="txtTableConfigs" TextMode="MultiLine" Height="200" Width="500" runat="server"></XS:TextBox>
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
