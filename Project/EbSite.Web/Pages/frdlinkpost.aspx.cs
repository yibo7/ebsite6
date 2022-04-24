using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Entity;

namespace EbSite.Web.Pages
{
    public partial class frdlinkpost : EbSite.Base.Page.CustomPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!ConfigsControl.Instance.IsAllowApplyFrdLink)
            {
                Tips("暂停申请", "抱歉，目前暂时不接受申请友情连接","");
                return;
            }

            if (!IsPostBack)
            {

                inithead();
            }

        }
        private void inithead()
        {

            base.SeoTitle = string.Concat("申请友情连接-", SiteName);
            base.SeoKeyWord = GetSeoWord(SeoSite.SeoTagIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoSite.SeoTagIndexDes, "");

        }

        protected void bntSave_Click(object sender, EventArgs e)
        {
            string spath = upTest.ValSavePath;
            EbSite.Entity.outlinks md = new outlinks();
            md.LogoUrl = spath;
            if (!string.IsNullOrEmpty(spath))
            {
                md.IsHaveLogo = true;
            }
            else
            {
                md.IsHaveLogo = false;
            }
            md.SiteID = GetSiteID;
            md.SiteName = tbSiteName.Text;
            md.Url = tburl.Text;
            md.QQ = tbQQ.Text;
            md.Email = tbemail.Text;
            md.Tel = tbtel.Text;
            md.Demo = tbdemo.Text;
            md.OrderID = 1;
            md.Mobile = tbmobile.Text;
            md.IsAuditing = false;
            md.AddTime = DateTime.Now;
            EbSite.BLL.outlinks.Instance.Add(md);

            base.Tips("消息","友情连接申请成功,等待管理员申请通过！","");
        }


    }
}