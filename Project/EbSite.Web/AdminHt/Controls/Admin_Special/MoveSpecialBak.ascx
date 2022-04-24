<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoveSpecialBak.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Special.MoveSpecialBak" %>
  <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
  <div style="text-align:center ">
  <div class="admin_toobar" style="width:60%; " >
   <fieldset>
        <legend>移动分类</legend>
           <div>  
     
      <table cellspacing="0" cellpadding="4" width="100%" align="center">
                <tr>
                    <td  style=" vertical-align:top" align="left" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width:90px;">源版块:</td>
					            <td>
                                    <XS:ListBox SelectionMode="Single" Height="300" ID="lbsSourceclass" runat="server"></XS:ListBox>
					            </td>
                            </tr>
			               
                        </table>
                    </td>
                    <td   align="right" width="50%">
                        <table width="100%">
				            <tr>
					            <td >目标版块:</td>
					            <td>						            
                                    <XS:ListBox SelectionMode="Single" Height="300" ID="lbsTarget" runat="server"></XS:ListBox>
					            </td>
				            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
					           
					            <td>
                                移动方式:
						            <XS:RadioButtonList id="movetype"   runat="server" RepeatColumns="1">
						                <asp:ListItem Value="0" >调整顺序到目标分类前</asp:ListItem>
						                <asp:ListItem Value="1" Selected="True">作为目标分类的子分类</asp:ListItem>
						            </XS:RadioButtonList>  
					            </td>
				            </tr>
                <tr>
                    <td style=" text-align:center ">
                         <XS:Button ID="bntSave" Text=" 提 交 " runat="server" />
                    </td>
                </tr>
            </table>
            </div>
    </fieldset>                                            
  
</div>
</div>