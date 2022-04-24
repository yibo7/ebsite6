<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddModel.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Model.AddModel" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="XSD" Namespace="EbSite.ControlData" Assembly="EbSite.ControlData" %>
<style>
    td{padding:8px;}
</style>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>模型编辑</h3>
            </div>
            <div class="content">
				<table style="width: 100%">
                <tr>
                    <td>
                        <%=Resources.lang.EBModelName %>:
                    </td>
                    <td style="text-align: left; font-size: 14px; font-weight: bold;">
                        <XS:TextBoxVl ID="txtModelName" IsAllowNull="false" runat="server"></XS:TextBoxVl>
                    </td>
                </tr>
                 <tr>
                                    <td>
                                        内容管理模板：
                                    </td>
                                    <td>
                                         <XS:DropDownList ID="ListTemID" runat="server"></XS:DropDownList>
                                         您可以自定义后台内容管理模板                          
                                    </td>
                    </tr>
                <asp:Panel ID="panTb" runat="server">
                    <tr>
                        <td>
                            表名称:
                        </td>
                        <td style="text-align: left; font-size: 14px; font-weight: bold;">
                            <XS:TextBoxVl ID="txtTableName" IsAllowNull="false" runat="server"></XS:TextBoxVl> 
                        </td>
                    </tr>
                </asp:Panel>
            </table>
            </div>
    </div>
</div>
<div class="text-center mt10">    
 <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
</div>