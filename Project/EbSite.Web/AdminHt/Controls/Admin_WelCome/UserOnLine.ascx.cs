using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_WelCome
{
    public partial class UserOnLine : Base
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
        public override string Permission
        {
            get
            {
                return "314";
            }
        }
        public int CountUserOnline
        {
            get { return EbSite.BLL.User.UserOnline.GetCountAllUser(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                pgCtr.ReWritePatchUrl = string.Concat(EbSite.Base.PageLink.GetBaseLinks.Get(GetSiteID).UserOnlineRw, "?p={0}");
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                //pgCtr.OtherPram = string.Format("cid,{0}", GetClassID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }

        }

    }
}