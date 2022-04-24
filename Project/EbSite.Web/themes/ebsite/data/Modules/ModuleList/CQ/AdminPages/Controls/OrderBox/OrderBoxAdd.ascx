<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderBoxAdd.ascx.cs" Inherits="EbSite.Modules.CQ.AdminPages.Controls.OrderBox.OrderBoxAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="admin_toobar">
        <fieldset>
            <legend>添加/修改信息</legend>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            步骤名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="Title" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            客服话语:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="Tips" Width="500"  TextMode="MultiLine" height="50" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            操作提示语:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="Seltip" Width="500"  TextMode="MultiLine" height="50" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            用户话语:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="Utem" Width="500"   TextMode="MultiLine" height="50" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            选项来源:
                        </td>
                        <td>   
                            <asp:DropDownList ID="StepType" runat="server"  >
                                <asp:ListItem Value="1" Text="源于上级选项请求分类ID"></asp:ListItem>
                                <asp:ListItem Value="2" Text="设置分类父ID"></asp:ListItem>
                                <asp:ListItem  Value="100" Text="文本输入"></asp:ListItem>
                            </asp:DropDownList>          
                           
                             <br /> 
                            <XS:TextBoxVl ID="DefaultParentClassID"     Width="200" HintInfo="请设置第一步的分类数据源父ID,可以是多个ID，如 1,2,3,一般情况下为一个ID，如1"  IsAllowNull="false" runat="server"   >0</XS:TextBoxVl>   
                             <br /> 
                             数据表:
                             <asp:DropDownList ID="SoureTable" runat="server"  >
                                <asp:ListItem Value="1" Text="EbSite分类表newclass"></asp:ListItem>
                                <asp:ListItem Value="2" Text="订单宝自定义选项表"></asp:ListItem>
                            </asp:DropDownList>             
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证规则:
                        </td>
                        <td>  
                         <XS:DropDownList   ID="ValidationRule" HintInfo="验证输入规则"  runat="server">
                            <asp:ListItem Value="0">不验证</asp:ListItem>
                            <asp:ListItem Value="1">手机验证</asp:ListItem>
                         </XS:DropDownList>                   
                        </td>
                    </tr>
                      <tr>
                        <td>
                            输入可否为空:
                        </td>
                        <td>  <XS:RadioButtonList HintInfo=" 文本输入是否允许为空  0：不允许 1：允许" ID="IsNullText" runat="server" RepeatDirection="Horizontal">
                              <asp:ListItem Value="0">不允许</asp:ListItem>
                              <asp:ListItem Value="1">允许</asp:ListItem>
                            </XS:RadioButtonList>      
                        </td>
                    </tr>
                    <tr>
                        <td>
                            关联字段:
                        </td>
                        <td>    
                         <XS:TextBoxVl ID="FieldName" HinfInfo="对应主站 北迈模块Order表的字段" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>                    
                           
                        </td>
                    </tr>
                     <tr>
                        <td>
                            排序:
                        </td>
                        <td>                        
                            <XS:TextBoxVl ID="OrderID" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:PlaceHolder>
<div style="text-align: center">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div> 
