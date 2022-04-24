<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ddd.aspx.cs" Inherits="EbSite.Web.ddd" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<head runat="server">
</head>
<body style="padding: 20px">
    <script src="/js/bootstrap.min.js"></script>
    <form runat="server">
        <%--<XS:UploadImg ID="upImg" Width="150" Height="150"  Ext="gif,png,jpg" UploadType="单个图片" Size="1024"  runat="server"/>--%>
        <XS:WebUploaderFile ID="upFile" CtrValue="/UploadFile/files/20220419/123.rar,/UploadFile/files/20220419/smehj2gjavx.rar" Ext="rar,zip,gif" UploadType="多文件上传" Size="102400" runat="server" />
        <%--<XS:SWFUploadMore ID="MoreUploadImg" UploadModel="Net默认组件" runat="server" AllowSize="4000" AllowExt="jpg,png,gif" IsMakeSmallImg="true" SaveFolder="testddd" />--%>
    </form>
    <br />
    

</body>
