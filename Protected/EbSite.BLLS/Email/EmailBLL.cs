using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web.Security;
using Amib.Threading;
using EbSite.Base.EntityAPI;
using EbSite.Base.Plugin;

namespace EbSite.BLL.Email
{
    public class EmailBLL 
    {

        public static SmartThreadPool EmailSendThreadPool;
        private static int iTime = 60*1000; //秒

        private static EmailModel emModel;

        static EmailBLL()
        {
            int iTimeSpan = Base.Configs.EmailSend.ConfigsControl.Instance.iTimeSpan;
            int iSyn = Base.Configs.EmailSend.ConfigsControl.Instance.SynNum;
            EmailSendThreadPool = new SmartThreadPool(iTimeSpan * iTime, iSyn, 1);

            emModel = new EmailModel();

            emModel.From = Base.Configs.EmailSend.ConfigsControl.Instance.emailfrom;
            emModel.FromPass = Base.Configs.EmailSend.ConfigsControl.Instance.emailuserpwd;
            emModel.IsBodyHtml = true;
            emModel.EnableSsl = true;
            emModel.Port = Base.Configs.EmailSend.ConfigsControl.Instance.Port;
            emModel.Smtp = Base.Configs.EmailSend.ConfigsControl.Instance.smtpserver;
        }
        
        /// <summary>
        /// 向一个Email列表,批量发送邮件
        /// </summary>
        /// <param name="Emails"></param>
        /// <param name="Title"></param>
        /// <param name="Body"></param>
        public static void SendEmailOfEmailList(List<string> Emails,string Title,string Body)
        {
            emModel.Title = Title;
            emModel.Body = Body;
            foreach (string OneEmail in Emails)
            {
                emModel.To = OneEmail;
                
                AddEmailToPool();
            }
        }
        /// <summary>
        /// 发送一份邮件
        /// </summary>
        /// <param name="EmailAdr"></param>
        /// <param name="Title"></param>
        /// <param name="Body"></param>
        public static void SendEmail(string EmailAdr, string Title, string Body)
        {
            emModel.Title = Title;
            emModel.Body = Body;
            emModel.To = EmailAdr;
            AddEmailToPool();
        }

        /// <summary>
        /// 向一个Email列表,批量发送邮件
        /// </summary>
        /// <param name="Users"></param>
        /// <param name="Title"></param>
        /// <param name="Body"></param>
        public static void SendEmailOfUserList(List<string> Users, string Title, string Body)
        {  
             List<string> Emails = new List<string>();
            foreach (string user in Users)
            {
                MembershipUser us=  Membership.GetUser(user);

                Emails.Add(us.Email);
            }
            if (Emails.Count>0)SendEmailOfEmailList(Emails, Title, Body);
        }
        /// <summary>
        /// 从用户组，获取当下所有用户邮件，批量发送
        /// </summary>
        /// <param name="GroupNames"></param>
        /// <param name="Title"></param>
        /// <param name="Body"></param>
        public static void SendEmailOfGroupsList(List<string> GroupNames, string Title, string Body)
        {
            List<string> Emails = new List<string>();

            foreach (string GroupName in GroupNames)
            {
               string[] UsersOfGroup =  Roles.GetUsersInRole(GroupName);

                foreach (string UserName in UsersOfGroup)
                {
                    MembershipUser us =  Membership.GetUser(UserName);
                    Emails.Add(us.Email);
                }
            }

            if (Emails.Count > 0) SendEmailOfEmailList(Emails, Title, Body);

            
        }
        /// <summary>
        /// 添加一个发送到线程池
        /// </summary>
        private static void AddEmailToPool()
        {
            IWorkItemResult result = EmailSendThreadPool.QueueWorkItem(new WorkItemCallback(SendEmail), emModel);
        }
        private static object SendEmail(object model)
        {
            EmailModel md = (EmailModel)model;
            if (!Equals(md, null))
            {
                 Factory.SendEmail(md, "");
                return true;
            }
            else
            {
                return false;
            }

        }

        #region //获取最大线程数  GetMaxThreadCount()
        public static int GetMaxThreadCount()
        {
            return EmailSendThreadPool.MaxThreads;
        }
        #endregion

        #region  //获取等待的任务数量
        public static int GetWaitingCallbacks()
        {
            return EmailSendThreadPool.WaitingCallbacks;
        }
        #endregion

        #region // 获取最小线程数  GetMinThreadCount()
        public static int GetMinThreadCount()
        {
            return EmailSendThreadPool.MinThreads;
        }
        #endregion

        #region //活动线程数 GetActiveThreadCount()
        public static int GetActiveThreadCount()
        {
            return EmailSendThreadPool.ActiveThreads;
        }
        #endregion

        #region //用户线程数 GetInUseThreadCount()
        public static int GetInUseThreadCount()
        {
            return EmailSendThreadPool.InUseThreads;
        }
        #endregion 


    }
}
