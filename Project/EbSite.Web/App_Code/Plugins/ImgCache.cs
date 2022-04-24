using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Amib.Threading;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Core;
using EbSite.Core.FSO;
using System.Linq;
namespace Plugins
{

    /// <summary>
    /// 演示了关于拦截HttpModuleRuning事件的应用
    /// </summary>
    [Extension("动态缓存缩略图", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class ImgCache
    {

        static protected ExtensionSettings _settings = null; 
        static private string[] aItems;
        /// <summary>
        /// Hooks up an event handler to the Post.Serving event.
        /// </summary>
        static ImgCache()
        {
               
             
            //(注意，注意)要与类名相同,否则无法生成相关配置
            string sSettingsName = "ImgCache";
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);
            settings.AddParameter("imgwh", "缩略图规格(一行一个,格式为:宽a高),第一个为移动版默认展出图片", 500, true, false, ParameterType.StringMax);
            settings.IsScalar = true;//单条配置 

            ExtensionManager.Instance.ImportSettings(settings);
            _settings = ExtensionManager.Instance.GetSettings(sSettingsName);

            string sWidthAndHeight = _settings.GetSingleValue("imgwh");
            Regex re = new Regex("\n");
              aItems = re.Split(sWidthAndHeight); 
            //EbSite.Log.Factory.GetInstance().InfoLog(aItems.Length.ToString());

            //组件启动时判断有没有存在缩略图缓存目录，如果没有生成一下，确保父目录是可继承修改权限
            string sPath = HttpContext.Current.Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath, "cacheimg/"));
            if (!FObject.IsExist(sPath, FsoMethod.Folder))
            {
                FObject.Create(sPath, FsoMethod.Folder);
            }

             

            EbSite.Base.EBSiteEvents.HttpModuleRuning += new EventHandler<HttpModuleRuningEventArgs>(On_HttpModuleRuning);

            EbSite.Base.EBSiteEvents.ContentShowEvent += new EventHandler<ContentShowEventArgs>(On_ContentShow);

        }

        static private void On_ContentShow(object sender, ContentShowEventArgs e)
        {
            //在这里处理一下手机版的图片路径，使用更小的缩略图
            if (Equals(e.PageType,ThemeType.MOBILE))
            {
                if (!Equals(aItems, null) && aItems.Length > 0)
                {
                    string sContent = e.ShowInfo;
                    string sSoureTag = "ebbaseimg";
                    //sContent = sContent.Replace(string.Concat(sSoureTag, ".png"), string.Concat(sSoureTag, aItems[0], ".png")); 
                    sContent = Regex.Replace(sContent, string.Concat(sSoureTag, ".png"), string.Concat(sSoureTag, aItems[0], ".png"));
                    sContent = Regex.Replace(sContent, string.Concat(sSoureTag, ".jpg"), string.Concat(sSoureTag, aItems[0], ".jpg"));
                    sContent = Regex.Replace(sContent, string.Concat(sSoureTag, ".jpeg"), string.Concat(sSoureTag, aItems[0], ".jpeg"));
                    sContent = Regex.Replace(sContent, string.Concat(sSoureTag, ".bmp"), string.Concat(sSoureTag, aItems[0], ".bmp"));
                    sContent = Regex.Replace(sContent, string.Concat(sSoureTag, ".gif"), string.Concat(sSoureTag, aItems[0], ".gif"));
                    e.ShowInfo = sContent;

                    //e.ShowInfo = Regex.Replace(sContent,
                    //    @"<img[\s]+src[\s]*=[\s]*((['""""]([^ '""""]*)[\'""""])|([^\s]*))ebbaseimg(.png|.gif|.jpg|.jpeg)",
                    //   string.Concat("<img src=$4ebbaseimg", aItems[0], "$5"));

                     

                }
              
             
            }

        }

