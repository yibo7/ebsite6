<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCoupons.ascx.cs" Inherits="EbSite.Modules.Shop.UserPages.Controls.OrderManage.MyCoupons" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<XS:ToolBar ID="ucToolBar" runat="server"></XS:ToolBar>
<div class="gdList_title" >
                
                    <div  style="width:200px;">优惠券名称</div>
                  <div  style="width:120px;">号码</div>
                  <div  style="width:100px;">满足金额</div>
                  <div  style="width:100px;">面值</div>

                   <div  style="width:160px;"> 有效期(止)</div>
                 
                </div> 
             <XS:Repeater ID="gdList" runat="server">            
                <itemtemplate>           
                <div class="gdListContent" >
                   <div  style="width:200px;"><%#Eval("CouponName")%></div>
                  <div  style="width:120px;"><%#Eval("ClaimCode")%></div>
                  <div  style="width:100px;"><%#Eval("Amount")%></div>
                  <div  style="width:100px;"><%#Eval("DiscountPrice")%></div>
                   <div  style="width:160px;"> <%#Eval("EndDateTime")%></div>
                </div>    
            </itemtemplate>
            </XS:Repeater>
      

