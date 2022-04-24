<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassList.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite.ClassList" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>

<div class="gdList_title" >

                  <div   style="width:30px;">序号</div> 
                  <div   style="width:360px;">  &nbsp;分类名称 (共<%=iLoadCount%>条)</div>
                  <div  style="width:130px;">操作  </div>
                </div>    
<XS:Repeater ID="gdList" runat="server">
    <itemtemplate> 
                <div class="gdListContent" >
                  <div style="width:30px;"> <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.ItemIndex + 1%></div> 
                  <div   style="width:360px;">   <%#Eval("ClassName")%></div>
                  
                  <div style="width:130px;">
                   [<a href="<%#ModifyBoxUrl(Eval("id").ToString()) %>">修改</a>]
                   [<a onclick="return confirm('确认要删除所选项吗？同时删除分类下面的收藏文件！');"  href='<%#DelUrl(Eval("id").ToString()) %>'>删除</a>]
                   [<a  href='<%#ShowUrl(Eval("id").ToString()) %>'>查看</a>]
                    </div>
                </div>           
               
            </itemtemplate>
</XS:Repeater>
   <XS:PagesContrl ID="pcPage" runat="server" />
   
   <script>


       function OpenAddPage() {
           window.location.href = "?mukey=ce3670a8-c31b-4913-bb26-1214717f5df5";
       }
   </script>