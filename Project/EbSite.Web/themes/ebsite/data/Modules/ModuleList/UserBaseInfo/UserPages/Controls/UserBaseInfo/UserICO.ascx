<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserICO.ascx.cs" Inherits="EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo.UserICO" %>
 <%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<br><br>
   
    <script type="text/javascript" src="<% =IISPath%>flash/common/common.js"></script>
 <script type="text/javascript">

     function updateavatar() {

         document.location.href =IISPath+ "UccIndex.ashx";
     }

     document.write(AC_FL_RunContent('width', '540', 'height', '253', 'scale', 'exactfit', 'src', '<%=FlashParam %>', 'id', 'mycamera', 'name', 'mycamera', 'quality', 'high', 'bgcolor', '#ffffff', 'wmode', 'transparent', 'menu', 'false', 'swLiveConnect', 'true', 'allowScriptAccess', 'always'));
</script>
	