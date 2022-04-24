<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoveMenu.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Menu.MoveMenu" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 
<div class="row ">
    <div class="col-sm-12 col-md-12 ">
       
            <div class="content">
				<table cellspacing="0" cellpadding="4" width="100%" align="center">
                <tr>
                    <td  style=" vertical-align:top" align="left" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width:90px;"><%=Resources.lang.EBSourMenu%>：</td>
					            <td align="left">
                                    <XS:ListBox SelectionMode="Single" Height="300" ID="lbsSourceclass" runat="server"></XS:ListBox>
					            </td>
                            </tr>
			               
                        </table>
                    </td>
                    <td  style=" vertical-align:top" align="left" width="50%">
                        <table width="100%">
				            <tr>
					            <td ><%=Resources.lang.EBTargMenu%>：</td>
					            <td align="left">						            
                                    <XS:ListBox SelectionMode="Single" Height="300" ID="lbsTarget" runat="server"></XS:ListBox>
					            </td>
				            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
					           
					            <td colspan="2">  
                                移动方式:
						            <XS:RadioButtonList id="movetype"   runat="server" >
						                <asp:ListItem Value="0" Selected="True" Text="<%$Resources:lang,EBAdjustOrderBf%>"></asp:ListItem>
						                <asp:ListItem Value="1" Text="<%$Resources:lang,EBAsTagerClass%>"></asp:ListItem>
						            </XS:RadioButtonList>  
					            </td>
				            </tr>
                <tr>
                    <td colspan="2" style="text-align: center; display: none; ">
                          <XS:Button  ID="bntSave" runat="server" Text=" <%$Resources:lang,EBSubmit%> " />
                    </td>
                </tr>
            </table>
            </div>
    </div>
</div>
<script>
    function SaveFrame() {
        $("#<%=bntSave.ClientID%>").click();
    }
</script>