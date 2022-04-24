<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PicConfig.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Configs.PicConfig" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>修改图片水印配置</h3>
            </div>
            <div class="content">
				<table>
                <tr>
                    <td>
                        <%=Resources.lang.EBOpenWmarkImg%>：
                    </td>
                    <td>
                        <XS:RadioButtonList ID="OpenWatermark" runat="server">
                            <asp:ListItem  Value="1">开启</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">不开启</asp:ListItem>                            
                        </XS:RadioButtonList>
                    </td>
                </tr>
                
                
                <tr>
                    <td>
                        <%=Resources.lang.EBWmarkPath%>：
                    </td>
                    <td>
                        <XS:TextBox ID="PicPath" HintInfo="相对路径，但请不要在前面加/,因在虚拟目录站点时会是虚拟目录名称"  Width="500"  runat="server"></XS:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBWmarkTrans%>：
                    </td>
                    <td>
                        <XS:TextBox ID="Watermarktransparency" HintInfo="水印图片透明度,取值的0-10之间，10表示无透明" Width="50" RequiredFieldType="数据校验" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBUploadPicQua%>：
                    </td>
                    <td>
                        <XS:TextBox ID="Imgquality" HintInfo="上传图片质量,取值的0-100之间，数字越大质量越好" Width="50" RequiredFieldType="数据校验" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBUploadPicQua%>：
                    </td>
                    <td>
                        <asp:Literal ID="llPosition" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>
 

<%--<div class="admin_toobar">
    <fieldset>
        <legend>缩略图设置</legend>
        <div>
            <table>
                <tr>
                    <td> 
                        <%=Resources.lang.EBOpThuFun%>：
                    </td>
                    <td colspan="3">
                        <XS:RadioButtonList ID="OpenMiniature" runat="server">
                            <asp:ListItem  Value="1">开启</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">不开启</asp:ListItem>                            
                        </XS:RadioButtonList>
                    </td>
                </tr>
                
                
                <tr>
                    <td> 小缩略图：small</td>
                    <td>
                        <%=Resources.lang.EBThuHeight%>：
                    </td>
                    <td>
                        <XS:TextBox ID="MiniatureHeight" Width="50" runat="server"></XS:TextBox>
                    </td>
               
                    <td>
                         <%=Resources.lang.EBThuWidth%>：
                    </td>
                    <td>
                       <XS:TextBox ID="MiniatureWidth" Width="50" runat="server"></XS:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td> 中缩略图：middle</td>
                    <td>
                        <%=Resources.lang.EBThuHeight%>：
                    </td>
                    <td>
                        <XS:TextBox ID="MidiatureHeight" Width="50" runat="server"></XS:TextBox>
                    </td>
               
                    <td>
                         <%=Resources.lang.EBThuWidth%>：
                    </td>
                    <td>
                       <XS:TextBox ID="MidiatureWidth" Width="50" runat="server"></XS:TextBox>
                    </td>
                </tr>
                
                 <tr>
                    <td> 大缩略图：big</td>
                    <td>
                        <%=Resources.lang.EBThuHeight%>：
                    </td>
                    <td>
                        <XS:TextBox ID="MaxiatureHeight" Width="50" runat="server"></XS:TextBox>
                    </td>
               
                    <td>
                         <%=Resources.lang.EBThuWidth%>：
                    </td>
                    <td>
                       <XS:TextBox ID="MaxiatureWidth" Width="50" runat="server"></XS:TextBox>
                    </td>
                </tr>
                
            </table>
        </div>
    </fieldset>
    
</div>
 --%>
 <div class="text-center mt10">     
    <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>"  />
 </div>
<br /><br />
 