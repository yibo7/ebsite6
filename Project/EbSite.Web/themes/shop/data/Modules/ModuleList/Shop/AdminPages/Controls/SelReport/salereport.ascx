<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="salereport.ascx.cs"
    Inherits="EbSite.Modules.Shop.AdminPages.Controls.SelReport.salereport" %>
<link type="text/css" href="<%=EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"))%>/css/ht.css" rel="stylesheet" />
<div class="dataarea ">
    <!--搜索-->
    <div class=" VIPbg m_none colorG">
        查看网店生意情况，您可以按月或按日分别查看店铺订单交易量、交易额和销售利润（需要设置商品成本价）
    </div>
    <h3>
        按月统计</h3>
    <!--结束-->
    <div>
        <div class="searcharea clearfix br_search">
            <ul class="a_none_left">
                <li><span>请选择：</span><span class="colorR">年</span><li>
                    <abbr class="formselect">
                        <asp:DropDownList ID="ddl_YearMonth" runat="server">
                            <asp:ListItem Value="2013" Selected="True">2013</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                        </asp:DropDownList>
                    </abbr>
                </li>
                    <li><span>
                        <asp:RadioButtonList ID="rdolist_month" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="l" Selected="True">交易量</asp:ListItem>
                            <asp:ListItem Value="e">交易额</asp:ListItem>
                            <asp:ListItem Value="r">利润</asp:ListItem>
                        </asp:RadioButtonList>
                    </span></li>
                    <li>
                        <asp:Button ID="btnSeachMonth" runat="server" Text="查询" CssClass="searchbutton" OnClick="btnSeachMonth_Click" />
                    </li>
                    
            </ul>
        </div>
        <div class="functionHandleArea clearfix m_none">
            <!--分页功能-->
            <div class="pageHandleArea">
                <ul>
                    <li class="paginalNum Pg_10"><asp:Literal ID="litTotalCount" runat="server" Text="总交易量"></asp:Literal>：<strong
                        class="colorA"><asp:Literal ID="litMonthSumCount" runat="server"></asp:Literal></strong></li>
                    <li class="paginalNum"><asp:Literal ID="litHeightCount" runat="server" Text="最高峰交易量"></asp:Literal>：<strong
                        class="colorA"><asp:Literal ID="litMonthMaxCount" runat="server"></asp:Literal></strong></li>
                </ul>
            </div>
        </div>
        <!--数据列表区域-->
        <div class="datalist">
            <div>
                <table cellspacing="0" border="0" id="ctl00_contentHolder_grdMonthSaleTotalStatistics" style="width: 100%; border-collapse: collapse;">
                    <tr class="table_title">
                        <th class="td_right td_left" scope="col">
                            月份
                        </th>
                        <th class="td_right td_left" scope="col">
                            <asp:Literal ID="litmonthtitle" runat="server" Text="交易量"></asp:Literal>
                        </th>
                        <th class="td_right td_left" scope="col" style="width: 60%;">
                            比例示意图
                        </th>
                    </tr>
                    <asp:Repeater ID="rptDataList_Month" runat="server">
                        <ItemTemplate>
                            <tr>
                        <td>
                            <%# Eval("m") %>
                        </td>
                        <td>
                            <%# Eval("c") %>
                        </td>
                        <td>
                            <img width='<%# EbSite.Core.Utils.ObjectToInt(Eval("s"),0)*4 %>'px' height="15" class="votelenth" /><%# Eval("s") %>%
                        </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
    <div>
        <h3>
            按日统计</h3>
        <div class="searcharea clearfix br_search">
            <ul class="a_none_left">
                <li><span>请选择：</span><span class="colorR">年</span></li>
                <li>
                    <abbr class="formselect">
                        <asp:DropDownList ID="ddl_YearDay" runat="server">
                            <asp:ListItem Value="2013" Selected="True">2013</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                        </asp:DropDownList>
                    </abbr>
                </li>
                <li><span class="colorR">月：</span>
                    <abbr class="formselect">
                        <asp:DropDownList ID="ddl_MonthDay" runat="server">
                            <asp:ListItem Value="01" Selected="True">1</asp:ListItem>
                            <asp:ListItem Value="02">2</asp:ListItem>
                            <asp:ListItem Value="03">3</asp:ListItem>
                            <asp:ListItem Value="04">4</asp:ListItem>
                            <asp:ListItem Value="05">5</asp:ListItem>
                            <asp:ListItem Value="06">6</asp:ListItem>
                            <asp:ListItem Value="07">7</asp:ListItem>
                            <asp:ListItem Value="08">8</asp:ListItem>
                            <asp:ListItem Value="09">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                        </asp:DropDownList>
                    </abbr>
                </li>
                <li><span>
                    <asp:RadioButtonList ID="rdoMonthDay" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="l" Selected="True">交易量</asp:ListItem>
                            <asp:ListItem Value="e">交易额</asp:ListItem>
                            <asp:ListItem Value="r">利润</asp:ListItem>
                        </asp:RadioButtonList>
                </span></li>
                <li>
                    <asp:Button ID="btnSeachDay" runat="server" Text="查询" CssClass="searchbutton" OnClick="btnSeachDay_Click" />
                </li>
               
            </ul>
        </div>
        <div class="functionHandleArea clearfix m_none">
            <!--分页功能-->
            <div class="pageHandleArea">
                <ul>
                    <li class="paginalNum Pg_10">
                        <asp:Literal ID="litDayTotalCount" runat="server" Text="总交易量"></asp:Literal>：<strong
                        class="colorA"><asp:Literal ID="litDayTCount" runat="server" Text="0"></asp:Literal></strong></li>
                    <li class="paginalNum">
                        <asp:Literal ID="litDayHeightCount" runat="server" Text="最高峰交易量"></asp:Literal>：<strong
                        class="colorA"><asp:Literal ID="litDayHCount" runat="server" Text="0"></asp:Literal></strong></li>
                </ul>
            </div>
        </div>
        <!--数据列表区域-->
        <div class="datalist">
            <div>
                <table cellspacing="0" border="0" id="ctl00_contentHolder_grdDaySaleTotalStatistics"
                    style="width: 100%; border-collapse: collapse;">
                    <tr class="table_title">
                        <th class="td_right td_left" scope="col">
                            日期
                        </th>
                        <th class="td_right td_left" scope="col">
                            <asp:Literal ID="litDaytitle" runat="server" Text="交易量"></asp:Literal>
                        </th>
                        <th class="td_right td_left" scope="col" style="width: 60%;">
                            比例示意图
                        </th>
                    </tr>
                    <asp:Repeater ID="rptDataListDay" runat="server">
                        <ItemTemplate>
                            <tr>
                        <td>
                            <%# Eval("m") %>
                        </td>
                        <td>
                            <%# Eval("c") %>
                        </td>
                        <td>
                            <img width='<%# EbSite.Core.Utils.ObjectToInt(Eval("s"),0)*4 %>'px' height="15" class="votelenth" /><%# Eval("s") %>%
                        </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</div>
<div class="databottom">
</div>
<div class="bottomarea testArea">
    <!--顶部logo区域-->
</div>
