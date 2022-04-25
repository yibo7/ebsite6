<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMap.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_SEO.SiteMap" %>
<%@ Import Namespace="EbSite.Base.Configs.ContentSet" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %> 
 <div   class="container-fluid main-title">
    什么是网站地图？网站地图又称站点地图，它就是一个页面，上面放置了网站上所有页面的链接。大多数人在网站上找不到自己所需要的信息时，可能会将网站地图作为一种补救措施。搜索引擎蜘蛛非常喜欢网站地图 ----引自 百度百科
</div>
 <div class="container-fluid mt10">
	<div class="row-fluid"> 
        <ul class="nav nav-tabs">
            <li class="active nav-item">
                <a href="#tg1" class="nav-link active" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-sitemap"></i></span>
                    <span class="hidden-xs">网站地图更新设置</span>
                </a>
            </li>
            <li class="nav-item">
                <a href="#tg2" class="nav-link" data-toggle="tab" aria-expanded="false">
                    <span class="visible-xs"><i class="fa fa-square-o"></i></span>
                    <span class="hidden-xs">robots管理</span>
                </a>
            </li>
        </ul>
        <div class="tab-content cbrowbox-tab">
            <div id="tg1" class="tab-pane active">
                <div class="row">
                    <div class="col-sm-12">
                            <div class="form-inline">
                                <div class="form-group1">                            
                                    <div class="form-father1"><label for="name">更新频率</label></div>
                                    <div class="form-father2"><XS:TextBoxVl ID="txtMapPl" HintInfo="(24小时是最合理的时间，用以通知搜索引擎抓取频率) " runat="server" Width="100"></XS:TextBoxVl>小时</div>
                                   
                                </div>
                                

                            </div>
                            <div class="form-inline">
                                <div class="form-group1">
                                    <div class="form-father1">
                                         <label for="name">每次更新数量</label>
                                    </div>
                                    <div class="form-father2">
                                        <XS:TextBox ID="txtMapSl" HintInfo="参与网站地图的记录数量，搜索引擎推荐为50-100个。过多可能会有负作用" runat="server" Width="100"></XS:TextBox>个
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="mt10">
                                <XS:Button ID="bntSave" runat="server" Text=" <%$Resources:lang,EBSaveConfig%> " />
                                <XS:Button ID="btnMake" runat="server" Text=" 立即生成 " OnClick="btnMake_Click" />
                            </div>


                            <div class="alert alert-info mt10">本站为您自动生成的网站地图地址如下:<a target="_blank" href="<%=IISPath %>sitemapindex.xml"><%=EbSite.Base.Host.Instance.Domain%>/sitemapindex.xml</a>。</div>

                    </div>
                </div>
            </div>
            <div id="tg2" class="tab-pane">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <XS:TextBox ID="txtRobots" runat="server" Height="500" TextMode="MultiLine" Width="100%"></XS:TextBox>
                            <br />
                            <XS:Button ID="btnSaveRobots" runat="server" Text=" 保存 " OnClick="btnSaveRobots_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>  