using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.HomeSet
{
    public partial class PlaceSetting : MPUCBaseSaveForUser
    {
        public override string PageName
        {
            get
            {
                return "我的站点设置";
            }
        }
        protected override bool IsSaveCloseWinBox
        {
            get
            {
                return false;
            }
        }
        public override string TipsText
        {
            get
            {
                if (!EbSite.BLL.SpaceSetting.Instance.Exists(UserID))
                {
                    return "您还没开通空间，请如实填写如下信息!";
                }
                else
                {
                    return "修改空间信息!";
                }

            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        #region 杨欢乐添加 判断用户级别 允许开通个人空间的用户级别
        private  bool IsAllow()
        {
            bool k = false;
            int level=int.Parse(Configs.Instance.Model.AllowOpenSiteGroup);
            if(EbSite.Base.Host.Instance.UserLevel>=level)
            {
                k = true;
            }
            return k;
        }
        #endregion
        #region 杨欢乐添加 判断用户级别 可以使用个性域名的用户级别
        private bool IsAllowDemainGroup()
        {
            bool k = false;
            int level = int.Parse(Configs.Instance.Model.UseMyDemainGroup);
            if (EbSite.Base.Host.Instance.UserLevel >= level)
            {
                k = true;
            }
            return k;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (IsAllow())
                {
                    ThemeID.DataTextField = "ThemeName";
                    ThemeID.DataValueField = "id";
                    ThemeID.DataSource = EbSite.BLL.SpaceThemes.Instance.GetListArray("");
                    ThemeID.DataBind();

                    if (!IsAllowDemainGroup()) //判断用户级别 可以使用个性域名的用户级别
                    {
                        this.ReWriteName.ReadOnly = true;
                    }
                }
                else
                {
                    base.ShowTipsPop("您的级别不够！");
                }

               
            }

        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("af371bdd-f674-4077-a9ed-e2896fb4c857");
            }
        }
        protected override void OnBasePageLoading()
        {

            if (EbSite.BLL.SpaceSetting.Instance.Exists(UserID))
            {
                SID = EbSite.BLL.SpaceSetting.Instance.GetSpaceIDByUserID(UserID).ToString();
            }

        }
        override protected void InitModifyCtr()
        {

            EbSite.BLL.SpaceSetting.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            int iThemeID = int.Parse(ThemeID.SelectedValue);

            Base.BLL.OtherColumn cRealname = new OtherColumn("ThemePath", BLL.SpaceThemes.Instance.GetPathByID(iThemeID));
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("Status", "1");
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("DefaultTabID", "0");
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("AddTime", DateTime.Now.ToString());
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("UpdatedateTime", DateTime.Now.ToString());
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("VisitedTimes", "0");
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("UserID", UserID.ToString());
            lstOtherColumn.Add(cRealname);
            if (UserGroups.Length > 0)
            {
                EbSite.BLL.SpaceSetting.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn, UserGroups[0]);
                #region 初使化用户组下的默认标签 yhl 2012-01-04

                //int groupid = EbSite.Base.Host.Instance.CurrentFirstGroup.Id;
                int groupid = EbSite.Base.AppStartInit.RoleID;
                List<Entity.SpaceTabsDefault> ls = EbSite.BLL.SpaceTabsDefault.Instance.FillList();

                List<Entity.SpaceTabsDefault> NLs = (from li in ls
                                                     where
                                                    (li.UserGroupID == groupid) || (li.UserGroupID == 0)
                                                     select li).ToList();
                int i = 1;
                foreach (Entity.SpaceTabsDefault spaceTabsDefault in NLs)
                {

                    Entity.SpaceTabs md=new SpaceTabs();
                    md.TabName = spaceTabsDefault.TabName;//标签名称
                    md.Layout = spaceTabsDefault.Layout;//版式
                    md.OrderNum = i;
                    md.UserID = base.UserID;
                    md.ParentID = 0;
                    md.Add();
                    i++;

                }
                #endregion

                base.ShowTipsPop("设置完成");
            }
            else
            {
                base.ShowTipsPop("您好当前所在的用户组不支持开通个人空间！");
            }


        }



    }
}