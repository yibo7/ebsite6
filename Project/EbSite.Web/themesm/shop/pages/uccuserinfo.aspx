<%@ Page Language="C#" AutoEventWireup="true"  Inherits="EbSite.Web.Pagesm.uccuserinfo" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<%@ Import Namespace="EbSite.BLL.GetLink" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
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
<form id="Form1" runat="server">
<asp:PlaceHolder ID="phBoxShow" runat="server">
    <div style="padding: 3px;">
        <div class="radiusbox" style="padding: 5px;">
            
                <div>
                    <ul   class="data-list data-list-ico" >
                       
                      <li  style="background: #fff; height: 80px;  ">
                          <a href="?t=1">
                            <dt class="toleft" style="margin-top: 30px;" >
                                头像:
                            </dt>
                            <span class="rimg" style="right: 100px;">
                                <img style="width: 80px; height: 80px"  src="<%=HostApi.AvatarBig(UserID) %>" />
                            </span>
                            <span class="arrow">
                                 
                            </span>
                            </a>
                        </li> 
                        <li style="background: #fff; ">
                            <dt class="toleft" >
                                登录帐号：
                            </dt>
                            <span class="rtext">
                               <asp:literal id="ltUserName" runat="server"></asp:literal>
                            </span>
                            <span class="arrow">
                                 
                            </span>
                        </li> 
                         <li style="background: #fff; ">
                           <dt class="toleft" >
                                电子邮箱：
                            </dt>
                            <span class="rtext">
                               <asp:literal id="txtEmail" runat="server"></asp:literal>
                            </span>
                            <span class="arrow">
                                 
                            </span>
                        </li> 
                         <li style="background: #fff; ">
                           <dt class="toleft" >
                                最后访问时间：
                            </dt>
                            <span class="rtext">
                               <asp:literal id="ltLastLogin" runat="server"></asp:literal>
                            </span>
                            <span class="arrow">
                                 
                            </span>
                        </li> 
                    </ul>
                </div>
              
             
               
        </div>
    </div>  
     </asp:PlaceHolder> 
     
     
      <asp:PlaceHolder ID="phEdite" Visible="False" runat="server">
          <style>
              .AspNetUpFile{width: 99%;}
              .AspNetBtn{ width: 99%;margin-top: 20px;}
          </style>
          <div style=" width: 100%; height: 150px;  ">
              <XS:UploadMobile  ID="txtMdPath" AllowSize="5024" Width="60%" OnUploadComplete="UploadComplete"  Height="42" AllowExt="jpg,gif"  runat="server"></XS:UploadMobile> 
             
          </div>
           <div id="tips" style="color: #ff0000;display: none;">提交中...</div> 

         <asp:Button ID="btnSaveIco" Height="50" Width="100" runat="server" style="display: none" Text="保存头像" onclick="btnSaveIco_Click" />
         <br/> <br/>
         <script>

             function UploadComplete() {
                 $("#tips").show();
                 setTimeout(function() {
                     $("#<%=btnSaveIco.ClientID %>").click();
                 }, 1000);
             }
         </script>
       </asp:PlaceHolder>
   </form>     
 <!--#include file="foot.inc" -->
</body>
</html>
