<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddSpecial.ascx.cs"
    Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.AddSpecial" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %> 
<style>td{ padding: 5px;}</style>
<div id="divsteptips" runat="server"  class="container-fluid main-title">第二步:添加专题 </div>

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 "> 
									<h4 class="m-t-0 m-b-20 header-title"><b>专题信息</b></h4>
									 <table>
                <tr>
                    <td>
                        专题名称:
                    </td>
                    <td>
                        <XS:TextBox ID="txtClassName" runat="server"></XS:TextBox>
                        <XS:TextBox ID="txtSpilt" Text="," Visible="false" HintInfo="多个专题分开符号" Width="30"
                            runat="server"></XS:TextBox>
                        <asp:CheckBox ID="cbMore" AutoPostBack="true" Text="批量添加" runat="server" OnCheckedChanged="cbMore_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td>
                        父级专题:
                    </td>
                    <td>
                        <asp:Label ID="lbClassName" ForeColor="#CC0000" Font-Bold="true" runat="server">一级专题</asp:Label>
                        <span onclick="reselclass()" style="color:#2963B8; cursor:pointer;" >重选父专题</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        专题模板(PC版):
                    </td>
                    <td>
                        <XS:DropDownList ID="drpTem" runat="server">
                        </XS:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        专题模板(移动版):
                    </td>
                    <td>
                       <XSD:SpecialTempsMobile ID="drpTemMobile"  runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        专题图片:
                    </td>
                    <td>
                        <XS:UploadImg Ext="jpg,jpeg,png,gif" Size="1024" Width="160" Height="160" ID="tbuUploadImg" UploadType="单个图片" runat="server" />
                        <%--<XS:SWFUpload UploadModel="Net默认组件" ID="Titletype" Width="300" AllowSize="1024" AllowExt="jpg,gif,png" runat="server"></XS:SWFUpload>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        排序ID:
                    </td>
                    <td>
                        <XS:TextBox ID="Orderid" Width="100" runat="server">0</XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        静态页面规则:
                    </td>
                    <td>
                        <XS:UcReNameRule ID="rnHtmlName" Width="380" runat="server" />
                        <br/>
                        <asp:CheckBox ID="cbIsCusttomRw" HintInfo="开启自定义也能用规则"   Text="自定义重写" runat="server"  />
                    </td>
                </tr>
                
                <tr>
                    <td>
                        专题Seo标题规则
                    </td>
                    <td>
                        <XS:TextBox ID="txtSeoSpecialTitle" CanBeNull="必填" runat="server" Width="300"></XS:TextBox>
                        ({专题名称} 代表专题名称,{站点名称} 代表网站名称) 
                    </td>
                </tr>
                <tr>
                    <td>
                        专题Seo关键词规则
                    </td>
                    <td>
                        <XS:TextBox ID="txtSeoSpecialKeyWord" CanBeNull="必填" runat="server" Width="300"></XS:TextBox>
                        ({专题名称} 代表专题名称,{站点名称} 代表网站名称)
                    </td>
                </tr>
                <tr>
                    <td>
                        专题Seo描述规则
                    </td>
                    <td>
                        <XS:TextBox ID="txtSeoSpecialDes" CanBeNull="必填" runat="server" Width="300"></XS:TextBox>
                        ({专题名称} 代表专题名称,{站点名称} 代表网站名称)
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        关联分类:
                    </td>
                    <td>                        
                        <XS:Notes Text="关联分类可以在制作部件时获取某个分类下的专题"  runat="server" ></XS:Notes>
                        <asp:ListBox ID="cblClass" Height="200" SelectionMode="Multiple" runat="server"></asp:ListBox>
                         
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="cbIsContinu" Checked="true" Text="操作完毕是否返回列表" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        专题介绍
                    </td>
                    <td>
                         <XS:Editor ID="txtInfo" ExtImg="png,jpg,gif"   SaveFolder="special"   Width="500" Height="300"  runat="server" />  
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <XS:Button ID="bntSave" Text=" 保 存 " runat="server" />
                    </td>
                </tr>
            </table> 
							</div>
						</div>
 
 <script>


     function reselclass() {
         if (confirm("重新选择将离开当前页面，数据可能丢失，确认离开吗?")) {
             location.href = "?t=2";
         }
     }
    </script>