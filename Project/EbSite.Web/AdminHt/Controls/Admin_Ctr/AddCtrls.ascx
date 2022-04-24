<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddCtrls.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Ctr.AddCtrls" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row">
    <div class="col-sm-12" style="background:#ffffff;"> 
            <h4 class="m-t-0 m-b-20 header-title"><b>添加/修改模型控件</b></h4>
            <table>   
                    <tr>
                        <td>
                            控件名称：
                        </td>
                        <td>
                            <XS:TextBox ID="txtTitle" CanBeNull="必填" runat="server"></XS:TextBox>
                        </td>
                    </tr>   
                    
                    <tr>
                        <td>
                            分类：
                        </td>
                        <td>
                            <asp:DropDownList ID="drpClass" AppendDataBoundItems="true" runat="server">
                             <asp:ListItem Text="全部" Value=""></asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                    </tr>   
                    
                      
                          
                     <tr>
                        <td>
                            控件参数：
                        </td>
                        <td>
                            <div runat="server" ID="phEdit" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="2" style="text-align:center; height:50px;">
                            <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
                        </td>
                    </tr>
                </table>
         
    </div>
</div>
<style>td{ padding: 5px;}</style>
 