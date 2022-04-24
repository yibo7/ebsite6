<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit.ascx.cs" Inherits="EbSite.Modules.Shop.Widgets.IndexDay.edit" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
调用类别:<XS:DropDownList ID="drpType" runat="server">
            <asp:ListItem Value="1" Text="推荐"></asp:ListItem>
            <asp:ListItem Value="2" Text="最新"></asp:ListItem>
            <asp:ListItem Value="3" Text="排行"></asp:ListItem>
            <asp:ListItem Value="4" Text="抢购"></asp:ListItem>
            <asp:ListItem Value="5" Text="团购"></asp:ListItem>
         </XS:DropDownList>
         
         <br/>
调 用 条 数： <XS:TextBox ID="txtCountTitle" CanBeNull="必填" RequiredFieldType="数据校验" Width="50" runat="server">6</XS:TextBox>
<br/>
数 据 模 板：<XS:ExtensionsCtrls ID="drpTemTitle"   ModelCtrlID="e878b3c7-6edc-466a-95da-61cb910cec68" runat="server"/>
<br/><br/><br/>
1.推荐，最新，排行 <br/>

 A.连接地址：EbSite.Base.Host.Instance.GetContentLink(int.Parse(Eval("id").ToString()), EbSite.Modules.Shop.SettingInfo.Instance.GetSiteID<br/>
 B.图片：SmallPic<br/>
 C.原价:Annex2<br/>
 D.优惠价:Annex16<br/>
 E.标题：newstitle
<br/><br/><br/>
2.抢购  <br/>
 A.连接地址：EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.RushShow(EbSite.Base.Host.Instance.GetSiteID, Eval("id"), Eval("ProductId"))<br/>
 B.图片：SmallImg<br/>
 C.原价:Price<br/>
 D.优惠价:CountDownPrice<br/>
 E.标题：Title<br/>
<br/>
3.团购 <br/><br/><br/>

 A.连接地址：EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.GroupShow(EbSite.Base.Host.Instance.GetSiteID,Eval("id"),Eval("productid"))<br/>
 B.图片：smallimg<br/>
 C.原价:Price<br/>
 D.优惠价:BuyPrice<br/>
 E.标题：Title<br/>