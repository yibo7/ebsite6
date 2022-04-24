<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="votepost.aspx.cs" Inherits="EbSite.Web.Pages.votepost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method="POST" action="voteview.aspx">
         <table style=" width:60%; margin-left:10px;">
            <asp:Repeater ID="rpVote" runat="server"  >
                  <ItemTemplate>
                    <tr>
                                        <td>
                                            <%# BindItems(Eval("id").ToString())%>
                                          
                                        </td>
                                       
                                        <td>
                                              <%# Eval("ItemName")%>
                                        </td>
                    </tr>   
                  
                    </ItemTemplate>
                </asp:Repeater> 
           </table>
    </form>
</body>
</html>
