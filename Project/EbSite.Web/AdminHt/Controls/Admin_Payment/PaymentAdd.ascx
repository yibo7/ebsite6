<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.PaymentAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>

<asp:PlaceHolder ID="phCtrList" runat="server">
    <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加支付方式</h3>
            </div>
            <div class="content">
				 <table >
                    <tr>
                        <td>
                            支付插件:
                        </td>
                        <td>
                          
                            <XS:DropDownList ID="PaymentApi" HintInfo="如果您是开发人员还可以开发自己的支付插件，详见ebsite的插件开发"  runat="server"></XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                支付方式名称:
                        </td>
                        <td>                    
                            <XS:TextBox Width="300" ID="PaymentName" runat="server"></XS:TextBox>
                        </td>
                     </tr>   
                     <tr>
                        <td>
                               手续费:
                        </td>
                        <td>                    
                            是否百分比:<XS:CheckBox ID="IsPercent" HintInfo="这里不选上，增减费用值为指定数额，如果选上，增减费用值为百分数，结算时将以定单金额为基数计算手续费" runat="server" />
                            
                           增减费用值: <XS:TextBox Text="0" ID="UseMoney" Width="50" HintInfo=" 支付手续费(正数)，或免除费用（负数）,一般情况下为正数，但如果您为了鼓励客户使用某种支付方式，也可以使用负数，将在结算时减少指定数额" runat="server"></XS:TextBox>
                        </td>
                     </tr>   
                      
                     <tr>
                        <td>
                                是否用于预付款:
                        </td>
                        <td>                    
                           <XS:CheckBox ID="IsUseInpour" HintInfo="如果选上，在预付款充值时可以选择此支付方式" runat="server" />
                        </td>
                     </tr>   
                      <tr>
                        <td>
                                是否开启:
                        </td>
                        <td>                    
                           <XS:CheckBox Checked="true"  ID="IsOpend" HintInfo="默认为开启,当你暂时不想使用此支付方式时，可以不选此项，当然您也可以删除，但为了方便您以后再次使用，可以选择不开启" runat="server" />
                        </td>
                     </tr>   
                     <tr>
                        <td>
                                展示图片:
                        </td>
                        <td>                    
                           <XS:SWFUpload ID="ShowImg" AllowExt="jpg,png,gif"  AllowSize="300"   runat="server" />
                           
                        </td>
                     </tr>   
                       <tr>
                        <td>
                                支付方式分类:
                        </td>
                        <td>                    
                           
                             <XS:DropDownList  ID="ClassID"  runat="server"></XS:DropDownList> 
                        </td>
                     </tr>   
                       <tr>
                        <td>
                                简称:
                        </td>
                        <td>                    
                          
                            <XS:TextBox Width="300" ID="ShortName" runat="server"></XS:TextBox>
                        </td>
                     </tr>   
                       
                      <tr>
                        <td>
                                备注:
                        </td>
                        <td>                    
                            <XS:TextBox TextMode="MultiLine" Width="500" Height="100" ID="Demo" runat="server"></XS:TextBox>
                        </td>
                     </tr>              
                </table>
            </div>
    </div>
</div>
 
</asp:PlaceHolder> 

<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " ValidationGroup="BB"/>
</div>
    
 
