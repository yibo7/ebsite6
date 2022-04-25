<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UrlReWrite.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.UrlReWrite" %>
<%@ Import Namespace="EbSite.Base.Configs.ContentSet" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<style>
    .cbrowbox-tab tr :hover{background-color:#dcf6ff}
</style>
 <div   class="container-fluid main-title">
    注意，目前只接受以下5种后缀重写.aspx,.ashx,.dll,.do,.htm,.html,目录/,其中除了aspx与ashx其他后缀重写，请到iis服务器中将其映射到asp.net处理模块,如果您不知道怎么设置，请不要改动以下配置
</div> 
<div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a href="#tg1" class="nav-link active" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-laptop"></i></span>
                    <span class="hidden-xs">PC版</span>
                </a>
            </li>
            <li class="nav-item">
                <a href="#tg2" class="nav-link" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-tablet"></i></span>
                    <span class="hidden-xs">手机版</span>
                </a>
            </li> 
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <table> 
            
           <tr>
                 <td>
                    <%=Resources.lang.EBConnAddrRelPg%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtIndexPath" Enabled="false"  CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtIndexPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
          
           
           <tr>
                 <td>
                    <%=Resources.lang.EBClasListPgConAddrR%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtListPath" Enabled="false"   CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtListPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
           <tr>
                 <td>
                    常规内容连接规则：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtContentPath" Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtContentPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
        <%--<tr>
                 <td>
                    定制内容连接规则：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtContentPath2" Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtContentPathRw2"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> --%>
           <tr>
                 <td>
                    <%=Resources.lang.EBSpePgLkAddr%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtSpecialPath"  Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtSpecialPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBTagListAddrRel%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtTaglist"  Enabled="false"   runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtTaglistRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBTagSearPgAddrRel%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtTagSearch" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtTagSearchRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>
           <tr>
                 <td>
                    登录页面:
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtLogin" Enabled="false"  CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtLoginRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
          
           
           <tr>
                 <td>
                    找回密码页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtLostpassword" Enabled="false"   CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtLostpasswordRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
           <tr>
                 <td>
                    注册页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtReg" Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtRegRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
           <tr>
                 <td>
                    搜索页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtSearch"  Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtSearchRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    用户主页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtUhome"  Enabled="false"   runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtUhomeRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    用户控制面板主页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtUccIndex" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtUccIndexRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
            <tr> 
                 <td>
                    自定义搜索面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtCusttomSearch" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtCusttomSearchRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    选择配送方式：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtDelivery" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtDeliveryRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    选择支付方式：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtPayment" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtPaymentRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    默认用户信息展示页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtUserInfo" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtUserInfoRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    友情连接申请页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtFrdlinkPost" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtFrdlinkPostRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    友情连接展示页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtFrdlink" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtFrdlinkRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    投票提交页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtVotePost" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtVotePostRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    投票展示页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtVoteView" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtVoteViewRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    投票分类(综合)提交页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtVoteClassPost" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtVoteClassPostRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    投票分类(综合)展示页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtVoteClassView" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtVoteClassViewRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    个人专辑前台展示页(非个人后台)：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtAlbum" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtAlbumRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
            <tr> 
                 <td>
                    排行榜展示页(总/月/周/日)：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtTop" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtTopRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    在线用户展示：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtUserOnline" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtUserOnlineRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    第三方登录返回完善数据页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtLoginBind" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtLoginBindRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    讨论区页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtRemark" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    
                </td>              
           </tr> 
           
     </table>
            </div>
            <div id="tg2" class="tab-pane">
                <table>
        <tr>
                 <td>
                    目录或子域：
                </td>
                <td>
                    <XS:TextBox ID="txtMPath"   HintInfo="比如在这里输入 m ，手机版访问可以是 http://m.***.com 或 http://wwww.***.com/m"   CanBeNull="必填" runat="server"  Width="300"></XS:TextBox>
                    
                </td>              
           </tr>  
            <tr>
                 <td>
                    站点模式：
                </td>
                <td>   <XS:RadioButtonList ID="rblSiteModule" runat="server"  RepeatColumns="3" HintInfo="当你要将移动站点设置为独立的站点域名时可以在这里设置">
                            <asp:ListItem Value="0">PC+移动</asp:ListItem>
                            <asp:ListItem Value="1">单独PC</asp:ListItem>
                            <asp:ListItem Value="2">单独移动</asp:ListItem>
                        </XS:RadioButtonList>
                                     
                   <%-- <XS:CheckBox ID="cbIsMobileSingSize"  HintInfo="选择后在本站访问手机版将会是404，如果你使用ebsite另外开设了一个站点来做移动版站点，可以选择这里，系统将不会解析手机url,所有手机url直接连接到站外站点"    runat="server"   ></XS:CheckBox>       --%>             
                </td>              
           </tr>  
           
         <tr>
                 <td>
                    <%=Resources.lang.EBConnAddrRelPg%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMIndexPath" Enabled="false"  CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMIndexPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
          
           
           <tr>
                 <td>
                    <%=Resources.lang.EBClasListPgConAddrR%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMListPath"  Enabled="false"   CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMListPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
           <tr>
                 <td>
                    <%=Resources.lang.EBContAddrRel%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMContentPath" Enabled="false"  CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMContentPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
           <tr>
                 <td>
                    <%=Resources.lang.EBSpePgLkAddr%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMSpecialPath"  Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMSpecialPathRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr>
                 <td>
                    搜索页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMSearch"  Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMSearchRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr>
                 <td>
                    登录页面:
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMLogin" Enabled="false"  CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMLoginRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
          
           
           <tr>
                 <td>
                    找回密码页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMLostpassword" Enabled="false"   CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMLostpasswordRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
           <tr>
                 <td>
                    注册页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMReg" Enabled="false" CanBeNull="必填" runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMRegRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
           <tr> 
                 <td>
                    投票提交页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMVotePost" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtMVotePostRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    投票展示页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMVoteView" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtMVoteViewRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           
           <tr> 
                 <td>
                    投票分类(综合)提交页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMVoteClassPost" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtMVoteClassPostRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
           <tr> 
                 <td>
                    投票分类(综合)展示页面：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMVoteClassView" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则
                    <XS:TextBox ID="txtMVoteClassViewRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr> 
            
          
           
           <tr> 
                 <td>
                    <%=Resources.lang.EBTagListAddrRel%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMTaglist"  Enabled="false"   runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMTaglistRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    <%=Resources.lang.EBTagSearPgAddrRel%>：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMTagSearch" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMTagSearchRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>
         
            <tr> 
                 <td>
                    用户主页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMUhome"  Enabled="false"   runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMUhomeRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
                </td>              
           </tr>  
            <tr> 
                 <td>
                    用户控制面板主页：
                </td>
                <td>
                    源页面
                    <XS:TextBox ID="txtMUccIndex" Enabled="false"    runat="server"  Width="200"></XS:TextBox>
                    重写规则<%=ConfigsControl.Instance.MPath%>/
                    <XS:TextBox ID="txtMUccIndexRw"   CanBeNull="必填" runat="server"  Width="500" ></XS:TextBox>
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
<br />


<style>td{ padding: 15px;}</style>