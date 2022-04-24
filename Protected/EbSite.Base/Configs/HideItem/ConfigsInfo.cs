

using System;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.HideItem
{
    public class ConfigsInfo : IConfigInfo
    {

        public bool Seo { get; set; }

        public bool Seo_Title { get; set; }

        public bool Seo_KW { get; set; }

        public bool Seo_Dis { get; set; }

        public bool PageNum { get; set; }
        public bool ClassHtmlRule { get; set; }
        public bool ContentHtmlRule { get; set; }
        public bool Mt { get; set; }
        public bool Mt_CM { get; set; }
        public bool Mt_CT { get; set; }
        public bool Mt_CTTT { get; set; }
        public bool Mt_CTTM { get; set; }
        public bool Mt_CMST { get; set; }
        public bool Sel { get; set; }
        public bool Sel_AddClass { get; set; }
        public bool Sel_AddContent { get; set; }
        public bool Sel_Hits { get; set; }
        public bool Sel_DayHits { get; set; }
        public bool Sel_WeekHits { get; set; }
        public bool Sel_MonthHits { get; set; }
        public bool Sel_OutLink { get; set; }
        public bool Sel_CModule { get; set; }
        public bool Sub { get; set; }
        
        
    }
}
