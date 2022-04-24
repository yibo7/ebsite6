using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.EmailSend
{
    public class ConfigsInfo : IConfigInfo
    {
        private string _emailfrom;
        private string _smtpserver;
        private string _emailuserName;
        private string _emailuserpwd;
        private string _emaildll;
        private int _iTimeSpan;
        private int _SynNum;
        private int _Port;
        /// <summary>
        /// 端口
        /// </summary>
        public int Port
        {
            set
            {
                _Port = value;
            }
            get
            {
                return _Port;
            }
        }
        private bool enableSsl;
        public bool EnableSsl
        {
            get
            {
                return enableSsl;
            }
            set
            {
                enableSsl = value;
            }
        }
        /// <summary>
        /// 群发邮件，同时发送邮件数，也就是同一时间发送多少份邮件
        /// </summary>
        public int SynNum
        {
            get
            {
                return _SynNum;
            }
            set
            {
                _SynNum = value;
            }
        }
        /// <summary>
        /// 群发件时，发送的时间间隔
        /// </summary>
        public int iTimeSpan
        {
            get
            {
                return _iTimeSpan;
            }
            set
            {
                _iTimeSpan = value;
            }
        }

        public string emaildll
        {
            get
            {
                return _emaildll;
            }
            set
            {
                _emaildll = value;
            }
        }
        /// <summary>
        /// 设置发送邮件使用的邮筒名称
        /// </summary>
        public string emailfrom
        {
            get
            {
                return _emailfrom;
            }
            set
            {
                _emailfrom = value;
            }
        }
        /// <summary>
        /// 设置smtp服务器名称
        /// </summary>
        public string smtpserver
        {
            get
            {
                return _smtpserver;
            }
            set
            {
                _smtpserver = value;
            }
        }
        /// <summary>
        /// 设置邮箱用户名称
        /// </summary>
        public string emailuserName
        {
            get
            {
                return _emailuserName;
            }
            set
            {
                _emailuserName = value;
            }
        }
        /// <summary>
        /// 设置邮箱登录密码
        /// </summary>
        public string emailuserpwd
        {
            get
            {
                return _emailuserpwd;
            }
            set
            {
                _emailuserpwd = value;
            }
        }
    }
}
