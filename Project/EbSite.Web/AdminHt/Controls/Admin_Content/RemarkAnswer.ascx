<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RemarkAnswer.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.RemarkAnswer" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    <fieldset>
        <legend>回复 用户问题</legend>
        <div>
            <table style="width:100%;">

             <tr>                       
                        <td width="50" >
                           问题：
                        </td>
                        <td style="text-align:left">
                           <XS:TextBox TextMode="MultiLine" ID="txtWt"  Enabled=false Height=100px Width=300  runat="server"></XS:TextBox>
                        </td>
                    </tr>
                    <tr>                       
                        <td width="50" >
                           回复：
                        </td>
                        <td style="text-align:left">
                           <XS:TextBox TextMode="MultiLine" ID="txtCt"  CanBeNull="必填"  Height=100px Width=300  runat="server"></XS:TextBox>
                        </td>
                    </tr>
                   
                     <tr>                       
                        <td  colspan="2">
                           <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
                        </td>
                    </tr>
                </table>
        </div>
    </fieldset>
</div>