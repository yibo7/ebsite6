using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace EbSite.Modules.UserBaseInfo
{
    public partial class Setting : Base.Modules.Settings
    {
        public override string PageName
        {
            get
            {
                return "模块设置";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //drpAllowOpenSiteGroup.BindD();
                //////////////
                //drpUseMyDemainGroup.BindD();
                //////
                //drpAllowModifyDefaultTabGroup.BindD();
                ////////
                //drpAllowModifyTabGroup.BindD();
                //////
                //drpAllowAddTabGroup.BindD();
                //////
                //drpAllowOrderTabGroup.BindD();
                ///////
                //drpUseThemeGroup.BindD();
                //////
                //drpUseLayout.BindD();
                ////
                //drpUseWidgets.BindD();

            }

        }
        public override void Save()
        {

            Configs.Instance.Model.FavoriteName = txtFavoriteName.Text.Trim();

            Configs.Instance.Model.AllowOpenSiteGroup = drpAllowOpenSiteGroup.SelectedValue;
            Configs.Instance.Model.UseMyDemainGroup = drpUseMyDemainGroup.SelectedValue;
            Configs.Instance.Model.AllowModifyDefaultTabGroup = drpAllowModifyDefaultTabGroup.SelectedValue;

            Configs.Instance.Model.AllowModifyTabGroup = drpAllowModifyTabGroup.SelectedValue;
            Configs.Instance.Model.AllowAddTabGroup = drpAllowAddTabGroup.SelectedValue;
            Configs.Instance.Model.AllowOrderTabGroup = drpAllowOrderTabGroup.SelectedValue;

            Configs.Instance.Model.UseThemeGroup = drpUseThemeGroup.SelectedValue;
            Configs.Instance.Model.UseLayout = drpUseLayout.SelectedValue;
            Configs.Instance.Model.UseWidgets = drpUseWidgets.SelectedValue;
            Configs.Instance.Save();
            //base.SaveConfig(Configs.Instance.Model);

        }
        public override void LoadConfigs()
        {

            txtFavoriteName.Text = Configs.Instance.Model.FavoriteName;

            drpAllowOpenSiteGroup.SelectedValue = Configs.Instance.Model.AllowOpenSiteGroup;
            drpUseMyDemainGroup.SelectedValue = Configs.Instance.Model.UseMyDemainGroup;
            drpAllowModifyDefaultTabGroup.SelectedValue = Configs.Instance.Model.AllowModifyDefaultTabGroup;

            drpAllowModifyTabGroup.SelectedValue = Configs.Instance.Model.AllowModifyTabGroup;
            drpAllowAddTabGroup.SelectedValue = Configs.Instance.Model.AllowAddTabGroup;
            drpAllowOrderTabGroup.SelectedValue = Configs.Instance.Model.AllowOrderTabGroup;

            drpUseThemeGroup.SelectedValue = Configs.Instance.Model.UseThemeGroup;
            drpUseLayout.SelectedValue = Configs.Instance.Model.UseLayout;
            drpUseWidgets.SelectedValue = Configs.Instance.Model.UseWidgets;

            
        }
        public override void CustomTags()
        {
            base.AddTags("基础设置", "tg1");
            base.AddTags("个人空间", "tg2");
        }
    }
}