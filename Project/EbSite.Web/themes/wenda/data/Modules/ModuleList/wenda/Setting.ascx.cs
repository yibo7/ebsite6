using System;
namespace EbSite.Modules.Wenda
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
        public override void Save()
        {
            SettingInfo md = new SettingInfo();
            Configs.Instance.Model.txtCatalog = txtCatalog.Text;
            //base.SaveConfig(Configs.Instance.Model);
            Configs.Instance.Model.txtReplay = txtReplay.Text;
            Configs.Instance.Model.ContentPath = txtContentPath.Text;
            Configs.Instance.Save();
            //SettingInfo.Instance.GetSysConfig.SaveConfig(md);
            //base.SaveConfig(md);



        }
        public override void LoadConfigs()
        {
            //cbIsAllow.Checked = SettingInfo.Instance.IsAllowUserAdd;
            txtCatalog.Text = Configs.Instance.Model.txtCatalog;

            txtContentPath.Text = Configs.Instance.Model.ContentPath;

            txtReplay.Text = Configs.Instance.Model.txtReplay;

           
        }
        public override void CustomTags()
        {
            base.AddTags("快速发帖设置", "tg1");
        }
    }
}