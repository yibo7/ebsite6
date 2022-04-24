//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Web;
//using EbSite.Configs.SysConfigs;

//namespace EbSite.Core.RewriteTem
//{
//    public class RewriteTemFactory
//    {

//        private static object _SyncRoot = new object();
//        public static IRewriteTem Instance;
//        //静态工厂方法
//        public static IRewriteTem GetInstance(HttpContext http)
//        {
//            if (Instance == null)
//            {
//                lock (_SyncRoot)
//                {
//                    if (Instance == null)
//                    {
//                        LinkType lt = Configs.SysConfigs.ConfigsControl.Instance.Linktype;
//                       if (LinkType.AspxHtml == lt)
//                        {
//                            Instance = new AutoHtmTemPath();
//                        }
//                        else if (LinkType.AspxRewrite == lt)
//                        {
//                            Instance = new ReWriteTemPath();
//                        }
                        
//                    }
//                }

//            }

//            return Instance;
//        }
//    }
//}
