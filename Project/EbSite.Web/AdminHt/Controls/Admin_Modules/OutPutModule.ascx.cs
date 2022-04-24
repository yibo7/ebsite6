using System;
using System.Collections.Generic;
using System.IO;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public partial class OutPutModule : BasePage
    {
        //public ModuleInfo Model
        //{
        //    get
        //    {
        //        ModuleInfo md = new ModuleInfo();
        //        if (!string.IsNullOrEmpty(Request["mid"]))
        //        {
        //            return BLL.ModulesBll.Modules.Instance.GetEntity(new Guid(Request["mid"]));
        //        }
        //        return md;
        //    }
        //}
        
        public override string Permission
        {
            get
            {
                return "238";
            }
        }
        

        private string sUrl
        {
            get
            {
               return ViewState["url"] as string;
            }
        }
        protected void bntOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sUrl))
            {
                string hUrl = BLL.ModulesBll.Modules.Instance.OutPutModule(GetModuleID);
                Core.Utils.RunClientJs(this, string.Format("window.open('{0}')", hUrl));
                llInfo.Text = "模块生成完毕，是否要分享到官方平台?";
                bntOut.Text = "是的，我要分享到官方";

                ViewState["url"] = hUrl;
            }
            else if (Equals(sUrl, "1"))
            {

                Core.Utils.RunClientJs(this, string.Format("window.open('{0}')", EbSite.Base.AppStartInit.OfficialsUrl));
                //base.ColseGreyBox(false);

            }
            else
            {
                //在这里将文件上传到官方服务器

                llInfo.Text = "文件提交完毕，感谢分享！";
                bntOut.Text = "点击进入官方网站";
                ViewState["url"] = "1";
            }
        }


    }
}