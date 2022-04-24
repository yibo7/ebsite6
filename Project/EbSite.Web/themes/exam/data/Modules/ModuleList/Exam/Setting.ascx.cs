using System;
namespace EbSite.Modules.Exam
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
            //SettingInfo.Instance.GetSysConfig.Instance.IsAllowUserAdd = cbIsAllow.Checked;
            base.SaveConfig(SettingInfo.Instance.GetSysConfig.Instance);
           
        }
        public override void LoadConfigs()
        {
            //cbIsAllow.Checked = SettingInfo.Instance.GetSysConfig.Instance.IsAllowUserAdd;
            
        }
        public override void CustomTags()
        {
            base.AddTags("�����ļ�1", "tg1");
            base.AddTags("�����ļ�2", "tg2");
        }
    }
}