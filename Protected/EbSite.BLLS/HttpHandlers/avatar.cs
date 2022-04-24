using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using EbSite.Core;
using System.Drawing;
using System.Drawing.Imaging;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class avatar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string sUserID = string.Empty;
            string UrlReferrer = Utils.GetUrlReferrer();//如果UrlReferrer为空，表示用户选择图片提交，如果UrlReferrer不为空，表示用户调用摄像头提交
            //如果是Flash提交
            if (string.IsNullOrEmpty(UrlReferrer))
            {
                string[] input = DecodeUid(Utils.GetString("input")).Split(','); //下标0为Uid，1为Olid
                int UserID = Utils.StrToInt(input[0], 0);

                EbSite.Base.EntityAPI.ShortUserInfo userInfo = EbSite.BLL.User.MembershipUserEb.Instance.GetShortUserInfo(UserID);

                if (userInfo == null ||
                    Utils.GetString("appid") !=
                    Utils.MD5(userInfo.UserName + userInfo.Password + userInfo.UserID + input[1]))
                {
                    EbSite.Base.Host.Instance.InsertLog("上传头像时数据校验不一至", "上传头像时数据校验不一至");
                    return;
                }

            }
            else if (Utils.IsCrossSitePost(UrlReferrer, Utils.GetHost()))
            {
                EbSite.Base.Host.Instance.InsertLog("上传头像时跨站提交", "上传头像时跨站提交");
                return;
            }


            ////如果是Flash提交
            //if (!string.IsNullOrEmpty(Utils.GetUrlReferrer()))
            //{
            //    sUserID = DecodeUid(Utils.GetString("input"));

            //    if (!string.IsNullOrEmpty(sUserID))
            //    {
            //        if (!Equals(sUserID, EbSite.Base.AppStartInit.UserID.ToString()))
            //        {
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else if (Utils.IsCrossSitePost(Utils.GetUrlReferrer(), Utils.GetHost())) //如果是跨站提交...
            //{
            //    EbSite.Base.Host.Instance.InsertLog("上传头像时跨站提交", "上传头像时跨站提交");
            //    return;

            //}


            sUserID = DecodeUid(Utils.GetString("input")).Split(',')[0];

            

            if (!string.IsNullOrEmpty(sUserID))
            {
                string rzTem = "isok:{0},msg:'{1}'";
                if (Utils.GetString("x") != "" && Utils.GetString("y") != "" && Utils.GetString("w") != "" && Utils.GetString("h") != "")
                {
                   
                    string sTemPath = Utils.GetMapPath(EbSite.Base.AppStartInit.UserUploadPath + "\\temp\\avatar_" + sUserID + ".jpg");
                    if (Core.FSO.FObject.IsExist(sTemPath, Core.FSO.FsoMethod.File))
                    {
                        string sIcoPath = BLL.User.MembershipUserEb.Instance.GetAvatarFileName(int.Parse(sUserID), 1);
                        Core.FSO.FObject.ExistsDirectory(sIcoPath);
                        

                        ResponseText("{" + string.Format(rzTem, "true", sIcoPath) + "}");
                        try
                        {
                            Bitmap bmpBase = new Bitmap(sTemPath);
                            int x = Utils.GetFormInt("x", 0);
                            int y = Utils.GetFormInt("y", 0);
                            int w = Utils.GetFormInt("w", 0);
                            int h = Utils.GetFormInt("h", 0);
                            Rectangle rect = new Rectangle(x, y, w, h);
                            Bitmap bmpNew = bmpBase.Clone(rect, bmpBase.PixelFormat);
                            bmpNew.Save(sIcoPath, ImageFormat.Jpeg);

                            bmpBase.Dispose();
                            bmpNew.Dispose();
                            File.Delete(sTemPath);
                        }
                        catch (Exception ex)
                        {
                            ResponseText("{" + string.Format(rzTem, "false", "切图出错:" + ex.Message) + "}");
                        }

                    }
                    else
                    {
                        ResponseText("{" + string.Format(rzTem, "false", "找不到临时图片") + "}"); 
                    }
                    
                    return;
                }
                else
                {
                    string filename = "avatar_" + sUserID + ".jpg";
                    string UploadFileUrl = string.Concat(EbSite.Base.AppStartInit.DomainName, "/", Base.Configs.SysConfigs.ConfigsControl.Instance.UploadPath, "/");
                    string UploadFileDir = Utils.GetMapPath(EbSite.Base.AppStartInit.UserUploadPath);
                    if (!Directory.Exists(UploadFileDir + "\\temp\\"))
                        Utils.CreateDir(UploadFileDir + "\\temp\\");

                    UploadFileDir = string.Concat(UploadFileDir, "\\temp\\", filename);
                    HttpContext.Current.Request.Files[0].SaveAs(UploadFileDir);

                    filename = "temp/" + filename;
                    //ResponseText(UploadFileUrl + filename);

                    ResponseText("{" + string.Format(rzTem, "true", UploadFileUrl + filename) + "}"); ;
                    return;
                }

                
            }
            
        }

        #region 头像
        private void ResponseText(string text)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(text);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 解码Uid
        /// </summary>
        /// <param name="encodeUid"></param>
        /// <returns></returns>
        private string DecodeUid(string encodeUid)
        {
            return DES.Decode(encodeUid.Replace(' ', '+'), Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="uid"></param>
        private void CreateDir(string uid)
        {
            //uid = Utils.FormatUid(uid);
            //string avatarDir = string.Format("{0}avatars/UploadFile/{1}/{2}/{3}",
            //    Base.AppStartInit.IISPath, uid.Substring(0, 3), uid.Substring(3, 2), uid.Substring(5, 2));
             
            string avatarPath = BLL.User.MembershipUserEb.Instance.GetAvatarPath(int.Parse(uid));
            if (!Directory.Exists(Utils.GetMapPath(avatarPath)))
                Directory.CreateDirectory(Utils.GetMapPath(avatarPath));
        }

     ///// <summary>
     ///// 
     ///// </summary>
     ///// <param name="tempath"></param>
     ///// <param name="uid"></param>
     ///// <param name="size"></param>
     ///// <returns></returns>
     //   private bool SaveAvatar(string tempath, string uid,int size)
     //   {
     //       //byte[] b = FlashDataDecode(Utils.GetString(avatar));
     //       //if (b.Length == 0)
     //       //    return false;
     //       //uid = Utils.FormatUid(uid);
     //       //int size = 1;
     //       //if (avatar == "avatar1")
     //       //    size = 1;
     //       //else if (avatar == "avatar2")
     //       //    size = 2;
     //       //else
     //       //    size = 3;

     //       string sPath = BLL.User.MembershipUserEb.Instance.GetAvatarFileName(int.Parse(uid), size);

     //       FileStream fs = new FileStream(Utils.GetMapPath(sPath), FileMode.Create);
     //       fs.Write(b, 0, b.Length);
     //       fs.Close();
     //       return true;
     //   }

        /// <summary>
        /// 解码Flash头像传送的数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private byte[] FlashDataDecode(string s)
        {
            byte[] r = new byte[s.Length / 2];
            int l = s.Length;
            for (int i = 0; i < l; i = i + 2)
            {
                int k1 = ((int)s[i]) - 48;
                k1 -= k1 > 9 ? 7 : 0;
                int k2 = ((int)s[i + 1]) - 48;
                k2 -= k2 > 9 ? 7 : 0;
                r[i / 2] = (byte)(k1 << 4 | k2);
            }
            return r;
        }

        ///// <summary>
        ///// 上传临时头像文件
        ///// </summary>
        ///// <returns></returns>
        //private string UploadFileTempAvatar(string uid)
        //{

        //    string filename = "avatar_" + uid + ".jpg";
        //    string UploadFileUrl = string.Concat(EbSite.Base.AppStartInit.DomainName, "/", Base.Configs.SysConfigs.ConfigsControl.Instance.UploadPath, "/");
        //    string UploadFileDir = Utils.GetMapPath(EbSite.Base.AppStartInit.UserUploadPath);
        //    if (!Directory.Exists(UploadFileDir + "\\temp\\"))
        //        Utils.CreateDir(UploadFileDir + "\\temp\\");



        //    UploadFileDir = string.Concat(UploadFileDir, "\\temp\\", filename);
        //    HttpContext.Current.Request.Files[0].SaveAs(UploadFileDir);

        //    filename = "temp/" + filename;
        //    return UploadFileUrl + filename;
        //}
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}
