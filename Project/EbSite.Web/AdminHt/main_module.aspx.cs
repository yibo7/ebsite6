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

        protected string GetRols
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                //EbSite.BLL.GetLink.HrefFactory.GetAspxInstance(GetSiteID).GetRemark()
                foreach (string role in ap.Roles)
                {
                    sb.Append(role);
                    sb.Append("|");
                }
                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);
                if (sb.Length == 0) return "未分配角色";
                return sb.ToString();
            }
        }

        protected AdminPrincipal ap;
        protected Entity.Sites SiteModel;
        protected string ModulsName = string.Empty;
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

                ModulsName = BLL.ModulesBll.Modules.Instance.GetModelName(new Guid(sModelID));


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
