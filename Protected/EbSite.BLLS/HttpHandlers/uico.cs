using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for uico
    /// </summary>
    public class uico : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //TimeSpan refresh = new TimeSpan(0, 15, 0); 
            //context.Response.Cache.SetExpires(DateTime.Now.Add(refresh)); 
            //context.Response.Cache.SetMaxAge(refresh); 
            //context.Response.Cache.SetCacheability(HttpCacheability.Public); 
            //context.Response.CacheControl = HttpCacheability.Public.ToString(); 
            //context.Response.Cache.SetValidUntilExpires(true); 

            context.Response.ContentType = "image/Jpeg";

            if (!string.IsNullOrEmpty(context.Request.QueryString["uid"]))
            {
                string path;
                string url = EbSite.Base.Host.Instance.EBMembershipInstance.GetAvatarFileName(Core.Utils.StrToInt(context.Request.QueryString["uid"], 0), 1);
                path = context.Server.MapPath(url);
                if (!EbSite.Core.FSO.FObject.IsExist(path, FsoMethod.File))
                {

                    path = Base.AppStartInit.GetRandICO();
                    if (string.IsNullOrEmpty(path))
                    {
                        path = context.Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath, "images/nopic.gif"));
                    }
                }
                //Core.Utils.TestDebug(path);
                //获取图片文件的二进制数据。
                byte[] datas = System.IO.File.ReadAllBytes(path);
                //将二进制数据写入到输出流中。
                context.Response.OutputStream.Write(datas, 0, datas.Length);
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
