using System;
using System.Collections.Generic;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Control;
using EbSite.Core;
using EbSite.BLL;


namespace EbSite.Modules.Wenda.Widgets.GetSolve.Controls
{
    public partial class GetClassData : System.Web.UI.UserControl
    {
        /// <summary>
        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
        /// </summary>
        protected int GetSiteID
        {
            get
            {
                return Host.Instance.GetSiteID;
            }
        }
        private int _iClassID = -1;
        

        public int iClassID
        {
            get
            {
                return _iClassID;
            }
            set
            {
                _iClassID = value;
            }
        }
        
        private int _iTop = 10;
        public int iTop
        {
            get
            {
                return _iTop;
            }
            set
            {
                _iTop = value;
            }
        }

        public DataListType _DataModel;

        public DataListType DataModel
        {
            get
            {
                return _DataModel;
            }
            set
            {
                _DataModel = value;
            }
        }
        public string _MyTemPath;

        public string MyTemPath
        {
            get
            {
                return _MyTemPath;
            }
            set
            {
                _MyTemPath = value;
            }
        }

        private bool _IsGetSub = false;
        public bool IsGetSub
        {
            get
            {
                return _IsGetSub;
            }
            set
            {
                _IsGetSub = value;
            }
        }
        private bool _IsHaveImg = false;
        /// <summary>
        /// 是否只查询有图片的内容
        /// </summary>
        public bool IsHaveImg
        {
            get
            {
                return _IsHaveImg;
            }
            set
            {
                _IsHaveImg = value;
            }
        }
        

        const double CacheDuration = 60.0;
        private static readonly string[] MasterCacheKeyArray = { "uc-GetSolve", "-", Host.Instance.GetSiteID.ToString() };
        private static CacheManager bllCache;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
                Repeater rp = new Repeater();

                rp.DataSource = GetData();

                if (!string.IsNullOrEmpty(MyTemPath))
                {
                    rp.ItemTemplate = LoadTemplate(MyTemPath);
                }
                else
                {
                    rp.ItemTemplate = LoadTemplate("defaulttem/title.ascx");
                }

                phList.Controls.Add(rp);
                
                rp.DataBind();
            }
        }
        /// <summary>
        /// 要查询的字段，可由用户后台设置
        /// </summary>
        //protected string Fields = "id,newstitle,ClassName,addtime,classid,HtmlName,SmallPic,UserID,UserNiName,UserName";
        protected List<Entity.NewsContent> GetData()
        {
            string Fields = NewsContent.DefualtFileds;
            //if (!string.IsNullOrEmpty(ConfigsControl.Instance.ContentFileds_Widget))
            //{
            //    Fields = Fields + "," + ConfigsControl.Instance.ContentFileds_Widget;
                
            //}

            string CacheKey = string.Concat("GetClassData-", DataModel, "-", iTop, "-", iClassID, "-", GetSiteID);
            List<Entity.NewsContent> lst = bllCache.GetCacheItem(CacheKey) as List<Entity.NewsContent>;
            if (lst == null)
            {
                if (DataModel == DataListType.HighScore)
                {
                    //lst = BLL.NewsContent.GetListGood(iTop, iClassID, IsGetSub, IsHaveImg, Fields, GetSiteID);
                    string sqlWhere = " Annex1>= "+30;
                    lst = BLL.NewsContent.GetListArray(sqlWhere, iTop, "AddTime", Fields, 2);  //写死了，因为现在系统不能获取正确的siteid
                }
                else if (DataModel == DataListType.Solve)
                {
                    //lst = BLL.NewsContent.GetListHot(iClassID, iTop, "", IsGetSub, IsHaveImg, Fields, GetSiteID);
                    string sqlWhere = " Annex4= " + 2;
                    lst = BLL.NewsContent.GetListArray(sqlWhere, iTop, "AddTime", Fields, 2);  //写死了，因为现在系统不能获取正确的siteid
                }
                if (!Equals(lst, null)) bllCache.AddCacheItem(CacheKey, lst);
            }
            return lst;
        }
    }

    public enum DataListType
    {
        /// <summary>
        /// 赏金求答案
        /// </summary>
        HighScore = 1,
        /// <summary>
        /// 已解决
        /// </summary>
        Solve = 2
    }
}