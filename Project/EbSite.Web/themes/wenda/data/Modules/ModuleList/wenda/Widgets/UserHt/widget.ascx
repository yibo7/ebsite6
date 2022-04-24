<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.UserHt.widget" %>
<style>
    .tb{ font-size: 14px;}
</style>
<div class="tb">1.<a href="/m/ZhuanJiaDaNing.ashx"><span style="color: red;" > 最新问题</span></a> 未回答（<a href="/m/ZhuanJiaDaNing.ashx"><span style="color: red;" ><%=MyNoAskCount %></span></a>）已回答（<%=MyOkAskCount %>）</div>
<div class="tb">2.<a href="/wenda/index.html" target="_blank"><span style="color: red;" > 所有问题</span></a> 已回答（<%=OkAskCount %>）未回答（<%=NoAskCount %>）</div>

<div class="tb">3.<a  target="_blank" href=<%=string.Format("http://www.beimai.com/jieda-2-{0}-1.ashx",EbSite.Base.Host.Instance.UserID) %>>
                            
                            <span style="color: red;" >问答管理 </span></a></div>