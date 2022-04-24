<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataInit.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.DataInit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<style>
    td {
        padding: 5px;
    }
  
</style> 
 <div   class="container-fluid main-title">
    以下操作请慎用，如果有不清楚之处请与官方联系，此类功能只为便于数据整理所提供
</div>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>批量添加内容到专题</h3>
            将内容归类到专题有利于seo优化，在您创建好大量专题的而缺少人手添加内容到专题的情况下此功能大有用场,内容表中任何字段下的数据，只要包含或等于某个专题名称时，将其添加到此专题下来
            </div>
            <div class="content"> 
                <table>
                    <td>
                        <label><%=Resources.lang.EBContFldName%></label>
                        
                    <XS:TextBox ID="txtSp_ContentFiled" HintInfo="内容表中任意字段名称,常用到ContentInfo(内容),NewsTitle(标题)" runat="server">ContentInfo</XS:TextBox>
                    </td>
                    <td>
                       <label> 条件</label>
                          <XS:DropDownList ID="drpSp_Where" runat="server">
                        <asp:ListItem Value="0" Text="包含"></asp:ListItem>
                        <asp:ListItem Value="1" Text="等于"></asp:ListItem>
                    </XS:DropDownList>
                    </td>
                    <td>
                        <br />
                       <label> 专题名称时</label>
                    </td>
                </table>
           
                <XS:Button ID="bntAddSpecial" runat="server" Confirm="true" Text="<%$Resources:lang,EBAddContenToS %>"
                    OnClick="bntAddSpecial_Click" /> 
            </div> 
    </div>
</div>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>批量添加内容到专题（单个操作）</h3>
            将内容归类到专题有利于seo优化，在您创建好大量专题的而缺少人手添加内容到专题的情况下此功能大有用场,内容表中任何字段下的数据，只要包含或等于某个专题名称时，将其添加到此专题下来
            </div>
            <div class="content">
				<table>
                    <tr>
                        <td>
                            <label><%=Resources.lang.EBContFldName%></label>
                            <XS:TextBox ID="txtAnyName" HintInfo="内容表中任意字段名称,常用到ContentInfo(内容),NewsTitle(标题)" runat="server">ContentInfo</XS:TextBox></td>
                        <td>
                             <label>条件</label>
                            <XS:DropDownList ID="drp_Sw" runat="server">
                                <asp:ListItem Value="0" Text="包含"></asp:ListItem>
                                <asp:ListItem Value="1" Text="等于"></asp:ListItem>
                            </XS:DropDownList>
                        </td>
                        <td>
                             <label>关健词</label>
                            <XS:TextBox ID="txtKey" HintInfo="关健词" runat="server"></XS:TextBox>
                        </td> 
                    </tr>
				</table>
                <div>
                     <label for="name">移动到目标专题</label> <br />
                            <XSD:SelectClass ID="slSpecialID" ApiFunctionName="GetSubSpecial" Size="10" runat="server"></XSD:SelectClass>
                </div>
                <div class="mt10">
                    
                 <XS:Button ID="Button1" runat="server" Confirm="true" Text="<%$Resources:lang,EBAddContenToS %>"
                            OnClick="bntAddSpecialDet_Click" />
                </div>
            </div>
    </div>
</div> 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>数据初始化</h3>
            此功能非常适用于新采集的数据，或从其他系统导入的数据，分类配置混乱的情况下使用
            </div>
            <div class="content">
				<XS:Button ID="bntClassToDefault" runat="server" Confirm="true" Text="<%$Resources:lang,EBInitAllDefualt %>"
                            OnClick="bntClassToDefault_Click" />
                <div class="mt10">
                     <XS:Button ID="bntClassResetOrderID" runat="server" Confirm="true" Text="<%$Resources:lang,EBRearSortId %>"
                            OnClick="bntClassResetOrderID_Click" />
                </div>
            </div>
    </div>
</div>

 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>专题模板设置-PC电脑版</h3>
            选择专题分类同时修改其下的子专题模板
            </div>
            <div class="content">
				
                        <label>内容模板：</label>
                        <XS:DropDownList ID="drpTemPc" Width="200" runat="server">
                        </XS:DropDownList>
                  
                         <label>选择专题分类： </label>
                        <br />                           
                        <XSD:SelectClass ID="drpPcSoure" ApiFunctionName="GetSubSpecial" Size="10" runat="server"></XSD:SelectClass>
                      
                        <div class="mt10">
                        <XS:Button ID="btnSpecialPcTem" runat="server" Confirm="true" Text="确定修改PC电脑版模板"
                            OnClick="btnSpecialPcTem_Click" />
                            </div>
              </div> 
    </div>
</div>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>专题模板设置-移动设备版</h3>
            选择专题分类同时修改其下的子专题模板
            </div>
            <div class="content">
			  <label>内容模板： </label>
                        <XSD:SpecialTempsMobile Width="200" ID="drpTemMobile" runat="server" />
                  <label> 选择专题分类： </label><br />
                        <XSD:SelectClass ID="drpMobileSoure" Width="200" ApiFunctionName="GetSubSpecial" Size="10" runat="server"></XSD:SelectClass>

                    <div class="mt10">
                        
                        <XS:Button ID="btnSpecialMobileTem" runat="server" Confirm="true" Text="确定修改移动设备模板"
                            OnClick="btnSpecialMobileTem_Click" />
                    </div>
                   
            </div>
        
</div>
</div>
 