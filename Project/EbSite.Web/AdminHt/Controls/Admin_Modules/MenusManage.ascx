<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="MenusManage.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Modules.MenusManage" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<div class="row">
    <div class="col-sm-12">
        <div class="card-box">
            <h4 class="m-t-0 m-b-20 header-title"><b>当前菜单名称：<asp:Label ID="MenuName" runat="server" Font-Size=Large ForeColor=Red></asp:Label></b></h4>
            <XS:ListBox SelectionMode="Single" Height="200" ID="lbsTarget"  runat="server"></XS:ListBox>
             <XS:RadioButtonList id="movetype"  RepeatColumns="1"  runat="server" >
						                <asp:ListItem Value="0" Selected="True">调整顺序到目标分类前</asp:ListItem>
						                <asp:ListItem Value="1" >作为目标分类的子分类</asp:ListItem>
						            </XS:RadioButtonList>  
                                    <div style="text-align: center; clear: both; margin-top: 10px;display: none">
                                        <XS:Button ID="bntOK" runat="server" Text=" 确 认 " onclick="bntOK_Click" />
                                    </div>
        </div>
    </div>
</div>
  <script>
     function SaveFrame() {
         $("#<%=bntOK.ClientID%>").click();
     }
 </script>