using System;
using System.Collections;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;
using System.Collections.Generic;
namespace EbSite.Widgets.GetRelatedContent
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    txtCount.Text = settings["txtCount"];

                    drpTem.CtrlValue = settings["txtTem"];
                    if(settings.ContainsKey("IsSmallImg"))
                        cbIsSmallImg.Checked = bool.Parse(settings["IsSmallImg"]);
                    if (settings.ContainsKey("IsRandAll"))
                        cbIsRandAll.Checked = bool.Parse(settings["IsRandAll"]);

                    if (settings.ContainsKey("CacheType"))
                        drpCacheType.SelectedValue = settings["CacheType"];

                }
                
           

            }


        }
       
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            //string sType = cblClass.SelectedValue;

            settings["txtCount"] = txtCount.Text;
            settings["txtTem"] = drpTem.CtrlValue;
            settings["IsSmallImg"] = cbIsSmallImg.Checked.ToString();
            settings["IsRandAll"] = cbIsRandAll.Checked.ToString();
            settings["CacheType"] = drpCacheType.SelectedValue;
             

            SaveSettings(settings);
        }

    }
}