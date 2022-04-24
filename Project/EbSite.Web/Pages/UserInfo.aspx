<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="EbSite.Web.Pages.UserInfo" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Repeater ID="rpDataList" runat="server"  >
                      <ItemTemplate> 
                    
                        </ItemTemplate>
                    </asp:Repeater> 
     <XS:PagesContrl ID="pgCtr" runat="server" />  
     
     <asp:Repeater ID="rpVisit" runat="server"  >
               <ItemTemplate> 
                    
               </ItemTemplate>
      </asp:Repeater> 
      
      <asp:Repeater ID="rpFrineds" runat="server"  >
              <ItemTemplate> 
                    
              </ItemTemplate>
      </asp:Repeater>

</body>
</html>
