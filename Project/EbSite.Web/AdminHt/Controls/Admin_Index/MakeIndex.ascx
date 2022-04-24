<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MakeIndex.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Index.MakeIndex" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
 

<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
            <div class="boxheader">
                <h3><%=Resources.lang.Menudd231a18%></h3>
            </div>
            <div class="content">
				<XS:Button ID="bntSave" Text=" 立即生成首页 " runat="server" />
            <asp:Label ID="lbErr" runat="server"  ></asp:Label>
            </div>
    </div>
</div>


<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>是否开启首页缓存</h3>
            </div>
            <div class="content">
				 
            <XS:CheckBox ID="cbIsIndexCache"  HintInfo="在调试模式下为了能即时查看修改效果，可以设置为不启用"  Text="是否开启首页缓存" runat="server" />
                <br />
            <XS:Button ID="bntSaveConfig" Text=" 保存设置 " runat="server" />
           
            </div>
    </div>
</div>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>手机站点首页</h3>
            </div>
            <div class="content">
				 <div>
                <a target="_blank" href="<%=HostApi.MobileBarcode%>">
                    <asp:Image ID="imgMobileIndexImg" runat="server" />
                </a>
            
            </div>
            <div>
                
            <asp:Button ID="btnMakeBarcode"  runat="server" Text="重新生成二维码" onclick="btnMakeBarcode_Click" />
            </div>
            </div>
    </div>
</div>

 