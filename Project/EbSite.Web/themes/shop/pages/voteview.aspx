<%@ Page Language="C#" AutoEventWireup="true"   Inherits="EbSite.Web.Pages.voteview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table style="  margin-left:10px;">
        <asp:Repeater ID="rpVote" runat="server"  >
              <ItemTemplate> 
                   
                    <tr>
                       
                        <td>
                           <div style="font-size: 14px; ">
                               <%# Eval("ItemName")%>
                           </div>
                            <div style='width:200px; height:15px; background:#EBEBEB ; '  align='left'>
	                            <div style='width: <%# Eval("ItemWidth")%>px;height:15px;background:#<%=GetColor%> ;'></div>
                            </div>
                        </td>
                        <td style=" vertical-align:bottom" >
                            <%# Eval("Percent")%>(<%# Eval("PostCount")%>票)
                        </td>
                    </tr>   
                </ItemTemplate>
            </asp:Repeater> 
       </table>
       <div>
           
           <a  href="<%=EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetVotePost(Model.id)%> ">去投票</a>

       </div>

</body>
</html>
