<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdd.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Sites.SiteAdd" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 
<asp:PlaceHolder ID="phCtrList" runat="server">
  
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div>
            <h3>添加/修改站点信息</h3>
        </div>
        <div class="content">
            <table>
                    <tr>
                        <td>站点名称:
                        </td>
                        <td>

                            <XS:TextBoxVl ID="SiteName" IsAllowNull="false" runat="server" ValidationGroup="BB"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>父级站点:
                        </td>
                        <td>
                            <XS:DropDownList ID="ParentID" runat="server"></XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>站点目录:
                        </td>
                        <td>
                            <XS:TextBoxVl ID="SiteFolder" HintInfo="如果设置此目录，那么静态页面及上传文件默认将单独保存在此目录下" Width="50" runat="server"></XS:TextBoxVl>
                        </td>
                    </tr>
                    <tr>
                        <td>站点前台皮肤:
                        </td>
                        <td>
                            <XS:DropDownList ID="PageTheme" ValidationGroup="AA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageTheme_SelectedIndexChanged"></XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>站点后台皮肤:
                        </td>
                        <td>
                            <XS:DropDownList ID="AdminTheme" runat="server"></XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>手机皮肤:
                        </td>
                        <td>
                            <XS:DropDownList ID="MobileTheme" runat="server"></XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>首页采用模板:
                        </td>
                        <td>
                            <XS:DropDownList HintInfo="在模板管理里创建好首页模板后，可以在这里选择并绑定到首页里来" ID="IndexTemID" runat="server" ValidationGroup="AA"></XS:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>分类连接方式：             
                        </td>
                        <td>
                            <XS:DropDownList ID="LinkTypeClass" HintInfo="本系统提供4种访问模式，手动静态表添加内容的同时生成静态页面，自动静态为访问的时生成静态页面，动态表示没有做处理，最后是重写路径" runat="server">
                                <asp:ListItem Value="0">手动静态</asp:ListItem>
                                <asp:ListItem Value="1">自动静态</asp:ListItem>
                                <asp:ListItem Value="2">动态</asp:ListItem>
                                <asp:ListItem Selected="True" Value="3">动态重写</asp:ListItem>
                            </XS:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>内容连接方式：             
                        </td>
                        <td>
                            <XS:DropDownList ID="LinkTypeContent" HintInfo="本系统提供4种访问模式，手动静态表添加内容的同时生成静态页面，自动静态为访问的时生成静态页面，动态表示没有做处理，最后是重写路径" runat="server">
                                <asp:ListItem Value="0">手动静态</asp:ListItem>
                                <asp:ListItem Value="1">自动静态</asp:ListItem>
                                <asp:ListItem Value="2">动态</asp:ListItem>
                                <asp:ListItem Selected="True" Value="3">动态重写</asp:ListItem>
                            </XS:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>专题连接方式：             
                        </td>
                        <td>
                            <XS:DropDownList ID="LinkTypeSpecial" HintInfo="本系统提供4种访问模式，手动静态表添加内容的同时生成静态页面，自动静态为访问的时生成静态页面，动态表示没有做处理，最后是重写路径" runat="server">
                                <asp:ListItem Value="0">手动静态</asp:ListItem>
                                <asp:ListItem Value="1">自动静态</asp:ListItem>
                                <asp:ListItem Value="2">动态</asp:ListItem>
                                <asp:ListItem Selected="True" Value="3">动态重写</asp:ListItem>
                            </XS:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>标签连接方式：             
                        </td>
                        <td>
                            <XS:DropDownList ID="LinkTypeTags" HintInfo="本系统提供4种访问模式，手动静态表添加内容的同时生成静态页面，自动静态为访问的时生成静态页面，动态表示没有做处理，最后是重写路径" runat="server">
                                <asp:ListItem Value="0">手动静态</asp:ListItem>
                                <asp:ListItem Value="1">自动静态</asp:ListItem>
                                <asp:ListItem Value="2">动态</asp:ListItem>
                                <asp:ListItem Selected="True" Value="3">动态重写</asp:ListItem>
                            </XS:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>其他连接方式：             
                        </td>
                        <td>
                            <XS:DropDownList ID="LinkTypeOrther" HintInfo="如注册，登录，用户控件面板等，此类连接改变此设置意义不大，因为有些连接无法静态化" runat="server">
                                <asp:ListItem Value="0">手动静态</asp:ListItem>
                                <asp:ListItem Value="1">自动静态</asp:ListItem>
                                <asp:ListItem Value="2">动态</asp:ListItem>
                                <asp:ListItem Selected="True" Value="3">动态重写</asp:ListItem>
                            </XS:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            是否分类内容化:
                        </td>
                        <td>
                            <XS:CheckBox ID="IsClassContent" HintInfo="内容化后台分类将以分页形式展示否则在一页内用树形展示，有些复杂结构的网站，内容分多级时可以采用此选项，如音乐网站，歌手类别(分类)-歌手(内容)-专辑(内容)-歌曲(内容)" runat="server" />
                        </td>
                    </tr>
                </table>
        </div>
    </div>
</div>

</asp:PlaceHolder>
<div class="mt10 text-center">
    <XS:Button ID="bntSave" runat="server" Text=" 保存 " ValidationGroup="BB" />
</div>
