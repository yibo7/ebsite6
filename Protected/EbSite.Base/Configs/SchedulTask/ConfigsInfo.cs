

using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.SchedulTask
{
    /// <summary>
    /// 生成静态页面 配置文件实体类
    /// </summary>
    public class ConfigsInfo : IConfigInfo
    {
        //private int _Index_TimerLength = 5;
        ///// <summary>
        ///// 是否打开定时更新
        ///// </summary>
        //public bool IsOpenIndexTimerUpdate { get; set; }
        ///// <summary>
        ///// 设置时间长度
        ///// </summary>
        //public int Index_TimerLength
        //{
        //    get
        //    {
        //        return _Index_TimerLength;
        //    }
        //    set
        //    {
        //        _Index_TimerLength = value;
        //    }
        //}
        /// <summary>
        /// 是否开启首页缓存
        /// </summary>
        public bool IsOpenIndexCache { get; set; }



        
    }
}
