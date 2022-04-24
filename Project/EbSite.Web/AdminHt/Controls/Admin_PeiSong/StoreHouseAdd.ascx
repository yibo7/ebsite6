<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StoreHouseAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_PeiSong.StoreHouseAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" Namespace="EbSite.ControlData" TagPrefix="XSD" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改仓库</h3>
            </div>
            <div class="content">
				 <table>
                    <tr>
                        <td>
                            仓库名称:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="StoreHouseName" IsAllowNull="false" runat="server"  ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                发货区域的:
                        </td>
                        <td>                    
                                
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

