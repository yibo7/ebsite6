<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reports.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_DataReport.Reports" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<script type="text/javascript" src="<%=IISPath%>js/echarts/simple.min.js?v=3.3.2"></script>
 
<div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>报表配置</h3>
            </div>
            <div class="content">
				 <div id="PagesMain">
                <div>
                    <asp:PlaceHolder ID="phTools" runat="server"></asp:PlaceHolder>
                    <XS:Button ID="bntQuery"  Width="50" runat="server" Text=" 查询 " OnClick="bntQuery_Click" />
                           
                </div> 
                <asp:PlaceHolder ID="phShowTable" runat="server">
                    <div style="text-align: left; padding: 8px;">
                        <asp:Literal ID="lbDefaultTips" runat="server"></asp:Literal>
                    </div>
                    <div class="table-responsive">
                        <XS:GridView ID="gdList" runat="server" AutoGenerateColumns="false">
                        </XS:GridView>
                    </div>

                </asp:PlaceHolder>
            </div>

            <asp:PlaceHolder ID="phShowCharts" runat="server">
                <div id="echartsmain" style="width: 100%; height: 500px;"></div>
                <script type="text/javascript">
                    // 基于准备好的dom，初始化echarts实例
                    var myChart = echarts.init(document.getElementById('echartsmain'));

                    // 指定图表的配置项和数据
                    var option = {
                        title: {
                            text: '<%=ChartsCf.Title%>',
                x: 'center'
            },
            tooltip: {
               <%=ChartsCf.Tooltip%>
            },
            legend: {
                <%=ChartsCf.LegendPram%>
                data: [<%=ChartsCf.LegendData%>]
            },
            xAxis: {
                data: [<%=ChartsCf.XAxisData%>]
            },
            yAxis: { type: 'value' },
            series: [<%=ChartsCf.SeriesData%>]
        };

        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);
                </script>

            </asp:PlaceHolder>
            </div>
    </div>
</div>



