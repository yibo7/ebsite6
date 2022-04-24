<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="--TimerSet.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Index.TimerSet" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<div class="admin_toobar">
    <fieldset>
        <legend>设置定时器</legend>
        <div >
            <XS:CheckBox ID="cbIsOpenIndexTimerUpdate" HintInfo="首页的更新方式有两种，第一种是定时更新，第二种是直接访问动态页(可缓存硬盘)，如果将iis里的默认文档设置为index.htm,那么要开启定时更新,设置为index.aspx不用开启此功能"  Text="是否开启首页定时更新" runat="server" />
             <br /> <br />
            每隔&nbsp;&nbsp;
            <XS:TextBoxVL IsAllowNull="false" ValidateType="匹配正整数" ID="txtTimeLen" runat="server" Width="50px"></XS:TextBoxVL> 
            &nbsp;分钟生成一次&nbsp;&nbsp;
            <br /> <br />
            <XS:Button ID="bntSave" runat="server" Text="<%$Resources:lang,EBSaveConfig%>" />
        </div>
    </fieldset>
</div>