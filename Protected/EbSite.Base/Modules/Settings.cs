using EbSite.Base.ControlPage;
using EbSite.Base.Modules.Configs;
using EbSite.Base.Page;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace EbSite.Base.Modules
{

    public abstract class Settings : UserControlBase
    {
        //public string ColseInfo = "";
        //public bool IsSaveColseOpen = false;
        public List<ListItemModel> TagsList = new List<ListItemModel>();
        /// <summary>
        /// 模块管理权限
        /// </summary>
        public override string Permission
        {
            get
            {
                return "237";
            }
        }
        public Settings()
        {
            this.CustomTags();
            base.Load += new EventHandler(this.StPage_Load);
        }

        public void AddTags(string sTitle, string sTagMark)
        {
            ListItemModel item = new ListItemModel();
            item.Value = sTagMark;
            item.Text = sTitle;
            this.TagsList.Add(item);
        }

        public abstract void CustomTags();

        public abstract void LoadConfigs();
        public abstract void Save();
        //protected void SaveConfig<ConfigType>(EbSite.Base.Modules.Configs.Configs<ConfigType> cf) where ConfigType : class , new()
        //{

        //    cf.GetSysConfig.SaveConfig();

        //}

        private void StPage_Load(object sender, EventArgs e)
        {
            this.LoadConfigs();
        }


        public delegate void UpdateTitleDelegate(Settings St);
    }
}

