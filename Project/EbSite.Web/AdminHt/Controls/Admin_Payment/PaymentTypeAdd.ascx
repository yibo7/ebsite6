<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentTypeAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Payment.PaymentTypeAdd" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加支付方式类别</h3>
            </div>
            <div class="content">
				  <asp:PlaceHolder ID="phCtrList" runat="server"> 
                <table>
                    <tr>
                        <td>
                            名称:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="Name" IsAllowNull="false" runat="server"  ValidationGroup="BB" ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            排序ID:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="OrderID" IsAllowNull="false" runat="server" ValidateType="匹配正整数"  ValidationGroup="BB" ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            简介:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="Demo"  runat="server" TextMode="MultiLine" Height="50" Width="300"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                                父级:
                        </td>
                        <td>                    
                            <XS:DropDownList  ID="ParentID"  runat="server"></XS:DropDownList> 
                        </td>
                     </tr>--%>
                     
                                     
                                   
                </table>
            
</asp:PlaceHolder>
            </div>
    </div>
</div>
<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " ValidationGroup="BB"/>
</div>
 
