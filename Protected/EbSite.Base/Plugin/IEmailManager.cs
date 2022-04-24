using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin.Base;

namespace EbSite.Base.Plugin
{
    public interface  IEmailManager : IProvider
    {
        
        ///// <summary>
        ///// 与SMTP_Send配合使用，用来添加邮件
        ///// </summary>
        ///// <param name="Path">邮件地址</param>
        //void SMTP_Attachments(string Path);
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="model">邮件实体 用到时请引用 EbOA.Entity</param>
        /// <returns></returns>
       bool SMTP_Send(EmailModel model);
    }
}
