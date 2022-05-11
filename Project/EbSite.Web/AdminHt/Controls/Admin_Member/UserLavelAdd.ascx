<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLavelAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.UserLavelAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    td{ padding: 5px;}
</style>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改信息</h3>
            </div>
            <div class="eb-content">
				 <asp:PlaceHolder ID="phCtrList" runat="server">
            <table>
                     <tr>
                        <td>
                            级别ID:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="LevelId" Width="120" ValidateType="正整数" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            级别名称:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="LevelName" Width="120" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            积分大于:
                        </td>
                        <td>
                            <XS:TextBoxVl Width="100" ID="MinCredit"  ValidateType=大于等于0整数包括0  runat="server"  />        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            积分小于:
                        </td>
                        <td>
                            <XS:TextBoxVl Width="100" ID="MaxCredit"  ValidateType="大于等于0整数包括0"  runat="server"  />     
                        </td>
                    </tr>
                     <tr>
                        <td>
                            代表图片:
                        </td>
                        <td>
                            <XS:SWFUpload ID="ImgPath" AllowExt="jpg,png,gif" AllowSize="1024"  runat="server" />
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