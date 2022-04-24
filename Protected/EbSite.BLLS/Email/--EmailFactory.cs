//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EbSite.BLL.Email
//{
//    public class EmailFactory
//    {
//        private static ISendEmail Instance;
//        //静态工厂方法
//        public static ISendEmail GetInstance()
//         {
//             if (Instance == null)
//             {
//                 if(!string.IsNullOrEmpty(Configs.EmailSend.ConfigsControl.Instance.smtpserver))
//                 {
//                     try
//                     {

//                         Instance = (ISendEmail)Activator.CreateInstance(Type.GetType(Configs.EmailSend.ConfigsControl.Instance.emaildll, false, true));
//                     }
//                     catch
//                     {
//                         throw new Exception("实例化邮件发送组件出错!,请检查邮件配置是否正确");
//                     }
//                 }
//                 else
//                 {
//                     throw new Exception("实例化邮件发送组件出错!,请检查邮件配置是否正确");
//                 }
                 
//                 return Instance;
//             }
//             else
//             {
//                 return Instance;
//             }
//         }
//    }
//}
