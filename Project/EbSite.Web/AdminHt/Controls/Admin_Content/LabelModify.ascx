<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabelModify.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.LabelModify" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>修改标签</h3>
            </div>
            <div class="eb-content">
				
<asp:PlaceHolder ID="phCtrList" runat="server">
   <table >
                    <tr>
                        <td>
                            标签名称:
                        </td>
                        <td>
                        
                            <XS:TextBoxVl ID="txtKeyName" IsAllowNull="false" runat="server"   ></XS:TextBoxVl>

                        </td>
                    </tr>
                    <tr>
                    <td>
                        静态页面规则:
                    </td>
                    <td>
                        <XS:UcReNameRule ID="rnHtmlName" Width="380" runat="server" />
                    </td>
                </tr>
                
                <tr>
                    <td>
                        标签Seo标题规则
                    </td>
                    <td>
                        <XS:TextBox ID="txtSeoLableTitle"  runat="server" Width="300"></XS:TextBox>

                        (#Title# 代表标签名称,#SiteName# 代表网站名称)
                    </td>
                </tr>
                <tr>
                    <td>
                        标签Seo关键词规则
                    </td>
                    <td>
                        <XS:TextBox ID="txtSeoLableKeyWord"   runat="server" Width="300"></XS:TextBox>
                        (#Title# 代表标签名称,#SiteName# 代表网站名称)
                    </td>
                </tr>
                <tr>
                    <td>
                        标签Seo描述规则
                    </td>
                    <td>
                        <XS:TextBox ID="txtSeoLableDes"   runat="server" Width="300"></XS:TextBox>
                        (#Title# 代表标签名称,#SiteName# 代表网站名称)
                    </td>
                </tr>
                   
                </table>
</asp:PlaceHolder>
            </div>
    </div>
</div>

<div class="text-center mt10">
    <XS:Button ID="bntSave" Width="300" runat="server"  Text=" 保存 " />
</div>