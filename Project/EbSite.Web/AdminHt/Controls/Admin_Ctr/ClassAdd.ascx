<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctr.ClassAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加模型控件分类</h3>
            </div>
            <div class="eb-content">
				 <table>
                    <tr>
                        <td>
                            <%=Resources.lang.EBCategoryName%>:
                        </td>
                        <td>
                            <XS:TextBox ID="txtTile" runat="server" CanBeNull="必填">
                            </XS:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Resources.lang.EBRemark%>:
                        </td>
                        <td>
                            <XS:TextBox ID="txtDescription" runat="server"  Height="100" TextMode="MultiLine"
                                Width="300">
                            </XS:TextBox>
                        </td>
                    </tr>
                    
                </table>
            </div>
    </div>
</div>
<div class="text-center mt10">    
 <XS:Button ID="bntSave" runat="server" Text=" <%$Resources:lang,EBSave%> "></XS:Button> 
</div>
<style>td{ padding: 5px;}</style>