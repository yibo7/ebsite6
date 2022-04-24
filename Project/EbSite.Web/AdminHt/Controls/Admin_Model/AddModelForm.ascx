<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddModelForm.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.AddModelForm" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>添加表单模型</h3>
            模板名称以form_并且后续为.aspx
            </div>
            <div class="content">
				 <table style="width:500px">
                    <tr>
                        <td>
                            <%=Resources.lang.EBModelName %>:
                        </td>
                        <td style=" text-align:left; font-size:14px; font-weight:bold; ">
                            <XS:TextBox ID="txtModelName" Width="200" runat="server"></XS:TextBox>
                        </td>
                        
                    </tr> 
                    <tr >
                        <td>
                            模板名称：
                        </td>
                        <td >                           
                            form_<XS:TextBoxVl runat="server" IsAllowNull="false" ValidateType="匹配由26个英文字母组成的字符串"  ID="txtTempName"></XS:TextBoxVl>.aspx
                        </td>
                        
                    </tr> 
                        <tr >
                        <td>
                            是否移除头部信息：
                        </td>
                        <td >                           
                            <asp:CheckBox ID="cbIsSystem" runat="server" />
                        </td>
                        
                    </tr> 
                    </table>
            </div>
    </div>
</div>

<div class="text-center mt10">
     <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
</div>
 