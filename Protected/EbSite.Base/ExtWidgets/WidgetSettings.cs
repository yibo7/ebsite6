using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Core.DataStore;

namespace EbSite.Base.ExtWidgets
{
    public class WidgetSettings : SettingsBase
    {
        public WidgetSettings(string setId,int SiteID)
        {
            SettingID = setId;
            ExType = ExtensionType.Widget;//默认使用，也可以在外面另外设置

            //这里保存在xml文件里,如果要保存在数据库，要重写一个数据库处理的StringDictionaryBehavior
            SettingsBehavior = new StringDictionaryBehavior(SiteID);
        }
    }
}
