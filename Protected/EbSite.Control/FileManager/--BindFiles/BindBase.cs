
//using System.Collections.Generic;
//using System.Web;
//using EbSite.Core.Strings;

//namespace EbSite.Control.FileManager
//{
//    public abstract class BindBase : IBindFiles
//    {

//        private string ImgPath
//        {
//            get
//            {
//                return Base.AppStartInit.IISPath + "images/filelist/";
//            }
//        }
        
//        private System.Web.UI.WebControls.Panel _GalleryPanel;
//        public System.Web.UI.WebControls.Panel GalleryPanel
//        {
//            get
//            {
//                return _GalleryPanel;
//            }
//            set
//            {
//                _GalleryPanel = value;
//            }
            
//        }

//        private string _CurrentFullFolder;

//        public string CurrentFullFolder
//        {
//            get
//            {
//                return _CurrentFullFolder;
//            }
//            set
//            {
//                _CurrentFullFolder = value;
//            }
//        }
        
//        public string[] aImg = { ".jpg", ".jpeg", ".jpe", ".gif", ".bmp", ".png" };
//        public string[] aFlash = { ".swf", ".flv" };
//        public string[] aAspx = { ".aspx", ".ascx" };
//        public string[] aZip = { ".rar", ".zip" };
//        public string[] aVideo = { ".wma", ".mp3", ".rm", ".mp4", ".wmv", ".rmvb" };
//        public string GetFileIco(string sFileUrl)
//        {
//            string sFileFix = GetString.getFileType(sFileUrl);
//            if (Validate.InArray(sFileFix, aImg))
//            {
//                return ImgPath + "img.gif"; //图片图标
//            }
//            else if (Validate.InArray(sFileFix, aFlash))
//            {
//                return ImgPath + "flashico.gif"; //flash图标
//            }
//            else if (Validate.InArray(sFileFix, aAspx))
//            {
//                return  ImgPath + "aspx.gif"; //aspx图标
//            }
//            else if (Validate.InArray(sFileFix, aZip))
//            {
//                return ImgPath + "zip.gif"; //图片图标
//            }
//            else if (Validate.InArray(sFileFix,aVideo))
//            {
//                return ImgPath + "musicico.gif"; //图片图标
//            }
//            else
//            {
//                return ImgPath + "ortherico.gif"; //图片图标
//            }
//        }
//        public virtual void BindFiles(string ImageFile)
//        {
            
//        }
//    }
//}
