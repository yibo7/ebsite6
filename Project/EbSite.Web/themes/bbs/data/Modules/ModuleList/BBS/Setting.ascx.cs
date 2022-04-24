using System;
namespace EbSite.Modules.BBS
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
            //SettingInfo.Instance.IsAllowUserAdd = cbIsAllow.Checked;
           //SettingInfo.Instance.TestTitle =  txtTest.Text;
           //SettingInfo.Instance.GetSysConfig.SaveConfig(SettingInfo.Instance);
           //base.SaveConfig(SettingInfo.Instance);
           
        }
        public override void LoadConfigs()
        {
            //cbIsAllow.Checked = SettingInfo.Instance.IsAllowUserAdd;
            //txtTest.Text = SettingInfo.Instance.TestTitle;
        }
        public override void CustomTags()
        {
            base.AddTags("配置文件1", "tg1");
            base.AddTags("配置文件2", "tg2");
        }
    }
}