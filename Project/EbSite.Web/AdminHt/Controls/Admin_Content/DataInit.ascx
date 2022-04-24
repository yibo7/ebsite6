<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataInit.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Content.DataInit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    td{ padding: 5px;}
</style>
<div class="alert alert-info">以下操作请慎用，如果有不清楚之处请与官方联系，此类功能只为便于数据整理所提供</div> 
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>前台搜索默认内容字段</h3>
            </div>
            <div class="content">
				<div class="alert alert-info">为了优化查询速度有必要去除没必要的字段</div> 
            <table>
                    <tr>
                        <td>
                            <XS:DropDownList  ID="drpContentType" runat="server" 
                                onselectedindexchanged="drpContentType_SelectedIndexChanged" 
                                AutoPostBack="True">
                                <asp:ListItem Text="应用于部件" Enabled="true" Value="0"></asp:ListItem>
                                 <asp:ListItem Text="应用于内容搜索" Value="1"></asp:ListItem>
                                  <asp:ListItem Text="应用于标签搜索 " Value="2"></asp:ListItem>
                            </XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <XS:CheckBoxList ID="drpContentFileds" RepeatColumns="6" runat="server">
                            </XS:CheckBoxList>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <div style=" margin-top:10px; ">
                            <XS:Button ID="bntSaveContentFileds"   runat="server"  
                                    Text="<%$Resources:lang,EBSaveConfig%>" onclick="bntSaveContentFileds_Click"  />
                            </div>
                         
                        </td>
                    </tr>
                </table>
            </div>
    </div>
</div>

 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>选择分表作为 搜索、排行、专题、标签 的数据源</h3>
            </div>
            <div class="content">
				<table>
                
                <tr>
                    <td><br>
                            <XS:CheckBoxList ID="drpContentTables" RepeatColumns="6" runat="server">
                            </XS:CheckBoxList>
                            

                    </td>
                </tr>
                 <tr >
                        <td >
                            <div style=" margin-top:10px; ">
                            <XS:Button ID="bntSaveContentTables"   runat="server"  
                                    Text="保存分表" onclick="bntSaveContentTables_Click"  />
                            </div>
                         
                        </td>
                    </tr>
            </table>
            </div>
    </div>
</div>
 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>清理所有站点以外的无用内容</h3>
            </div>
            <div class="content">
				 <table>
                
                <tr>
                    <td><br>
                         <XS:Button ID="btnClearData"   runat="server"  
                                    Text="开始清理" onclick="btnClearData_Click"  />

                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>

 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>后台搜索字段</h3>
            </div>
            <div class="content">
				<table>
                <tr>
                    <td>
                        <div class="alert alert-info">可以在这里自定义后台内容管理的搜索字段，格式 为 字段名称1｜显示名称2，字段名称2｜显示名称2</div>  
             
                    </td>
                </tr>
                <tr>
                    <td>
                        <XS:TextBox ID="txtAdminSearchFileds" TextMode="MultiLine"  Width="500" Height="100" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                         <XS:Button ID="bntSaveAdminSearchFileds"   runat="server"  
                                    Text="<%$Resources:lang,EBSaveField %>" onclick="bntSaveAdminSearchFileds_Click"  />

                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>    
 
 
    
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>点击率归零</h3>
            </div>
            <div class="content">
				<table>
          
                <tr>
                    <td>
                     <XS:DropDownList ID="drpContentNumType" runat="server">
                           <asp:ListItem Value="0" Text="全部"></asp:ListItem>
                    <asp:ListItem Value="1" Text="总点击率"></asp:ListItem>
                    <asp:ListItem Value="2" Text="当天点击率"></asp:ListItem>
                    <asp:ListItem Value="3" Text="本周点击率"></asp:ListItem>
                    <asp:ListItem Value="4" Text="本月点击率"></asp:ListItem>
                    <asp:ListItem Value="5" Text="排序ID"></asp:ListItem>
                         </XS:DropDownList>            
                    </td>
                    <td>
                         <div class="alert alert-info">某些情况下，我们要重新统计点击率，可以将其归零</div>  
              
                </td>
                </tr>
               
                  
                <tr>
                    <td colspan="2" >
                     <XS:Button ID="bntContentInitNum" runat="server" Confirm="true" Text="<%$Resources:lang,EBMakeDataReset %>" 
                                onclick="bntContentInitNum_Click"  /> 
                    </td>
                </tr>
                
            </table>
            </div>
    </div>
</div>
 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>数据初始化</h3>
            </div>
            <div class="content">
				<table>
          
               
               
                <tr>
                    <td>
                      <XS:Button ID="bntUpdateClassName" runat="server" Confirm="true" 
                                    Text="<%$Resources:lang,EBAcIdupcn %>" onclick="bntUpdateClassName_Click"  />
                    </td>
                    <td>
                         <div class="alert alert-info">同上情况，根据内容表里的分类名称，生成分类，或归类到分类</div>  
              
                    </td>
                </tr>
                <tr>
                    <td>
                    <XS:Button ID="bntUpdateClassForClassName" runat="server" Confirm="true" 
                                    Text="<%$Resources:lang,EBGeClZero %>" 
                                    onclick="bntUpdateClassForClassName_Click"   />
                    </td>
                    <td>
                         <div class="alert alert-info">同上情况,如我们从其他系统导入数据到内容表，这时分类无法对应得上，其ID都为0，所以要重新匹配一次</div>  
               
                    </td>
                </tr>
                <tr>
                    <td>
                     <XS:Button ID="bntResetGood" runat="server" Confirm="true" 
                                    Text="<%$Resources:lang,EBAllDSetNoRecomm %>" onclick="bntResetGood_Click"  />
                    </td>
                    <td>
                        <div class="alert alert-info">当系统运行时间过长，我们推荐的数据过多，有很多过时的数据难以处理时，可以在此重置</div>  
                
                    </td>
                </tr>
               
                
            </table>
            </div>
    </div>
</div>

 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
       
            <div class="content">
				<XS:Button ID="bntClearOutSiteContent"  runat="server" Confirm="true" HintInfo="不在所有站群内的内容,如:之前创建了站点添加了内容，站点删除后内容还保存在内容表，可以在这里清理" Text="清理垃圾内容" onclick="bntClearOutSiteContent_Click"   />  
            </div>
    </div>
</div>
 