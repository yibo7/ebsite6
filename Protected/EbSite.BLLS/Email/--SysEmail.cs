//using System;
//using System.Collections.Generic;
//using System.Net.Mail;
//using System.Net.Mime;
//using System.Text;

//namespace EbSite.BLL.Email
//{
//    public class SysEmail : ISendEmail
//    {
//        private MailMessage mailMessage = new MailMessage();
//        private SmtpClient smtpClient = new SmtpClient();
//        /// <summary>
//        /// 发送
//        /// </summary>
//        /// <returns></returns>
//         public override bool Send(EmailModel model)
//        {

//            mailMessage.To.Add(model.To); //收件人地址
//            mailMessage.From = new System.Net.Mail.MailAddress(model.From); //发件人地址
//            mailMessage.Subject = model.Title;
//            mailMessage.Body = model.Body;
//            mailMessage.IsBodyHtml = true;
//            mailMessage.BodyEncoding = model.MailEncoding;//System.Text.Encoding.UTF8;
//            mailMessage.Priority = model.Priority;//System.Net.Mail.MailPriority.Normal;

//                smtpClient.Credentials = new System.Net.NetworkCredential
//                (mailMessage.From.Address, model.FromPass);//设置发件人身份的票据 
//                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
//                smtpClient.Host = "smtp." + mailMessage.From.Host;
//                smtpClient.Send(mailMessage);
            
//            return true;
//        }
//         /// <summary> 
//         /// 添加附件 
//         /// </summary> 
//         public override void Attachments(string Path)
//         {
//             string[] path = Path.Split(',');
//             Attachment data;
//             ContentDisposition disposition;
//             for (int i = 0; i < path.Length; i++)
//             {
//                 data = new Attachment(path[i], MediaTypeNames.Application.Octet);//实例化附件 
//                 disposition = data.ContentDisposition;
//                 disposition.CreationDate = System.IO.File.GetCreationTime(path[i]);//获取附件的创建日期 
//                 disposition.ModificationDate = System.IO.File.GetLastWriteTime(path[i]);// 获取附件的修改日期 
//                 disposition.ReadDate = System.IO.File.GetLastAccessTime(path[i]);//获取附件的读取日期 
//                 mailMessage.Attachments.Add(data);//添加到附件中 
//             }
//         }
//         ///// <summary> 
//         ///// 异步发送邮件 
//         ///// </summary> 
//         ///// <param name="CompletedMethod"></param> 
//         //public void SendAsync(SendCompletedEventHandler CompletedMethod)
//         //{
//         //    if (mailMessage != null)
//         //    {
//         //        InitEmail();
//         //        smtpClient = new SmtpClient();
//         //        smtpClient.Credentials = new System.Net.NetworkCredential
//         //        (mailMessage.From.Address, FromPass);//设置发件人身份的票据 
//         //        smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
//         //        smtpClient.Host = "smtp." + mailMessage.From.Host;
//         //        smtpClient.SendCompleted += new SendCompletedEventHandler
//         //        (CompletedMethod);//注册异步发送邮件完成时的事件 
//         //        smtpClient.SendAsync(mailMessage, mailMessage.Body);
//         //    }
//         //} 
//        //private void InitEmail()
//        //{
//        //    mailMessage.To.Add(To); //收件人地址
//        //    mailMessage.From = new System.Net.Mail.MailAddress(From); //发件人地址
//        //    mailMessage.Subject = Title;
//        //    mailMessage.Body = Body;
//        //    mailMessage.IsBodyHtml = true;
//        //    mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
//        //    mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
            
//        //}
//    }
//}
