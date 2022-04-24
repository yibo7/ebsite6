using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using EbSite.UEditor.MINI;

namespace EbSite.UEditor
{
    /// <summary>
    /// 编辑器所有与后端互动的集中入口,通过config.json下的配置action来标记不同的业务
    /// </summary>
    public class UEditorHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {

            Handler action = null;

            string url_out = EbSite.Core.Utils.GetReferer(context);
            if (!string.IsNullOrEmpty(url_out)) //如果是flash上传，这里是取不取来源，所以这里的验证只对页面上传起作用
            {
                string url_my = Convert.ToString(context.Request.ServerVariables["SERVER_NAME"]);
                int changdu = url_my.Length;
                string dddd = url_out.Substring(7, changdu);//7为 http://
                if (!dddd.EndsWith(url_my)) //
                {
                    EbSite.Base.Host.Instance.InsertLog("有人企图站外上传文件", string.Format("时间:{0},外部来源:{1},我的域名:{2}", DateTime.Now, url_out, url_my));
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

            if (EbSite.Base.Host.Instance.UserID < 1)
            {
                action = new NotSupportedHandler(context);
            }
            else
            {
                string sIISPath = Config.GetIISPath;
                switch (context.Request["action"])
                {
                    case "config":
                        action = new ConfigHandler(context);
                        break;
                    case "uploadimage":
                        action = new UploadHandler(context, new UploadConfig()
                        {
                            AllowExtensions = Config.GetStringList("imageAllowFiles"),
                            PathFormat = Config.GetString("imagePathFormat"),
                            SizeLimit = Config.GetInt("imageMaxSize"),
                            UploadFieldName = Config.GetString("imageFieldName"),
                            UrlPrefix = Config.GetString("imageUrlPrefix").Replace("{IISPath}", sIISPath)

                        });
                        break;
                    case "uploadscrawl":
                        action = new UploadHandler(context, new UploadConfig()
                        {
                            AllowExtensions = new string[] { ".png" },
                            PathFormat = Config.GetString("scrawlPathFormat"),
                            SizeLimit = Config.GetInt("scrawlMaxSize"),
                            UploadFieldName = Config.GetString("scrawlFieldName"),
                            Base64 = true,
                            Base64Filename = "scrawl.png",
                            UrlPrefix = Config.GetString("scrawlUrlPrefix").Replace("{IISPath}", sIISPath)
                        });
                        break;
                    case "uploadvideo":
                        action = new UploadHandler(context, new UploadConfig()
                        {
                            AllowExtensions = Config.GetStringList("videoAllowFiles"),
                            PathFormat = Config.GetString("videoPathFormat"),
                            SizeLimit = Config.GetInt("videoMaxSize"),
                            UploadFieldName = Config.GetString("videoFieldName"),
                            UrlPrefix = Config.GetString("videoUrlPrefix").Replace("{IISPath}", sIISPath)
                        });
                        break;
                    case "uploadfile":
                        action = new UploadHandler(context, new UploadConfig()
                        {
                            AllowExtensions = Config.GetStringList("fileAllowFiles"),
                            PathFormat = Config.GetString("filePathFormat"),
                            SizeLimit = Config.GetInt("fileMaxSize"),
                            UploadFieldName = Config.GetString("fileFieldName"),
                            UrlPrefix = Config.GetString("fileUrlPrefix").Replace("{IISPath}", sIISPath)
                        });
                        break;
                    case "listimage":
                        action = new ListFileManager(context, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles"));
                        break;
                    case "listfile":
                        action = new ListFileManager(context, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles"));
                        break;
                    case "catchimage": //这个是由前端粘贴 html 到编辑器时自动检测内容里的图片并下载到临时图片,应该标记这些文件是否使用
                        action = new CrawlerHandler(context);
                        break;
                    case "minupimg": //min版的文件上传
                        action = new umeditorImageUp(context);
                        break;
                    default:
                        action = new NotSupportedHandler(context);
                        break;

                        
                }
            }
            action.Process();
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