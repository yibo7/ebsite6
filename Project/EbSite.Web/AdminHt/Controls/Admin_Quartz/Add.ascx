<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Quartz.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改计划任务</h3>
            </div>
            <div >
				 <table >
                    <tr>
                        <td>
                            任务名称:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="TaskName" IsAllowNull="false" runat="server"  ValidationGroup="BB" ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                执行类型:
                        </td>
                        <td>                    
                            <XS:DropDownList  ID="RunType"  runat="server">
                                <asp:ListItem Value="0">调用URL</asp:ListItem>
                                <asp:ListItem Value="1">执行程序集</asp:ListItem>
                            </XS:DropDownList> 
                        </td>
                     </tr>
                    <tr>
                        <td>
                            程序集或URL:
                        </td>
                        <td>
                           <XS:TextBoxVl ID="AssemblyName" HintInfo="根据上面执行类型设置此项，可以是调用一个Url地址" Width="500"  runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            类名名称:
                        </td>
                        <td>
                           <XS:TextBoxVl ID="ClassName"  Width="300"  runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr> 

                    <tr>
                        <td>
                            Cron表达式:
                        </td>
                        <td>
                           <XS:TextBoxVl ID="CronExpressionString"   Width="500"  runat="server"   ></XS:TextBoxVl>
                        </td>
                    </tr>   
                                     
                           <tr>
                        <td>
                            备注:
                        </td>
                        <td>
                          
                            <XS:TextBoxVl ID="Remark"   runat="server"  Width="300" Height="200"  TextMode="MultiLine" ></XS:TextBoxVl>
                        </td>
                    </tr>           
                </table>
            </div>
    </div>
</div>
    

</asp:PlaceHolder>
<div class="text-center mt10">    
<XS:Button ID="bntSave" HintInfo="修改或添加任务会导致网站重启，请确认" runat="server"  Text=" 保存 "  />
</div>
<style>td{ padding: 5px;}</style>