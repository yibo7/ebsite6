using System.Text;

namespace EbSite.Core
{
    public class Log4SmtpAppender: log4net.Appender.SmtpAppender
    {
        public bool EnableSsl { get; set; }
        public bool IsBodyHtml { get; set; }
        protected override void SendEmail(string messageBody)
        {
            
            Encoding MailEncoding = System.Text.Encoding.UTF8;
            EMailSender.Send(To, Subject, messageBody, SmtpHost,Username, Password, Port, MailEncoding, IsBodyHtml, EnableSsl);
        }
    }
}