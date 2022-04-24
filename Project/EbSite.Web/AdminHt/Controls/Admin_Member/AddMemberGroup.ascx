<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMemberGroup.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Member.AddMemberGroup" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register TagPrefix="EB" Assembly="EbSite.Web" Namespace="EbSite.Web.PublicControl" %>
<style>
    td {
        padding: 5px;
    }
</style>
  
 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="active tab">
                <a href="#tg1" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">添加/编辑用户组</span>
                </a>
            </li>
            <li class="tab">
                <a href="#tg2" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-user"></i></span>
                    <span class="hidden-xs">高级选项</span>
                </a>
            </li> 
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <table>

                <tr>
                    <td>
                        <font color='#E78A29'>*</font><%=Resources.lang.EBUserGroupName %>：
                    </td>
                    <td>
                        <XS:TextBox ID="txtGruopName" CanBeNull="必填" runat="server"></XS:TextBox>
                    </td>
                </tr>


                <!--2.0后不再提倡这个<tr>
                    <td>
                        <%=Resources.lang.EBCanAddCc %>：
                    </td>
                    <td>
                        最多只能列出500个分类<br>
                        <asp:ListBox ID="cblClass" AppendDataBoundItems="true"  Height="200" SelectionMode="Multiple" runat="server">
                            <asp:ListItem Text="不可以添加任何分类下的内容" Value=""></asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBContentQuan %>：
                    </td>
                    <td>
                        <XS:TextBox ID="txtContentNum" runat="server" Width="80" CanBeNull="必填" HintInfo="可添加内容条数,0代表无限制"
                            HintShowType="down" HintTitle="提示" MaxLength="100000" RequiredFieldType="数据校验">0</XS:TextBox>(单位为数字)
                    </td>
                </tr>
                
                <tr>
                    <td>
                       <%=Resources.lang.EBRegToRev %>：
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsAuditing" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBAllowDelContent%>：
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsAllowDelete" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <%=Resources.lang.EBAllowMdfContent%>：
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsAllowModify" runat="server" />
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBAddContentAudit%>：
                    </td>
                    <td>
                        <asp:CheckBox ID="cbIsAuditingContent" runat="server" />
                    </td>
                </tr>-->


            </table>
            </div>
            <div id="tg2" class="tab-pane">
                <table class="TableList2">
                        <tr>
                            <td>
                                <%=Resources.lang.EBUserModel%>：
                            </td>
                            <td>
                                <XS:DropDownList ID="drpUserModel" runat="server"></XS:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>用户控制面板主页：
                            </td>
                            <td>
                                <XS:TextBox ID="txtManageIndex" Width="300" HintInfo="要在主站点皮肤下创建对应的用户控制面板主页页面" runat="server" CanBeNull="必填"></XS:TextBox>(用户后台管理页面)
                            </td>
                        </tr>
                        <tr>
                            <td>用户控制面板母板页：
                            </td>
                            <td>
                                <XS:TextBox ID="txtManageIndexMaster" Width="300" HintInfo="要在主站点皮肤下创建对应的用户控制面板母板页" runat="server" CanBeNull="必填"></XS:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>用户信息页面：
                            </td>
                            <td>
                                <XS:TextBox ID="txtWebSite" Width="300" HintInfo="要在主站点皮肤下创建对应的选用户信息页面" runat="server" CanBeNull="必填"></XS:TextBox>
                                (用户信息页面)
                            </td>
                        </tr>
                    </table>
            </div> 
        </div>
    </div>
</div>

<div class="text-center mt10">
    <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " Width="80" runat="server" />
</div>
<script>
    function onshowadv() {
        $(".TableList2").show();
    }

</script>
