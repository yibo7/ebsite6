using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EbSite.Base
{
    public enum ThemeType : int
    {
        /// <summary>
        ///  PC版
        /// </summary>
        PC = 1,
        /// <summary>
        /// 手机版
        /// </summary>
        MOBILE = 2,
        /// <summary>
        /// 后台
        /// </summary>
        ADMIN = 3
    }

    public class ThemesUtils
    {
        public static string GetThemesFolder(ThemeType tt)
        {

            if (tt == ThemeType.PC)
            {
                return "themes";
            }
            else
            {
                return "themesm";
            }
        }
    }
}
