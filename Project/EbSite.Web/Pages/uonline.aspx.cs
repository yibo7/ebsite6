using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.Pages
{
    public partial class uonline : EbSite.Base.Page.CustomPage
    {
        private int iPageSize
        {
            get
            {
                if (pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return 30;
                }

            }

        }

        protected string GetUserLink(object UserID)
        {
            if (!Equals(UserID.ToString(), "0"))
            {
                return EbSite.BLL.GetLink.LinkOrther.Instance.GetInstance(GetSiteID).GetUserInfo(UserID);
            }
            return "#";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.SeoTitle = string.Concat("在线用户-", SiteName);

            if (!IsPostBack)
            {
                iSearchCount = EbSite.BLL.User.UserOnline.GetCountAllUser();
                rpUserOnline.DataSource = EbSite.BLL.User.UserOnline.GetAllUser(pgCtr.PageIndex, iPageSize, "");
                rpUserOnline.DataBind();
                intpages();
            }
        }

        protected int iSearchCount = 0;
        protected void intpages()
        {
            if (!Equals(pgCtr, null))
            {
                pgCtr.ReWritePatchUrl = string.Concat(EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).UserOnlineRw,"?p={0}");
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                //pgCtr.OtherPram = string.Format("cid,{0}", GetClassID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }
       
    }
}