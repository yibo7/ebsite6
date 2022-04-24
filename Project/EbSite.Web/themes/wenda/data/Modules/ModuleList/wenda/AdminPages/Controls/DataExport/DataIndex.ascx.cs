using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using EbSite.Modules.Wenda.ModuleCore.Pages;
using System.Threading;
using System.Text;

namespace EbSite.Modules.Wenda.AdminPages.Controls.DataExport
{
    public partial class DataIndex : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("2232be14-114f-437c-aba1-1b4dda80b85f");
            }
        }
        public override string PageName
        {
            get
            {
                return "北迈问答数据导入";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "35";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "33";
            }
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "34";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return ModuleCore.BLL.PostUserControl.Instance.FillList();

        }
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }


        override protected void Delete(object iID)
        {
            ModuleCore.BLL.PostUserControl.Instance.Delete(int.Parse(iID.ToString()));
        }

        private static string bmStrConn = "Data Source='202.85.212.233,4387';Initial Catalog='beimai';User ID='beimai2011';Password='cqs263@che%^*.comsqlbeimai';Pooling=true; MAX Pool Size=512;Min Pool Size=50;Connection Lifetime=30;";
        SqlConnection sqlConn = new SqlConnection(bmStrConn);
        protected void btnInPut_Click(object sender, EventArgs e)
        {
            string selID = this.ddlDataSource.SelectedValue;
            if (!string.IsNullOrEmpty(selID) && !selID.Equals("0"))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                if (selID.Equals("1"))
                {
                    #region 专家问答

                    //专家问答
                    string strSql = "select content,adminreplay,b_name,h_name,ipaddress from dbo.Bm_Replay where source=2";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(strSql, sqlConn);
                    sda.Fill(dt);
                    sda.Dispose();
                    sqlConn.Close();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ArrayList arrKey = new ArrayList();
                        arrKey.Add("如果您的问题与车型有关，请选择上面的品牌和车系");
                        object objTitle = null, objHef = null;
                        object brand = null, carmodel = null;

                        foreach (DataRow dr in dt.Rows)
                        {
                            objTitle = dr["content"];
                            if (objTitle == null)
                            {
                                //如果为空，则进行下一次循环
                                continue;
                            }
                            if (arrKey.Contains(objTitle))
                            {
                                continue;
                            }
                            if (objTitle.ToString().Length < 5)
                            {
                                continue;
                            }

                            brand = dr["b_name"];
                            carmodel = dr["h_name"];
                            if (brand == null && carmodel == null)
                            {
                                continue;
                            }
                            objHef = dr["adminreplay"];
                            string tmpHref = "";
                            if (objHef == null)
                            {
                                tmpHref = "";
                            }
                            else
                            {
                                //过滤掉网址
                                if (objHef.ToString().Contains("http://www.beimai.com"))
                                {
                                    tmpHref = "";
                                }
                                else
                                {
                                    tmpHref = objHef.ToString();
                                }
                            }
                            int classID = 0;
                            if (carmodel != null)
                            {
                                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel("id", "parentid>9223 and classname='" + carmodel.ToString() + "'");
                                if (md != null)
                                {
                                    classID = md.ID;
                                }
                            }
                            else if (brand != null)
                            {
                                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel("id", "parentid>0 and parentid<12470 and classname='" + brand.ToString() + "'");
                                if (md != null)
                                {
                                    classID = md.ID;
                                }
                            }
                            string strIP = dr["ipaddress"].ToString();
                            if (classID > 0)
                            {
                                EbSite.Modules.Wenda.ModuleCore.Pages.mfastTopics m = new mfastTopics();
                                string tmpTitle = objTitle.ToString();
                                if (tmpTitle.Length > 30)
                                {
                                    tmpTitle = tmpTitle.Substring(0, 30);
                                }
                                m.DataImport(tmpTitle, classID, objTitle.ToString(), tmpHref, strIP);
                                arrKey.Add(objTitle);
                            }
                        }
                    }

                    #endregion 专家问答
                }
                else if (selID.Equals("2"))
                {
                    #region 订单问答

                    string strSql = "select id,y_bname,y_hname,y_year,y_pailiang,y_zidongflag,y_intro from Bm_YuDingOrder";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(strSql, sqlConn);
                    sda.Fill(dt);
                    sda.Dispose();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ArrayList arrKeys = new ArrayList();
                        string rid="",strDwName = "",strYear = "",strPL = "",strBrandName="",strIntro="";
                        List<string> HfList = new List<string>();
                        string[] arrTmplate = { "{0}多少钱", "{0}价格是多少", "{0}如何报价", "{0}的最低价格", "{0}能给个报价吗", "{0}有没有报价表啊", "{0}价格如何查询", "{0}新件是多少钱", "请问{0}的拆车件是多少钱", "{0}麻烦给个报价", "{0}谁知道价格吗", "{0}有知道价格行情的吗", "请问大虾，{0}现在的价格是多少", "专家们，关于{0}现在是多少钱", "我要购买{0},有人知道价格吗", "老大们，能不能告诉我{0}多少啊" };
                        Random r = new Random();
                        int index =0;
                        bool isOk = false;

                        string tmpTitle = "",tmpContent="",tmpCarInfo="";
                        foreach (DataRow dr in dt.Rows)
                        {
                            index = r.Next(16);

                            #region 汽车信息
                            //车型名称
                            if (dr["y_hname"] != null)
                            {
                                strBrandName = dr["y_hname"].ToString();
                                if (!string.IsNullOrEmpty(strBrandName))
                                {
                                    strBrandName = "车型:" + strBrandName;
                                }
                            }
                            else
                            {
                                if (dr["y_bname"] != null)
                                {
                                    strBrandName = "汽车品牌:" + dr["y_bname"].ToString();
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            int classID = 0;
                            if (dr["y_hname"] != null)
                            {
                                string tmpHName=dr["y_hname"].ToString();
                                if (tmpHName.IndexOf("日本雷克萨斯") > -1 && tmpHName.IndexOf("凌志") < 0)
                                {
                                    tmpHName = tmpHName.Replace("日本雷克萨斯", "日本雷克萨斯凌志");
                                }
                                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel("id", "parentid>9223 and classname='" + tmpHName + "'");
                                if (md != null)
                                {
                                    classID = md.ID;
                                }
                            }
                            else if (dr["y_bname"] != null)
                            {
                                string tmpHName = dr["y_bname"].ToString();
                                if (tmpHName.IndexOf("日本雷克萨斯") > -1 && tmpHName.IndexOf("凌志") < 0)
                                {
                                    tmpHName = tmpHName.Replace("日本雷克萨斯", "日本雷克萨斯凌志");
                                }
                                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel("id", "parentid>0 and parentid<12470 and classname='" + tmpHName + "'");
                                if (md != null)
                                {
                                    classID = md.ID;
                                }
                            }

                            //档位类型(-1:全部 0:手动 1:自动 2:手自合一)
                            if (dr["y_zidongflag"] != null)
                            { 
                                strDwName = dr["y_zidongflag"].ToString();
                                switch (strDwName)
                                { 
                                    case "-1":
                                        strDwName = "全部";
                                        break;
                                    case "0":
                                        strDwName = "手动档";
                                        break;
                                    case "1":
                                        strDwName = "自动档";
                                        break;
                                    case "2":
                                        strDwName = "手自合一";
                                        break;
                                    default:
                                        strDwName = "";
                                        break;
                                }
                                if (!string.IsNullOrEmpty(strDwName))
                                {
                                    strDwName = "档位类型:" + strDwName;
                                }
                            }
                            //排量
                            if (dr["y_pailiang"] != null)
                            {
                                strPL = dr["y_pailiang"].ToString();
                                if (strPL.Equals("0.0"))
                                {
                                    strPL = "";
                                }
                                else
                                {
                                    strPL = "排量:" + strPL;
                                }
                            }
                            //年款
                            if (dr["y_year"] != null)
                            {
                                strYear = dr["y_year"].ToString();
                                if (strYear.Length == 4)
                                {
                                    strYear = "年款:"+strYear;
                                }
                                else
                                {
                                    strYear = "";
                                }
                            }
                           
                            //询价备注
                            if (dr["y_intro"] != null)
                            {
                                strIntro = dr["y_intro"].ToString().Trim();
                                strIntro = strIntro.Replace("来源：网上", "").Replace("此信息来源于:网上","");
                            }
                            if (!string.IsNullOrEmpty(strBrandName))
                            {
                                tmpCarInfo = strBrandName;
                            }
                            if (!string.IsNullOrEmpty(strPL))
                            {
                                tmpCarInfo += "，"+strPL;
                            }
                            if (!string.IsNullOrEmpty(strYear))
                            {
                                tmpCarInfo += "，"+strYear;
                            }
                            if (!string.IsNullOrEmpty(strDwName))
                            { 
                                tmpCarInfo+="，"+strDwName;
                            }

                            #endregion 汽车信息

                            rid = dr["id"].ToString();
                            string strPJs = GetOrderItem(rid,out HfList);

                            if (!string.IsNullOrEmpty(strIntro))
                            {
                                isOk = false;
                                //过滤规则
                                if (strIntro.Length > 5 && (strIntro.IndexOf("多少") > -1 || strIntro.IndexOf("价格") > -1 || strIntro.IndexOf("价钱") > -1 || strIntro.IndexOf("发动机") > -1 || strIntro.IndexOf("保险") > -1 || strIntro.IndexOf("中网") > -1 || strIntro.IndexOf("钢圈") > -1 || strIntro.IndexOf("倒车镜") > -1))
                                {
                                    tmpContent = string.Concat(strIntro,strPJs,"，",tmpCarInfo);
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
                            if(isOk)
                            {
                                if (!string.IsNullOrEmpty(strPJs))
                                {
                                    //随机取用模板
                                    tmpContent = string.Concat(string.Format(arrTmplate[index], strPJs),"，",tmpCarInfo);
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            //获取Title
                            if (tmpContent.Length >50)
                            {
                                tmpTitle = tmpContent.Substring(0,50);
                            }
                            else
                            {
                                tmpTitle = tmpContent;
                            }
                            //添加到数据库
                            ModuleCore.Pages.mfastTopics model = new mfastTopics();
                            model.DataImportList(tmpTitle, classID, tmpContent, HfList.ToArray());
                        }
                    }

                    #endregion 订单问答
                }
            }
            sqlConn.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="priceResult"></param>
        /// <returns></returns>
        private string GetOrderItem(string id,out List<string> priceResult)
        {
            StringBuilder result = new StringBuilder();//配件列表(用逗号隔开)
            priceResult =new List<string>();//回答列表
            DataTable dt = new DataTable();
            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }
            string strSql = "select y_goodsname,y_price from Bm_YuDingOrderList where y_id="+id;
            SqlDataAdapter sda = new SqlDataAdapter(strSql, sqlConn);
            sda.Fill(dt);
            sda.Dispose();


            string[] arrHref = { "{0}价格是{1}元", "{0}是{1}元", "{0}报价{1}元", "{0}价格动态{1}元", "{0} {1}元可以买到", "目前{0}是{1}元","{0}大概是{1}元"};
            string[] timesArr = {"2","8","16","20","22","23","28","17","26","5","9","13","11","29","19"};
            Random r = new Random();
            Random rt = new Random();

            int index=0;
            if (dt != null && dt.Rows.Count > 0)
            {
                string gname = "", gprice = "";
                foreach (DataRow dr in dt.Rows)
                {
                    index=r.Next(6);
                    if (dr["y_goodsname"] == null)
                    {
                        continue;
                    }
                    gname = dr["y_goodsname"].ToString();
                    result.Append(gname+"，");
                    if (dr["y_price"] != null)
                    {
                        gprice = dr["y_price"].ToString();
                    }
                    if (!gprice.Equals("0.00"))
                    {
                        if (priceResult.Count > 20)
                        {
                            break;//跳出循环
                        }
                        priceResult.Add(string.Format(arrHref[index] + "|" + timesArr[rt.Next(14)], gname, gprice));
                    }
                }
            }

            return result.ToString().TrimEnd('，');
        }
    }
}