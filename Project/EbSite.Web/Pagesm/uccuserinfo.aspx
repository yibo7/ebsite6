<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uccuserinfo.aspx.cs" Inherits="EbSite.Web.Pagesm.uccuserinfo" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<head runat="server">
    <title></title>
</head>
<body>
      <div class="toolbar " id="toolbar">
  <span class="button fl backpage" >返回</span>
  <h2 class="title" >
    <%=MTitle %>
    </h2>
  <span class="button fr" url="<%=EbSite.Base.AppStartInit.IISPath%>LogOut.aspx" id="">退出</span>
</div>
    <div style="padding: 3px;">
        <div class="radiusbox" style="padding: 5px;">
           <asp:PlaceHolder ID="phBoxShow" runat="server">
                <div>
                    <ul   class="data-list data-list-ico" >
                       
                      <li  style="background: #fff; ">
                            <dt >
                                头像:
                            </dt>
                            <span class="rightimg">
                                <img   src="<%=HostApi.AvatarBig(UserID) %>" />
                            </span>
                            <span class="arrow">
                                 
                            </span>

                        </li> 
                        <li style="background: #fff; ">
                            <dt >
                                登录帐号：
                            </dt>
                            <span class="rightimg">
                               <asp:literal id="ltUserName" runat="server"></asp:literal>
                            </span>
                            <span class="arrow">
                                 
                            </span>
                        </li> 
                         <li style="background: #fff; ">
                           <dt >
                                电子邮箱：
                            </dt>
                            <span class="rightimg">
                               <asp:literal id="txtEmail" runat="server"></asp:literal>
                            </span>
                            <span class="arrow">
                                 
                            </span>
                        </li> 
                         <li style="background: #fff; ">
                           <dt >
                                最后访问时间：
                            </dt>
                            <span class="rightimg">
                               <asp:literal id="ltLastLogin" runat="server"></asp:literal>
                            </span>
                            <span class="arrow">
                                 
                            </span>
                        </li> 
                    </ul>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phEdite" Visible="False" runat="server">
                <XS:UploadMobile  ID="txtMdPath" AllowSize="5024" Width="60%"  Height="42" AllowExt="png,jpg,gif"  runat="server"></XS:UploadMobile>  
               <asp:Button ID="btnSaveIco" Height="50" Width="100" runat="server" Text="保存头像" 
                      onclick="btnSaveIco_Click" />
             </asp:PlaceHolder>
               
        </div>
    </div>
      <div>
                  
              </div>
</body>
</html>
