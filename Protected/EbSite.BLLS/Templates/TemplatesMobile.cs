using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Web;
using EbSite.BLL.Tem;
using EbSite.Base;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;
using System.Linq;
namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑类Templates 的摘要说明。
    /// </summary>
    public class TemplatesMobile : TemplatesBase
    {
        override public ThemeType eThemeType
        {
            get { return ThemeType.MOBILE; }
        }
      
        override protected  string MasterCacheKeyArray
        {
            get
            {
                return  "BllTemplatesMobile" ;
            }
        }

        public TemplatesMobile(string ThemeName)
            : base(ThemeName)
        {
           

        }
        
    }
}

