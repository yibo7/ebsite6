<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCredits.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderManage.MyCredits" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div class="gdList_title" >
                  
                    <div  style="width:50px;">序号</div>
                  <div  style="width:100px;">订单编号</div>
                  <div  style="width:160px;">日期</div>
                  <div  style="width:130px;">类型</div>
                   <div  style="width:100px;">增加</div>
                    <div  style="width:100px;">减少</div>
                     <div  style="width:100px;">当前积分</div>
                </div> 
             <XS:Repeater ID="gdList" runat="server">            
                <itemtemplate>           
                <div class="gdListContent" >
                  <div  style="width:50px;"> <%#Container.ItemIndex+1 %></div> 
                  <div style="width:100px;"><%#Eval("orderid") %></div>
                  <div  style="width:160px;">  <%#Eval("TradeDate")%></div>
                  <div  style="width:130px;"> <%#TypeName(Eval("TradeType").ToString())%> </div>
                   <div  style="width:100px;"> <%#Eval("Increased")%> </div>
                  <div style="width:100px;"> <%#Eval("Reduced")%></div>
                   <div style="width:100px;"> <%#Eval("Points")%></div>
                </div>    
            </itemtemplate>
            </XS:Repeater>
      
<div>
    <XS:PagesContrl ID="pcPage" runat="server" />
</div>
