using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.ContentSet;

namespace EbSite.BLL
{
    public class ThemesMobile : ThemesBase
    {
        override protected ThemeType eThemeType
        {
            get { return ThemeType.MOBILE; }
        }
        override public string ThemesVpath
        {
            get
            {
                return string.Concat(IISPath, "themesm");
            }
        }
        public override string FilePathName
        {
            get
            {
                return "/themesm/";
            }
        }
       
     
        override protected void UpdateConfigs(string ThemePath)
        {
            //ConfigsControl.Instance.MobileStyle = ThemePath;
            //ConfigsControl.SaveConfig();
            CurrentSite.MobileTheme = ThemePath;
            EbSite.BLL.Sites.Instance.Update(CurrentSite);

        }
        /// <summary>
        /// 重写数据的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/Themes/Mobile/"));
            }
        }
    }
}
