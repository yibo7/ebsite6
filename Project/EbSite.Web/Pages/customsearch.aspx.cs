//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using EbSite.Base.Configs.SysConfigs;
//using EbSite.BLL.SearchCustom;
//using EbSite.Entity.SearchCustom;

//namespace EbSite.Web.Pages
//{
//    public partial class customsearch : EbSite.Base.Page.SearchBase
//    {
//        /// <summary>
//        /// 获取部件ID
//        /// </summary>
//        protected string CID
//        {
//            get
//            {
//                return Request["cid"];
//            }
//        }
//        protected string sType
//        {
//            get
//            {
//                return Request["t"];
//            }
//        }
//        private int _iPageSize = EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeTagValue;
//        protected override int iPageSize
//        {
//            get
//            {
//                return _iPageSize;
//            }
//            set
//            {
//                _iPageSize = value;
//            }

//        }

//        private void bindinfo(SearchModel sm)
//        {
//            int ResultCount = 0;

//            string sTem = sm.Tem;
//            sTem = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).GetTemPath(sTem);
//            if (!string.IsNullOrEmpty(sTem))
//            {

//                rpGetList.ItemTemplate = LoadTemplate(sTem);
//            }
//            rpGetList.DataSource = Utils.SearchResult(PageIndex, iPageSize, sm, ref ResultCount);
//            rpGetList.DataBind();
//            base.iSearchCount = ResultCount;

//            intpages();

//        }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                SearchModel sm;
//                if (!string.IsNullOrEmpty(CID))
//                {
//                    sm = GetSearchModel();
//                }
//                else
//                {
//                    sm = Session["SearchModel"] as SearchModel;
//                }
//                if (!Equals(sm, null))
//                {
//                    iPageSize = sm.PageSize;
//                    base.KeyWord = sm.KeyWords;
//                    bindinfo(sm);
//                }
//                else
//                {
//                    Tips("发生错误！", "搜索时发生错误！！或已经超时", IISPath);
//                }

//                SeoTitle = string.Concat(KeyWord, "-", SiteName);
//            }
//        }
//        private SearchModel GetSearchModel()
//        {
//            Edit md = new Edit();
//            md.DataID = new Guid(CID);
//            //md.WidgetID = new Guid(CID);
//            StringDictionary settings = md.GetSettings();
//            if (!Equals(settings, null))
//            {

//                List<ColumnModel> lstSCM = new List<ColumnModel>();
//                DataTable dt = md.GetSettingsTable();

//                if (dt.Rows.Count > 0)
//                {
//                    foreach (DataRow dr in dt.Rows)
//                    {
//                        string sColumnName = dr["SearchFiled"].ToString();
//                        ColumnModel scm = new ColumnModel();

//                        scm.ColumnValue = Request[sColumnName];
//                        if (!string.IsNullOrEmpty(scm.ColumnValue))

//                            //搜索的关键词
//                            base.KeyWord += string.Concat(scm.ColumnValue, "|");

//                        scm.SearchColumn = sColumnName;
//                        string sWh = dr["Where"].ToString();
//                        if (!string.IsNullOrEmpty(sWh))
//                        {
//                            scm.sWhere = (ESearhWhere)int.Parse(sWh);
//                        }

//                        string sdt = dr["DataType"].ToString();
//                        if (!string.IsNullOrEmpty(sdt))
//                        {
//                            scm.DataType = (EColumnDataType)int.Parse(sdt);
//                        }

//                        string sAndOr = dr["AndOr"].ToString();
//                        if (!string.IsNullOrEmpty(sAndOr))
//                        {
//                            scm.AndOr = int.Parse(sAndOr);
//                        }

//                        scm.SearchTableName = dr["TableName"].ToString();

//                        lstSCM.Add(scm);
//                    }


//                }

//                SearchModel sm = new SearchModel();
//                if (!string.IsNullOrEmpty(settings["PageSize"]))
//                    sm.PageSize = int.Parse(settings["PageSize"]);

//                sm.TableNames = settings["TableNames"];//表名称，可以是多个，逗号分开
//                sm.SelectColumns = settings["Columns"];//搜索的字段
//                sm.WhereColumns = lstSCM; //字段值，及条件等
//                sm.KeyWords = base.KeyWord;
//                sm.Tem = settings["Tem"];

//                Session["SearchModel"] = sm;

//                return sm;
//            }
//            else
//            {
//                return null;
//            }
//        }
//        private void intpages()
//        {
//            if (Equals(sType, "1"))
//            {
//                pgCtr.Linktype = LinkType.AspxRewrite;
//                string sPath = Core.Strings.GetString.RegexReplace(Request.RawUrl, "-([0-9]+)/(.*?)", "-{0}/");
//                //这有点不好理解,以重构
//                pgCtr.ReWritePatchUrl = sPath;

//            }

//            pgCtr.AllCount = iSearchCount;
//            pgCtr.PageSize = iPageSize;

//            pgCtr.CurrentClass = "CurrentPageCoder";
//            pgCtr.ParentClass = "PagesClass";

//        }
//    }
//}