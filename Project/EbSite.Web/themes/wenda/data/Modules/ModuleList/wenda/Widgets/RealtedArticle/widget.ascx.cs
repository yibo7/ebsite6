using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL;
using EbSite.BLL.Ctrtem;
using EbSite.Base.Static;



namespace EbSite.Modules.Wenda.Widgets.RealtedArticle
{
    public partial class widget : WidgetBase
    {
        public override string CacheKey
        {
            get
            {
                return Request["id"];
            }
        }

        private int iRequestID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                else
                {

                    return -1;
                }
            }
        }
        // Methods
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                EbSite.Entity.NewsContent Model = new EbSite.Entity.NewsContent();
                Model = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(iRequestID);

                rpRelateContent.DataSource = GetRss10IDS(10, Model.ClassID);

                //ModuleCore.BLL.class_article.Instance.GetListArray(10, "classid=" + Model.ClassID, "RAND()");
                rpRelateContent.DataBind();

            }
        }

        public List<RssAskModel> GetRss10IDS(int iTOP, int bmclassid)
        {
            
            List<RssAskModel> items = new List<RssAskModel>();

            #region yhl 2013-09-16 注释
           

            List<EbSite.Entity.NewsContent> modelList = new List<EbSite.Entity.NewsContent>();
            //DataSet ds = new DataSet();

           ModuleCore.Entity.AskCache cacheModel =
                ModuleCore.BLL.AskCache.Instance.GetEntity(iRequestID, 1);
            if (!Equals(cacheModel, null))
            {
                string StrWhere =string.Format("classid={0} and id in({1})" , bmclassid,cacheModel.randomids);
                modelList = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListArray(StrWhere,iTOP,"","",SettingInfo.Instance.GetSiteID);
                //ds = EbSite.Modules.Wenda.ModuleCore.BLL.class_article.Instance.GetClassArticleRandomContentIDS(iTOP, StrWhere, cacheModel.randomids);
            }

            if ( modelList.Count > 0)
            {
                foreach (var newsContent in modelList)
                {
                    RssAskModel item = new RssAskModel();
                    item.Title = newsContent.NewsTitle;// dt.Rows[i]["newstitle"].ToString();
                    item.Content = "";

                    item.CtLink = Base.Host.Instance.GetContentLink(newsContent.ID, SettingInfo.Instance.GetSiteID,newsContent.ClassID);
                    item.ID = newsContent.ID; // Convert.ToInt32(dt.Rows[i]["AskId"].ToString());
                    items.Add(item);
                }       
            }
            #endregion


            return items;
        }
        public override bool IsEditable
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return "RealtedArticle";
            }
        }

    }

    public class RssAskModel
    {

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string CtLink { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 评论式 解答人 地址
        /// </summary>
        public string JiedaLink { get; set; }
        /// <summary>
        /// 评论式 解答人 ID
        /// </summary>
        public int UserID { get; set; }

    }
}