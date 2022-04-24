<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysConfig.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.SysConfig" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 <div   class="container-fluid main-title">
    注意,修改系统配置所有缓存将重新加载
</div>
 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="active nav-item">
                <a class="nav-link active" href="#tg1" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-cogs"></i></span>
                    <span class="hidden-xs">基础配置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg2" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-tachometer"></i></span>
                    <span class="hidden-xs">性能相关的配置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg3" data-toggle="tab">
                    <span class="visible-xs"><i class="fa fa-group"></i></span>
                    <span class="hidden-xs">与开发者相关的配置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg4" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-group"></i></span>
                    <span class="hidden-xs">手机短信配置</span>
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#tg5" data-toggle="tab" >
                    <span class="visible-xs"><i class="fa fa-group"></i></span>
                    <span class="hidden-xs">文件服务器</span>
                </a>
            </li>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <table>


                    <tr>
                        <td>
                            <%=Resources.lang.EBInstallPath%>：               
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtsMapPath" HintInfo="您安装系统的时候程序自动完成此值，以后系统每次启动也会自动检测一遍，您也可以手动完成" IsAllowNull="false" runat="server" Width="242px"></XS:TextBoxVl>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <%=Resources.lang.EBDomainName%>：            
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtsLocalhost" HintInfo="这里填写您的网站域名，完整格式如，http://www.ebsite.net" IsAllowNull="false" runat="server" Width="242px"></XS:TextBoxVl>
                            <XS:CheckBox ID="IsAutoUpdateDomain" Text="是否自动更新" runat="server" />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <%=Resources.lang.EBVirtualDirectory%>：            
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtIISPath" HintInfo="如果是安装在虚拟目录，这里将填写目录名称，如xp下的iis，以网站的形式安装，则为/" IsAllowNull="false" runat="server" Width="242px"></XS:TextBoxVl>

                        </td>

                    </tr>

                    <tr>
                        <td>
                            <%=Resources.lang.EBFileUploadPath%>：             
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtUplaodPath" HintInfo="文件上传的路径，相对根目录路径，但请不要在前面加/" runat="server" Width="242px"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>当前站点搜索引擎：             
                        </td>
                        <td>
                            <XS:DropDownList ID="drpSearchEngine" AppendDataBoundItems="True" HintInfo="搜索引擎来源于搜索插件，您也可以开发自己的搜索引擎插件" runat="server">
                                <asp:ListItem Text="默认" Value="" />
                            </XS:DropDownList>(可切换不同的站点来设置些选项，尖对不同站点采用不同搜索引擎)
                        </td>
                    </tr>
                    <tr>
                        <td>IP转换区域处理程序：             
                        </td>
                        <td>
                            <XS:DropDownList ID="drpIpToArea" AppendDataBoundItems="True" HintInfo="系统默认使用新浪微薄ipApi,由于各第三方平台提供的IP转换地区数据精准率不一，你可以自己开发这个处理程序，安装到插件后在这里选用" runat="server">
                                <asp:ListItem Text="默认" Value="" />
                            </XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>默认快递查询插件：             
                        </td>
                        <td>
                            <XS:DropDownList ID="drpKuaiDi" AppendDataBoundItems="True" HintInfo="设置一个快递查询插件，可能第三方应该模块会使用到，如官方的商城模块,当然如果您的网站没有使用到快递查询功能，可以不用理会！" runat="server">
                                <asp:ListItem Text="不选择" Value="" />
                            </XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>缓存处理程序：             
                        </td>
                        <td>
                            <XS:DropDownList ID="drpCacheBll" AppendDataBoundItems="True" runat="server">
                                <asp:ListItem Text="系统默认" Value="" />
                            </XS:DropDownList>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>默认邮件发送插件：             
                        </td>
                        <td>
                            <XS:DropDownList ID="drpEmailSendPlugin" AppendDataBoundItems="True" runat="server">
                                <asp:ListItem Text="还没安装相关插件" Value="" />
                            </XS:DropDownList>
                        </td>
                    </tr>--%>
                   
                    <tr>
                        <td>
                            <%=Resources.lang.EBLanguage%>：             
                        </td>
                        <td>
                            <XS:DropDownList ID="ddlCulture" runat="server">
                                <asp:ListItem Text="自动" Value="Auto" />
                                <asp:ListItem Text="english" Value="en" />
                            </XS:DropDownList>
                        </td>
                    </tr>



                    <tr>
                        <td>
                            <%=Resources.lang.EBAntiCheatingS%>：                        
                        </td>
                        <td>
                            <XS:RadioButtonList HintInfo="由于某些网站对点击率的要求比较严格，所以本系统推出两种防作弊模式，采用session会更加安全，但cookie更节省服务器资源，请根据需要设置" ID="rbIsCookieOrSession" runat="server">
                                <asp:ListItem Selected="True" Value="0">cookie</asp:ListItem>
                                <asp:ListItem Value="1">session</asp:ListItem>
                            </XS:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Resources.lang.EBHowLongTimUpd%>：
                        
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtHitsUpdateTimeLength" HintInfo="访问量的统计过于频繁，系统采用了批更新方式，通过收集一定的访问数据后作一次性更新，所以里设置的是这个收集过程的时长,因此，如果您访问了某个页面，未能马上看到点击率的更新，这属于正常现象" IsAllowNull="false" ValidateType="匹配正整数" runat="server" Width="50"></XS:TextBoxVl>
                            分钟
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Resources.lang.EBLogStateLT%>：
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtLoginExpires" IsAllowNull="false" ValidateType="匹配正整数" HintInfo="将用户登录后的状态保存下来，方便用户再次到来时置于登录状态，这里保存的是保存的状态时长" runat="server" Width="50"></XS:TextBoxVl>
                            分钟
                        </td>
                    </tr>





                    <tr>
                        <td>是否开启个人空间:
                        </td>
                        <td>
                            <XS:CheckBox ID="cblIsOpenUserHome" HintInfo="如果你安装了个人空间模块，可以选择此项，如果没有安装，请不要选择此项，否则点击用户连接时会提示错误！" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <%=Resources.lang.EBCookieDom%>：     
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtCookieDomain" HintInfo="如果您要跨子域验证，这里可以帮您实现，如要在*.ebsite.cn下所有域名共享cookie,那么这里可以填写.ebsite.cn" runat="server" Width="200"></XS:TextBoxVl>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <%=Resources.lang.EBIubsDir%>：           
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtUserPath" IsAllowNull="false" HintInfo="模块的重写目录，一般情况下不用修改" runat="server" Width="100"></XS:TextBoxVl>
                        </td>
                    </tr>

                    <tr>
                        <td>移动自动适应：            
                        </td>
                        <td>
                            <XS:CheckBox ID="cbIsMobileRedirect" runat="server" />(在移动设备下访问PC地址，自动适应移动页面内容)
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <%=Resources.lang.EBBottomCopyright%>：            
                        </td>
                        <td>
                            <XS:UEditor ID="txtCopyright" Width="800" Height="300" runat="server" />
                        </td>
                    </tr>

                </table>
            </div>
            <div id="tg2" class="tab-pane">
                <table>

                    <tr>
                        <td>是否开启页面gzip压缩：            
                        </td>
                        <td>
                            <XS:CheckBox ID="cbIsOpenGzip" runat="server" />(压缩页面内容输出,压缩率可达80%,此功能不能在手动静态下使用)
                        </td>
                    </tr>
                    <tr>
                        <td>样式表CSS混合压缩选项：<br>
                            <font color="#cccccc">(手机版本默认启用目录压缩)</font>
                        </td>
                        <td>
                            <XS:RadioButtonList ID="rblEnableCssCompression" RepeatColumns="1" runat="server">
                                <asp:ListItem Text="原生代码输出,不压缩" Value="0"></asp:ListItem>
                                <asp:ListItem Text="gzip压缩并混合目录(合并themes下及themes/皮肤名称/css/下所有样式表一起输出)" Value="1"></asp:ListItem>
                                <asp:ListItem Text="gzip压缩并混合文件(只将themes下的base.css及themes/皮肤名称/css/index.css输出)" Value="2"></asp:ListItem>
                                <asp:ListItem Text="gzip压缩不混合目录(合并themes下及themes/皮肤名称/css/下所有样式表一起输出)" Value="3"></asp:ListItem>
                                <asp:ListItem Text="gzip压缩不混合文件(只将themes下的base.css及themes/皮肤名称/css/index.css输出)" Value="4"></asp:ListItem>
                            </XS:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>JS混合压缩选项：  
                            <br>
                            <font color="#cccccc">(手机版本默认启用合并压缩) </font>
                        </td>
                        <td>
                            <XS:RadioButtonList ID="rblEnableJsCompression" RepeatColumns="1" runat="server">
                                <asp:ListItem Text="原生代码输出,不压缩" Value="0"></asp:ListItem>
                                <asp:ListItem Text="混合并且gzip压缩输出" Value="1"></asp:ListItem>
                                <asp:ListItem Text="gzip压缩输出(不混合)" Value="2"></asp:ListItem>
                            </XS:RadioButtonList>

                        </td>
                    </tr>
                    <tr>
                        <td>是否缓存JS与CSS:
                        </td>
                        <td>
                            <XS:CheckBox ID="cbIsCacheJsCss" HintInfo="当css与js动态输出时，可以使用此项，默认缓存30天，在调试模式下可以去除缓存" runat="server" />
                        </td>
                    </tr>
                    <%--  <tr>
                    <td>
                       缓存模式:
                    </td>
                    <td>
                          <XS:RadioButtonList HintInfo="默认缓存模式,内存最快，其他次是内存+硬盘(只在内存缓存键值)，硬盘(纯硬盘缓存)" ID="rblCacheModel" RepeatColumns="3"  runat="server">
                            <asp:ListItem Selected="True" Value="0">内存</asp:ListItem>
                            <asp:ListItem Value="1">硬盘</asp:ListItem>                
                            <asp:ListItem Value="2">内存+硬盘</asp:ListItem>                   
                        </XS:RadioButtonList>         
                    </td>
                </tr>     --%>
                </table>
            </div>
            <div id="tg3" class="tab-pane">
                <table>
                    <tr>
                        <td>是否开启SQL跟踪：            
                        </td>
                        <td>
                            <XS:CheckBox ID="cbIsOpenSql" runat="server" />(开发者调试用)
                        </td>
                    </tr>
                    <tr>
                        <td>是否系统友好异常提示：            
                        </td>
                        <td>
                            <XS:CheckBox ID="cbIsErrFriend" runat="server" />(非开发者调试时建议开户)
                        </td>
                    </tr>
                    <tr>
                        <td>卸载模块是否同时删除项目文件：            
                        </td>
                        <td>
                            <XS:CheckBox ID="cbDelModuleAndFile" runat="server" />(非开发者调试时建议选上)
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tg4" class="tab-pane">
                <table>                    
                    <tr>
                        <td>默认手机短信发送插件：             
                        </td>
                        <td>
                            <XS:DropDownList ID="drpMobileMsgSendPlugin" AppendDataBoundItems="True" runat="server">
                                <asp:ListItem Text="还没安装相关插件" Value="" />
                            </XS:DropDownList>
                             
                            
                        </td>
                    </tr>
                    <tr>
                        <td>输入手机号码：             
                        </td>
                        <td>
                            <XS:TextBoxVl ID="txtMobileNumber"  HintInfo="输入要接收测试短信的号码！" IsAllowNull="true" runat="server" Width="242px"></XS:TextBoxVl>
                            
                        </td>
                    </tr>
                       <tr>
                        <td>           
                        </td>
                        <td>
                          <XS:Button ID="btnTestMobileMsg" Width="300" runat="server" Text="测试发送" OnClick="btnTestMobileMsg_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        <div id="tg5" class="tab-pane">
            <table>                    
                <tr>
                    <td>
                        是否开启文件服务器：             
                    </td>
                    <td>
                        <XS:CheckBox ID="cbIsOpenFileServer" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        文件服务器地址：             
                    </td>
                    <td>
                        <XS:TextBoxVl ID="txtFileServerUrl"  HintInfo="请输入文件服务器地址,如:http://www.ebsite.net/fsapi/！" IsAllowNull="true" runat="server" Width="242px"></XS:TextBoxVl>
                            
                    </td>
                </tr> 
            </table>
        </div>
        </div>
    </div>
</div>

<div class="text-center mt10">
    <XS:Button ID="bntSave" Width="300" runat="server" Text=" <%$Resources:lang,EBSaveConfig%> " />
</div>

<br /><br />