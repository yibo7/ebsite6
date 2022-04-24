<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetBoxStyleAdd.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace.WidgetBoxStyleAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
   <div class="row m-t-15">
    <div class="col-sm-12">
        <div class="card-box">
           <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            样式名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="StyleName" IsAllowNull="false" runat="server"  ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            样式模板:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="StyleTemp" runat="server"    IsAllowNull="false" TextMode="MultiLine" height="200" width="500"  ></XS:TextBoxVl>
                        </td>
                    </tr>
                    
                     
                   <%-- <tr>
                        <td>
                            适用皮肤:
                        </td>
                        <td>
                            <XS:DropDownList ID="CopyThemeID" runat="server">
                            </XS:DropDownList>
                        </td>
                    </tr>

                     <tr>
                        <td>
                            类别:
                        </td>
                        <td>
                         <XS:DropDownList ID="StyleClass" runat="server">
                         </XS:DropDownList>
                             
                        </td>
                    </tr>--%>
                     <tr>
                        <td>
                            颜色选择控件参数:
                        </td>
                        <td>
                             <XS:TextBoxVl HintInfo="说明：边框颜色|标题背景色|内容背景色 在模板里这样获取对应的颜色 {边框颜色} {标题背景色} {内容背景色}" ID="StyleColorPram"  runat="server" width="400" ></XS:TextBoxVl>
                             
                        </td>
                    </tr>
                    <tr>
                        <td>
                            下拉列表控件参数:
                        </td>
                        <td>
                        
                             <XS:TextBoxVl ID="CustomDropDownListPram" HintInfo="说明：参数格式为 风格=列表项名称1&列表项值1,列表项名称2&列表项值2|渐变方向=列表项名称1&列表项值1,列表项名称2&列表项值2 ; 在模板里这样获取对应的选项值 {风格} {渐变方向} "  runat="server" width="400" ></XS:TextBoxVl>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            文本输入控件参数:
                        </td>
                        <td>
                        
                             <XS:TextBoxVl ID="CustomTextBoxPram" HintInfo="说明：参数格式为 显示标题1=模式*高*宽*说明|显示标题2=模式*高*宽*说明;在模板里这样获取对应的选项值 {显示标题1} {显示标题2}，说明可以不填写;其中有模式 0代表单行文本框，1代表多行文件框  "  runat="server" width="400" ></XS:TextBoxVl>
                        </td>
                    </tr>
                   
                    
                </table>
        </div>
    </div>
</div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
    
</div>
