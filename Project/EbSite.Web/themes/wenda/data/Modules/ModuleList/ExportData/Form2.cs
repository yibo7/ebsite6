using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExportData
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private MySqlConnection myConn = new MySqlConnection(ExportData.ExtenMethod.strConn);
        private int successRows = 0, tmpTotal = 0;
        private string ThisDate = "";
        private int flag = 0;//标示完成状态
        private Thread th = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.rdo_sourcetype.Checked)
            {
                //声明线程
                Thread th = new Thread(new ThreadStart(OrderToWenDa));
                //启动线程
                th.Start();
                this.btnStart.Enabled = false;
                //打开定时器
                this.timer1.Enabled = true;
                this.timer3.Enabled = true;
                this.label11.Text = "同步中...";
            }
            else
            {
                //MessageBox.Show("请选择转换来源");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (int.Parse(this.labSuccess.Text) < tmpTotal)
            {
                //监视转换的条数，时时更新
                this.label9.Text = ThisDate;
                this.labTotal.Text = tmpTotal.ToString();
                this.labSuccess.Text = successRows.ToString();
                this.labWaitting.Text = (tmpTotal - int.Parse(this.labSuccess.Text)).ToString();
            }
        }

        private void OrderToWenDa()
        {
            //开始时间
            string str = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            //string str = "2013-6-23";
            string strTamp = ScalarMySql(string.Format("select unix_timestamp('{0}')", str));
            if (!ExistThisTamp(strTamp))
            {
                ThisDate = str;
                successRows = 0;
                string staDate = str + " 00:00:00";
                string endDate = str + " 23:59:59";
                //导入机制按每天
                string strSql = string.Format("select id,b_brandname,b_carmodelname,b_caryear,b_pl,b_dwtype,b_remark from bm_order where b_orderdate>='{0}' and b_orderdate<='{1}'", staDate, endDate);
                DataTable dt = GetMySqlDataTable(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    tmpTotal = dt.Rows.Count;
                    ArrayList arrKeys = new ArrayList();
                    string rid = "", strDwName = "", strYear = "", strPL = "", strBrandName = "", strIntro = "";
                    List<string> HfList = new List<string>();
                    string[] arrTmplate = { "{0}多少钱", "{0}价格是多少", "{0}如何报价", "{0}的最低价格", "{0}能给个报价吗", "{0}有没有报价表啊", "{0}价格如何查询", "{0}新件是多少钱", "请问{0}的拆车件是多少钱", "{0}麻烦给个报价", "谁知道{0}的价格吗", "{0}有知道价格行情的吗", "请问大虾，{0}现在的价格是多少", "专家们，关于{0}现在是多少钱", "我要购买{0},有人知道价格吗", "老大们，能不能告诉我{0}多少啊" };
                    Random r = new Random();
                    int index = 0;
                    bool isOk = false;

                    string tmpTitle = "", tmpContent = "", tmpCarInfo = "";
                    ExtenMethod em = new ExtenMethod();
                    foreach (DataRow dr in dt.Rows)
                    {
                        index = r.Next(16);

                        #region 汽车信息
                        //车型名称
                        if (dr["b_carmodelname"] != null)
                        {
                            strBrandName = dr["b_carmodelname"].ToString();
                            if (!string.IsNullOrEmpty(strBrandName))
                            {
                                strBrandName = "车型：" + strBrandName;
                            }
                        }
                        else
                        {
                            if (dr["b_brandname"] != null)
                            {
                                strBrandName = "汽车品牌：" + dr["b_brandname"].ToString();
                            }
                            else
                            {
                                continue;
                            }
                        }

                        int classID = 0;
                        string classNameEx = "";
                        string annex14 = "";
                        if (dr["b_carmodelname"] != null)
                        {
                            string tmpHName = dr["b_carmodelname"].ToString();
                            if (tmpHName.IndexOf("日本雷克萨斯") > -1 && tmpHName.IndexOf("凌志") < 0)
                            {
                                tmpHName = tmpHName.Replace("日本雷克萨斯", "日本雷克萨斯凌志");
                            }
                            classNameEx = tmpHName;
                            string tmpCid = ScalarMySqlEX("select id,annex14 from eb_newsclass where siteid=2 and annex7='" + tmpHName + "'", out annex14);
                            if (!string.IsNullOrEmpty(tmpCid))
                            {
                                classID = int.Parse(tmpCid);
                            }
                        }
                        else if (dr["b_brandname"] != null)
                        {
                            string tmpHName = dr["b_brandname"].ToString();
                            if (tmpHName.IndexOf("日本雷克萨斯") > -1 && tmpHName.IndexOf("凌志") < 0)
                            {
                                tmpHName = tmpHName.Replace("日本雷克萨斯", "日本雷克萨斯凌志");
                            }
                            classNameEx = tmpHName;
                            string tmpCid = ScalarMySqlEX("select id,annex14 from eb_newsclass where siteid=2 and annex7='" + tmpHName + "'", out annex14);
                            if (!string.IsNullOrEmpty(tmpCid))
                            {
                                classID = int.Parse(tmpCid);
                            }
                        }

                        //档位类型(-1:全部 0:手动 1:自动 2:手自合一)
                        //if (dr["b_dwtype"] != null)
                        //{
                        //    strDwName = dr["b_dwtype"].ToString();
                        //    switch (strDwName)
                        //    {
                        //        case "-1":
                        //            strDwName = "全部";
                        //            break;
                        //        case "0":
                        //            strDwName = "手动档";
                        //            break;
                        //        case "1":
                        //            strDwName = "自动档";
                        //            break;
                        //        case "2":
                        //            strDwName = "手自合一";
                        //            break;
                        //        default:
                        //            strDwName = "";
                        //            break;
                        //    }
                        //    if (!string.IsNullOrEmpty(strDwName))
                        //    {
                        //        strDwName = "档位类型：" + strDwName;
                        //    }
                        //}
                        //排量
                        if (dr["b_pl"] != null)
                        {
                            strPL = dr["b_pl"].ToString();
                            if (string.IsNullOrEmpty(strPL) || strPL.Equals("0.0"))
                            {
                                strPL = "";
                            }
                            else
                            {
                                strPL = "排量：" + strPL;
                            }
                        }
                        //年款
                        if (dr["b_caryear"] != null)
                        {
                            strYear = dr["b_caryear"].ToString();
                            if (strYear.Length == 4)
                            {
                                strYear = "年款：" + strYear;
                            }
                            else
                            {
                                strYear = "";
                            }
                        }

                        //询价备注
                        if (dr["b_remark"] != null)
                        {
                            strIntro = dr["b_remark"].ToString().Trim();
                            strIntro = strIntro.Replace("[]", "");
                        }
                        if (!string.IsNullOrEmpty(strBrandName))
                        {
                            tmpCarInfo = strBrandName;
                        }
                        if (!string.IsNullOrEmpty(strPL))
                        {
                            tmpCarInfo += "，" + strPL;
                        }
                        if (!string.IsNullOrEmpty(strYear))
                        {
                            tmpCarInfo += "，" + strYear;
                        }
                        if (!string.IsNullOrEmpty(strDwName))
                        {
                            tmpCarInfo += "，" + strDwName;
                        }

                        #endregion 汽车信息

                        rid = dr["id"].ToString();
                        if (string.IsNullOrEmpty(rid))
                        {
                            continue;
                        }
                        string subPJs = "";
                        string strPJs = GetOrderItem(rid, out subPJs, out HfList);

                        if (!string.IsNullOrEmpty(strIntro))
                        {
                            isOk = false;
                            //过滤规则
                            int di = strIntro.IndexOf('【');
                            if (di > 0)
                            {
                                strIntro = strIntro.Substring(0, di);
                            }
                            if (strIntro.Length > 5)
                            {
                                //strIntro = strIntro.Replace("【爱车配件坏了，已决定购买新件。】", "").Replace("【先了解一下价格，再考虑是否更换购买新件。】", "").Replace("【是事故车或需要购买多个配件】", "").Replace("【爱车配件坏了，已决定购买新件。】", "");
                                string tmpSubPJs = string.IsNullOrEmpty(subPJs) ? "" : "还有" + subPJs;
                                tmpContent = string.Concat(tmpSubPJs, tmpCarInfo);
                                if (!string.IsNullOrEmpty(strPJs))
                                {
                                    tmpTitle = string.Concat(strPJs, "，", strBrandName, "，", strIntro);
                                }
                                else
                                {
                                    tmpTitle = string.Concat(strBrandName, "，", strIntro);
                                }
                            }
                            else
                            {
                                isOk = true;
                            }
                        }
                        else
                        {
                            isOk = true;
                        }
                        if (isOk)
                        {
                            if (!string.IsNullOrEmpty(strPJs))
                            {
                                //随机取用模板
                                string tmpSubPJs = string.IsNullOrEmpty(subPJs) ? "" : "还有" + subPJs;
                                tmpContent = string.Concat(tmpSubPJs, tmpCarInfo);
                                tmpTitle = string.Concat(string.Format(arrTmplate[index], strPJs + "，" + strBrandName + "，"));
                            }
                            else
                            {
                                continue;
                            }
                        }
                        //tmpContent = "";
                        //添加到数据库
                        em.DataImportList(tmpTitle, classID, classNameEx, annex14, "", HfList.ToArray());
                        successRows++;
                    }
                }
                ExecuteMySql(string.Format("insert into bm_ordertowenda(timestamp) values({0})", strTamp));
                //MessageBox.Show("导入完毕");
                //this.btnStart.Enabled = true;
                flag = 1;
            }
            else
            {
                flag = 2;
                //this.btnStart.Enabled = true;
                //MessageBox.Show("昨天订单已经转换完毕");
            }
        }

        /// <summary>
        /// 获取配件信息
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <param name="subPj">如果超过3个配件,则组合成剩余的配件信息</param>
        /// <param name="priceResult">回答列表</param>
        /// <returns></returns>
        private string GetOrderItem(string id, out string subPj, out List<string> priceResult)
        {
            StringBuilder result = new StringBuilder();//配件列表(用逗号隔开)
            subPj = "";
            priceResult = new List<string>();//回答列表
            string strSql = "select c_goodsname,c_sellprice from bm_orderlist where c_orderid=" + id;
            DataTable dt = GetMySqlDataTable(strSql);;

            string[] arrHref = { "{0}价格是{1}元", "{0}是{1}元", "{0}报价{1}元", "{0}价格动态{1}元", "{0} {1}元可以买到", "目前{0}是{1}元", "{0}大概是{1}元" };
            string[] timesArr = { "2", "8", "16", "20", "22", "23", "28", "17", "26", "5", "9", "13", "11", "29", "19" };
            Random r = new Random();
            Random rt = new Random();

            int index = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                string gname = "", gprice = "";
                int tIndex = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    index = r.Next(6);
                    if (dr["c_goodsname"] == null)
                    {
                        continue;
                    }
                    gname = dr["c_goodsname"].ToString();

                    //判断是否超过了3个
                    if (tIndex < 3)
                    {
                        result.Append(gname + "，");
                    }
                    else
                    {
                        subPj += string.Format("{0}，", gname);
                    }

                    if (dr["c_sellprice"] != null)
                    {
                        gprice = dr["c_sellprice"].ToString();
                    }

                    if (!gprice.Equals("0.00"))
                    {
                        if (priceResult.Count > 20)
                        {
                            break;//跳出循环
                        }
                        priceResult.Add(string.Format(arrHref[index] + "|" + timesArr[rt.Next(14)], gname, gprice));
                    }
                    tIndex++;
                }
            }

            return result.ToString().TrimEnd('，');
        }

        #region 数据访问方法

        private bool ExecuteMySql(string strSql)
        {
            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = myConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            int rows = cmd.ExecuteNonQuery();
            myConn.Close();
            if (rows > 0)
            {
                return true;
            }
            return false;
        }

        private bool ExistThisTamp(string strTamp)
        {
            string strSql = "select count(id) from bm_ordertowenda where timestamp=" + strTamp;
            string r = ScalarMySql(strSql);
            if (!string.IsNullOrEmpty(r) && !r.Equals("0"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DataTable GetMySqlDataTable(string strSql)
        {
            try
            {
                DataTable dt = new DataTable();
                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                //string strSql = "select c_goodsname,c_sellprice from bm_orderlist where c_orderid=" + id;
                MySqlDataAdapter sda = new MySqlDataAdapter(strSql, myConn);
                sda.Fill(dt);
                sda.Dispose();
                myConn.Close();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        private string ScalarMySql(string strSql)
        {
            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = myConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                return obj.ToString();
            }
            myConn.Close();
            return "0";
        }
        private string ScalarMySqlEX(string strSql, out string annex14)
        {
            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = myConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string id = reader["id"].ToString();
                    //cname = reader["annex7"].ToString();
                    annex14 = reader["annex14"].ToString();
                    return id;
                }
                else
                {
                    //cname = "";
                    annex14 = "";
                    return "0";
                }
            }
        }

        #endregion 数据访问方法

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.btnStart.Enabled)
            {
                int cesuotime = DateTime.Now.Hour;//得到现在的时间
                //每天早上10点同步
                if (cesuotime ==10)
                {
                    this.label11.Text = "同步中...";
                    this.timer3.Enabled = true;
                    this.timer1.Enabled = true;
                    this.btnStart_Click(sender, e);
                    //this.timer2.Enabled = false;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                this.label11.Text = "休眠";
                this.btnStart.Enabled = true;
                this.timer3.Enabled = false;
                flag = 0;
                successRows = 0;
                tmpTotal = 0;
                this.labTotal.Text = "0";
                this.labSuccess.Text = "0";
                this.labWaitting.Text = "0";
            }
            else if (flag == 2)
            {
                this.label11.Text = "休眠";
                this.btnStart.Enabled = true;
                this.timer3.Enabled = false;
                flag = 0;
            }
        }
    }
}
