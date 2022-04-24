<%@ Page Language="C#" AutoEventWireup="true"   Inherits="EbSite.Web.Pages.votepost" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    
    
<div  style="background-color:#F4F4F4">
   <div class="usercontainer" style="position:relative; ">
    
	  
     	<div class="top_part2 logoline">
         	 	<div class="bmlogo"><img src="<% =base.ThemeCss%>user/smalllogo.gif"  class="logo" /></div>
		 	 <div class="logofont">查看投票</div>
			<div class="logofnt">做最好用的.net网站建设系统</div>
          	<div class="login_link"><a href="/">首页</a> <a>帮助</a></div>
      	</div>
      <div class="clear"></div>
     

   </div>
</div>


<div class="usercontainer2"  >
	<div class="usercontainer"  style="background-color:#FFFFFF; border:1px solid #ccc; height:600px; padding: 10px;  ">
	    
	    <div style="float: left; width: 50%;">
	            <div style="border-bottom: 1px dotted #ccc; width: 80%; line-height: 30px; font-size: 14px; font-weight: bold;"><%=Model.VoteName %></div>
	            
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
                        <table>
                            <tr>
                                <td>
                                  
                                <div style="padding: 8px;background: #A31602; width: 80px; margin-top: 30px;color: #fff; text-align: center; cursor: pointer;" onclick="PostVote(<%=Model.IsMoreSel.ToString().ToLower() %>,<%=Model.id %>,'divVoteItems',<%=Model.AllowMaxSel %>,<%=GetSiteID %>)">
                                       投 票
                                 </div>
                                
                                </td>
                                <td>
                                    
                                    <div style="padding: 8px;background: #2FA367; width: 100px; margin-top: 30px; text-align: center; ">
                                       <a style="color: #fff"  href="<%=EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetVoteView(Model.id)%> ">查看投票结果</a>
                                     </div>

                                </td>
                            </tr>
                        </table>
                       

                </form>


                    
	    </div>
	   
          <div style="float: right;width: 50%;">
              <div style="height: 30px; line-height: 30px; background: #F7F7F7; border-bottom: 1px solid #ccc; padding-left: 10px; font-size: 14px;">
                  其他投票
              </div>
              <div class="votelist">
                  <XS:Widget WidgetName="投票列表"  WidgetID="daf1b481-596f-435b-b6c8-0146802947af" runat="server"/>
              </div>
          </div>

	</div>   
</div>
    

</body>
</html>
