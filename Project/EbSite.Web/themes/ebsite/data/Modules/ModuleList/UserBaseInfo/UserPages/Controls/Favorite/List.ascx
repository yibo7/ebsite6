<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite.List" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div class="gdList_title" >
                  <div  style="width:40px; "><span style="cursor:pointer" onclick="on_checkback($('.gdListContent'))">[全选]</span></div> 
                    <div  style="width:100px;">类别</div>
                  <div  style="width:360px;">消息标题 (共<%=iLoadCount%>条)</div>
                  <div  style="width:160px;">日期</div>
                  <div  style="width:100px;">操作</div>
                </div> 
             <XS:Repeater ID="gdList" runat="server">            
                <itemtemplate>           
                <div class="gdListContent" >
                  <div  style="width:40px;"> <input name="ebcheckboxname" value="<%#Eval("id")%>" type="checkbox" /></div> 
                  <div style="width:100px;"><a href="?t=2&tid=<%#Eval("ClassID")%>">[ <%#ClassName(Eval("ClassID").ToString())%>]</a></div>
                  <div  style="width:360px;">  <a href="<%#Eval("LinkUrl")%>" target="_blank"><%#Eval("Title")%></a></div>
                  <div  style="width:160px;"><span style=" color:#cccccc">(<%#Eval("AddDateTime")%>)</span>  </div>
                  <div style="width:100px;"><a onclick="return confirm('确认要删除所选项吗？');"  href="<%#DelUrl(Eval("id").ToString()) %>">删除</a></div>
                </div>    
            </itemtemplate>
            </XS:Repeater>
      
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
