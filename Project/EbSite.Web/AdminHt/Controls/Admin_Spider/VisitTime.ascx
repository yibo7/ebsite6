<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitTime.ascx.cs" Inherits="EbSite.Web.AdminHt.Controls.Admin_Spider.VisitTime" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>
<script type="text/javascript" src="<%=IISPath%>js/echarts/simple.min.js?v=3.3.2"></script>



 <div class="row cbrowbox">
    <div class="col-sm-12 col-md-12 ">
        <div class="boxheader">
                <h3>24小时来访分析</h3>
            </div>
            <div class="eb-content">
				
<div style="text-align: center; padding: 10px;">
    <input onclick="getVisitTimeData(1)" class="btn btn-primary" type="button" value="今天"/>
    <input onclick="getVisitTimeData(2)" class="btn btn-default" type="button" value="昨天"/>
    <input onclick="getVisitTimeData(3)" class="btn btn-primary" type="button" value="最近7天"/>
    <input onclick="getVisitTimeData(4)" class="btn btn-default" type="button" value="最近30天"/>
</div>
<div id="echartsmain" style="width: 100%;height:500px;"></div>
    <script type="text/javascript">
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('echartsmain'));

        // 指定图表的配置项和数据
       var option = {
            title: {
                
            },
            tooltip: {
                trigger: 'axis'
            },
            legend: {
                data: ['百度', '360']
            },
            toolbox: {
                show: true,
                feature: {
                    dataZoom: {
                        yAxisIndex: 'none'
                    },
                    dataView: { readOnly: false },
                    magicType: { type: ['line', 'bar'] },
                    restore: {},
                    saveAsImage: {}
                }
            },
            xAxis: {
                type: 'category',
                boundaryGap: false,
                data: ['0', '1', '2', '3', '4', '5', '6','7','8','9','10','11','12','13','14','15','16','17','18','19','20','21','22','23']
            },
            yAxis: {
                type: 'value',
                axisLabel: {
                    formatter: '{value} 次'
                }
            },
            series: [
                {
                    name: '百度',
                    type: 'line',
                    data: [11, 11, 15, 13, 12, 13, 10],
                    markPoint: {data: [{ type: 'max', name: '最大值' },{ type: 'min', name: '最小值' }]},
                    markLine: {data: [{ type: 'average', name: '平均值' }]}
                },
                {
                    name: '360',
                    type: 'line',
                    data: [13, -2, 2, 5, 3, 2, 0],
                    markPoint: {
                        data: [
                            { name: '周最低', value: -2, xAxis: 1, yAxis: -1.5 }
                        ]
                    },
                    markLine: {
                        data: [
                            { type: 'average', name: '平均值' },
                            [{
                                symbol: 'none',
                                x: '90%',
                                yAxis: 'max'
                            }, {
                                symbol: 'circle',
                                label: {
                                    normal: {
                                        position: 'start',
                                        formatter: '最大值'
                                    }
                                },
                                type: 'max',
                                name: '最高点'
                            }]
                        ]
                    }
                }
            ]
        };

        // 使用刚指定的配置项和数据显示图表。
       //myChart.setOption(option);


       function getVisitTimeData(itype) {
           myChart.clear();
           runadminws("GetVititTime", { it: itype }, function (msg) {
               var legendData = [];
               //var xAxisData = [];
               option.series = [];
               for (var i = 0; i < msg.d.length; i++) {
                 
                   //var seriesData = [];
                   
                   var item = msg.d[i];
                   legendData.push(item.SpiderName);
                   var seriesDataModel = { name: "", type: "line", data: [], markPoint: { data: [{ type: 'max', name: '最大值' }, { type: 'min', name: '最小值' }] } };
                   seriesDataModel.name = item.SpiderName;
                   //$.log(seriesDataModel.name);
                   //$.logobj(item.Data.length);
                   for (var j = 0; j < item.Data.length; j++) {
                       var subitem = item.Data[j];
                       seriesDataModel.data.push(subitem.Value);
                       //if (xAxisData.indexOf(subitem.Text) == -1)
                            //xAxisData.push(subitem.Text);
                   }
                   //seriesData.push(seriesDataModel);

                   option.series.push(seriesDataModel);
               }

               option.legend.data = legendData;
               //option.xAxis.data = xAxisData;
               //$.logobj(option.series);
               myChart.setOption(option);
           });
       }

       getVisitTimeData(1);
    </script>
            </div>
    </div>
</div>