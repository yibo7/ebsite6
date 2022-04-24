using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Modules;
using EbSite.BLL;


namespace EbSite.Modules.Wenda.Widgets.GetSolveAsk
{
    public partial class widget : WidgetBase
    {
        private string sKeyWord
        {
            get
            {
                return Request["k"];
            }
        }
        /// <summary>
        /// 得到当站点的SiteID
        /// </summary>
        protected int SiteDI
        {
            get
            {
                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("4e0edb7e-1b30-41ad-9f74-d63c80458c35"));
                // /themes/bmask/data/Modules/ModuleList/BmAsk/
                string[] arry = mpath.Split('/');
                List<EbSite.Entity.Sites> ls = EbSite.BLL.Sites.Instance.FillList();

                EbSite.Entity.Sites md = (from i in ls where i.PageTheme == arry[2] select i).ToList()[0];

                return md.id;
            }
        }
        public override void LoadData()
        {

            if (!base.IsPostBack)
            {

                StringDictionary settings = GetSettings();
                int iTOP = 10;
                if (settings.ContainsKey("txtTOP"))
                {
                    iTOP = int.Parse(settings["txtTOP"]);
                }

                string Fields = NewsContentSplitTable.DefualtFileds;
                //string sqlWhere = " Annex1>= " + 30;
                string sqlWhere = " Annex21 = "+2+" ";


                rpList.DataSource = Base.AppStartInit.NewsContentInstDefault.GetListArray(sqlWhere, iTOP, "AddTime DESC", "*", SiteDI);  //写死了，因为现在系统不能获取正确的siteid;
                rpList.DataBind();

            }
        }
        /// <summary>
        /// 获取当前内容ID
        /// </summary>
        protected int iID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                return 0;
            }
        }

        public override string Name
        {
            get { return "GetSolveAsk"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


    }
}