        static private void On_HttpModuleRuning(object sender, HttpModuleRuningEventArgs e)
        {
             

            HttpContext httpContext = e.App.Context;
            string requestPath = httpContext.Request.Path.ToLower();
            string sFileType = EbSite.Core.Strings.GetString.getFileType(requestPath);
            string[] pics =new string[] {".png",".jpg", ".jpeg", ".gif" };

            if (EbSite.Core.Strings.Validate.InArray(sFileType.Trim().ToLower(), pics))
            {
                string sPath = httpContext.Server.MapPath(requestPath);
                if (!FObject.IsExist(sPath, FsoMethod.File))
                {
                    string sReg = "(.*ebbaseimg)(([0-9]*)a([0-9]*)).(png|gif|jpg|jpeg)";
                    Regex r = new Regex(sReg);//RegexOptions.IgnoreCase | RegexOptions.Compiled  加了这两个选项导致性能下降
                    Match m = r.Match(requestPath);
                    if (m.Success)
                    {
                        string sRequestWh = m.Result("$2");

                        if (!Equals(aItems, null)&& aItems.Contains(sRequestWh))
                        {
                            int iWidth = Utils.StrToInt(m.Result("$3"));
                            int iHeight = Utils.StrToInt(m.Result("$4"));
                            if (iWidth > 0 && iHeight > 0)
                            {


                                //得到原图相对路径
                                string sSoreUrl = r.Replace(requestPath, "$1.$5");
                                //得到原图绝对路径
                                string sSoreUrlFull = httpContext.Server.MapPath(sSoreUrl);

                                if (FObject.IsExist(sSoreUrlFull, FsoMethod.File))//如果原图存在才处理
                                {
                                    string sSmallUrl = string.Concat(EbSite.Base.Host.Instance.IISPath, "cacheimg/", EbSite.Core.Utils.MD5(requestPath), sFileType);

                                    string sSmallUrlFull = httpContext.Server.MapPath(sSmallUrl);
                                    if (!FObject.IsExist(sSmallUrlFull, FsoMethod.File))
                                    {
                                        #region 将生成缩略图任务添加到队列中

                                        ImgInfo imi = new ImgInfo();
                                        imi.SourePath = sSoreUrlFull;
                                        imi.SmallPath = sSmallUrlFull;
                                        imi.Width = iWidth;
                                        imi.Height = iHeight;
                                        IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(MakeImg), imi);

                                        #endregion

                                        #region  实时输出缩略图

                                        Image input = Image.FromFile(imi.SourePath);
                                        if (input.Width > input.Height)
                                            iHeight = input.Height * iWidth / input.Width;
                                        else
                                            iWidth = input.Width * iHeight / input.Height;

                                        var bmp = new Bitmap(input, iWidth, iHeight);
                                        var ms = new MemoryStream();
                                        bmp.Save(ms, ImageFormat.Png);
                                        ms.Position = 0;
                                        //获取图片文件的二进制数据。
                                        byte[] datas = ms.ToArray();// System.IO.File.ReadAllBytes(path);
                                                                    //将二进制数据写入到输出流中。
                                        httpContext.Response.OutputStream.Write(datas, 0, datas.Length);
                                        httpContext.Response.End();
                                        e.IsStop = true;

                                        #endregion


                                    }
                                    else
                                    {
                                        sSoreUrl = sSmallUrl;
                                        //EbSite.Log.Factory.GetInstance().InfoLog(sSoreUrl);
                                        httpContext.Response.ContentType = "image/JPEG";
                                        httpContext.RewritePath(sSoreUrl);
                                        e.IsStop = true;
                                    }
                                }


                            }
                        }

                        
                    }
                }
                    
            }

        }

        static private object MakeImg(object sender)
        {
            ImgInfo model = sender as ImgInfo;
            if(model!=null)
                EbSite.Core.ImagesMake.GenThumbnail(model.SourePath, model.SmallPath, model.Width, model.Height);

            return 1;

        }


    }

    public class ImgInfo
    {
        
        public int Width { get; set; }
        public int Height { get; set; }
        public string SourePath { get; set; }
        public string SmallPath { get; set; }

    }

}
