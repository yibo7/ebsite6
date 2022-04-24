<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpiderAdd.ascx.cs"  Inherits="EbSite.Web.AdminHt.Controls.Admin_Spider.SpiderAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改信息</h3>
            </div>
            <div class="content">
				<asp:PlaceHolder ID="phCtrList" runat="server">
                   <table>
                                    <tr>
                                        <td>
                                            搜索引擎名称:
                                        </td>
                                        <td>                        
                                            <XS:TextBoxVl ID="SpiderCnName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            蜘蛛标识:
                                        </td>
                                        <td>
                                            <XS:TextBoxVl ID="SpiderEnName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>
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
 