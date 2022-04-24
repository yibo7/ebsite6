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
    public class TemplatesPC : TemplatesBase
    {
        override public ThemeType eThemeType
        {
            get { return ThemeType.PC; }
        }
 
        override protected  string MasterCacheKeyArray
        {
            get
            {
                return "BllTemplatesPC" ;
            }
        }

        public TemplatesPC(string ThemeName)
            : base(ThemeName)
        {
           

        }
        
    }
}

