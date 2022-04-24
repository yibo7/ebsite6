using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbSite.Base.EntityCustom;

namespace EbSite.Mvc.Models
{
    public class Index : ModelBae
    {
        public Index()
        {
            base.SeoTitle = GetSeoWord(SeoConfigs.SeoSiteIndexTitle, "");
            base.SeoKeyWord = GetSeoWord(SeoConfigs.SeoSiteIndexKeyWord, "");
            base.SeoDes = GetSeoWord(SeoConfigs.SeoSiteIndexDes, "");
        }
       override protected  Guid TemID
        {
            get
            {
                return  CurrentSite.IndexTemID;
            }
        }
    }
}
