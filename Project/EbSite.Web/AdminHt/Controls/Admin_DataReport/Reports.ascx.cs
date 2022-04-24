using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModulesBll;
using EbSite.Control;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_DataReport
{
    public partial class Reports : UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "322";
            }
        }
        protected ChartsConfig ChartsCf = new ChartsConfig();
         

        protected void LoadDefaultList()
        {
           
            ReportConfigBll bll = new ReportConfigBll();

            string skey = Request["key"];
            if (!string.IsNullOrEmpty(skey))
            {
                DataSet ds = bll.GetDefaultData(skey);

                if (!Equals(ds,null)&& ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (ReportShowType > 0)
                    {
                        BuilECharts(dt);
                        
                    }
                    else
                    {
                        BuilGruidHeader(dt);
                        gdList.DataSource = dt;
                        gdList.DataBind();
                    }
                     
                }

               
            }
          

        }
         

        private void BuilGruidHeader(DataTable dt)
        {
            gdList.Columns.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)   //绑定普通数据列
            {
                string sColumnName = dt.Columns[i].ColumnName;
                
                BoundField bfColumn = new BoundField();
                bfColumn.DataField = sColumnName;
                bfColumn.HeaderText = dt.Columns[i].Caption;
                gdList.Columns.Add(bfColumn); 

            }

            BuilECharts(dt);

        }

        private void BuilEChartsLineBar(DataTable dt)
        {
            //echart legendData
            //在这里设置 dicColumnValues 与 dicColumnName 是为了处理 echart XAxisData时使用
            Dictionary<int, string> dicColumnValues = new Dictionary<int, string>();
            Dictionary<int, string> dicColumnName = new Dictionary<int, string>();

            StringBuilder sbLegendData = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string sColumnName = dt.Columns[i].ColumnName;

                if (i > 0)
                {

                    sbLegendData.AppendFormat("'{0}',", sColumnName);
                    dicColumnValues.Add(i, "");//先创建一个结构，在后面赋值
                    dicColumnName.Add(i, sColumnName);
                }

            }

            if (sbLegendData.Length > 0)
                sbLegendData.Remove(sbLegendData.Length - 1, 1);
            ChartsCf.LegendData = sbLegendData.ToString();

            //echart XAxisData
            StringBuilder sbX = new StringBuilder();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dt.Rows[i];

                string v = row[0].ToString();
                sbX.AppendFormat("'{0}',", v);
                //设置 series Data的值以更下面处理series Data时使用
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    dicColumnValues[j] = dicColumnValues[j] + string.Format(",'{0}'", row[j]);

                }

            }

            if (sbX.Length > 0)
                sbX.Remove(sbX.Length - 1, 1);
            ChartsCf.XAxisData = sbX.ToString();


            //series Data
            string ChartType = "line";
            if (ReportShowType == 2)
            {
                ChartType = "bar";
            }


            StringBuilder sbSeriesData = new StringBuilder();
            foreach (var data in dicColumnName)
            {
                string sSeriesData = dicColumnValues[data.Key];

                if (!string.IsNullOrEmpty(sSeriesData) && sSeriesData.Length > 0)
                {
                    StringBuilder sbData = new StringBuilder(sSeriesData);
                    if (sbData.Length > 0)
                    {
                        sbData.Remove(0, 1);

                        string sTitle = data.Value;
                        sbSeriesData.Append("{");
                        sbSeriesData.AppendFormat(@"
                            name: '{0}',
                            type: '{2}',
                            data: [{1}]
                        ", sTitle, sbData, ChartType);

                        sbSeriesData.Append("},");
                    }
                }

            }

            if (sbSeriesData.Length > 0)
                sbSeriesData.Remove(sbSeriesData.Length - 1, 1);
            ChartsCf.SeriesData = sbSeriesData.ToString();
        }

        private void BuilECharts(DataTable dt)
        {
            if (ReportShowType == 3) //饼图
            {
                ChartsCf.Title = "";
                ChartsCf.LegendPram = " orient: 'vertical',left: 'left',";
                ChartsCf.Tooltip = @"trigger: 'item',            
formatter: ""{a} <br/>{b} : {c} ({d}%)""";
                BuilEChartsPie(dt);
            }
            else
            {
                ChartsCf.Tooltip = " trigger: 'axis'";
                BuilEChartsLineBar(dt); //线图与柱图
            }

        }


        private void BuilEChartsPie(DataTable dt)
        { 
            //echart XAxisData
            StringBuilder sbLegendData = new StringBuilder();
            StringBuilder sbSeriesData = new StringBuilder();
            sbSeriesData.Append("{");
            sbSeriesData.AppendFormat(@" name: '访问来源',
            type: 'pie',
            //radius : '55%',
            //center: ['50%', '60%'],
            data:[");

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dt.Rows[i];

                string sName = row[0].ToString();
                string sValue = row[1].ToString();
                sbLegendData.AppendFormat("'{0}',", sName);
                sbSeriesData.Append("{");
                sbSeriesData.AppendFormat("value:{0}, name:'{1}'", sValue, sName);
                sbSeriesData.Append("},");
            }

            if (sbLegendData.Length > 0)
                sbLegendData.Remove(sbLegendData.Length - 1, 1);
            ChartsCf.LegendData = sbLegendData.ToString();

            //series Data
            if (sbSeriesData.Length > 0)
                sbSeriesData.Remove(sbSeriesData.Length - 1, 1);
            sbSeriesData.Append("]}");
            ChartsCf.SeriesData = sbSeriesData.ToString();
        }


        protected void bntQuery_Click(object sender, EventArgs e)
        {
            List<ExtensionsCtrls> ctrs = new List<ExtensionsCtrls>();

            foreach (System.Web.UI.Control uc in phTools.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                if (uc is ExtensionsCtrls)
                {
                    ExtensionsCtrls myuc = (ExtensionsCtrls)uc;
                    ctrs.Add(myuc);

                }
            }

            if (ctrs.Count > 0)
            {
                ReportConfigBll bll = new ReportConfigBll();

                string skey = Request["key"];
                if (!string.IsNullOrEmpty(skey))
                {
                    DataSet ds = bll.RunQuery(skey,ctrs);

                    if (ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                       
                        if (ReportShowType > 0) //图表
                        {
                            BuilECharts(dt);
                        }
                        else  //表格
                        {
                            gdList.DataSource = dt;
                            gdList.DataBind();
                        }
                        

                    }
                }
            }

        }
        //0为表格，1为线性图，2为柱形图，3为饼图.
        private int ReportShowType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportConfigBll bll = new ReportConfigBll();

            string skey = Request["key"];  //报表配置ID
            if (!string.IsNullOrEmpty(skey))
            {
                Entity.ReportConfig model = bll.GetConfigById(skey);
                ReportShowType = model.ShowType;
                lbDefaultTips.Text = model.DefaultTips;

                ChartsCf.Title = model.ReportName;

                if (ReportShowType > 0)
                {
                    phShowTable.Visible = false;
                    phShowCharts.Visible = true;
                }
                else
                {
                    phShowTable.Visible = true;
                    phShowCharts.Visible = false;
                }
                //绑定默认报表
                LoadDefaultList();

                if (!Equals(model.Ctrs, null) && model.Ctrs.Count > 0)
                {
                    phTools.Controls.Add(ParseControl("<table><tr>"));
                    foreach (var ctrModel in model.Ctrs)
                    { 
                        phTools.Controls.Add(ParseControl(string.Format("<td><label for=\"name\">&nbsp;{0}&nbsp;</label>", ctrModel.Text)));

                        EbSite.Control.ExtensionsCtrls ctr = new EbSite.Control.ExtensionsCtrls();
                        ctr.ModelCtrlID = new Guid(ctrModel.Value);
                        ctr.ID = ctrModel.Value;
                        phTools.Controls.Add(ctr);

                        phTools.Controls.Add(ParseControl("</td>"));
                    }

                    phTools.Controls.Add(ParseControl("</tr></table>"));


                }
                else
                {
                    bntQuery.Visible = false;
                }

               
            }

           
            
        }
         


    }
}