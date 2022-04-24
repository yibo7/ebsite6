<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EbSite.Web.Pagesm.index" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <XS:Repeater runat="server" ID="rpList">
                        <ItemTemplate>
                                <li><a href="http://www.baidu.com">
                            <dt>谁知道前机盖撑杆，前平衡杆开口胶，后平衡杆开口胶，车型：韩国起亚索兰托，价格吗?</dt>
                            <dd class="content">
                                新华网深圳3月23日电（记者 赵瑞西）23日，深圳市南山区西里医院的大楼</dd>
                            <dd class="source">
                                提问：新浪&nbsp;&nbsp;时间:2013-4-10 9:01:28</dd>
                        </a></li> 
                         </ItemTemplate>    
                       </XS:Repeater>
                        <div class="pageindex">
                        <XS:PagesContrl PageSize="20" ID="pgCtr" ReWritePatchUrl="/wenda/{0}-index.ashx" runat="server" />
                    </div>
    </div>
    </form>
</body>
</html>
