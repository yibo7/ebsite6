<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeyWord.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.KeyWord" %>
<%@ Import Namespace="EbSite.Base.Configs.ContentSet" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
 <div   class="container-fluid main-title">
    您正在为当前站点<font color="#000000"><b>[<%=HostApi.GetSite(GetSiteID).SiteName %>]</b></font>配置关键词

</div>

<asp:Label ForeColor="red" ID="lbNoSetInfo" runat="server" Text=""></asp:Label> 
 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="active tab">
                <a href="#tg1" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-home"></i></span>
                    <span class="hidden-xs">首页关键词</span>
                </a>
            </li>
            <li class="tab">
                <a href="#tg2" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-sitemap"></i></span>
                    <span class="hidden-xs">分类页关键词</span>
                </a>
            </li> 
             <li class="tab">
                <a href="#tg3" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-image"></i></span>
                    <span class="hidden-xs">专题页关键词</span>
                </a>
            </li> 
            
             <li class="tab">
                <a href="#tg4" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-book"></i></span>
                    <span class="hidden-xs">内容页关键词</span>
                </a>
            </li> 
             <li class="tab">
                <a href="#tg3" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-tags"></i></span>
                    <span class="hidden-xs">标签大全页关键词</span>
                </a>
            </li> 
             <li class="tab">
                <a href="#tg3" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-tag"></i></span>
                    <span class="hidden-xs">标签内容页关键词</span>
                </a>
            </li> 
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <table>
        
           <tr>
                 <td>
                    <%=Resources.lang.EBFrtPgTitSeoRule%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoSiteIndexTitle" HintInfo="{站点名称} 代表网站名称"  CanBeNull="必填" runat="server"  Width="500">{站点名称}_网站建设系统</XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBFrtPgSeoKeyR%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoSiteIndexKeyWord"  CanBeNull="必填" TextMode="MultiLine" Height="50" HintInfo="{站点名称} 代表网站名称" runat="server"  Width="500">{站点名称}，网站建设</XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBFrtPgDesRuS%>：
                </td>
                <td>
                
                    <XS:TextBox ID="txtSeoSiteIndexDes"  CanBeNull="必填"  runat="server" TextMode="MultiLine" Height="50" HintInfo="{站点名称} 代表网站名称" Width="500">{站点名称}是一个功能强大的网站建设系统</XS:TextBox>                    
                    
                </td>              
           </tr>  
           </table>
            </div>
            <div id="tg2" class="tab-pane">
                <table>
           <tr>
                 <td>
                    <%=Resources.lang.EBClassSeoTitRul%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoClassTitle"  CanBeNull="必填" runat="server" HintInfo="{分类名称} 代表当前分类名称,{站点名称} 代表网站名称,父级分类依次为:{父分类0},{父分类1},{父分类2}..."  Width="500">{分类名称}_{站点名称}</XS:TextBox>
                   
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBSeoKwRul%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoClassKeyWord"  CanBeNull="必填" runat="server" HintInfo="{分类名称} 代表当前分类名称,{站点名称} 代表网站名称,父级分类依次为:{父分类0},{父分类1},{父分类2}..." TextMode="MultiLine" Height="50"  Width="500"></XS:TextBox>
                   
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBSeoDesRulc%>：
                </td>
                <td>
                
                    <XS:TextBox ID="txtSeoClassDes"  CanBeNull="必填" runat="server" HintInfo="{分类名称} 代表当前分类名称,{站点名称} 代表网站名称,父级分类依次为:{父分类0},{父分类1},{父分类2}..." TextMode="MultiLine" Height="50"  Width="500"></XS:TextBox>
                   
                </td>              
           </tr>  
           
                 </table>
            </div> 
            <div id="tg3" class="tab-pane">
                <table>
           <tr>
                 <td>
                    <%=Resources.lang.EBSpeSeoTitRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoSpecialTitle"  CanBeNull="必填" runat="server" HintInfo="{专题名称} 代表专题名称,{站点名称} 代表网站名称"  Width="500">{专题名称}_{站点名称}</XS:TextBox>
                   
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBSpeSeoKwRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoSpecialKeyWord"  CanBeNull="必填" runat="server" HintInfo="{专题名称} 代表专题名称,{站点名称} 代表网站名称" TextMode="MultiLine" Height="50"   Width="500"></XS:TextBox>
                    
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBSpeDesSeoRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoSpecialDes"  CanBeNull="必填" runat="server" HintInfo="{专题名称} 代表专题名称,{站点名称} 代表网站名称" TextMode="MultiLine" Height="50"  Width="500"></XS:TextBox>                    
                </td>              
           </tr>  
             </table>
            </div>
            <div id="tg4" class="tab-pane">
                <table>      
           
           <tr>
                 <td>
                    <%=Resources.lang.EBCtntSeoTitRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoContentTitle"  CanBeNull="必填" runat="server" HintInfo="{内容标题}代表当前内容标题 {分类名称} 代表当前分类名称,{站点名称} 代表网站名称,{内容标签},父级分类依次为:{父分类0},{父分类1},{父分类2}..."  Width="500">{内容标题}_{站点名称}</XS:TextBox>
                    
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBCntntSeoKwRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoContentKeyWord"  CanBeNull="必填" runat="server" HintInfo="{内容标题}代表当前内容标题 {分类名称} 代表当前分类名称,{站点名称} 代表网站名称,{内容标签},父级分类依次为:{父分类0},{父分类1},{父分类2}..." TextMode="MultiLine" Height="50"  Width="500"></XS:TextBox>
                    
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBCntntDesRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoContentDes"  CanBeNull="必填" runat="server" HintInfo="{内容标题}代表当前内容标题 {分类名称} 代表当前分类名称,{站点名称} 代表网站名称,{内容标签},{内容简介}提取内容简介,父级分类依次为:{父分类0},{父分类1},{父分类2}..." TextMode="MultiLine" Height="50" Width="500"></XS:TextBox>
                    
                </td>              
           </tr>
           
 
             </table>
            </div>
            <div id="tg5" class="tab-pane">
                <table>  
           <tr>
                 <td>
                    <%=Resources.lang.EBTagPgTitRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoTagIndexTitle"  CanBeNull="必填" runat="server" HintInfo="{站点名称} 代表网站名称" Width="500">标签大全_{站点名称}</XS:TextBox>
                    
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBTagPgSeoKwRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoTagIndexKeyWord"  CanBeNull="必填" runat="server" HintInfo="{站点名称} 代表网站名称" TextMode="MultiLine" Height="50"  Width="500"></XS:TextBox>                    
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBTagPgDesRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoTagIndexDes"  CanBeNull="必填" runat="server" HintInfo="{站点名称} 代表网站名称" TextMode="MultiLine" Height="50" Width="500"></XS:TextBox>
                    
                </td>              
           </tr>
           
         </table>
            </div>
            <div id="tg6" class="tab-pane">
                <table>         
           <tr>
                 <td>
                    <%=Resources.lang.EBTagListRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoTagListTitle"  CanBeNull="必填" runat="server" HintInfo="{站点名称} 代表网站名称,{标签名称}代表当前的标签名称"   Width="500">{标签名称}_{站点名称}</XS:TextBox>
                    
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBSeoKwTagListRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoTagListKeyWord"  CanBeNull="必填" runat="server" HintInfo="{站点名称} 代表网站名称,{标签名称}代表当前的标签名称" TextMode="MultiLine" Height="50" Width="500"></XS:TextBox>                    
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBTagListDesRu%>：
                </td>
                <td>
                    <XS:TextBox ID="txtSeoTagListDes"  CanBeNull="必填" runat="server" HintInfo="{站点名称} 代表网站名称,{标签名称}代表当前的标签名称" TextMode="MultiLine" Height="50"  Width="500"></XS:TextBox>
                    
                </td>              
           </tr>
  
         </table>
            </div>
        </div>
    </div>
</div>
 
<div class="text-center mt10">    
<XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>"  />
</div>

<style>td{ padding: 5px;}</style>