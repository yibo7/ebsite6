using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.BLL;
using EbSite.Base;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    abstract public class BaseList : UserControlListBase
    {
        /// <summary>
        /// 来自的皮肤类型,1为pc,2这移动
        /// </summary>
        protected int ThemesType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["tt"]))
                {
                    return int.Parse(Request["tt"]);
                }
                return 1;
            }
        }

        protected string CurrentThemeName
        {
            get { return Request["theme"]; }
        }

        protected TemplatesBase TemBll
        {
            get
            {
                if (eThemeType == ThemeType.PC)
                {
                    return new TemplatesPC(CurrentThemeName);
                }
                else
                {
                    return new TemplatesMobile(CurrentThemeName);
                }
            }
        }
        public ThemeType eThemeType
        {
            get
            {
                return (ThemeType)ThemesType;
                
            }
        }
         public BaseList()
        {
            
        }
        protected string ThemesFolder
        {
            get { return ThemesUtils.GetThemesFolder(eThemeType); }
        }

        protected string GetTabUrl
        {
           get
           {
               return string.Format("Admin_Tem.aspx?tt={0}&theme={1}", ThemesType, CurrentThemeName);
           }
        }

    }
}