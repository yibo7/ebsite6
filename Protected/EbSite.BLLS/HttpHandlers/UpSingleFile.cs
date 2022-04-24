using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using EbSite.Base.Modules.Configs;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.BLL.HttpHandlers
{

    public class UpSingleFile : IHttpHandler, IRequiresSessionState
    {
        private string jsonString(string str)
        {
            str = str.Replace(@"\", @"\\");
            str = str.Replace("/", @"\/");
            str = str.Replace("'", @"\'");
            return str;
        }

        private bool IsDataOK(string savepth, int filesize, int UserID,int UserOnlineID, string ext,HttpContext context)
        {
            string valstr = context.Request["valstr"];
            if (!string.IsNullOrEmpty(valstr))
            {
               
                string sv = Base.Host.Instance.EncodeByMD5(string.Concat(savepth, filesize, Base.Host.Instance.EncodeByKey(ext), UserOnlineID, UserID));

                
                return (sv.Equals(valstr));

            }
            return false;
        }
        private string[] aImsgType = { ".jpg", ".bmp", ".jpeg", ".png", ".gif" }; //gif不能加水印
        private string[] NoAllowExt = {".aspx",".ashx",".asp",".php",".jsp",".do"};//绝对不允许上传的后缀

        public void ProcessRequest(HttpContext context)
        {             

            if (!Utils.IsPost())
                    return;
            string sUserID = context.Request["userid"];//这里是加密后的字体
            string strSavefolder = context.Request["folder"];

           

            string strSavefolderTem = ""; 
            if (!string.IsNullOrEmpty(strSavefolder))
            {
                
                strSavefolderTem = Base.Host.Instance.DecodeByKey(strSavefolder);
                 if(string.IsNullOrEmpty(strSavefolderTem))
                    strSavefolderTem = Base.Host.Instance.DecodeByKey(context.Server.UrlDecode(strSavefolder));
                string folderTem = "";
                if (strSavefolderTem.EndsWith("/"))
                {
                    folderTem = strSavefolderTem; 
                }
                else
                {
                    folderTem = string.Concat(strSavefolderTem,"/");
                }

                if (folderTem.StartsWith("/"))
                    strSavefolder = string.Concat(Base.AppStartInit.UserUploadPath, folderTem);
                else
                {
                    strSavefolder = string.Concat(Base.AppStartInit.UserUploadPath, "/", folderTem);
                }
            }
            else
            {
                context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0001','msg':'没有正确的路径！错误代码:0001'}");
                context.Response.End();
                return;
            }
            int UserID = 0;
            int UserOnlineID =0;
            if (!string.IsNullOrEmpty(sUserID))
            {
                string sUserIDs = Base.Host.Instance.DecodeByKey(sUserID);//context.Server.UrlDecode(sUserID
                if(string.IsNullOrEmpty(sUserIDs))
                    sUserIDs = Base.Host.Instance.DecodeByKey(context.Server.UrlDecode(sUserID));
                string[] aUserIDKey = sUserIDs.Split(',');
                if (aUserIDKey.Length == 2)
                {
                    UserID = Core.Utils.StrToInt(aUserIDKey[0],0); 
                    UserOnlineID = Core.Utils.StrToInt(aUserIDKey[1],0);
                    if (UserID < 1 ) //if (UserID < 1 || UserOnlineID<1)
                    {
                        Log.Factory.GetInstance().ErrorLog(string.Format("UpSingleFile上传图片不成功:用户ID或在线ID小于1，可以参考,加密串：{0},解密串:{1},密钥:{2}", sUserID, sUserIDs, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey));
                        context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0002','msg':'没有上传的权限，可能没有登录！错误代码:0002'}");
                        context.Response.End();
                        return;
                    }

                    
                    
                }
                else
                {
                    Log.Factory.GetInstance().ErrorLog(string.Format("UpSingleFile上传图片不成功:解密用户ID出错，Split后长度不等2,加密串：{0},解密串:{1},密钥:{2}", sUserID, sUserIDs, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey));
                    context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0003','msg':'提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误代码:0003'}");
                    context.Response.End();
                    return;
                }
               
            }
            else
            {
                context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0004','msg':'提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误代码:0004'}");
                context.Response.End();
                return;
            }

            int iUpFileSize = 100;
            

            string extDefault = ""; 

            if (!string.IsNullOrEmpty(context.Request["sz"]))
            {
                iUpFileSize = int.Parse(context.Request["sz"]);
            }

            if (!string.IsNullOrEmpty(context.Request["ext"]))
            {
                extDefault = context.Request["ext"];
            }

            if (!string.IsNullOrEmpty(extDefault))
            {
                if (!IsDataOK(strSavefolderTem, iUpFileSize, UserID, UserOnlineID, extDefault, context)) //只有知道网站密钥才能取到UserOnlineID,然后去验证md5的数据完整性
                {

                    EbSite.Base.Host.Instance.InsertLog("有人企图站外上传文件", string.Format("时间:{0},提供的数据校验不一至！用户ID:{1},在线ID:{2}", DateTime.Now,UserID, UserOnlineID));
                    context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0005','msg':'提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误代码:0005'}");
                    context.Response.End();
                    return;
                }
            }
            else
            {

                context.Response.Write("{'err':'您没有上传文件的权限,没有设置文件类型,错误代码:0006','msg':'没有设置文件类型！错误代码:0006'}");
                context.Response.End();
                return;
            }

            

            string strIsFalshUpload = context.Request["tp"];//如果为null,即表示当前上传是flash
                                                            //bool IsSmallImg = !string.IsNullOrEmpty(context.Request["issmallimg"]);

            //if (Base.Configs.PicConfigs.ConfigsControl.Instance.OpenMiniature)
            //    IsSmallImg = true;

            bool IsSmallImg = false;//不再使用自动生成缩略图，如有需要请安装缩略图缓存组件

            UploadFileInfo model = new UploadFileInfo();

            byte[] buffer;
            if (!string.IsNullOrEmpty(strIsFalshUpload)) //asp.net默认组件上传
            {

                #region 跨域验证处理

                if (EbSite.Base.Host.Instance.UserID < 1 || UserID != EbSite.Base.Host.Instance.UserID)
                {
                    EbSite.Base.Host.Instance.InsertLog("有人企图站外上传文件", string.Format("时间:{0},提供的数据校验不一至！", DateTime.Now));
                    context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0007','msg':'提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误代码:0007'}");
                    context.Response.End();
                    return;
                }

                string url_out = Convert.ToString(context.Request.ServerVariables["HTTP_REFERER"]);

                if (!string.IsNullOrEmpty(url_out)) //如果是flash上传，这里是取不取来源，所以这里的验证只对页面上传起作用
                {
                    string url_my = Convert.ToString(context.Request.ServerVariables["SERVER_NAME"]);
                    int changdu = url_my.Length;
                    string dddd = url_out.Substring(7, changdu);//7为 http://
                    if (!dddd.EndsWith(url_my)) //
                    {
                        EbSite.Base.Host.Instance.InsertLog("有人企图站外上传文件", string.Format("时间:{0},来源:{1}", DateTime.Now, url_out));
                        context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0008','msg':'提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！,错误代码:0008'}");
                        context.Response.End();
                        return;
                    }
                }
                else
                {
                    EbSite.Base.Host.Instance.InsertLog("有人企图站外上传文件", string.Format("时间:{0},来源:为null,可能被黑客想伪造", DateTime.Now));
                    context.Response.Write("{'err':'您没有上传文件的权限,错误代码:0009','msg':'提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误代码:0009'}");
                    context.Response.End();
                    return;
                }

                #endregion

                string IsQuickUp = context.Request.QueryString["im"]; //告诉编辑器是否上传完成后快速载入到编辑框 
                string input = context.Request.ServerVariables["HTTP_CONTENT_DISPOSITION"];
                string fileName = "";
                if (input != null) //在editbox上传的使用这个
                {
                    buffer = context.Request.BinaryRead(context.Request.TotalBytes);
                    fileName = Regex.Match(input, "filename=\"(.+?)\"").Groups[1].Value;
                }
                else
                {
                    string IBaiduUploader = context.Request.QueryString["bdup"];
                    
                    HttpPostedFile fileUplFile ;

                    if (!string.IsNullOrEmpty(IBaiduUploader))
                    {
                        fileUplFile = context.Request.Files.Get("file");
                    }
                    else
                    {
                        fileUplFile = context.Request.Files.Get("filedata");
                        //if (Equals(fileUplFile, null))
                        //    fileUplFile = context.Request.Files[0];
                    }

                    fileName = fileUplFile.FileName;
                    buffer = new byte[fileUplFile.ContentLength];
                    Stream inputStream = fileUplFile.InputStream;
                    inputStream.Read(buffer, 0, fileUplFile.ContentLength);
                    inputStream.Close();
                }
                string[] aFileType = extDefault.Split(',');
                string sFileType = GetString.getFileType(fileName,false);
                if (!Validate.InArray(sFileType.ToLower(), aFileType))
                {
                    EbSite.Base.Host.Instance.InsertLog("有人企图上传感非法文件", string.Format("时间:{0},来源:为null,可能被黑客想伪造", DateTime.Now));
                    context.Response.Write("{'err':'有人企图上传感非法文件,错误代码:0010','msg':'提高自身职业道德，做文明的中国人，请不要做不要做伤害他人之事！错误代码:0009'}");
                    context.Response.End();
                    return;
                }
                string strErr = "";
                string sData = "''";
                string strBackMsg = "";
                if (UploadFile(iUpFileSize, strSavefolder, fileName, buffer, context, ref model,
                    out strBackMsg))
                {

                    #region 是否快速载入到editbox
                    string url;
                    if (IsQuickUp == "1")
                    {
                        url = string.Concat("!", model.FileNewName);
                    }
                    else
                    {
                        url = model.FileNewName;
                    }
                    #endregion
                    
                    sData = string.Concat(new object[] { "{'url':'", url, "','localname':'", this.jsonString(model.FileOldName), "','id':'", model.id, "'}" });
                }
                else
                {
                    strErr = strBackMsg;
                }

                context.Response.Write("{'err':'" + this.jsonString(strErr) + "','msg':" + sData + "}");
            }
            else   //flash
            {

                HttpPostedFile fileUplFile = context.Request.Files["Filedata"];
                string fileName = context.Server.UrlDecode(fileUplFile.FileName);
                buffer = new byte[fileUplFile.ContentLength];
                Stream inputStream = fileUplFile.InputStream;
                inputStream.Read(buffer, 0, fileUplFile.ContentLength);
                inputStream.Close();

                string BackMsg = "";
                if (UploadFile(iUpFileSize, strSavefolder, fileName,   buffer, context, ref model,
                    out BackMsg))
                {
                    fileName = context.Server.UrlPathEncode(fileName);
                    context.Response.Write(string.Concat("{oldname:\"", fileName, "\",savepath:\"", model.FileNewName, "\",id:\"", model.id, "\"}"));
                }
                else
                {

                    context.Response.Write("{'err':'" + this.jsonString(context.Server.UrlPathEncode(BackMsg))+"'}");
                }

            }
            
        }
        
        private bool UploadFile(int iUpFileSize, string sSavefolder, string fileName,   byte[] buffer, HttpContext context, ref UploadFileInfo model, out string strTipsMsg)
        {
            string sFileType = GetString.getFileType(fileName);

            if (Validate.InArray(sFileType.ToLower(), NoAllowExt))
            {
                strTipsMsg = "上传的文件不安全，系统屏蔽此类文件上传!";
                return false;
            }

            if (buffer.Length > (iUpFileSize*1024)) //大小验证
            {
                strTipsMsg = "文件大小超过" + iUpFileSize + "KB";
                return false;
            }



            try
            {
                bool islocal = Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenFileServer;
                if (!islocal) //考虑到某些情况下需要将文件上传到本地，使用此参数
                {
                    #region 本地上传
                    //原图保存路径

                    string strSaveFullPath;

                    //string sSmallImgPath = string.Empty; //小图文件名称
                    //string sMiddleImgPath = string.Empty;//中图文件名称
                    //string sBigImaPath = string.Empty;//大图文件名称

                    string sNewFileName = IsImg(sFileType)?GetImgNameByDate(fileName): GetString.GetNewNameByDate(fileName);// GetString.GetNewNameByDate(fileName, out sSmallImgPath, out sMiddleImgPath, out sBigImaPath);



                    string sSavefolderAndName = string.Concat(sSavefolder, sNewFileName);
                    strSaveFullPath = context.Server.MapPath(sSavefolderAndName);

                    FObject.ExistsDirectory(strSaveFullPath);

                    //FileStream streamFile = new FileStream(strSaveFullPath, FileMode.Create, FileAccess.Write);
                       
                    if (Base.Configs.PicConfigs.ConfigsControl.Instance.OpenWatermark == 1 && IsImg(sFileType) && sFileType.ToLower() != ".gif") //gif图片不能水印  如果是加水印图片 Validate.InArray(sFileType.ToLower(), aImsgType)
                    { 

                            #region 水印图片处理

                            string sImgMarkFullPath = context.Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath, Base.Configs.PicConfigs.ConfigsControl.Instance.PicPath));
                            try
                            {


                                if (Core.FSO.FObject.IsExist(sImgMarkFullPath, FsoMethod.File))
                                {

                                    MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length);
                                    ms.Write(buffer, 0, buffer.Length);
                                    Image img = Image.FromStream(ms, true);
                                    //Image img = Image.FromStream(streamFile);

                                    Core.ImagesMake.AddImageSignPic(img, strSaveFullPath,
                                        sImgMarkFullPath,
                                        Base.Configs.PicConfigs.ConfigsControl.Instance.WatermarkPlace,
                                        Base.Configs.PicConfigs.ConfigsControl.Instance.Imgquality,
                                        Base.Configs.PicConfigs.ConfigsControl.Instance.Watermarktransparency);
                                }
                                //else
                                //{
                                //    streamFile.Write(buffer, 0, buffer.Length);
                                //    streamFile.Flush();
                                //    streamFile.Close();
                                //}
                            }
                            catch (Exception e)
                            {
                                Log.Factory.GetInstance().ErrorLog(string.Format("来自UpSingleFile上传图片发生错误:水印不能生成,原因:{0},水印图：{1}，源图:{2}", e.Message, sImgMarkFullPath, strSaveFullPath));
                                //streamFile.Write(buffer, 0, buffer.Length);
                                //streamFile.Flush();
                                //streamFile.Close();

                            }
                            #endregion
                        
                    }
                    else
                    {
                        FileStream streamFile = new FileStream(strSaveFullPath, FileMode.Create, FileAccess.Write);
                        streamFile.Write(buffer, 0, buffer.Length);
                        streamFile.Flush();
                        streamFile.Close();
                    }

                   

                    #region 是否生成缩略图
                    //if (IsSmallImg)
                    //{
                    //    string[] IsSmallImgType = new[] { ".jpg", ".bmp", ".jpeg", ".png", ".gif" };
                    //    if (Validate.InArray(sFileType.ToLower(), IsSmallImgType))
                    //    {
                    //        //缩略图保存路径(小)
                    //        string sFileThumnamePath = "";
                    //        string sFileThumnameFullPath = "";
                    //        //缩略图保存路径(中)
                    //        string sMidFileThumnamePath = "";
                    //        string sMidFileThumnameFullPath = "";
                    //        //缩略图保存路径(大)
                    //        string sBigFileThumnamePath = "";
                    //        string sBigFileThumnameFullPath = "";

                    //        sFileThumnamePath = string.Concat(sSavefolder, sSmallImgPath);
                    //        sMidFileThumnamePath = string.Concat(sSavefolder, sMiddleImgPath);
                    //        sBigFileThumnamePath = string.Concat(sSavefolder, sBigImaPath);


                    //        sFileThumnameFullPath = context.Server.MapPath(sFileThumnamePath);
                    //        sMidFileThumnameFullPath = context.Server.MapPath(sMidFileThumnamePath);
                    //        sBigFileThumnameFullPath = context.Server.MapPath(sBigFileThumnamePath);

                    //        EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureHeight);
                    //        EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sMidFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureHeight);
                    //        EbSite.Core.ImagesMake.GenThumbnail(strSaveFullPath, sBigFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureHeight);

                    //    }
                    //}
                    #endregion


                    model.FileNewName = sSavefolderAndName;
                    model.FileOldName = fileName;
                    strTipsMsg = "上传成功！";

                    #region 添加到数据库保存文件上传日志
                    if (!(string.IsNullOrEmpty(model.FileNewName) || string.IsNullOrEmpty(model.FileOldName)))
                    {
                        model.AddDate = DateTime.Now;
                        BLL.UploadFileInfoBLL.Instance.Add(model);
                    }
                    #endregion


                    return true;
                    #endregion

                }
                else
                {
                    string result;
                    if (Post(buffer, out result, sSavefolder, fileName))
                    {
                        model.FileNewName = result;
                        model.FileOldName = fileName;
                        strTipsMsg = "上传成功！";
                        return true;
                    }
                    else
                    {
                        strTipsMsg = "上传失败！" + result;
                        return false;
                    }
                }

                    

            }
            catch (Exception exception)
            {
                strTipsMsg = exception.Message;
                return false;
            }
            
        } 
        /// <summary>
        /// 判断文件名是不是图片
        /// </summary>
        /// <param name="sFileType"></param>
        /// <returns></returns>
        private bool IsImg(string sFileType)
        {
            return Validate.InArray(sFileType.ToLower(), aImsgType);
        }
        /// <summary>
        /// 新获取一个图片文件的名称
        /// </summary>
        /// <param name="OldFileName"></param>
        /// <returns></returns>
        public  string GetImgNameByDate(string OldFileName)
        {
            string str = GetString.getFileType(OldFileName);
            string randomFileName = string.Concat(DateTime.Now.ToString("yyyyMMdd"), "/", Path.GetRandomFileName().Replace(".", ""));//某些情况下带点路径不兼用

            return string.Concat(randomFileName, "-ebbaseimg", str);
        }
        private bool Post(byte[] postData, out string result,  string sfolder,string oldfilename)
        {
            //(HttpWebRequest)WebRequest.Create("http://localhost:52273/fsapi/");
            var request = (HttpWebRequest)WebRequest.Create(Base.Configs.SysConfigs.ConfigsControl.Instance.FileServerUrl);

            request.Method = "POST"; 
            request.Headers.Add("bfs-oldfilename", oldfilename);//主要为了实现让文件服务器端获取后缀
            request.Headers.Add("bfs-key", Base.Host.Instance.EncodeByMD5(Base.Host.Instance.EncodeByKey(Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey)));
            if(!string.IsNullOrEmpty(sfolder))
                request.Headers.Add("bfs-sfolder", EbSite.Base.Host.Instance.EncodeByKey(sfolder));
            //request.Headers.Add("bfs-simg", simg); 


            if (postData != null)
            {
                request.ContentLength = postData.Length;
                request.KeepAlive = true;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(postData, 0, postData.Length);
                dataStream.Close();
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var status = response.Headers["bfs-status"];
                result = response.Headers["bfs-result"];
                return response.StatusCode == HttpStatusCode.OK && status == "100";
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return false;

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        ///// <summary>
        ///// 生成缩略图函数
        ///// </summary>
        ///// <param name="width">原始图片的宽度</param>
        ///// <param name="height">原始图片的高度</param>
        ///// <param name="left">水印字符的生成位置</param>
        ///// <param name="right">水印字符的生成位置</param>
        ///// <param name="picpath">原图的所在路径</param>
        ///// <param name="picthumpath">生成缩略图的所在路径</param>
        //public void GetThumbnailImage(int width, int height, int left, int right, string picpath, string picthumpath, string MarkText)
        //{
        //    string newfile = picthumpath;
        //    System.Drawing.Image oldimage = System.Drawing.Image.FromFile(picpath);
        //    System.Drawing.Image thumbnailImage =
        //        oldimage.GetThumbnailImage(width, height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        //    //Response.Clear();
        //    Bitmap output = new Bitmap(thumbnailImage);
        //    Graphics g = Graphics.FromImage(output);

        //    if (string.IsNullOrEmpty(MarkText))
        //        g.DrawString(null, new Font("Courier New", 14), new SolidBrush(Color.White), left, right);
        //    else
        //        g.DrawString(MarkText, new Font("Courier New", 14), new SolidBrush(Color.Blue), left, right);//写入文字到图片中

        //    output.Save(picthumpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    output.Dispose();
        //    //Response.ContentType = "image/gif";
        //}
        //public bool ThumbnailCallback()
        //{
        //    return true;
        //}
    }
}
