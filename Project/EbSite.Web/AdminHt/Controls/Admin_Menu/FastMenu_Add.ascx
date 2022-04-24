<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FastMenu_Add.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.FastMenu_Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="admin_toobar">
    <fieldset>
        <legend>添加/修改菜单</legend>
        <div>
            <table class="TableList">
                <tr>
                    <td>
                       菜单名称：
                    </td>
                    <td>
                        <xs:TextBoxVl MaxLength="100"  IsAllowNull="False"  HintInfo="菜单的名称，不能为空" ID="txtMenuName" runat="server"></xs:TextBoxVl>
                            
                    </td>
                </tr>                
                <tr>
                    <td>
                       分类：
                    </td>
                    <td>
                       <XS:DropDownList ID="drpClass"  runat="server"></XS:DropDownList>  
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBLinkPath%>：
                    </td>
                    <td>
                      <XS:TextBoxVl ID="txtUrl" Width="500"    HintInfo="该菜单链接的页面路径" runat="server"></XS:TextBoxVl>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        菜单图标:
                    </td>
                    <td>
                       <XS:DropDownList ID="drpImg" onchange="imgchang()"  runat="server"></XS:DropDownList>
					    <IMG id="imgview"  border="0" >
                    </td>
                </tr>
                  
                <tr>
                    <td colspan="2" style="text-align: center">
                          <XS:Button ID="bntSave" Text=" 保存 " runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</div>
<script>
		function imgchang()
		{			
		    var imgsel = document.getElementById('<%=drpImg.ClientID%>');
		    var imgview = document.getElementById('imgview');
		    
			if(imgsel.selectedIndex!=0)
			{
			 
			    imgview.src=imgsel.options[imgsel.selectedIndex].value;
                
			}
			else
			{
			    imgview.src='../images/Menus/folder16.gif';
			    			
			}
		}
		imgchang();
</script>
