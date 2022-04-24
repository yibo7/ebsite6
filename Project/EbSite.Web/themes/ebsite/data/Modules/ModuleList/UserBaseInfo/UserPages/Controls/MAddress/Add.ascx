<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.MAddress.Add" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:PlaceHolder ID="phCtrList" runat="server">
    <div style="padding:10px;">
    <div class="radiusbox">
      <div class="ebinput"  >   
             <asp:TextBox ID="UserRealName" placeholder="收货人姓名" runat="server"></asp:TextBox>
       </div>
       <div class="linesolid"></div> 
       <div class="ebinput" >   
              <asp:TextBox ID="AddressInfo" placeholder="收货地址" runat="server"></asp:TextBox>
       </div>
         <div class="linesolid"></div> 
       <div class="ebinput" >   
              <asp:TextBox ID="PostCode" placeholder="邮政编码" runat="server"></asp:TextBox>
       </div>
        <div class="linesolid"></div> 
       <div class="ebinput" >   
              <asp:TextBox ID="Mobile" placeholder="手机号码" runat="server"></asp:TextBox>
       </div>
       <div class="linesolid"></div> 
       <div class="ebinput" >   
              <asp:TextBox ID="Phone" placeholder="电话号码" runat="server"></asp:TextBox>
       </div>
    </div>
</div>
</asp:PlaceHolder>
<div style="text-align:center">
    <asp:LinkButton ID="bntSave" runat="server" Text=" 保存地址 "    />
</div>


