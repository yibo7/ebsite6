using System;
using System.Collections.Generic;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    public interface IMobileSend : IProvider
    {
        
        /// <summary>
        /// 发送一条短信
        /// </summary>
        /// <param name="Msg">短信内容</param>
        /// <param name="MobiNumber">手机号码</param>
        /// <param name="UserName">用户账号</param>
        void SendMsg(string Msg, string MobiNumber, string UserName);
       
        /// <summary>
        /// 格式化插件的执行优先级，此处很重要，因如多个格式化插件同时执行时，
        /// 可能会覆盖其他的格式，所以要有个优先级问题
        /// </summary>
        int ExecutionPriority { get; }
    }
}

