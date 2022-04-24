<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Show.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.MAddress.Show" %>
<style>
    .radiusbox div{ height: 30px;line-height: 30px;padding: 8px;}
    .radiusbox div.linesolid{ height: 1px;padding: 0px;}
</style>
    <div style="padding:10px;">
    <div class="radiusbox">
      <div >收货人姓名:  <%=Model.UserRealName %></div>
      <div class="linesolid"></div> 
      <div>手机号码:  <%=Model.Mobile %></div>
      <div class="linesolid"></div> 
      <div>联系电话:  <%=Model.Phone %></div>
      <div class="linesolid"></div> 
      <div>邮政编码:  <%=Model.PostCode %></div>
      <div class="linesolid"></div> 
      <div>收货地址:  <%=Model.AddressInfo %></div>
    
    </div>
</div>