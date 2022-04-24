<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="widget.ascx.cs" Inherits="EbSite.Widgets.LocoySpider.widget" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
打开火车头，新建一个Web发布模块,在“文件发布参数”里，按以下格式填写，保存就可以了<br>
在创建任务时的第二步里，"采集内容规则",请按以下"发表Post数据"里的标签添加,采集标签时不同的标签之间一定要以逗号分开
<div style=" width:800px; ">
   <table id="tbContent">
        <tr>
            <td>
                发表地址后缀:
            </td>
            <td>
                <XS:TextBox ID="txtAddPage" Width="500" runat="server"></XS:TextBox>
            </td>                        
       </tr>
       <tr>
            <td>
                来源页面后缀:
            </td>
            <td>
                <XS:TextBox ID="txtFromPage" Width="500" runat="server"></XS:TextBox>
            </td>                        
       </tr>
       <tr>
            <td>
                发表Post数据:
            </td>
            <td>
                 <XS:TextBox ID="txtPostData" Width="500" TextMode="MultiLine" Height="200" runat="server"></XS:TextBox>
            </td>                        
       </tr>
       <tr>
            <td>
                发表错误标志:
            </td>
            <td>
                <XS:TextBox ID="TextBox1" Width="300" runat="server">发表失败</XS:TextBox>
            </td>                        
       </tr>
       <tr>
            <td>
                发表成功标志:
            </td>
            <td>
                <XS:TextBox ID="TextBox2" Width="300" runat="server">发表成功</XS:TextBox>
            </td>                        
       </tr>
   </table>
</div>