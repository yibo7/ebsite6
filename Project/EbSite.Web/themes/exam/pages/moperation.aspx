<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.BBS.ModuleCore.Pages.moperation" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control.xsPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>

<!--#include file="header.inc" -->
    <div class="txt-c">
	<form runat="server">
    <table class="mapbox" cellpadding="0" cellspacing="0">
		<tr>
        	<td class="contentmain-right">
            	
                    <div class="adminbox" >
                        <div style="font-weight:bold">���ӹ̶�:</div>
                       <div>
                                          <XS:RadioButtonList RepeatColumns="5"  ID="rblTop" runat="server">
                                                <asp:ListItem Value="100" Text="ȡ���̶�"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="������̶�"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="���а��̶�"></asp:ListItem>
                                    </XS:RadioButtonList>
                       </div>
                       <div style="font-weight:bold">���ӱ��:</div>
                        <div>
                           
                            <XS:ListBox ID="lstbPostLab" Width="100" Height="120" runat="server">
                                <asp:ListItem Value="0" Text="ȡ�����"></asp:ListItem>
                                <asp:ListItem Value="1" Text="������"></asp:ListItem>
                                <asp:ListItem Value="2" Text="������"></asp:ListItem>
                                <asp:ListItem Value="3" Text="����"></asp:ListItem>
                                <asp:ListItem Value="4" Text="����"></asp:ListItem>
                                <asp:ListItem Value="5" Text="�̶�"></asp:ListItem>
                                <asp:ListItem Value="6" Text="����"></asp:ListItem>
                                <asp:ListItem Value="7" Text="����"></asp:ListItem>
                                <asp:ListItem Value="8" Text="����"></asp:ListItem>
                                <asp:ListItem Value="9" Text="ͶƱ"></asp:ListItem>
                                <asp:ListItem Value="9" Text="����"></asp:ListItem>
                            
                            </XS:ListBox>
                        </div>
                        <div style="font-weight:bold">��������:</div>
                        <div>
                           
                            <asp:RadioButtonList RepeatColumns="5" ID="rbllTitleFont" runat="server">
                                <asp:ListItem Value="0" Text="ȡ������"></asp:ListItem>
                                 <asp:ListItem Value="1" Text="����Ӵ�"></asp:ListItem>
                                 <asp:ListItem Value="2" Text="����б��"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div style="font-weight:bold">������ɫ:</div>
                        <div>
                                  <XS:ColorPicker ID="cpTitleColor" runat="server" />
                        </div>
                        
                    </div>
                
                     <div > 
                     
                         
                         <asp:Button id="btnSavePost" runat="server" Text=" �������� " />
                         <XS:Button id="btnDel" Confirm="true" CssClass="inputbtn" runat="server" Text="ɾ������" />
                        
                 	</div>

            </td>
        </tr>
    </table>
    </form>
</div>
<br/>              <br/>
<!--#include file="footer.inc" -->
</body>
</html>
