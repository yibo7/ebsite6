<%@ Page Language="C#" AutoEventWireup="true"   Inherits="EbSite.Web.Pagesm.tagvmobile" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink"%>
<!doctype html>
<html>
<head id="Head1"    runat="server"></head>
<body> 
<!--#include file="header.inc" -->
    <div class="eb-content">
        <h2> ��������<strong><%=iSearchCount%></strong>����<strong><%=KeyWord%></strong>��ص�����</h2>
        <div class="w-home-search">
            <form action="<%=EbSite.Base.Host.Instance.MSearchRw %>" method="get">
            <input type="submit" value=" �� �� " alog-alias="search">
            <div class="input">
                <div class="ui-input-mask" style="height: 45px;">
                    <input name="k" id="k" type="text" autocomplete="off" autocorrect="off" maxlength="100"
                        placeholder="�������������⡭" style="position: absolute; top: 0px; left: 0px; width: auto;
                                                                                                         right: 40px;">
                        <input type="hidden" name="site" value="<%=GetSiteID %>" />
                        
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
                        <li><a target="tagv" href="<%#HostApi.MGetContentLink(Eval("ID"),Eval("ClassId"),0) %>"><%# Eval("NewsTitle")%> </a></li>  
                  </ItemTemplate>
                         
            </asp:Repeater>
          </ul>
          <div class="btnloadmore">���ظ���...</div>
	    <XS:PagesContrl ID="pgCtr" runat="server" /> 
   </div>
  <!--#include file="foot.inc" -->   
    <script>
        $("#k").val('<%=KeyWord %>');
        loadpage(".data-list", ".btnloadmore", '.data-list li');
  </script>   
 
</body>
</html>
