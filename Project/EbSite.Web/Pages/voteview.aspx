<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="voteview.aspx.cs" Inherits="EbSite.Web.Pages.voteview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style=" width:60%; margin-left:10px;">
        <asp:Repeater ID="rpVote" runat="server"  >
              <ItemTemplate> 
                   
                    <tr>
                        <td>
                            <%# Eval("ItemName")%>
                        </td>
                        <td>
                            <div style='width:200px; height:15px; border:1px #71AC04 solid; background-color: #EBEBEB;' align='left'>
	                            <div style='width: <%# Eval("ItemWidth")%>px;height:15px;background:#BDE777 ;'></div>
                            </div>
                        </td>
                        <td>
                            <%# Eval("Percent")%>(<%# Eval("PostCount")%>票)
                        </td>
                    </tr>   
                </ItemTemplate>
            </asp:Repeater> 
       </table>
    </form>
</body>
</html>
