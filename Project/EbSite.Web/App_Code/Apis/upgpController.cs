using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using Amib.Threading;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Core.FSO;
using EbSite.Core.Strings;
using EbSite.Mvc.Controllers;
using EbSite.Mvc.Filters;

namespace EbSite
{
    /*
编写api要注意：就算方法名一名，但参数变量的命名也不能一样，否则出错
如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
   */
    //[RoutePrefix("content")]
    public class upgpController : ApiBaseController
    {
        [HttpGet]
        public int CheckMd5(string md5)
        {
            return 1;
        }

        public string Post()
        {
            string sSavefolderAndName = string.Empty;
            string fileName = string.Empty;
            string strTipsMsg = string.Empty;
            bool isOk = false;
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                HttpPostedFile fileUplFile = HttpContext.Current.Request.Files.Get("file");
                if (!Equals(fileUplFile, null))
                {
                    fileName = fileUplFile.FileName;
                    string sFileType = GetString.getFileType(fileName).ToLower();
                    string[] allowType = {".gp3", ".gp4", ".gp5", ".gpx"};
                    if (EbSite.Core.Strings.Validate.InArray(sFileType.ToLower(), allowType))
                    {
                        int iUpFileSize = 1024;//KB
                        long lengSize = fileUplFile.ContentLength;
                        if (lengSize > (iUpFileSize*1024)) //大小验证
                        {
                            strTipsMsg = "文件大小不能超过" + iUpFileSize + "KB";

                        }
                        else
                        {
                            string sBigImgPath = GetString.GetNewNameByDate(fileName);
                            sSavefolderAndName = string.Concat("/tabfile/", sBigImgPath);
                            string strSaveFullPath = HttpContext.Current.Server.MapPath(sSavefolderAndName);
                            try
                            {
                                FObject.ExistsDirectory(strSaveFullPath);
                                fileUplFile.SaveAs(strSaveFullPath);
                                strTipsMsg = "上传成功";
                                isOk = true;
                                UpdateToUserModel model = new UpdateToUserModel(sSavefolderAndName, strSaveFullPath, Host.Instance.UserID, Host.Instance.UserName, Host.Instance.UserNiName);
                                IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(UpdateToUser), model);
                            }
                            catch (Exception e)
                            {
                                strTipsMsg = e.Message;
                            }
                        }
                        

                    }
                    else
                    {
                        strTipsMsg = "文件格式不正确";
                    }
                 

                }
              
            }
           
             string srz = string.Format("'url':'{0}','localname':'{1}','isok':{2},'msg':'{3}'", sSavefolderAndName, jsonString(fileName), isOk?"true":"false", strTipsMsg);
            srz = string.Concat("{", srz, "}");

            return srz;
        }
        private string jsonString(string str)
        {
            str = str.Replace(@"\", @"\\");
            str = str.Replace("/", @"\/");
            str = str.Replace("'", @"\'");
            return str;
        }

        private object UpdateToUser(object model)
        {
            UpdateToUserModel mdUserInfo = model as UpdateToUserModel;

            if (!Equals(mdUserInfo, null))
            {

            }
            else
            {
                Log.Factory.GetInstance().ErrorLog("上传文件转换UpdateToUserModel对象出错！");
            }
            return 1;
        }


    }

    public class UpdateToUserModel
    {
        public UpdateToUserModel(string sUrl,string sSavePath,int iUserId,string sUserName,string sUserNiName)
        {
            this.Url = sUrl;
            this.SavePath = sSavePath;
            this.UserId = iUserId;
            this.UserName = sUserName;
            this.UserNiName = sUserNiName;
        }
        public string Url { get; set; }
        public string SavePath { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserNiName { get; set; }

    }
}
