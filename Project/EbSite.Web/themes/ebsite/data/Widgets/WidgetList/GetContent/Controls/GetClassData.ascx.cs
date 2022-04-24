using System;
using System.Collections.Generic;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Static;
using EbSite.Control;
using EbSite.Core;
using EbSite.BLL;
namespace EbSite.Pages.Control
{
    public partial class GetClassData : System.Web.UI.UserControl
    {
        /// <summary>
        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
        /// </summary>
        public int SiteID { get; set; }
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
        //杨欢乐给注释
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

        //杨欢乐添加 图片显示个数
        //private int _iImgTop = 10;
        //public int iImgTop
        //{
        //    get
        //    {
        //        return _iImgTop;
        //    }
        //    set
        //    {
        //        _iImgTop = value;
        //    }
        //}
        ////杨欢乐添加 标题显示个数
        //private int _iTitleTop = 10;
        //public int iTitleTop
        //{
        //    get
        //    {
        //        return _iTitleTop;
        //    }
        //    set
        //    {
        //        _iTitleTop = value;
        //    }
        //}

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
        private  string CacheClass ; 
        //private static readonly string[] MasterCacheKeyArray = { "uc-GetContent", "-", Host.Instance.GetSiteID.ToString() };
        //private static CacheManager bllCache;





        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               // bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
                CacheClass = string.Concat("widucgetass", "-", Host.Instance.GetSiteID.ToString());
                Repeater rp = new Repeater();

                rp.DataSource = GetData();

                if (!string.IsNullOrEmpty(MyTemPath))
                {
                    rp.ItemTemplate = LoadTemplate(MyTemPath);
                }
                else
                {
                    string sGetClassDataPath = string.Concat("~/", EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsWidgetList(), "/GetContent/Controls/defaulttem/title.ascx"); ;

                    rp.ItemTemplate = LoadTemplate(sGetClassDataPath);//"~/Widgets/GetContent/Controls/defaulttem/title.ascx"
                }

                phList.Controls.Add(rp);
                
                rp.DataBind();
            }
        }
        /// <summary>
        /// 要查询的字段，可由用户后台设置
        /// </summary>
        //protected string Fields = "id,newstitle,ClassName,addtime,classid,HtmlName,SmallPic,UserID,UserNiName,UserName";


        private NewsContentSplitTable NewsContentInst
        {
            get
            {
                return  EbSite.Base.AppStartInit.GetNewsContentInst(iClassID);
            }
        }
        protected List<Entity.NewsContent> GetData()
        {
            if (SiteID < 1)
            {
                Response.Write("<font color=#ff0000>站点ID为0,可能没有设置相关站点</font>");
                return null;
            }


            string Fields = NewsContentSplitTable.DefualtFileds;
            
            //if (!string.IsNullOrEmpty(ConfigsControl.Instance.ContentFileds_Widget))
            //{
            //    Fields = Fields + "," + ConfigsControl.Instance.ContentFileds_Widget;
            //}
            if (!string.IsNullOrEmpty(BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_Widget))
            {
                Fields = Fields + "," + BLL.DataSettings.Content.Instance.GetConfigCurrent.SearchFileds_Widget;
            }
            //string CacheKey = string.Concat("GetClassData-", DataModel, "-", iTop, "-", iClassID, "-", SiteID);
            string CacheKey = string.Concat("GetClassData-", "-", iTop, "-", iClassID, "-", SiteID);
            List<Entity.NewsContent> lst = EbSite.Base.Host.CacheApp.GetCacheItem<List<Entity.NewsContent>>(CacheKey, CacheClass); //bllCache.GetCacheItem(CacheKey) as List<Entity.NewsContent>;
            if (lst == null)
            {

                if (DataModel == DataListType.GoodList)
                {

                    lst = NewsContentInst.GetListGood(iTop, iClassID, IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.AllHot)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.WeekHot)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "w", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.Adv)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "adv", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.DayHot)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "d", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.MonthHot)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "m", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.CommentHot)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "ch", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else if (DataModel == DataListType.FavorableHot)
                {
                    lst = NewsContentInst.GetListHot(iClassID, iTop, "fh", IsGetSub, IsHaveImg, Fields, SiteID);
                }
                else
                {
                    lst = NewsContentInst.GetListNewOfNewsClass(iClassID, iTop, IsGetSub, IsHaveImg, Fields, SiteID);
                }

                if (!Equals(lst, null)) EbSite.Base.Host.CacheApp.AddCacheItem(CacheKey,lst,CacheDuration,ETimeSpanModel.分钟, CacheClass); // bllCache.AddCacheItem(CacheKey, lst);
            }
            return lst;
        }
    }
    public enum DataListType
    {
        /// <summary>
        /// 最新数据
        /// </summary>
        BestNewDate = 1,
        /// <summary>
        /// 调用推荐数据
        /// </summary>
        GoodList = 2,
        /// <summary>
        /// 调用总排行数据
        /// </summary>
        AllHot = 3,
        /// <summary>
        /// 调用本周热门数据
        /// </summary>
        WeekHot = 4,
        /// <summary>
        /// 收藏率排行
        /// </summary>
        Adv = 5,
        /// <summary>
        /// 评论最多的内容
        /// </summary>
        CommentHot,
        /// <summary>
        /// 好评（被顶）最多的内容
        /// </summary>
        FavorableHot, 
        /// <summary>
        /// 今日点击排行
        /// </summary>
        DayHot,
        /// <summary>
        /// 本月点击排行
        /// </summary>
        MonthHot
    }
    
    
}