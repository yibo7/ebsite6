using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using EbSite.Core.Strings;

namespace EbSite.UEditor
{

    /// <summary>
    /// Crawler 的摘要说明
    /// </summary>
    public class CrawlerHandler : Handler
    {
        private string[] Sources;
        private Crawler[] Crawlers;
        public CrawlerHandler(HttpContext context) : base(context) { }

        public override void Process()
        {
            Sources = Request.Form.GetValues("source[]");
            if (Sources == null || Sources.Length == 0|| EbSite.Base.Host.Instance.UserID < 1)
            {
                WriteJson(new
                {
                    state = "参数错误：没有指定抓取源,或无权限"
                });
                return;
            }

            

            Crawlers = Sources.Select(x => new Crawler(x, Server).Fetch()).ToArray();
            WriteJson(new
            {
                state = "SUCCESS",
                list = Crawlers.Select(x => new
                {
                    state = x.State,
                    source = x.SourceUrl,
                    url = x.ServerUrl
                })
            });
        }
    }

    public class Crawler
    {
        public string SourceUrl { get; set; }
        public string ServerUrl { get; set; }
        public string State { get; set; }

        private HttpServerUtility Server { get; set; }


        public Crawler(string sourceUrl, HttpServerUtility server)
        {
            this.SourceUrl = sourceUrl;
            this.Server = server;
        }

        public Crawler Fetch()
        {
            if (!IsExternalIPAddress(this.SourceUrl))
            {
                State = "INVALID_URL";
                return this;
            }
            var request = HttpWebRequest.Create(this.SourceUrl) as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    State = "Url returns " + response.StatusCode + ", " + response.StatusDescription;
                    return this;
                }
                if (response.ContentType.IndexOf("image") == -1)
                {
                    State = "Url is not an image";
                    return this;
                }

                var savePath = string.Empty;
                string sSmallImgPath = string.Empty;
                string sMidImgPath = string.Empty;
                string sBigImgPath = string.Empty;
                string Savefolder = Base.AppStartInit.UserUploadPath;
                if (!Savefolder.EndsWith("/"))
                {
                    Savefolder = string.Concat(Savefolder, "/");
                }
                Savefolder = string.Concat(Savefolder, "uedtps/");
                savePath = string.Concat(Savefolder, GetString.GetNewNameByDate(this.SourceUrl, out sSmallImgPath, out sMidImgPath, out sBigImgPath));
                var localPath = Server.MapPath(savePath); //绝对目录

                ServerUrl = savePath;//保存后的相对路径

                //ServerUrl = PathFormatter.Format(Path.GetFileName(this.SourceUrl), Config.GetString("catcherPathFormat"));
                //var savePath = Server.MapPath(ServerUrl);
                if (!Directory.Exists(Path.GetDirectoryName(localPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                }
                try
                {
                    var stream = response.GetResponseStream();
                    var reader = new BinaryReader(stream);
                    byte[] bytes;
                    using (var ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[4096];
                        int count;
                        while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            ms.Write(buffer, 0, count);
                        }
                        bytes = ms.ToArray();
                    }
                    File.WriteAllBytes(localPath, bytes);
                    State = "SUCCESS";


                }
                catch (Exception e)
                {
                    State = "抓取错误：" + e.Message;
                }

                //bool IsSmallImg = Base.Configs.PicConfigs.ConfigsControl.Instance.OpenMiniature;
                //string sFileType = GetString.getFileType(savePath);
                //if (IsSmallImg)
                //{
                //    //生成一个小图，以更以后在手机端调用
                //    string[] aImsg = new[] { ".jpg", ".bmp", ".jpeg", ".png", ".gif" };

                //    if (Validate.InArray(sFileType.ToLower(), aImsg))
                //    {
                //        string sFileThumnameFullPath = Server.MapPath(string.Concat(Savefolder, sSmallImgPath));
                //        string sMidFileThumnameFullPath = Server.MapPath(string.Concat(Savefolder, sMidImgPath));
                //        string sBigFileThumnameFullPath = Server.MapPath(string.Concat(Savefolder, sBigImgPath));

                //        EbSite.Core.ImagesMake.GenThumbnail(localPath, sFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MiniatureHeight);
                //        EbSite.Core.ImagesMake.GenThumbnail(localPath, sMidFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MidiatureHeight);
                //        EbSite.Core.ImagesMake.GenThumbnail(localPath, sBigFileThumnameFullPath, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureWidth, Base.Configs.PicConfigs.ConfigsControl.Instance.MaxiatureHeight);

                //    }
                //}

                return this;
            }
        }

        private bool IsExternalIPAddress(string url)
        {
            var uri = new Uri(url);
            switch (uri.HostNameType)
            {
                case UriHostNameType.Dns:
                    var ipHostEntry = Dns.GetHostEntry(uri.DnsSafeHost);
                    foreach (IPAddress ipAddress in ipHostEntry.AddressList)
                    {
                        byte[] ipBytes = ipAddress.GetAddressBytes();
                        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (!IsPrivateIP(ipAddress))
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case UriHostNameType.IPv4:
                    return !IsPrivateIP(IPAddress.Parse(uri.DnsSafeHost));
            }
            return false;
        }

        private bool IsPrivateIP(IPAddress myIPAddress)
        {
            if (IPAddress.IsLoopback(myIPAddress)) return true;
            if (myIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                byte[] ipBytes = myIPAddress.GetAddressBytes();
                // 10.0.0.0/24 
                if (ipBytes[0] == 10)
                {
                    return true;
                }
                // 172.16.0.0/16
                else if (ipBytes[0] == 172 && ipBytes[1] == 16)
                {
                    return true;
                }
                // 192.168.0.0/16
                else if (ipBytes[0] == 192 && ipBytes[1] == 168)
                {
                    return true;
                }
                // 169.254.0.0/16
                else if (ipBytes[0] == 169 && ipBytes[1] == 254)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
