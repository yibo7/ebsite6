using System;
namespace EbSite.Modules.BBS
{
    public partial class Setting : Base.Modules.Settings
    {
       
        public override string PageName
        {
            get
            {
                return "ģ������";
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
            base.AddTags("�����ļ�1", "tg1");
            base.AddTags("�����ļ�2", "tg2");
        }
    }
}