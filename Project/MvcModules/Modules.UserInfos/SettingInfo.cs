using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modules.Framework;

namespace Modules.UserInfos
{
    [Module("客户信息", Version = "1.0.0", Author = "北京北迈科技发展有限公司", AuthorUrl = "www.beimai.com", IndexUrl = "/userinfo/")]
    public class SettingInfo : Modules.Framework.SettingBase
    {
        public SettingInfo()
        {
            MainWebUrl = iniParser.GetSetting("App", "MainWebUrl");
        }
        public void Save()
        {
            iniParser.AddSetting("App", "MainWebUrl", MainWebUrl);
        }
        public string MainWebUrl { get; set; }
    }
}