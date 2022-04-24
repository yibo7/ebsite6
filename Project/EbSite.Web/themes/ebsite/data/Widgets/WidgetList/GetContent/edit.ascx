<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Widgets.GetContent.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

 选择分类:<XS:DropDownList ID="drpClass" AppendDataBoundItems="true" runat="server">
            <asp:ListItem Value="0">全部分类</asp:ListItem>
            <asp:ListItem Value="-1">自动适应分类</asp:ListItem>
            <asp:ListItem Value="-2">自动适应内容</asp:ListItem>
         </XS:DropDownList>
         或指定分类ID:<XS:TextBox HintInfo="超过500个分类时，不能列表出来，只能指定子分类ID" ID="txtIDs" Width="50" runat="server"></XS:TextBox>
         <br /><br />
         调用类别:<XS:DropDownList ID="drpType" runat="server">
            <asp:ListItem Value="1" Text="最新数据列表"></asp:ListItem>
            <asp:ListItem Value="2" Text="推荐数据列表"></asp:ListItem>
            <asp:ListItem Value="3" Text="总点击排行"></asp:ListItem>
            <asp:ListItem Value="4" Text="本周点击排行"></asp:ListItem>
            <asp:ListItem Value="5" Text="收藏率排行"></asp:ListItem> 
            <asp:ListItem Value="6" Text="评论最多的内容"></asp:ListItem>
            <asp:ListItem Value="7" Text="好评(被顶)最多的内容"></asp:ListItem> 
            <asp:ListItem Value="8" Text="今日点击排行"></asp:ListItem>
            <asp:ListItem Value="9" Text="本月点击排行"></asp:ListItem>             
         </XS:DropDownList>
<br /><br />
是否只调用有图片的内容:<asp:CheckBox ID="cbIsGetSmallImg" runat="server" />
<br /><br />
是否调用子分类下的数据:<asp:CheckBox ID="cbIsGetSub" runat="server" />
<br /><br />
自定义模板:
<XS:ExtensionsCtrls ID="drpTem"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
<br /><br />
调用条数:<XS:TextBoxVl ID="txtCount"   IsAllowNull="false" ValidateType="整数"   Width="50" runat="server">12</XS:TextBoxVl>

<br><br />
使用说明:<br>
 如果您想更改数据展示方式,请自定义数据模板,自定义模板这里使用相对路径,<br />
 如你上传一个数据模板在网站根目录下,<br />
 名为test.ascx,输入/test.ascx即可,<br />
 制作模板时可调用字段(具体意义查看模型):
         id;
         smallpic;
         newstitle;
         titlestyle;
         classid;
         hits;
         isgood;
         contentinfo;
         dayhits;
         weekhits;
         monthhits;
         lasthitstime<br />
         tagids;
         userid;
         orderid;
         htmlname;
         contenttemid;
         contenthtmlnamerule;
         markismakehtml;
         iscomment;
         addtime;
         username;
         annex1;<br />
         annex2;
         annex3;
         annex4;
         annex5;
         annex6;
         annex7;
         annex8;
         annex9;
         annex10;
         ClassName;
         