using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;

namespace EbSite.Web.Pages
{
    public partial class frdlink : EbSite.Base.Page.CustomPage
    {
        protected string TisInfo
        {
            get { return ConfigsControl.Instance.FrdLinkDemo; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inithead();
                bindData();
            }

        }
        private void inithead()
        {

            base.SeoTitle = string.Concat("友情连接-", SiteName);
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoTagIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoTagIndexDes, "");

        }

        private void bindData()
        {
            List<Entity.outlinks> ls = BLL.outlinks.Instance.GetListArray("");

            List<Entity.outlinks> LogoLs = (from i in ls where i.IsHaveLogo == true  select i).ToList();
            List<Entity.outlinks> TextLs = (from i in ls where i.IsHaveLogo == false  select i ).ToList();
            rpFrdlinkLogo.DataSource = LogoLs;
            rpFrdlinkLogo.DataBind();


            rpFrdlinkText.DataSource = TextLs;
            rpFrdlinkText.DataBind();
        }
    }
}