<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageCode.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.PageCode" %>
<%@ Import Namespace="EbSite.Base.Configs.ContentSet" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>分页设置</h3>
            </div>
            <div class="content">
				 <table>
        <tr>
                 <td>
                    <%=Resources.lang.EBPageListSize%>：
                </td>
                <td>
                    <XS:TextBox ID="txtPageSizeClass" RequiredFieldType="数据校验" CanBeNull="必填" runat="server" Width="50"></XS:TextBox>
                </td>              
           </tr>
             <tr>
                 <td>
                    <%=Resources.lang.EBSpcListPg%>：
                </td>
                <td>
                    <XS:TextBox ID="txtPageSizeSpecial" RequiredFieldType="数据校验" CanBeNull="必填" runat="server" Width="50"></XS:TextBox>
                </td>              
           </tr>   
           <tr>
                 <td>
                    <%=Resources.lang.EBLblListSize%>：
                </td>
                <td>
                    <XS:TextBox ID="txtPageSizeTag" RequiredFieldType="数据校验" CanBeNull="必填" runat="server" Width="50"></XS:TextBox>
                </td>              
           </tr>      
           <tr>
                 <td>
                    <%=Resources.lang.EBTagSearSize%>：
                </td>
                <td>
                    <XS:TextBox ID="txtPageSizeTagValue" RequiredFieldType="数据校验" CanBeNull="必填" runat="server" Width="50"></XS:TextBox>
                </td>              
           </tr>  
    </table>
            </div>
    </div>
</div>
<div class="text-center mt10">
    
<XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>"  />
</div>
