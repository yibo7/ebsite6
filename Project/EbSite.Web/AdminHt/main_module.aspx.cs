using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL;
using EbSite.BLL.ModulesBll;
using EbSite.Core;
using EbSite.Entity.Module;
using EbSite.Pages;


namespace EbSite.Web.AdminHt
{
    public partial class main_module : EbSite.Base.Page.ManagePage
    {
        protected string sModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mid"]))
                {
                    return Request["mid"].Trim();
                }
                else
                {
                    Host.Instance.Tips("出错了", "找不到相应的模块目录！", "");
                    return "";
                }
            }
        }
         

        protected AdminPrincipal ap;
        protected Entity.Sites SiteModel;
        protected string ModulsName = string.Empty;
        protected string Producer = string.Empty;
        protected string ProducerUrl = string.Empty;
        protected string Version = string.Empty;
        protected override void OnPreInit(EventArgs e)
        {
            //此页面不需要PagesCustom,所以重写了此办法
        }
        protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                ap = AppStartInit.CheckAdmin(); 
                SiteModel = Host.Instance.CurrentSite;
                var module = Modules.Instance.GetEntity(new Guid(sModelID));
                ModulsName = module.ModuleName;
                Producer = module.Author;
                ProducerUrl = module.AuthorUrl;
                Version = module.Version;

                List<ModulesPageModel> lstMenus = new List<ModulesPageModel>();
                BLL.ModulesBll.MenusForAdminer mm = new MenusForAdminer(new Guid(sModelID));

                List<ModulePageInfo> lstParent = mm.GetParentMenu();

                foreach (ModulePageInfo pageInfo in lstParent)
                {
                    lstMenus.Add(new ModulesPageModel(pageInfo.PageName, pageInfo.GetRealUrl()));
                }

                rpMenus.DataSource = lstMenus;
                rpMenus.DataBind();

            }
		} 
    }

}
