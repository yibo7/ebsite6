<%@ Page Language="C#" AutoEventWireup="true"   Inherits="EbSite.Web.Pages.votepost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method="POST" action="voteview.aspx">
            <div id="divVoteItems">
                <asp:Repeater ID="rpVote" runat="server"  >
                  <ItemTemplate>
                    <div>
                         <%# BindItems(Eval("id"), Eval("ItemName"))%> 
                    </div>
                    </ItemTemplate>
                </asp:Repeater> 
            </div>
         
           <div>
               
               <input style="padding: 8px; background-color: #006400; color: #fff;" onclick="PostVote(<%=Model.IsMoreSel.ToString().ToLower() %>,<%=Model.id %>,'divVoteItems',<%=Model.AllowMaxSel %>,<%=GetSiteID %>)" type="button" value=" 投 票 " />
           </div>
           <a  href="<%=EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetVoteView(Model.id)%> ">查看投票结果</a>


    </form>
</body>
</html>
