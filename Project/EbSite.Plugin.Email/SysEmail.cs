using System;
using System.Net.Mail;
using System.Net.Mime;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;

namespace EbSite.Plugin.Email
{
    [Extension("小菜邮件发送系统", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class SysEmail : IEmailManager
    {


        public bool SMTP_Send(EmailModel model)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            mailMessage.To.Add(new System.Net.Mail.MailAddress(model.To)); //收件人地址
            mailMessage.From = new System.Net.Mail.MailAddress(model.From); //发件人地址
            mailMessage.Subject = model.Title;
            mailMessage.Body = model.Body;
            mailMessage.IsBodyHtml = model.IsBodyHtml;
            mailMessage.BodyEncoding = model.MailEncoding;//System.Text.Encoding.UTF8;
            mailMessage.Priority = model.Priority;//System.Net.Mail.MailPriority.Normal;          
            //smtpClient.EnableSsl = true;
            if (model.Port > 0)
                smtpClient.Port = model.Port;
            //smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential
            (mailMessage.From.Address, model.FromPass);//设置发件人身份的票据 
            smtpClient.EnableSsl = model.EnableSsl;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpClient.Host = model.Smtp;//"smtp." + mailMessage.From.Host;
            smtpClient.Send(mailMessage);
            return true;
        }



        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;



            ExtensionSettings settings = new ExtensionSettings(sSettingsName);


            //settings.AddParameter("Description", "条款", 300, true, true, ParameterType.StringMax);
            //settings.AddParameter("ImgUpload", "图片上传", 300, true, true, ParameterType.Upload);
            //settings.Help = ConfigHelpHtml;
            ////是否单个
            //settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);

        }
        private Host HostApi;
        private ExtensionSettings ConfigString;
        /// <summary>
        /// 初始化插件。这是类调用的第一个方法。
        /// </summary>
        /// <param name="host">提供了访问主系统的api</param>
        /// <param name="config">Configuration string for the plugin.</param>
        public void Init(Host host, ExtensionSettings config)
        {
            this.HostApi = host;
            ConfigString = config;

            ConfigString.GetSingleValue("Description");
        }

        /// <summary>
        /// 注销插件后将调用此办法
        /// </summary>
        public void Shutdown()
        {

        }

        /// <summary>
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
        public string ConfigHelpHtml
        {
            get
            {
                return @"
<div>
  <b>使用帮助:</b><br/>
  <ul>
    <li>在后台安装后，可以在系统的配置里选择。</li>
  </ul>
</div>
      ";
            }
        }

        #endregion
    }
}
