<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ebtips.aspx.cs" Inherits="EbSite.Web.ebtips" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body style="text-align:center; background:#F5F4F5 ">
    <center>
    <div style="text-align:left; background:#FFF;  font-size:13px; border:solid 1px #ABAAAB;  width:500px; margin-top: 50px; ">
       <div style="padding: 8px;border-bottom: 1px solid #BAB9BA;background: #DBDADB;" >操作提示</div>
       <div style="padding:10px; height:200px;">
        <asp:Label ID="lbInfo" runat="server" ></asp:Label>
       </div>
       <div style="padding: 8px; text-align: right;"><a href="<%=IISPath %>" >返回首页</a></div>
     </div>
     </center>
</body>
</html>
