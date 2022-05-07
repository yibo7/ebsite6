<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetClassInit.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.SetClassInit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 


<%--<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>分类默认配置</h3>
            </div>
            <div class="content">
				<div class="alert alert-info">默认添加分类时使用的设置</div>
                <a class="btn btn-primary" href="Admin_Class.aspx?t=5&id=0">更改分类默认设置</a>
                <XS:Button ID="btnClearClassConfig" runat="server" Text="刷新分类设置" HintInfo="比如采集过来的分类，将其实设置到默认分类设置，如果是子类即设置到所在父分类一样的配置" Tips_Msg="如果分类数据量大可能要比较长的时间" Confirm="True" OnClick="btnClearClassConfig_Click" />
            </div>
    </div>
</div>--%>


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>前台搜索默认分类字段</h3>
            </div>
            <div class="content">
				<div class="alert alert-info">为了优化查询速度有必要去除没必要的字段</div>
                <div>
                    <XS:CheckBoxList RepeatColumns="6" ID="drpClassFileds" runat="server">
                    </XS:CheckBoxList>
                </div>
                <div class="m-t-30">
                    <XS:Button ID="bntSaveClassFileds" runat="server" Text="<%$Resources:lang,EBSaveConfig%>" OnClick="bntSaveClassFileds_Click" />
                </div>
            </div>
    </div>
</div>

 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>清理所有站点以外的无用分类</h3>
            </div>
            <div class="content">
				 <XS:Button ID="btnClearData" runat="server"
                    Text="开始清理" OnClick="btnClearData_Click" />
            </div>
    </div>
</div>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>后台搜索字段</h3>
            </div>
            <div class="content">
				 <div class="alert alert-info">可以在这里自定义后台分类管理的搜索字段，格式 为 字段名称1｜显示名称2，字段名称2｜显示名称2</div>
                <div>
                    <XS:TextBox ID="txtAdminSearchFileds" TextMode="MultiLine" Width="500" Height="100" runat="server"></XS:TextBox>
                </div>
                <div class="mt10">
                    <XS:Button ID="bntSaveAdminSearchFileds" runat="server"
                        Text="<%$Resources:lang,EBSaveField %>" OnClick="bntSaveAdminSearchFileds_Click" />
                </div>
            </div>
    </div>
</div>



<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>点击率归零</h3>
            </div>
            <div class="content">
				<div class="alert alert-info">由于本系统分类也可以当作内容使用，所以存在访问率，这里如果重置为零后将重新统计</div>
                <div>
                    <XS:DropDownList ID="drpClassNumType" runat="server">
                        <asp:ListItem Value="0" Text="全部"></asp:ListItem>
                        <asp:ListItem Value="1" Text="总点击率"></asp:ListItem>
                        <asp:ListItem Value="2" Text="当天点击率"></asp:ListItem>
                        <asp:ListItem Value="3" Text="本周点击率"></asp:ListItem>
                        <asp:ListItem Value="4" Text="本月点击率"></asp:ListItem>
                    </XS:DropDownList>
                </div>
                <div class="mt10">
                    <XS:Button ID="bntClassInitNum" runat="server" Confirm="true" Text="<%$Resources:lang,EBMakeDataReset %>"
                        OnClick="bntClassInitNum_Click" />
                </div>
            </div>
    </div>
</div>
 
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>数据初始化</h3>
            </div>
            <div class="content">
				 <div class="alert alert-info">同上</div>
                <div>
                    <XS:Button ID="bntClassResetOrderID" runat="server" Confirm="true"
                        Text="<%$Resources:lang,EBRearSortId %>" OnClick="bntClassResetOrderID_Click" />
                </div>
                <div class="mt10">
                    <XS:Button ID="Button1" runat="server" Confirm="true" Text="<%$Resources:lang,EBMakeDataReset %>"
                        OnClick="bntClassInitNum_Click" />
                </div>
            </div>
    </div>
</div>

 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>整理每个分类所有父级</h3>
            </div>
            <div class="content">
				<div class="alert alert-info">批量整理分类的父级分类 ParentIDs</div>
                <div >
                    <XS:Button ID="btnClassSort" runat="server" Confirm="true"
                        Text="开始整理" OnClick="btnClassSort_Click" />
                </div>
            </div>
    </div>
</div>
 


<%--<div class="admin_toobar">
    <fieldset>
        <legend>重置分类模型或模板</legend>
        <div style=" height:100px; ">

            <table>
            <tr>
                <td>
                <XS:Notes ID="Notes6" Text="当系统运行了一段时间后，我们突然要改变某个分类下的模板或模型，这时候数据量大则需要在此批量修改"   runat=server></XS:Notes>
                </td>
               </tr>   
                <tr>
                    <td>
                    <XS:ExtensionsCtrls  ID="mcClassList1"  ModelCtrlID="5c125a7b-d5f1-4c7a-aecd-03955c982529" runat="server"/>
         
                             或指定分类ID<XS:TextBox ID="txtClassID1" HintInfo="此值不为空，将使用此此值"  Width="50" runat="server"></XS:TextBox>
                             
                    </td>
                </tr>
                <tr>
                    <td>
                        分类模型:<XS:ExtensionsCtrls ID="mcClassModel"   ModelCtrlID="e0e3acd0-a7ba-426e-9baa-3223b763cf84" runat="server"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                          分类模板:                                                        
                            <XS:ExtensionsCtrls ID="mcClassTem"    ModelCtrlID="6d84d961-8fba-4bcc-82fe-f0f9043f8fc5" runat="server"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                          内容模型:<XS:ExtensionsCtrls ID="mcContentModel1"   ModelCtrlID="af2d45eb-0e3a-4deb-bbe2-4a97c5b54dee" runat="server"/>
                               
                    </td>
                </tr>
                 <tr>
                    <td>
                        内容模板:
                             
                                <XS:ExtensionsCtrls ID="mcContentTem1"  ModelCtrlID="8693da83-38f3-4fc0-9eea-714de639227c" runat="server"/>
                    </td>
                </tr>
                               
                  
                <tr>
                    <td >
                     <XS:Button ID="bntReSetClassConfigs"  runat="server" Confirm="true" 
                                Text="<%$Resources:lang,EBStartReset %>" onclick="bntReSetClassConfigs_Click"  />  
                           <asp:CheckBox ID="cbClassSubClass" Text="更新到子分类" runat="server" />
                    </td>
                </tr>
                
            </table>
              
        </div>
         
</fieldset>
</div>--%>


