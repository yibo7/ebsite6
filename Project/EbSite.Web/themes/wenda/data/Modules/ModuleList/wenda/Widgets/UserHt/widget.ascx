<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Modules.Wenda.Widgets.UserHt.widget" %>
<style>
    .tb{ font-size: 14px;}
</style>
<div class="tb">1.<a href="/m/ZhuanJiaDaNing.ashx"><span style="color: red;" > ��������</span></a> δ�ش�<a href="/m/ZhuanJiaDaNing.ashx"><span style="color: red;" ><%=MyNoAskCount %></span></a>���ѻش�<%=MyOkAskCount %>��</div>
<div class="tb">2.<a href="/wenda/index.html" target="_blank"><span style="color: red;" > ��������</span></a> �ѻش�<%=OkAskCount %>��δ�ش�<%=NoAskCount %>��</div>

<div class="tb">3.<a  target="_blank" href=<%=string.Format("http://www.beimai.com/jieda-2-{0}-1.ashx",EbSite.Base.Host.Instance.UserID) %>>
                            
                            <span style="color: red;" >�ʴ���� </span></a></div>