<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassConfigs.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.ClassConfigs" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>

<style>
    td{padding:8px;}
</style>
 
 <div  id="divsteptips" runat="server"   class="container-fluid main-title">
    第二步:添加分类
</div>
 

 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="#tg1" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">基础设置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link"  href="#tg2" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">模型设置</span>
                </a>
            </li> 
            <li class="tanav-itemb">
                <a class="nav-link"  href="#tg3" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">模板设置</span>
                </a>
            </li> 
            <li class="tanav-itemb">
                <a class="nav-link" href="#tg4" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">子分类设置</span>
                </a>
            </li> 
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active"> 
		          <div class="form-group">
			        <label for="name">是否可以添加子分类</label>
			        <XS:CheckBox runat="server" ID="IsCanAddSub"></XS:CheckBox>
		          </div>
		          <div class="form-group">
			        <label for="inputfile">是否可以添加内容</label>
			        <XS:CheckBox runat="server" ID="IsCanAddContent"></XS:CheckBox>
                           
		          </div>
		          <div class="form-group">
			        <label for="inputfile">分类静态面页规则</label>
			        <XS:UcReNameRule ID="rnHtmlName" Width="380"   runat="server" />    
		          </div>
                    <div class="form-group">
			        <label for="inputfile">内容静态面页规则</label>
			        <XS:UcReNameRule ID="rnHtmlContent" Width="380"   runat="server" />
		          </div>
                     <div class="form-group">
			        <label for="inputfile"> 一页显示数量(前台)：</label>
			        <XS:TextBoxVl ValidateType="大于等于0整数包括0" Width="50" runat="server"  ID="PageSize">0</XS:TextBoxVl>
		          </div>
                    <div class="form-group">
			        <label for="inputfile"> 内容扩展(模块选择)：</label>
			        <XSD:ModuleList ID="BingModule" runat="server"></XSD:ModuleList>
		          </div> 
                <div>
                      注:默认不用选择,内容扩展选项来自所选模块下的ExtContent扩展文件(为.ascx),当eBsite内容表字段不足够使用时
                                 可以对当前分类下的内容表扩展保存数据
                </div>
                
            </div>
            <div id="tg2" class="tab-pane">
                <table>
                     <tr>
                                    <td>
                                        分类模型：
                                    </td>
                                    <td>
                                        <XSD:ClassModels ID="ClassModelID"   runat="server" />
                          
                                    </td>
                    </tr>
                   
                    <tr>
                                    <td>
                                        内容模型：
                                    </td>
                                    <td>
                                        <XSD:ContentModels ID="ContentModelID"    runat="server" />
                          
                                    </td>
                    </tr>
                   
        
                       
                </table>
            </div> 
             <div id="tg3" class="tab-pane">
                 <div style="border-bottom: 1px solid #ccc; color: #047AAF">PC电脑版</div>
        <div>
            <table>
             <tr>
                                    <td>
                                        分类模板：
                                    </td>
                                    <td>
                                        <XSD:ClassTemps ID="ClassTemID"  runat="server" />
                          
                                    </td>
                    </tr>
                     <tr>
                                    <td>
                                        内容模板：
                                    </td>
                                    <td>
                                        <XSD:ContentTemps ID="ContentTemID"    runat="server" />
                          
                                    </td>
                    </tr>
                    <%-- <tr>
                                    <td>
                                        内容管理模板：
                                    </td>
                                    <td>
                                         <XS:DropDownList ID="ListTemID" runat="server"></XS:DropDownList>
                                         您可以自定义后台内容管理模板                          
                                    </td>
                    </tr>--%>
            </table>  
        </div>
        <div style="border-bottom: 1px solid #ccc; color: #047AAF">移动设备版</div>
        <div>
            <table>
             <tr>
                                    <td>
                                        分类模板：
                                    </td>
                                    <td>
                                        <XSD:ClassTempsMobile ID="ClassTemIDMobile"  runat="server" />
                          
                                    </td>
                    </tr>
                     <tr>
                                    <td>
                                        内容模板：
                                    </td>
                                    <td>
                                        <XSD:ContentTempsMobile ID="ContentTemIDMobile"    runat="server" />
                          
                                    </td>
                    </tr>
            </table>  
        </div>

             </div>

            <div id="tg4" class="tab-pane">
                <table>
                <tr>
                        <td>
                            子分类添加名字：
                        </td>
                        <td>
                            <XS:TextBox runat="server" ID="SubClassAddName"></XS:TextBox>
                          
                        </td>
                </tr>    

                 <tr>
                                <td>
                                    子分类模型：
                                </td>
                                <td>
                                    <XSD:ClassModels  ID="SubClassModelID"    runat="server" />
                                </td>
                </tr>    
                <tr>
                                <td>
                                    子分类内容模型：
                                </td>
                                <td>
                                    <XSD:ContentModels ID="SubDefaultContentModelID"     runat="server" />
                                </td>
                </tr>      
        
                  <tr>
                                <td>
                                    子分类模板：
                                </td>
                                <td>
                                    <XSD:ClassTemps ID="SubClassTemID"  runat="server" />
                          
                                </td>
                </tr>
                 <tr>
                                <td>
                                    子分类内容模板：
                                </td>
                                <td>
                                    <XSD:ContentTemps ID="SubDefaultContentTemID"    runat="server" />
                          
                                </td>
                </tr>
 
                 <tr>
                                <td>
                                    子分类是否可添加子分类：
                                </td>
                                <td>
                                      <XS:CheckBox ID="SubIsCanAddSub"   runat="server" />
                                </td>
                </tr>   
                 <tr>
                                <td>
                                    子分类是否可以添加内容：
                                </td>
                                <td>
                                    <XS:CheckBox ID="SubIsCanAddContent"   runat="server" />
                                </td>
                </tr>                    
            </table>
            </div>
        </div>
    </div>
</div>
  
 
<div style="padding: 10px;">
     <XS:CheckBox ID="cbConfigsToSub" Visible="false" Text="是否将配置传递给下级分类" runat="server" />
    
</div>
<div style="padding: 10px;">
  <XS:CheckBox ID="cbIsAddNew" Visible="False" ForeColor="#ff0000"   Text="创建一个新的分类配置" runat="server" /> 
</div>
<XS:HiddenField ID="hfConfigId"   runat="server" /> 
  <div style="text-align: center; padding: 10px;">
    
     <XS:Button ID="bntSave" Text=" 保存分类设置 " runat="server" ValidationGroup="savedata" />
 </div>
