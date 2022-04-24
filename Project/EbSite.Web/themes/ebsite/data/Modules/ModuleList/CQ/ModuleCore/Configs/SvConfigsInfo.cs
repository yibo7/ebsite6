using System;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Core;

namespace EbSite.Modules.CQ.ModuleCore.Configs
{
    public class SvConfigsInfo : IConfigInfo
    {
        public string Title { get; set; }
        public string Demo { get; set; }
        public int DemoModel { get; set; }
        public int IsShowClose { get; set; }
        public int ChatModel { get; set; }
        public int FloatListModel { get; set; }
        public int FloatPlaceModel { get; set; }
        public bool IsSaveOrder { get; set; }
        public bool IsFull { get; set; }
        public int Top { get; set; }
        public int IsShowMore { get; set; }
        public string FloatServiceLink { get; set; }
        public int FloatServiceMaxNum { get; set; }
        public bool IsServicerOutLink { get; set; }
        public string WelcomeInfo { get; set; }
        public int TimeSpan { get; set; }
        public int TimeSpanToAuto { get; set; }
        public int TimeSpanToAutoModel { get; set; }
        public int MaxReceive { get; set; }
        /// <summary>
        /// 是否开户主动邀请
        /// </summary>
        public bool IsOpenInvite { get; set; }
        /// <summary>
        /// 主动邀请延迟
        /// </summary>
        public int InviteTimeSpan { get; set; }
        /// <summary>
        /// 主动邀请语
        /// </summary>
        public string InviteInfo { get; set; }
        /// <summary>
        /// 主动邀请模式
        /// </summary>
        public int InviteModel { get; set; }

        /// <summary>
        /// 是否开启评价
        /// </summary>
        public bool IsOpenAppraise { get; set; }


    }
}
