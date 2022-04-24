using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Static;
using EbSite.BLL;
using EbSite.BLL.Ctrtem;


namespace EbSite.Modules.Wenda.Widgets.UserHt
{
    public partial class widget : WidgetBase
    {

        public int MyNoAskCount = 0;//未回答
        public int MyOkAskCount = 0;//已回答

        public int OkAskCount = 0;//已回答 所有
        public int NoAskCount = 0;//未回答 所有

        // Methods
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {

                

                string cachekeyOK = string.Concat("myOKsing", "widget");
                List<Entity.NewsContent> lsok = EbSite.Base.Host.CacheRawApp.GetCacheItem<List<Entity.NewsContent>>(cachekeyOK, "UserHt");// as List<Entity.NewsContent>;
                if (lsok == null)
                {
                    lsok = Base.AppStartInit.NewsContentInstDefault.GetListArray("annex11>0", 0, "", "id", 2);
                    EbSite.Base.Host.CacheRawApp.AddCacheItem(cachekeyOK, lsok, 10, ETimeSpanModel.FZ, "UserHt");

                }
                
                OkAskCount = lsok.Count;


              

                string cachekeyNO = string.Concat("myNOsing", "widget");
                List<Entity.NewsContent> lsno = EbSite.Base.Host.CacheRawApp.GetCacheItem<List<Entity.NewsContent>>(cachekeyNO, "UserHt");// as List<Entity.NewsContent>;
                if (lsno == null)
                {
                    lsno = Base.AppStartInit.NewsContentInstDefault.GetListArray("annex11=0", 0, "", "id", 2);
                    EbSite.Base.Host.CacheRawApp.AddCacheItem(cachekeyNO, lsok, 10, ETimeSpanModel.FZ, "UserHt");

                }
                NoAskCount = lsno.Count;

                string strsql = " State=0 and userid =" + EbSite.Base.Host.Instance.UserID;

                List<ModuleCore.Entity.expertAsk> lsitno = ModuleCore.BLL.expertAsk.Instance.GetListArrayCache(0, strsql, "");

                MyNoAskCount = lsitno.Count;

                string strsql1 = " State=1 and userid =" + EbSite.Base.Host.Instance.UserID;
                List<ModuleCore.Entity.expertAsk> lsitok = ModuleCore.BLL.expertAsk.Instance.GetListArrayCache(0, strsql1, "");

                MyOkAskCount = lsitok.Count;





            }
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
                return "UserHt";
            }
        }

    }
}