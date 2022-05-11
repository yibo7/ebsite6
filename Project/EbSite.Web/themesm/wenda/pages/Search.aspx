<%@ Page Language="C#" AutoEventWireup="true"   Inherits="EbSite.Web.Pagesm.search" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!doctype html>
<html>
<head    runat="server"></head>
<body>
<!--#include file="header.inc" -->


    <div class="eb-content">
        <h2> 共搜索到<strong><%=iSearchCount%></strong>条与<strong><%=KeyWord%></strong>相关的数据</h2>
        <div class="w-home-search">
            <form action="<%=EbSite.Base.Host.Instance.MSearchRw %>" method="get">
            <input type="submit" value=" 搜 索 " alog-alias="search">
            <div class="input">
                <div class="ui-input-mask" style="height: 45px;">
                    <input name="k" id="k" type="text" autocomplete="off" autocorrect="off" maxlength="100"
                        placeholder="请描述您的问题…" style="position: absolute; top: 0px; left: 0px; width: auto;
                        right: 40px;"><input type="hidden" name="site" value="<%=GetSiteID %>" />
                    <div class="ui-quickdelete-button" style="height: 20px; width: 20px; top: 13px; right: 10px;">
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
    <div style="background: #fff;border: 1px solid #ccc; margin:8px;">
        <ul class="data-list">
            <asp:Repeater ID="rpGetList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href="<%#HostApi.MGetContentLink(Eval("id"))%>"><%# Eval("NewsTitle")%> </a>
                                </li>  
                             </ItemTemplate>
             </asp:Repeater>
             <!--
            <XS:PagesContrl ID="PagesContrl1" Linktype="Aspx" runat="server" />  
           -->
          
          <div class="btnloadmore">加载更多...</div> 
           
        </ul>
   </div>
  <!--#include file="foot.inc" -->   
  
    <script>
        $("#k").val('<%=KeyWord %>');
  </script>                          
</body>
</html>




    
       

