<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.CompanyAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改配送公司</h3>
            </div>
            <div class="eb-content">
                <asp:PlaceHolder ID="phCtrList" runat="server">
				 <table>
                    <tr>
                        <td>
                            公司名称:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="CompanyName" IsAllowNull="false" runat="server"  ValidationGroup="BB" ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                快递100Code:
                        </td>
                        <td>                    
                            <XS:TextBoxVl ID="CompanyCode" IsAllowNull="false" runat="server"  ValidationGroup="BB" ></XS:TextBoxVl>
                        </td>
                     </tr>   
                        <tr>
                        <td>
                                快递官方网站:
                        </td>
                        <td>                    
                            <XS:TextBoxVl ID="CompanyUrl" runat="server"  ValidationGroup="BB" ></XS:TextBoxVl>
                        </td>
                     </tr>   
                      <tr>
                        <td>
                                运单查询网址:
                        </td>
                        <td>                    
                            <XS:TextBoxVl ID="OrderQueryUrl"  runat="server"  ValidationGroup="BB" ></XS:TextBoxVl>
                        </td>
                     </tr>   
                                
                </table>
                    
    
</asp:PlaceHolder>
            </div>
    </div>
</div>
<div class="text-center mt10">    
    <XS:Button ID="bntSave" runat="server"  Text=" 保存 " ValidationGroup="BB"/>
</div>