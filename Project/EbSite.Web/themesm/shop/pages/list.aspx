<%@ Page Language="C#" AutoEventWireup="true" Inherits="EbSite.Web.Pagesm.list" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <title></title>
 
</head>
<body>
    <div id="page">
        <div class="cont">
            <!--#include file="header.inc" -->
            <div class="w-navigator">
                <a <%=rpGetSubClassList.Items.Count>0?"class='selclass'":"class='selclassex'" %>><%=Model.ClassName %></a>
                <a href="javascript:void()" class="filterclass">ɸѡ</a>
            </div>
            <div class="cmnTab orderBar">
                <a id="sort2" href="?orderby=2"><span>�۸��</span></a><a id="sort3" href="?orderby=3"><span>�۸��</span></a><a id="sort4" href="?orderby=4"><span>���ۡ�</span></a><a href="?orderby=1" id="sort1"><span>������</span></a>
            </div>
            <div id="container1">
                <ul class="data-listex">
                    <XS:RepeaterList ID="rpGetClassList" runat="server">
                        <ItemTemplate>
                            <li>
                                <a class="ItemCell" href="<%#HostApi.MGetContentLink(Eval("ID")) %>">
                                    <div class="ProImg">
                                         <img width="80" height="60" alt=" <%#Eval("newstitle")%>" src="<%#Eval("smallpic") %>">
                                    </div>
                                    <div class="proright">
                                        <div class="ProName"><%#Eval("newstitle")%></div>
                                        <div class="NePrice"> <span>&yen;<%#Eval("annex16") %></span><em>(��棺<%# EbSite.Core.Utils.ObjectToInt(Eval("annex12"),0)>0?"�л�":"<span style='color:red;'>��ʱȱ��</span>" %>)</em></div>
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </XS:RepeaterList>
                </ul>
                
            </div>
            <div class="btnloadmore">���ظ���...</div>
                <XS:PagesContrl ID="pgCtr" PageSize="5" runat="server" />
            <!--#include file="foot.inc" -->
        </div>
        <div class="panel" style="margin-left: 0px; margin-right: 0px; padding-left: 0px; padding-right: 0px;">
            <h2 style="color: white; padding-left: 20px;">
                <%=Model.ClassName %></h2>
            <div style="width: 100%; height: 2px; margin-top: 10px; background-color: #514f4f; z-index: 1;">
                <div style="height: 2px; width: 108px; margin: 0px; padding: 0px; background-color: #b7b7b7; z-index: 999;">
                </div>
            </div>
            <ul class="panel-dir">
                <XS:RepeaterList ID="rpGetSubClassList" runat="server">
                    <ItemTemplate>
                        <li>&nbsp;&nbsp;<a href="<%#EbSite.Base.Host.Instance.MGetClassHref(Eval("id"),1,0)%>"><%# Eval("classname")%></a></li>
                    </ItemTemplate>
                </XS:RepeaterList>
            </ul>
        </div>
        <div class="filterpanel" style="margin-left: 0px; margin-right: 0px; padding-left: 0px; padding-right: 0px;margin-top:-10px;">
      
            <div style="width:100%; height:100%; background-color:#D1CCC7;font-size:14px;font-family:'Microsoft YaHei'; ">
                   <div style="padding-top: 5px; text-align: center;">��Ʒɸѡ</div>
                   
               
                        <XS:Repeater ID="rptMBigSpecialList" runat="server" EnableViewState="false">
                            <ItemTemplate>
                               <div class="rsxtop">����: <%#Eval("Text")%></div>
                              
                               <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> "><div class="rsx">����</div></a>
                                        <XS:Repeater ID="rpSubList" runat="server">
                                            <ItemTemplate>
                                             <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>">  <div class="rsx"><%#Eval("Text")%></div></a>
                                            </ItemTemplate>
                                        </XS:Repeater>
                                      
                            </ItemTemplate>
                        </XS:Repeater>
                        <XS:Repeater ID="rptMSpecialList" runat="server">
                            <ItemTemplate>
                                 <div class="rsxtop">����</div>
                                  <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> "><div class="rsx">����</div></a>
                               
                                        <XS:Repeater ID="rpSubList" runat="server">
                                            <ItemTemplate>
                                                <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>"> <div class="rsx"><%#Eval("Text")%></div></a>
                                            </ItemTemplate>
                                        </XS:Repeater>
                                      
                            </ItemTemplate>
                        </XS:Repeater>
                        <XS:Repeater ID="rptMBrandList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                              <div class="rsxtop">Ʒ��</div>
                              <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> "><div class="rsx">����</div></a>
                                           
                                        <XS:Repeater ID="rpSubList" runat="server">
                                            <ItemTemplate>
                                                <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>"> <div class="rsx"><%#Eval("Text")%></div></a>
                                            </ItemTemplate>
                                        </XS:Repeater>
                                      
                            </ItemTemplate>
                        </XS:Repeater>
                        <XS:Repeater ID="rpMSKUList" runat="server" EnableViewState="False">
                    <ItemTemplate>
                         <div class="rsxtop"><%#Eval("Text")%></div>
                       
                       <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %> "><div class="rsx">����</div></a>
                                <XS:Repeater ID="rpSubList" runat="server">
                                    <ItemTemplate>
                                        <a href="<%#Eval("Url") %>" class="<%#Eval("StyleBg") %>"> <div class="rsx"><%#Eval("Text")%></div></a>
                                    </ItemTemplate>
                                </XS:Repeater>
                             
                    </ItemTemplate>
                </XS:Repeater>
                  
            </div>
        </div>
    </div>
    <script type="text/javascript">
       loadpage(".data-listex", ".btnloadmore", '.data-listex li');

       // loadpage(".data-list", ".btnloadmore", '.data-list li');
        function GetUrlParams(ParamName) {
            var URLParams = new Object();
            var aParams = document.location.search.substr(1).split('&');
            for (i = 0; i < aParams.length; i++) {
                var aParam = aParams[i].split('=');
                URLParams[aParam[0]] = aParam[1];
            }

            var sValue = URLParams[ParamName];
            if (sValue == undefined)
                return "";
            return sValue;
        }

        toggleright("selclass", "panel", "cont", "right");
        

        //ɸѡ�¼�
        toggleright("filterclass", "filterpanel", "cont", "right");

        var orderby = GetUrlParams("orderby");
        $("#sort" + orderby).addClass("curr");
        function hidefilterpanel()
        {
            $(".filterclass").click();
        }
    </script>
</body>
</html>
