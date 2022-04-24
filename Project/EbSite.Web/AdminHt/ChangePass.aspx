<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="EbSite.Web.AdminHt.ChangePass" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<asp:content id="Content1" contentplaceholderid="ctphBody" runat="Server">
    <div class="row cbrowbox">
    <div class="col-sm-12"> 
            <h4 class="m-t-0 m-b-20 header-title"><b>修改密码</b></h4>
            <div class="form-group">
		<label>原 密 码</label>
		<XS:TextBoxVl ID="txtOldPass" Width="200" runat="server"  TextMode="Password" IsAllowNull="false" />
	  </div>
	  <div class="form-group">
		<label >新 密 码</label>
		<XS:TextBoxVl  ID="txtPassWord" Width="200" runat="server" TextMode="Password"  IsAllowNull="false" />
	  </div>
            <div class="form-group">
		<label >新 密 码</label>
		<XS:TextBoxVl  ID="txtCfPassWord" Width="200" runat="server" TextMode="Password" IsAllowNull="false" />
	  </div>  
    </div>
</div> 
    <div class="text-center mt10">
        
 <XS:Button ID="bntSave" runat="server" OnClick="OnClick" Width="100"  Text=" 修改 " />
    </div>

  
</asp:content>
