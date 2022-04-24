using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web;
using EbSite.BLL.HttpHandlers;
using EbSite.Control;
using EbSite.Core.FSO;
using EbSite.Core.Strings;


namespace EbSite.Core
{
    public class HtmlDown
    {
        public HtmlDown()
        {
            
        }
        //private bool _IsMarkImg = false;
        ///// <summary>
        ///// 是否下载站外图片加水印
        ///// </summary>
       
        //public bool IsMarkImg
        //{
        //    get
        //    {
        //        return _IsMarkImg;
        //    }
        //    set
        //    {
        //        _IsMarkImg = value;
        //    }
        //}
        
        //private string _MarkImgPath;
        ///// <summary>
        ///// 水印图片相对路径
        ///// </summary>
       
        //public string MarkImgPath
        //{
        //    get
        //    {
        //        return _MarkImgPath;
        //    }
        //    set
        //    {
        //        _MarkImgPath = value;
        //    }
        //}
        private string _NoDownDomains = "localhost,127.0.0.1";
        /// <summary>
        /// 下载站外图片时，屏蔽的无效域名
        /// </summary>
        
        public string NoDownDomains
        {
            get
            {
                return _NoDownDomains;
            }
            set
            {
                _NoDownDomains = value;
            }
        }

        private string _SaveFilePath = "/upload/";
        /// <summary>
        /// 下载站外图片时，图片的保存路径 如 /upload/
        /// </summary>
      
        public string SaveFilePath
        {
            get
            {
                return _SaveFilePath;
            }
            set
            {
                _SaveFilePath = value;
            }
        }
       /// <summary>
       /// 下载html里的图片
       /// </summary>
       /// <param name="HTML"></param>
       /// <param name="CompleteInfo"></param>
       /// <returns></returns>
        public string DownloadImages(string HTML,ref string CompleteInfo)
        {
            string articleContent = HTML;

            
                ArrayList array = Strings.GetString.GetImgFileUrl(articleContent);

                int success = 0;
                //HProgressBar.Start();
                //HProgressBar.Roll("正在下载站外图片", 0);
                for (int i = 0; i < array.Count; i++)
                {
                    Uri u = new Uri(array[i].ToString());
                    string url = u.Host;

                    if (!Strings.Validate.InArray(url, NoDownDomains, ','))
                    {
                     

                    string sOutFileUrl = array[i].ToString();
                    //Base.Configs.PicConfigs.ConfigsControl.Instance.OpenMiniature
                    string localUrl = DownRemoteImgBase64.SaveRemoteImg(sOutFileUrl, SaveFilePath, false, HttpContext.Current);
                    articleContent = articleContent.Replace(sOutFileUrl, localUrl);

                        //if (IsOK)
                          success++;
                        
                       
                    }
                } 
                if (success > 0)
                {

                    CompleteInfo = "下载完成 " + success + " 张图片!";

                }
                else
                {
                    CompleteInfo = "错误：0 张图片被下载!";

                }
            

            return articleContent;

        }
       



    }
}
