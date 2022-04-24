using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web
{
    public partial class form : EbSite.Base.Page.BasePage
    {
        //private int SiteID
        //{
        //    get
        //    {
        //       return Core.Utils.StrToInt(Request["site"], 0);
        //    }
        //}
        private Guid ModelID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["mid"]))
                {
                    return new Guid(Request["mid"]);
                }
                return Guid.Empty;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RedirectPathAspx();
            }
        }
        protected  string GetTemPath()
        {
            string TemPath = string.Empty;
            ModelInterface bllModel = new FormModel(GetSiteID);
           if (ModelID!=Guid.Empty)
            {
               ModelClass mc = bllModel.GeModelByID(ModelID);
                TemPath = mc.GetFormTemUrl();
                //Entity.Templates obTem = BLL.Templates.GetModelByCache(mc.TempIDForForm);
                //TemPath = obTem.TemPath;
            }
            return TemPath;
        }
        protected void RedirectPathAspx()
        {
            string TemPath = GetTemPath();
            if (!string.IsNullOrEmpty(TemPath))
            {
                Server.Transfer(string.Concat(Base.AppStartInit.IISPath, TemPath));
            }
            else
            {
                Response.Write("找不到模板!");
            }
        }
        
    }
}