<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tagvmobile.aspx.cs" Inherits="EbSite.Web.Pagesm.tagvmobile" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="taglist">
              <asp:Repeater ID="rpList"  runat="server">
                                        <ItemTemplate>
                                            <li>  
                                                <a href="<%#EbSite.Base.Host.Instance.TagsSearchList(Eval("ID"),1)%>" target=_blank><%#Eval("TagName")%></a>(<span style=" color:Red"> <%#Eval("num")%></span>)
                                                              
                                            </li>
                                        </ItemTemplate>
                            </asp:Repeater>                        
                                 
                                    
</div>

 <XS:PagesContrl ID="pgCtr" PageSize="300" runat="server" /> 
   
</body>
</html>
