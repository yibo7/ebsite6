<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Safe.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.Safe" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>密码的加密方式</h3>
            修改后会导致现在所有用户无法登录,如果您的网站已经有大量用户，请修改之前做相应处理
            </div>
            <div class="content">
				  <XS:RadioButtonList ID="rblPassType" RepeatColumns="2" runat="server" 
                        onselectedindexchanged="rblRequestModel_SelectedIndexChanged">
                        <asp:ListItem Value="0">MD5加密(MD5)</asp:ListItem>
                        <asp:ListItem Value="1">哈希加密(Hashed)</asp:ListItem>
                        <asp:ListItem Value="2">两次MD5加密(MD5MD5)</asp:ListItem>
                        <asp:ListItem Value="3">一次MD5加密加上一次哈希加密(MD5Hashed)</asp:ListItem>
                    </XS:RadioButtonList>
            </div>
    </div>
</div>

 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>数据库相关</h3>
            </div>
            <div class="content">
				<table>
                   <tr>
                             <td>
                               是否加密数据库连接串：            
                            </td>
                            <td>                  
                                <XS:CheckBox ID="cbIsEndDataBaseStr" HintInfo="更有效地保户你数据库安全"  runat="server" />
                    
                            </td>             
                       </tr>   
                             </table>
            </div>
    </div>
</div>
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>后台管理</h3>
            </div>
            <div class="content">
				<table>
        <tr>
                 <td>
                    <%=Resources.lang.EBSysBackendDirN%>：         
                </td>
                <td>
                    <XS:TextBoxVL ID="txtAdminPath" HintInfo="如果担心后台被别人猜中，留下不安全隐患，这里可以起个有个性的后台路径" runat="server" Width="100"></XS:TextBoxVL>
                </td>            
           </tr> 
           <tr>
                 <td>
                    <%=Resources.lang.EBErrLogHmtLock%>：          
                </td>
                <td>
                    <XS:TextBoxVL ID="txtErrLoginNum"  IsAllowNull="false" ValidateType="匹配正整数" HintInfo="指的是后台管理员的登录，当错误登录达到指定次数时，锁定此用户" runat="server" Width="50"></XS:TextBoxVL>
                </td>          
           </tr> 
                
                 </table>
            </div>
    </div>
</div>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>数据审核</h3>
            </div>
            <div class="content">
				 <table>
                  <tr>
                            <td>
                                <%=Resources.lang.EBAuditCont%>:
                            </td>
                            <td>
                                <XS:CheckBox ID="cbAuditingContent"  HintInfo="在这里设定用户添加的内容是否要经过审核才能在前台显示（除指定免审核的用户）" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%=Resources.lang.EBCmntModer%>:
                            </td>
                            <td>
                                <XS:CheckBox ID="cbAuditingComment" HintInfo="用户发表评论后，是否要经过审核才能显示到前台来" runat="server" />
                            </td>
                        </tr>
                
                         </table>
            </div>
    </div>
</div>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>验证码</h3>
            </div>
            <div class="content">
				<table>
         <tr>
                    <td>
                        <%=Resources.lang.EBOpLogverCode%>:
                    </td>
                    <td>
                        <XS:CheckBox ID="cbIsOpenSafeCoder" HintInfo="登录前是否默认启用验证码，当您未启用时，前台用户登录错误超过1次时也会自动启用验证码功能" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBOpDisverCode%>:
                    </td>
                    <td>
                        <XS:CheckBox ID="cbIsOpenSafeCoder_PL" HintInfo="考虑到安全性，您也可以在用户发表评论时启用此功能" runat="server" />
                    </td>
                </tr>
                 </table>
            </div>
    </div>
</div> 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>日志开启</h3>
            </div>
            <div class="content">
				 <table>
                       <tr>
                    <td>
                        是否开启系统异常日志:
                    </td>
                    <td>
                        <XS:CheckBox ID="cbIsOpenAppLog" HintInfo="系统的异常错误往往是系统致命的错误，这样的错误发生多了，可能会导致系统崩溃,所以及时跟踪系统异常信息具有很大的重要意义" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        是否开启404错误日志:
                    </td>
                    <td>
                        <XS:CheckBox ID="cbIsOpen404Log" HintInfo="可以帮助检查网站有没有404错误页面发生，可以在日志管理的html错误生成里查看" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                       是否开启管理员登录日志:
                    </td>
                    <td>
                        <XS:CheckBox ID="IsOpenAdminLoginLog" HintInfo="开户此功能，系统可以详细记录每一个后台管理员的登录日志，为后台的安全运作提供必不可少的分析数据" runat="server" />
                    </td>
                </tr>
                 </table>
            </div>
    </div>
</div> 
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>网站密钥</h3>
            修改密钥需要重新登录
            </div>
            <div class="content">
				<XS:TextBoxVL ID="txtPassKey" IsAllowNull="false" HintInfo="网站需要密码与解密的地方用到的密钥" runat="server" Width="200">KeyEbSite</XS:TextBoxVL>
            </div>
    </div>
</div>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>Web服务访问安全配置</h3>
            </div>
            <div class="content">
				<table>
                     <tr>    
              
                                <td>
                                    <XS:RadioButtonList ID="rblRequestModel" RepeatColumns="4" runat="server" 
                                        onselectedindexchanged="rblRequestModel_SelectedIndexChanged">
                                        <asp:ListItem Value="0">允许跨域</asp:ListItem>
                                        <asp:ListItem Value="1">禁止跨域</asp:ListItem>
                                    </XS:RadioButtonList>
                                   <%-- <div>
                                     安全码: <XS:TextBox ID="txtWebServiceSafeCode" HintInfo="在上面选择 验证安全码 后，此安全码就会起作用！"  runat="server"></XS:TextBox>
                                    </div>--%>
                    
                                </td>
               
                            </tr>
                    </table>
            </div>
    </div>
</div>
  
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>发表内容免审核的用户级别</h3>
            在启用了内容审核功能后，某些用户可以不受此功能的限制,按Ctrl可以多选
            </div>
            <div class="content">
				<asp:ListBox SelectionMode="Multiple" Width="200" Height="150" ID="lblUserleva1" runat="server"></asp:ListBox>
            </div>
    </div>
</div>

 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>Editbox允许上传文件图片视频的用户级别</h3>
            前台要有使用editbox控件地方，只允许在此范围的用户群才可以上传图片,按Ctrl可以多选
            </div>
            <div class="content">
				 <asp:ListBox SelectionMode="Multiple" Width="200" Height="150" ID="lblUserleva2" runat="server"></asp:ListBox>
            </div>
    </div>
</div>
 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader headertips">
                <h3>互动操作时间隔</h3>
            指发表评论，发表内容，搜索等操作的时间间隔，这里单位为分钟,0为不启用
            </div>
            <div class="content">
				<XS:TextBoxVL ID="txtPostTimeOut"  IsAllowNull="false" ValidateType="大于等于0整数包括0"  runat="server" Width="50">10</XS:TextBoxVL>分钟
            </div>
    </div>
</div>
 
<div class="text-center mt10">
    <XS:Button ID="bntSave" runat="server" width="300" Text="<%$Resources:lang,EBSaveConfig%>"  />
</div>
 <br /><br /> 
    
 