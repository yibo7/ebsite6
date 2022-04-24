<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Vote_CJTP.ascx.cs" Inherits="EbSite.Modules.BBS.AdminPages.Controls.Vote.Vote_CJTP" %>
<%@ Register Assembly="EbSite.Control" Namespace="EbSite.Control" TagPrefix="XS" %>

<script type="text/javascript" src="/js/plugin/highcharts/highcharts.src.js"></script>
<!--[if IE]>
			<script type="text/javascript" src="/js/plugin/highcharts/excanvas.compiled.js"></script>
<![endif]-->
<script type="text/javascript">
    var chart;
    $(document).ready(function () {
        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container',
                margin: [50, 200, 60, 170]
            },
            title: {
                text:<%=title%>
            },
            plotArea: {
                shadow: null,
                borderWidth: null,
                backgroundColor: null
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.point.name + '</b>: ' + this.y + ' %';
                }
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            if (this.y > 5) return this.point.name;
                        },
                        color: 'white',
                        style: {
                            font: '13px Trebuchet MS, Verdana, sans-serif'
                        }
                    }
                }
            },
            legend: {
                layout: 'vertical',
                style: {
                    left: 'auto',
                    bottom: 'auto',
                    right: '50px',
                    top: '100px'
                }
            },
            series: [{
                type: 'pie',
                name: 'Browser share',
                data: [                
                <%=s%>              
         ]
            }]
        });
    });
</script>
<table>
    <tr>
        <td>
            <div id="container" style="width: 800px; height: 500px; margin: 0 auto" >
            </div>
        </td>
        <td>
            <XS:GridView ID="gvXZ" runat="server" AutoGenerateColumns="False" 
                CssClass="GridView" EnableModelValidation="True">
                <Columns>
                 <asp:TemplateField>
                        <ItemTemplate>
                            <XS:CheckBox ID="cbXZ" runat="server" onclick="IfDX()"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Eval("title")%>
                            <asp:Label ID="lbId" runat="server" Text='<%# Eval("id")%>' style="display:none"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="票数">
                        <ItemTemplate>
                             <%# Eval("piaoshu")%>
                        </ItemTemplate>
                         <HeaderStyle Width="60px" />
                         <ItemStyle Width="60px" />
                         <FooterStyle Width="60px"/>
                    </asp:TemplateField>
                </Columns>
            </XS:GridView>
            <XS:LinkButton ID="lbTP" runat="server" Text="投票" IsButton="true" OnClick="lbTP_Click"></XS:LinkButton>
        </td>
    </tr>
</table>
<table style=" width:900px;">
    <tr>
        <td>
      <%--  <EB:Remark runat="server" ID="remarkSomeThing"  Title="投票反馈" RemarkClass="投票" Width="800" /> --%>
        </td>
    </tr>
</table>
<script>
    function IfDX() {
     var num = 0;
     var xz="<%=ifDX%>";
     if (xz == "单选") {
         var checks = document.getElementsByTagName("input");
         for (var i = 0; i < checks.length; i++) {
             if (checks[i].type == "checkbox" && checks[i].checked) {
                 num = num + 1
             }
             if (num > 1) {
                 checks[i].checked = false;
             }
         }
     }
    }
</script>
