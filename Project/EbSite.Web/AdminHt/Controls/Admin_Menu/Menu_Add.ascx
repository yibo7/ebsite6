<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu_Add.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.Menu_Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>添加/修改菜单</h3>
            </div>
            <div class="content">
				 <table class="TableList">
                <tr>
                    <td>
                        <font color='#E78A29'>*</font> <%=Resources.lang.EBMenuName %>：
                    </td>
                    <td>
                        <xs:TextBox MaxLength="100"  CanBeNull=必填 HintTitle="提示" HintShowType="down" HintInfo="菜单的名称，不能为空" ID="txtMenuName" runat="server"></XS:TextBox>
                            
                    </td>
                </tr>                
                <tr>
                    <td>
                        <font color='#E78A29' >*</font> 
                            <%=Resources.lang.EBParentClass %>：
                    </td>
                    <td>
                       <XS:DropDownList ID="drpPatentID" AppendDataBoundItems=true runat="server">
                                <asp:ListItem Value="00000000-0000-0000-0000-000000000000" Selected="True">根目录</asp:ListItem>
                            </XS:DropDownList>  
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBLinkPath%>：
                    </td>
                    <td>
                      <XS:TextBox ID="txtUrl" Width="300"  HintTitle="提示" HintInfo="该菜单链接的页面路径" runat="server"></XS:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBDirctCtrName%>：
                    </td>
                    <td>
                      <XS:TextBox ID="txtCtrPath" Width="300"  HintTitle="提示" HintInfo="定向控件名称" runat="server"></XS:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <%=Resources.lang.EBIcon%>(16x16):
                    </td>
                    <td>
                       <XS:DropDownList ID="drpImg" onchange="imgchang()"  runat="server">
                            </XS:DropDownList>
					    
					    <IMG id="imgview"  border="0" >
                    </td>
                </tr>
                 <tr>
                    <td>
                        <%=Resources.lang.EBTarget%>(16x16):
                    </td>
                    <td>
                        <XS:TextBox ID="txtTarget" CanBeNull=可为空 Width="80" HintTitle="提示" HintInfo="设置连接的target属性" runat="server"></XS:TextBox>
                            常用目标:<input type="radio"  id="mainbody" onclick="javascript:<%=txtTarget.ClientID %>.value='mainbody';" value="mainbody" />mainbody
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Resources.lang.EBPermisId%>：
                    </td>
                    <td>
                        <xs:TextBox  RequiredFieldType="数据校验"  HintTitle="提示" HintShowType="down" HintInfo="权限ID" ID="txtPermissionID" runat="server"></XS:TextBox>
                            
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
