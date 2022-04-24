using System;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.CustumData
{
    public class ConfigsInfo : IConfigInfo
    {

        private DateTime _WeekHitsLastTime;
        private DateTime _DayHitsLastTime;
        private DateTime _MonthHitsLastTime;
        

        /// <summary>
        /// 获取月点击最后点击时间
        /// </summary>
        public DateTime MonthHitsLastTime
        {
            get
            {
                return _MonthHitsLastTime;
            }
            set
            {
                _MonthHitsLastTime = value;
            }
        }
        /// <summary>
        /// 获取周点击最后点击时间
        /// </summary>
        public DateTime WeekHitsLastTime
        {
            get
            {
                return _WeekHitsLastTime;
            }
            set
            {
                _WeekHitsLastTime = value;
            }
        }
        /// <summary>
        /// 获取天点击最后点击时间
        /// </summary>
        public DateTime DayHitsLastTime
        {
            get
            {
                return _DayHitsLastTime;
            }
            set
            {
                _DayHitsLastTime = value;
            }
        }

        
        
}

}
