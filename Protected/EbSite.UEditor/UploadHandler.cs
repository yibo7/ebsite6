using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using EbSite.Core.FSO;
using EbSite.Core.Strings;
using System.Drawing;
namespace EbSite.UEditor
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : Handler
    {

        public UploadConfig UploadConfig { get; private set; }
        public UploadResult Result { get; private set; }

        public UploadHandler(HttpContext context, UploadConfig config)
            : base(context)
        {
            this.UploadConfig = config;
            this.Result = new UploadResult() { State = UploadState.Unknown };
        }
        static private string[] aImsgType = { ".jpg", ".bmp", ".jpeg", ".png" }; //gif不能加水印
        public override void Process()
        {
            if (EbSite.Base.Host.Instance.UserID < 1)
            {
                Result.State = UploadState.NoLogin;
                Result.ErrorMessage = "当前用户没有上传权限！";
                WriteResult(string.Concat(UploadConfig.UrlPrefix, ""));
                return;
            }

            byte[] uploadFileBytes = null;
            string uploadFileName = null;

            if (UploadConfig.Base64) //只有涂鸦的情况才使用到，如果是截图直接用下面的方式
            {
                uploadFileName = UploadConfig.Base64Filename;
                uploadFileBytes = Convert.FromBase64String(Request[UploadConfig.UploadFieldName]);
            }
            else
            {
                var file = Request.Files[UploadConfig.UploadFieldName];
                uploadFileName = file.FileName;

                if (!CheckFileType(uploadFileName))
                {
                    Result.State = UploadState.TypeNotAllow;
                    WriteResult("");
                    return;
                }
                if (!CheckFileSize(file.ContentLength))
                {
                    Result.State = UploadState.SizeLimitExceed;
                    WriteResult("");
                    return;
                }
                 
                uploadFileBytes = new byte[file.ContentLength];
                try
                {
                    file.InputStream.Read(uploadFileBytes, 0, file.ContentLength);
                }
                catch (Exception)
                {
                    Result.State = UploadState.NetworkError;
                    WriteResult("");
                }
            }

            Result.OriginFileName = uploadFileName;

            //var savePath = PathFormatter.Format(uploadFileName, UploadConfig.PathFormat);
            var savePath = string.Empty; //只是相对目录
             string sSmallImgPath = string.Empty;
            string sMidImgPath = string.Empty;
            string sBigImgPath = string.Empty;
            string Savefolder = Base.AppStartInit.UserUploadPath;
            if (!Savefolder.EndsWith("/"))
            {
                Savefolder = string.Concat(Savefolder, "/");
            }
            Savefolder = string.Concat(Savefolder, "uedt/");
            savePath = string.Concat(Savefolder,GetString.GetNewNameByDate(uploadFileName, out sSmallImgPath, out sMidImgPath, out sBigImgPath));
            var localPath = Server.MapPath(savePath);
            try
            {


                if (!Directory.Exists(Path.GetDirectoryName(localPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                }
                string sFileType = GetString.getFileType(savePath);
                //是否加水印
                if (Base.Configs.PicConfigs.ConfigsControl.Instance.OpenWatermark == 1 &&  Validate.InArray(sFileType.ToLower(), aImsgType)) //如果是加水印图片
                {
                    string sImgMarkFullPath = Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath, Base.Configs.PicConfigs.ConfigsControl.Instance.PicPath));
                    try
                    {


                        if (Core.FSO.FObject.IsExist(sImgMarkFullPath, FsoMethod.File))
                        {

                            MemoryStream ms = new MemoryStream(uploadFileBytes, 0, uploadFileBytes.Length);
                            ms.Write(uploadFileBytes, 0, uploadFileBytes.Length);
                            Image img = Image.FromStream(ms, true);
                            //Image img = Image.FromStream(streamFile);

                            Core.ImagesMake.AddImageSignPic(img, localPath, sImgMarkFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.WatermarkPlace,
                                Base.Configs.PicConfigs.ConfigsControl.Instance.Imgquality,
                                Base.Configs.PicConfigs.ConfigsControl.Instance.Watermarktransparency);
                        }

                    }
                    catch (Exception e)
                    {
                        Log.Factory.GetInstance().ErrorLog(string.Format("来自Ueditor上传图片发生错误:水印不能生成,原因:{0},水印图：{1}，源图:{2}", e.Message, sImgMarkFullPath, localPath));

                    }


                }
                else
                {
                    File.WriteAllBytes(localPath, uploadFileBytes);
                }

                //bool IsSmallImg = Base.Configs.PicConfigs.ConfigsControl.Instance.OpenMiniature;

                //if (IsSmallImg)
                //{
                //    //生成一个小图，以更以后在手机端调用
                //    string[] aImsg = new[] { ".jpg", ".bmp", ".jpeg", ".png", ".gif" };

                //    if (Validate.InArray(sFileType.ToLower(), aImsg))
                //    {
                //        string sFileThumnameFullPath = Server.MapPath(string.Concat(Savefolder,  sSmallImgPath));
                //        string sMidFileThumnameFullPath = Server.MapPath(string.Concat(Savefolder, sMidImgPath));
                //        string sBigFileThumnameFullPath = Server.MapPath(string.Concat(Savefolder,  sBigImgPath));

                //        EbSite.Core.ImagesMake.GenThumbnail(localPath, sFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureHeight);
                //        EbSite.Core.ImagesMake.GenThumbnail(localPath, sMidFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureHeight);
                //        EbSite.Core.ImagesMake.GenThumbnail(localPath, sBigFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureHeight);

                //    }
                //}

                Result.Url = savePath;
                Result.State = UploadState.Success;
            }
            catch (Exception e)
            {
                Result.State = UploadState.FileAccessError;
                Result.ErrorMessage = e.Message;
            }
            finally
            {
                WriteResult(string.Concat(UploadConfig.UrlPrefix, savePath));
            }
        }

        private void WriteResult(string sp)
        {
            this.WriteJson(new
            {
                state = GetStateMessage(Result.State),
                url = Result.Url,
                title = Result.OriginFileName,
                original = Result.OriginFileName,
                error = Result.ErrorMessage,
                savepath= sp
            });
        }

        private string GetStateMessage(UploadState state)
        {
            switch (state)
            {
                case UploadState.Success:
                    return "SUCCESS";
                case UploadState.FileAccessError:
                    return "文件访问出错，请检查写入权限";
                case UploadState.SizeLimitExceed:
                    return "文件大小超出服务器限制";
                case UploadState.TypeNotAllow:
                    return "不允许的文件格式";
                case UploadState.NetworkError:
                    return "网络错误";
                case UploadState.NoLogin:
                    return "用户无权限";
            }
            return "未知错误";
        }

        private bool CheckFileType(string filename)
        {
            var fileExtension = Path.GetExtension(filename).ToLower();
            return UploadConfig.AllowExtensions.Select(x => x.ToLower()).Contains(fileExtension);
        }

        private bool CheckFileSize(int size)
        {
            return size < UploadConfig.SizeLimit;
        }
    }

    public class UploadConfig
    {
        /// <summary>
        /// 文件命名规则
        /// </summary>
        public string PathFormat { get; set; }

        /// <summary>
        /// 上传表单域名称
        /// </summary>
        public string UploadFieldName { get; set; }

        /// <summary>
        /// 上传大小限制
        /// </summary>
        public int SizeLimit { get; set; }

        /// <summary>
        /// 上传允许的文件格式
        /// </summary>
        public string[] AllowExtensions { get; set; }

        /// <summary>
        /// 文件是否以 Base64 的形式上传
        /// </summary>
        public bool Base64 { get; set; }

        /// <summary>
        /// Base64 字符串所表示的文件名
        /// </summary>
        public string Base64Filename { get; set; }
        /// <summary>
        /// 问路径前缀
        /// </summary>
        /// <value>The URL prefix.</value>
        public string UrlPrefix { get; set; }
    }

    public class UploadResult
    {
        public UploadState State { get; set; }
        public string Url { get; set; }
        public string OriginFileName { get; set; }

        public string ErrorMessage { get; set; }
    }

    public enum UploadState
    {
        Success = 0,
        SizeLimitExceed = -1,
        TypeNotAllow = -2,
        FileAccessError = -3,
        NetworkError = -4,
        Unknown = 1,
        NoLogin = -5
    }


}
