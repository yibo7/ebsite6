<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Modules.BBS.ModuleCore.Pages.moperation" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Register Assembly="EbSite.ControlData" TagPrefix="XSD" Namespace="EbSite.ControlData" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>

<!--#include file="header.inc" -->
  
	<form id="Form1" runat="server">
    <center>
<table class="mapbox" cellpadding="0" style="width: 90%" cellspacing="0">
		<tr>
		    <td class="contentmain-left" style="width: 50%; float: right; ">
                 
                    <div class="adminbox" style="float: right;vertical-align: top; height: 500px;" >
                        <div style="font-weight:bold">帖子固顶:</div>
                       <div>
                                          <XS:RadioButtonList RepeatColumns="5"  ID="rblTop" runat="server">
                                                <asp:ListItem Value="100" Text="取消固顶"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="分类版块固顶"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="所有版块固顶"></asp:ListItem>
                                    </XS:RadioButtonList>
                       </div>
                       <div style="font-weight:bold">帖子标记:</div>
                        <div>
                           
                            <XS:ListBox ID="lstbPostLab" Width="100" Height="120" runat="server">
                                <asp:ListItem Value="0" Text="取消标记"></asp:ListItem>
                                <asp:ListItem Value="1" Text="精华贴"></asp:ListItem>
                                <asp:ListItem Value="2" Text="热门贴"></asp:ListItem>
                                <asp:ListItem Value="3" Text="蓝旗"></asp:ListItem>
                                <asp:ListItem Value="4" Text="红旗"></asp:ListItem>
                                <asp:ListItem Value="5" Text="绿顶"></asp:ListItem>
                                <asp:ListItem Value="6" Text="蓝顶"></asp:ListItem>
                                <asp:ListItem Value="7" Text="红星"></asp:ListItem>
                                <asp:ListItem Value="8" Text="绿星"></asp:ListItem>
                                <asp:ListItem Value="9" Text="投票"></asp:ListItem>
                                <asp:ListItem Value="9" Text="提问"></asp:ListItem>
                            
                            </XS:ListBox>
                        </div>
                        <div style="font-weight:bold">标题字体:</div>
                        <div>
                           
                            <asp:RadioButtonList RepeatColumns="5" ID="rbllTitleFont" runat="server">
                                <asp:ListItem Value="0" Text="取消设置"></asp:ListItem>
                                 <asp:ListItem Value="1" Text="标题加粗"></asp:ListItem>
                                 <asp:ListItem Value="2" Text="标题斜体"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div style="font-weight:bold">标题颜色:</div>
                        <div>
                                  <XS:ColorPicker ID="cpTitleColor" runat="server" />
                        </div>
                        <br/>
                         <div> <asp:Button id="btnSavePost" runat="server" Text=" 保存以上设置 " /></div>
                    </div>
		       
            </td>
        	<td class="contentmain-right" style="width: 50%; text-align: left;vertical-align: top;padding: 20px;">
        	   <div style="font-weight:bold">移动帖子到:</div>
                        <div>
                            <XSD:SelectClass ID="selClass" Size="25"  runat="server"></XSD:SelectClass>
                           
                        </div>
                        <div> <asp:CheckBox ID="isUpdatePostTime" Checked="True"  Text="是否刷新发帖时间(修改后帖子排在第一位)" runat="server" /></div>
                <div>  <XS:Button id="btnMovePost" Confirm="true" CssClass="inputbtn" runat="server" Text="确认移动到所选分类" /></div>
                <div>  <XS:Button id="btnDel" Confirm="true" CssClass="inputbtn" runat="server" Text="删除帖子(小心操作)" /></div>
            </td>
        </tr>
    </table>
     
    </center>
    </form>
<br/>              <br/>
<!--#include file="footer.inc" -->
</body>
</html>
