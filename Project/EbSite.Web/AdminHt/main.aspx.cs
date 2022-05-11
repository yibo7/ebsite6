using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Pages;


namespace EbSite.Web.AdminHt
{
    public partial class main : EbSite.Base.Page.ManagePage
    {
        
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

        //add by mh
        public void MoneyOptionChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(drpSites.SelectedValue))
            {

                //EbSite.BLL.AdminUser md = new AdminUser(base.UserName);
                //md.CurrentSiteID = int.Parse(drpSites.SelectedValue);
                //md.Update();
                //Core.Utils.WriteCookie("adminsiteid", drpSites.SelectedValue);
                //Session["adminsiteid"] = drpSites.SelectedValue;
                AppStartInit.ChangeSite(drpSites.SelectedValue);
                Response.Redirect(Request.RawUrl);

            }
            else
            {
                base.Tips("","站点列表取值为空，操作错误");
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                
                ap = apAdmin;
                llRoles.Text = GetRols;
                //btnUpate.Text = Resources.lang.EBNotNewV;
                //try
                //{
                //    UpdateNew un = new UpdateNew();
                //    bool IsHaveNewVersion = un.CheckVersion();
                //    if (IsHaveNewVersion && un.VersionModel != null)
                //    {

                //        llVersion.Text =
                //            string.Format(
                //                "<a  id='havenewv' style=\" color:Red;cursor:pointer\" onclick='GoToUpdate()' title='点击进入升级向导' target=_blank >eBSite有新版啦</a>┊");
                //    }
                //}
                //catch (Exception)
                //{
                    
                    
                //}
              
                
                rpTopMenus.DataSource = BLL.Menus.Instance.GetMenusByParentID(Guid.Empty,UserName);
                rpTopMenus.DataBind();

                drpSites.DataTextField = "SiteName";
                drpSites.DataValueField = "id";

                List<Entity.Sites> ls = BLL.Sites.Instance.FillList();
                List<Entity.Sites> nls = (from i in ls orderby i.id ascending select i).ToList();
                drpSites.DataSource = nls;
                drpSites.DataBind();
                drpSites.SelectedValue = base.GetSiteID.ToString();
                
                CurrentSiteName.Text = SiteName;
                if (IsHaveLimit("316"))
                {
                    logoRight.Visible = true;
                }
                else
                {
                    logoRight.Visible = false;
                }

                
               
            }
		}
        protected override void OnPreInit(EventArgs e)
        {
            //此页面不需要PagesCustom,所以重写了此办法
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
           BLL.User.UserIdentity.SignOutAdmin();
           Base.AppStartInit.RedirectToIndex();
        }
    }
}
