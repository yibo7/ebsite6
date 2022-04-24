<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DesignFloor.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.FloorSet.DesignFloor" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div style="border: solid 2px #000; width: 996px; height: 358px; background: url(<%=GetModulePath %>css/Floor.png)">
    <div style="height: 45px;">
        <div style="float: left; width: 200px; line-height: 45px;">
           <a href="?muid=474c0eda-f726-4cd9-b619-757798c233f1&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=0&id=<%=FloorId %>"> <span style="padding-left: 60px; padding-top: 18px; font-size: 13px; color: #AA0905;">
              设置楼层名称及色调 </span></a></div>
        <div style="float: left; width: 795px; line-height: 45px;">
            <a href="?muid=474c0eda-f726-4cd9-b619-757798c233f1&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=1&fid=<%=FloorId %>"><span style="padding-left: 369px; padding-top: 18px; font-size: 13px; color: #AA0905;">设置楼层分类</span></a>
        </div>
    </div>
    <div style="height: 302px;">
        <div style="float: left; width: 200px;">
            <a href="?muid=474c0eda-f726-4cd9-b619-757798c233f1&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=7&fid=<%=FloorId %>"><span style="padding-left: 50px; line-height: 302px; padding-top: 128px; font-size: 17px;
                color: #AA0905;">设置广告商品</span></a></div>
        <div style="float: left; width: 555px;">
            <div style="height: 30px;">
                <a href="?muid=474c0eda-f726-4cd9-b619-757798c233f1&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=3&fid=<%=FloorId %>"><span style="padding-left: 195px; line-height: 30px; padding-top: 118px; font-size: 13px;
                    color: #AA0905;">设置楼层子分类</span></a></div>
            <div style="height: 270px;">
                <a href="?muid=474c0eda-f726-4cd9-b619-757798c233f1&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=11&fid=<%=FloorId %>"><span style="padding-left: 215px; line-height: 230px; padding-top: 68px; font-size: 17px;
                    color: #AA0905;">设置商品列表</span></a></div>
        </div>
        <div style="height: 302px; line-height: 300px; float: left; width: 240px;">
            <div style="height: 254px;">
                <a href="?muid=474c0eda-f726-4cd9-b619-757798c233f1&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=9&fid=<%=FloorId %>"><span style="padding-left: 75px; line-height: 250px; padding-top: 118px; font-size: 17px;
                    color: #AA0905;">设置品牌列表</span></a></div>
            <div style="height: 40px;">
                <a href="?muid=474c0eda-f726-4cd9-b619-757798c233f1&mid=cfccc599-4585-43ed-ba31-fdb50024714b&t=5&fid=<%=FloorId %>"><span style="padding-left: 95px; line-height: 40px; padding-top: 16px; font-size: 13px;
                    color: #AA0905;">设置广告链接</span></a></div>
        </div>
    </div>
</div>
