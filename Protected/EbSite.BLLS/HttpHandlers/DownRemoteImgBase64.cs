using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EbSite.Core.FSO;
using EbSite.Core.Strings;
using System.Drawing;
namespace EbSite.BLL.HttpHandlers
{
    public class DownRemoteImgBase64
    {
        static private string[] aImsgType = { ".jpg", ".bmp", ".jpeg", ".png" }; //gif不能加水印
        public static string SaveRemoteImg(string sUrl, string Savefolder, bool IsSmallImg, HttpContext _context, string upExt = ",jpg,jpeg,gif,png,", int maxAttachSize = 5097152)
        {
            byte[] fileContent;
            string objStream;
            string sExt;
            string sFile;
            if (sUrl.StartsWith("data:image"))
            {
                // base64编码的图片，可能出现在firefox粘贴，或者某些网站上，例如google图片
                int pstart = sUrl.IndexOf('/') + 1;
                sExt = sUrl.Substring(pstart, sUrl.IndexOf(';') - pstart).ToLower();

                if (upExt.IndexOf("," + sExt + ",") == -1) return "";

                fileContent = Convert.FromBase64String(sUrl.Substring(sUrl.IndexOf("base64,") + 7));
            }
            else
            {
                // 图片网址
                sExt = sUrl.Substring(sUrl.LastIndexOf('.') + 1).ToLower();

                if (upExt.IndexOf("," + sExt + ",") == -1) return "";

                fileContent = getUrl(sUrl);
            }

            if (fileContent.Length > maxAttachSize) return "";//超过最大上传大小忽略

            //有效图片保存
            //sFile = getLocalPath(sExt, _context);
            string sSmallImgPath = string.Empty;
            string sMidImgPath = string.Empty;
            string sBigImgPath = string.Empty;
            if (Savefolder.EndsWith("/"))
                sFile = string.Concat(Savefolder, GetString.GetNewNameByDate(string.Concat("dddd.", sExt), out sSmallImgPath, out sMidImgPath, out sBigImgPath));
            else
            {
                sFile = string.Concat(Savefolder, "/", GetString.GetNewNameByDate(string.Concat("dddd.", sExt), out sSmallImgPath, out sMidImgPath, out sBigImgPath));
            }

            string strSaveFullPath = _context.Server.MapPath(sFile);

            Core.FSO.FObject.ExistsDirectory(strSaveFullPath);
            string sFileType = GetString.getFileType(sFile);
            if (Base.Configs.PicConfigs.ConfigsControl.Instance.OpenWatermark == 1 && Validate.InArray(sFileType.ToLower(), aImsgType)) //如果是加水印图片
            {
                string sImgMarkFullPath = _context.Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath, Base.Configs.PicConfigs.ConfigsControl.Instance.PicPath));
                try
                {


                    if (Core.FSO.FObject.IsExist(sImgMarkFullPath, FsoMethod.File))
                    {

                        MemoryStream ms = new MemoryStream(fileContent, 0, fileContent.Length);
                        ms.Write(fileContent, 0, fileContent.Length);
                        Image img = Image.FromStream(ms, true);
                        //Image img = Image.FromStream(streamFile);

                        Core.ImagesMake.AddImageSignPic(img, strSaveFullPath,sImgMarkFullPath,Base.Configs.PicConfigs.ConfigsControl.Instance.WatermarkPlace,
                            Base.Configs.PicConfigs.ConfigsControl.Instance.Imgquality,
                            Base.Configs.PicConfigs.ConfigsControl.Instance.Watermarktransparency);
                    }
                    
                }
                catch (Exception e)
                {
                    Log.Factory.GetInstance().ErrorLog(string.Format("来自DownRemoteImgBase64上传图片发生错误:水印不能生成,原因:{0},水印图：{1}，源图:{2}", e.Message, sImgMarkFullPath, strSaveFullPath));
                    
                }


            }
            else
            {
                File.WriteAllBytes(strSaveFullPath, fileContent);
            }

            

            //if (IsSmallImg)
            //{
            //    //生成一个小图，以更以后在手机端调用
            //    string[] aImsg = new[] { ".jpg", ".bmp", ".jpeg", ".png", ".gif" };
               
            //    if (Validate.InArray(sFileType.ToLower(), aImsg))
            //    {
            //        string sFileThumnameFullPath = _context.Server.MapPath(string.Concat(Savefolder, "/", sSmallImgPath));
            //        string sMidFileThumnameFullPath = _context.Server.MapPath(string.Concat(Savefolder, "/", sMidImgPath));
            //        string sBigFileThumnameFullPath = _context.Server.MapPath(string.Concat(Savefolder, "/", sBigImgPath));

            //        EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureHeight);
            //        EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sMidFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureHeight);
            //        EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sBigFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureHeight);

            //    }
            //}

            return sFile;
        }


        static private byte[] getUrl(string sUrl)
        {
            WebClient wc = new WebClient();
            try
            {
                return wc.DownloadData(sUrl);
            }
            catch
            {
                return null;
            }
        }
    }
}
