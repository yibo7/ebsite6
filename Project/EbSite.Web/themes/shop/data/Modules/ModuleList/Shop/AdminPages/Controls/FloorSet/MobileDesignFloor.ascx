<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MobileDesignFloor.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.MobileDesignFloor" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div style="border: solid 2px #000; width: 500px; height: 201px; background: url(<%=GetModulePath %>css/mobilefloor.png)">
    <a href="FloorSet.aspx?muid=eff717bb-3ad6-4386-9849-a6c435d1a93f&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=14&id=<%=FloorId %>" style="display:block; width:170px;height:60px; margin-left:130px; margin-top:30px;"></a>
    <a href="FloorSet.aspx?muid=eff717bb-3ad6-4386-9849-a6c435d1a93f&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=15&fid=<%=FloorId %>" style="display:block; width:380px;height:27px; margin-left:70px; margin-top:28px;"></a>
    <a href="FloorSet.aspx?muid=eff717bb-3ad6-4386-9849-a6c435d1a93f&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=17&fid=<%=FloorId %>" style="display:block; width:380px;height:27px; margin-left:70px; margin-top:20px;"></a>
</div>

