using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.UserPages.Controls.MWenDaManage
{
    public partial class MyAskList : MPUCBaseListForUserRpMobile
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("3a50369d-0a0c-497f-bb81-ef999055145c");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的提问";
            }
        }
       
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }

        protected int GetSiteID
        {
            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["site"]))
                {
                    return 10;
                }
                return Core.Utils.StrToInt( Request.QueryString["site"],1);
            }
        }

        protected int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {

            
          
            string strsql = " userid =" + base.UserID;
            List<Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListPages(pcPage.PageIndex, pcPage.PageSize, strsql, out iCount, GetSiteID);
            iLoadCount =iCount;
            return ls;
        }

        override protected object SearchList(out int iCount)
        {
            string strsql =  string.Format(" userid ={1} and newstitle like '%{0}%' ", SearchKey,base.UserID);
            List<Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListPages(pcPage.PageIndex, pcPage.PageSize, strsql, out iCount, GetSiteID);
            iLoadCount = iCount;
            return ls;
        }
        override protected void Delete(object iID)
        {
            Base.AppStartInit.NewsContentInstDefault.Delete(int.Parse(iID.ToString()),GetSiteID);
        }
    }
}