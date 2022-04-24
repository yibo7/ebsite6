using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.SessionState;
using EbSite.Core.Strings;

namespace EbSite.Control.FileManager
{
    /// <summary>
    /// 专门为editebox开发的远程图片获取
    /// </summary>
    public class UploadImgByUrls : IHttpHandler, IRequiresSessionState
    {
        private string upExt = ",jpg,jpeg,gif,png,";  //上传扩展名
        //private string attachDir = "/upload";        //上传文件保存路径，结尾不要带/
        private int dirType = 1;                    // 1:按天存入目录 2:按月存入目录 3:按扩展名存目录  建议使用按天存
        private int maxAttachSize = 5097152;        // 最大上传大小，默认是5M
        //private bool IsDataOK(string savepth, int filesize, int UserOnlineID, HttpContext context)
        //{
        //    string valstr = context.Request["valstr"];
        //    if (!string.IsNullOrEmpty(valstr))
        //    {
        //        string sv = Base.Host.Instance.EncodeByMD5(string.Concat(savepth, filesize, UserOnlineID));
        //        return (sv.Equals(valstr));

        //    }
        //    return false;
        //}
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (EbSite.Base.Host.Instance.UserID > 0)
            {
                string url_out = Convert.ToString(context.Request.ServerVariables["HTTP_REFERER"]);

                if (!string.IsNullOrEmpty(url_out)) //如果是flash上传，这里是取不取来源，所以这里的验证只对页面上传起作用
                {
                    string url_my = Convert.ToString(context.Request.ServerVariables["SERVER_NAME"]);
                    int changdu = url_my.Length;
                    string dddd = url_out.Substring(7, changdu);//7为 http://
                    if (!dddd.EndsWith(url_my)) //
                    {
                        EbSite.Base.Host.Instance.InsertLog("有人企图站外上传文件", string.Format("时间:{0},来源:{1}", DateTime.Now, url_out));
                        context.Response.Write("提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误：001");
                        context.Response.End();
                        return;
                    }
                }
                else
                {
                    EbSite.Base.Host.Instance.InsertLog("有人企图站外上传文件", string.Format("时间:{0},来源:为null,可能被黑客想伪造", DateTime.Now));
                    context.Response.Write("提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误：002");
                    context.Response.End();
                    return;
                }



                string sUserID = context.Request["userid"];

                bool IsSmallImg = Base.Configs.PicConfigs.ConfigsControl.Instance.OpenMiniature;//!string.IsNullOrEmpty(context.Request["issmallimg"]);

                string strSavefolder = context.Request["folder"];
                if (!string.IsNullOrEmpty(strSavefolder))
                {
                    strSavefolder = Base.Host.Instance.DecodeByKey(strSavefolder);

                    if (strSavefolder.EndsWith("/"))
                    {
                        strSavefolder = strSavefolder.Substring(0, strSavefolder.LastIndexOf("/"));
                    }

                    if (strSavefolder.StartsWith("/"))
                        strSavefolder = string.Concat(Base.AppStartInit.UserUploadPath, strSavefolder);
                    else
                    {
                        strSavefolder = string.Concat(Base.AppStartInit.UserUploadPath, "/", strSavefolder);
                    }
                }
                else
                {
                    context.Response.Write("提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误：003");
                    context.Response.End();
                    return;
                }

            

                int UserID = 0;
                int UserOnlineID = 0;
                if (!string.IsNullOrEmpty(sUserID))
                {
                    string[] aUserIDKey = Base.Host.Instance.DecodeByKey(sUserID).Split(',');
                    if (aUserIDKey.Length == 2)
                    {
                        UserID = Core.Utils.StrToInt(aUserIDKey[0], 0);
                        UserOnlineID = Core.Utils.StrToInt(aUserIDKey[1], 0);
                        if (UserID < 1 || UserOnlineID < 1)
                        {
                            context.Response.Write("提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误：004");
                            context.Response.End();
                            return;
                        }



                    }
                    else
                    {
                        context.Response.Write("提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误：005");
                        context.Response.End();
                        return;
                    }

                }
                else
                {
                    context.Response.Write("提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误：006");
                    context.Response.End();
                    return;
                }
                if (UserID != EbSite.Base.Host.Instance.UserID)
                {
                    context.Response.Write("提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误：007");
                    context.Response.End();
                    return;
                }

                //attachDir = strSavefolder;//string.Concat(Base.AppStartInit.UserUploadPath, "/editebox");
                string[] arrUrl = context.Request["urls"].Split('|');
                for (int i = 0; i < arrUrl.Length; i++)
                {
                    string localUrl = saveRemoteImg(arrUrl[i], strSavefolder, IsSmallImg, context);
                    if (localUrl != "")
                        arrUrl[i] = localUrl;//有效图片替换
                }

                context.Response.Write(String.Join("|", arrUrl));
            }
            else
            {
                context.Response.Write("");
            }

        }

        string saveRemoteImg(string sUrl, string Savefolder, bool IsSmallImg, HttpContext _context)
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
            sFile = string.Concat(Savefolder,  GetString.GetNewNameByDate(string.Concat("dddd.", sExt), out sSmallImgPath, out sMidImgPath, out sBigImgPath));
            else
            {
                sFile = string.Concat(Savefolder, "/", GetString.GetNewNameByDate(string.Concat("dddd.", sExt), out sSmallImgPath, out sMidImgPath, out sBigImgPath));
            }

            string strSaveFullPath = _context.Server.MapPath(sFile);

            Core.FSO.FObject.ExistsDirectory(strSaveFullPath);

            File.WriteAllBytes(strSaveFullPath, fileContent);

            if (IsSmallImg)
            {
                //生成一个小图，以更以后在手机端调用
                string[] aImsgType = new[] { ".jpg", ".bmp", ".jpeg", ".png", ".gif" };
                string sFileType = GetString.getFileType(sFile);
                if (Validate.InArray(sFileType.ToLower(), aImsgType))
                {
                    string sFileThumnameFullPath = _context.Server.MapPath(string.Concat(Savefolder, "/", sSmallImgPath));
                    string sMidFileThumnameFullPath = _context.Server.MapPath(string.Concat(Savefolder, "/", sMidImgPath));
                    string sBigFileThumnameFullPath = _context.Server.MapPath(string.Concat(Savefolder, "/", sBigImgPath));

                    EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureHeight);
                    EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sMidFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureHeight);
                    EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sBigFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureHeight);

                }
            }
            
            return sFile;
        }
         

        byte[] getUrl(string sUrl)
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
