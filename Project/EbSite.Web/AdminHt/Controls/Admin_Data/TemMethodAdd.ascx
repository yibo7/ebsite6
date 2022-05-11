<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemMethodAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Data.TemMethodAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>函数添加/修改</h3>
            </div>
            <div class="eb-content">
                
<asp:PlaceHolder ID="phCtrList" runat="server">
				<table>
                    <tr>
                        <td>
                            函数名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="Title" IsAllowNull="false" runat="server"   Width="300"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            调用代码:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="GetCode" runat="server"   Width="600"  IsAllowNull="false"  ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            调用演示:
                        </td>
                        <td>
                            <XS:TextBoxVl Width="600px" ID="Demo" TextMode="MultiLine" runat="server" Height="200px"> </XS:TextBoxVl>                                                                                            
                        </td>
                    </tr>       
                    
                    <tr>
                        <td>
                            作者:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="Author" runat="server"  Width="50"    ></XS:TextBoxVl>
                        </td>
                    </tr>           
                 
                </table>
    
</asp:PlaceHolder>
            </div>
    </div>
</div>
 
<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " />
</div> 