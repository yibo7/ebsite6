using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.ExtWidgets;
using EbSite.Base.Static;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.dialog.Controls
{
    public partial class WidgetData : UserControlListBase
    {
        protected override string AddUrl
        {
            get { throw new NotImplementedException(); }
        }
        protected override void Delete(object ID)
        {
            throw new NotImplementedException();
        }
        protected override object LoadList(out int iCount)
        {
            throw new NotImplementedException();
        }

      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                RepWidgetAll.DataSource = WidgetAll();
                RepWidgetAll.DataBind();

                RepWidgetModule.DataSource = WidgetModule();
                RepWidgetModule.DataBind();

                RepWidgeteSite.DataSource = WidgetSite();
                RepWidgeteSite.DataBind();

            }
        }
        protected string MakeCoder(string sID, string sName)
        {
            return EbSite.Control.Widget.GetWidgetCtrCoder(sID, sName);

           
        }
        private List<WidgetShow> WidgetAll()
        {
            string rawKey = string.Concat("wd-", base.GetSiteID);
             List<WidgetShow>  list =EbSite.Base.Host.CacheApp.GetCacheItem<List<WidgetShow>>(rawKey,"dig");
            if (Equals(list, null))
            {
                string ZoneName = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.DefualtZoneName;
                list = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList(ZoneName); 
                if (!Equals(list, null))
                   EbSite.Base.Host.CacheApp.AddCacheItem(rawKey, list,60,ETimeSpanModel.FZ, "dig");

            }
            return list;
        }
        private List<WidgetShow> WidgetModule()
        {
            string rawKey = string.Concat("wdm-", base.GetSiteID);
            List<WidgetShow> list = EbSite.Base.Host.CacheApp.GetCacheItem<List<WidgetShow>>(rawKey, "dig");
            if (Equals(list, null))
            {
                List<WidgetShow> newList = (from li in WidgetAll()
                                            where (li.ModulID != new Guid("00000000-0000-0000-0000-000000000000"))
                                            select li
                                      ).ToList();
                list = newList;
               
                EbSite.Base.Host.CacheApp.AddCacheItem(rawKey, list, 60, ETimeSpanModel.FZ, "dig");

            }
            return list;
        }
        private List<WidgetShow> WidgetSite()
        {
            string rawKey = string.Concat("wds-", base.GetSiteID);
            List<WidgetShow> list = EbSite.Base.Host.CacheApp.GetCacheItem<List<WidgetShow>>(rawKey, "dig");
            if (Equals(list, null))
            {
                List<WidgetShow> newList = (from li in WidgetAll()
                                            where (li.ModulID == new Guid("00000000-0000-0000-0000-000000000000"))
                                            select li
                                      ).ToList();
                list = newList;
              
                 EbSite.Base.Host.CacheApp.AddCacheItem(rawKey, list, 60, ETimeSpanModel.FZ, "dig");

            }
            return list;
        }
    }
}