using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Base;

namespace EbSite.Web.Pagesm
{
    public partial class uccindex : UccBase
    {
       override protected string MTitle
        {
            get
            {
                return "个人中心";
            }
        }
       protected int Credits = 0;
       //protected decimal iBalance = 0;//余款
       protected string UserLevelName = string.Empty;
       protected EbSite.Base.EntityAPI.MembershipUserEb UserInfos;
       protected bool IsAdmin = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfos = MembershipUserEb.Instance.GetEntity(UserID);
            
            Credits = UserInfos.Credits;
            IsAdmin = UserInfos.ManagerID > 0;
            
            EbSite.Entity.UserLevel userLevel = EbSite.BLL.UserLevel.Instance.GetEntity(UserInfos.UserLevel);
            UserLevelName = userLevel.LevelName;

            //List<Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, "UserId=" + base.UserID, "");
            //if (ls.Count > 0)
            //{
            //    iBalance = ls[0].Balance;
            //}

            BindModulesMenus();
        }

        private void BindModulesMenus()
        {

            rpModuleMenus.DataSource = BLL.MenusForUser.Instance.GetMenusByParentID(Guid.Empty, ThemeType.MOBILE);
            rpModuleMenus.DataBind();
            
        }

    }
}