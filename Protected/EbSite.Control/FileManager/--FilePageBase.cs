//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Web;
//using System.Web.UI;
////using EbSite.Pages;

//namespace EbSite.Control.FileManager
//{
//    public class FilePageBase : Page
//    {
//        //protected override void AddHeaderPram()
//        //{
//        //    //不需要此办法,所以重写了
//        //}
//        /// <summary>
//        /// 网站的安装目录
//        /// </summary>
//        protected string AppPath
//        {
//            get
//            {
//                return HttpContext.Current.Request.PhysicalApplicationPath;
//            }
//        }
       
//        /// <summary>
//        /// 从配置文件获取默认上传目录
//        /// </summary>
//        protected string DefaultFolder
//        {
//            get
//            {

//                return EbSite.Base.AppStartInit.UserUploadPath;
//            }
//        }
//    }
//}
