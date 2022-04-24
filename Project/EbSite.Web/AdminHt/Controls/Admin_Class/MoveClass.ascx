<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoveClass.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Class.MoveClass" %>
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
					            <td style="width:90px;"><%=Resources.lang.EBSourceEp %>:</td>
					            <td>
                                    <XS:ListBox SelectionMode="Single" Height="300" ID="lbsSourceclass" runat="server"></XS:ListBox>
					            </td>
                            </tr>
			               
                        </table>
                    </td>
                    <td   align="right" width="50%">
                        <table width="100%">
				            <tr>
					            <td ><%=Resources.lang.EBTargetEp %>:</td>
					            <td>						            
                                    <XS:ListBox SelectionMode="Single" Height="300" ID="lbsTarget" runat="server"></XS:ListBox>
					            </td>
				            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
					           
					            <td>
                                <%=Resources.lang.EBMobileWay %>:
						            <XS:RadioButtonList id="movetype"   runat="server" RepeatColumns="1">
						                <asp:ListItem Value="0" Text="<%$Resources:lang,EBAdjustOrderBf %>"></asp:ListItem>
						                <asp:ListItem Value="1" Selected="True" Text="<%$Resources:lang,EBAsTagerClass %>"></asp:ListItem>
						            </XS:RadioButtonList>  
					            </td>
				            </tr>
                <tr>
                    <td style=" text-align:center ">
                         <XS:Button ID="bntSave" Text=" <%$Resources:lang,EBSubmit %> " runat="server" />
                    </td>
                </tr>
            </table>
            </div>
    </fieldset>                                            
  
</div>
</div>