<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMenu_Add.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.UserMenu_Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改菜单</h3>
            只能修改图标与重写目录
            </div>
            <div class="eb-content">
				<table class="TableList">
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBMenuName %>：
                    </td>
                    <td>
                        <xs:TextBox MaxLength="100" Enabled="false" CanBeNull=必填 HintTitle="提示" HintShowType="down" HintInfo="菜单的名称，不能为空" ID="txtMenuName" runat="server"></XS:TextBox>
                            
                    </td>
                </tr>                
                <%--<tr>
                    <td>
                        <font color='#E78A29' >*</font> 
                            <%=Resources.lang.EBParentClass %>：
                    </td>
                    <td>
                       <XS:DropDownList ID="drpPatentID" AppendDataBoundItems=true runat="server">
                                <asp:ListItem Value="" Selected="True">根目录</asp:ListItem>
                            </XS:DropDownList>  
                    </td>
                </tr>--%>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBLinkPath%>：
                    </td>
                    <td>
                      <XS:TextBox ID="txtUrl" Width="300" Enabled="false"  HintTitle="提示" HintInfo="该菜单链接的页面路径" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBDirctCtrName%>：
                    </td>
                    <td>
                      <XS:TextBox ID="txtCtrPath"  Enabled="false" Width="300"  HintTitle="提示" HintInfo="模块菜单ID" runat="server"></XS:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBIcon%>(16x16):
                    </td>
                    <td>
                       <XS:DropDownList ID="drpImg" onchange="imgchang()"  runat="server"></XS:DropDownList>
					    
					    <IMG id="imgview"  border="0" >
                    </td>
                </tr>
                 <tr>
                    <td>
                        <%=Resources.lang.ReWritePath%>:
                    </td>
                    <td>
                        <XS:TextBox ID="txtTarget" HintInfo="重写后格式为:http://您的域名/m/重写目录.ashx"  Width="80"   runat="server"></XS:TextBox>                          
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2" style="text-align: center">
                          <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSave%> " runat="server" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>
 
 
<script>
    function imgchang() {
        var imgsel = document.getElementById('<%=drpImg.ClientID%>');
        var imgview = document.getElementById('imgview');

        if (imgsel.selectedIndex != 0) {

            imgview.src = imgsel.options[imgsel.selectedIndex].value;

        }
        else {
            imgview.src = '../images/Menus/folder16.gif';

        }
    }
    imgchang();
</script>