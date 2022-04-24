<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendAreaAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.SendAreaAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改配送区域</h3>
            </div>
            <div class="content">
				  <asp:PlaceHolder ID="phCtrList" runat="server">
   
                <table>
                    <tr>
                        <td>
                            区域名称:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="AreaName" IsAllowNull="false" runat="server"    ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                下属城市:
                        </td>
                        <td>                    
                           <XS:AreaSelector runat="server" Width="500" ID="CityIDs" />
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
    
 
