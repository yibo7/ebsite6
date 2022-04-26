<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ddd.aspx.cs" Inherits="EbSite.Web.ddd" %>

<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<head runat="server">
</head>
<body style="padding: 20px">
    <script src="/js/bootstrap.min.js"></script>
    <form runat="server">
        <%--<XS:UploadImg CtrValue="/UploadFile/LogoPic/20220425/250wu355ln4-ebbaseimg.gif" ID="upImg" Width="150" Height="150"  Ext="gif,png,jpg" UploadType="单个图片" Size="1024"  runat="server"/>--%>
        <%--<XS:WebUploaderFile ID="upFile" CtrValue="/UploadFile/files/20220419/123.rar,/UploadFile/files/20220419/smehj2gjavx.rar" Ext="rar,zip,gif" UploadType="多文件上传" Size="102400" runat="server" />--%>
        <%--<XS:SWFUploadMore ID="MoreUploadImg" runat="server" AllowSize="4000" AllowExt="jpg,png,gif"  SaveFolder="testddd" />--%>
        <%--<XS:SWFUpload HintInfo="控件文件以.zip为后缀的文件" ID="txtMdPath" Width="300" AllowSize="10024" AllowExt="zip,rar,gif" runat="server"  SaveFolder="temp"></XS:SWFUpload>--%>
    </form>
    <br /> 
    <script>
        jQuery(function ($) {  
            tb_err('请先选择性别,fsdfsfdsdf')
        });

    </script>
</body>
