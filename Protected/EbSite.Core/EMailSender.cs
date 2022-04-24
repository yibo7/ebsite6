using System.Net.Mail;
using System.Text;

namespace EbSite.Core
{
    public class EMailSender
    {
        public static bool Send(string sTo,string sTitle,string sBody,string sSmtpServer, string sFrom,string sFromPass,int Port, Encoding MailEncoding , bool IsBodyHtml = true, bool EnableSsl = true,MailPriority Priority = System.Net.Mail.MailPriority.Normal)
        {
            if(Equals(MailEncoding,null))
                MailEncoding = System.Text.Encoding.UTF8;
            // = System.Text.Encoding.UTF8
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            mailMessage.To.Add(new System.Net.Mail.MailAddress(sTo)); //收件人地址
            mailMessage.From = new System.Net.Mail.MailAddress(sFrom); //发件人地址
            mailMessage.Subject = sTitle;
            mailMessage.Body = sBody;
            mailMessage.IsBodyHtml = IsBodyHtml;
            mailMessage.BodyEncoding = MailEncoding;//System.Text.Encoding.UTF8;
            mailMessage.Priority = Priority;//System.Net.Mail.MailPriority.Normal;          
            //smtpClient.EnableSsl = true;
            if (Port > 0)
                smtpClient.Port = Port;
            //smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential
            (mailMessage.From.Address, sFromPass);//设置发件人身份的票据 
            smtpClient.EnableSsl = EnableSsl;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtpClient.Host = sSmtpServer;//"smtp." + mailMessage.From.Host;
            smtpClient.Send(mailMessage);
            return true;
        }
    }
}