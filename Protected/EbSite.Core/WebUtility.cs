using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;
using EbSite.Core.FSO;
using EbSite.Core.Strings;
using ServiceStack.ServiceInterface.ServiceModel;

namespace EbSite.Core
{
    /// <summary>
    /// WebUtility : 基于System.Web的拓展类。
    /// </summary>
    public class WebUtility
    {
        public static Dictionary<string, string> GetBodyKewordDis(string sUrl)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string sHtml = EbSite.Core.WebUtility.GetPageContentAuto(sUrl);

            string sRule = @"<meta\s+name=""description""\s+content=""(.*?)""";

            Match mc = Regex.Match(sHtml, sRule);
            if (mc.Success)
            {
                if (mc.Groups.Count > 1)
                    dic.Add("d", EbSite.Core.WebUtility.ReplaceUrl(mc.Groups[1].Value,""));
            }

            sRule = @"<meta\s+name=""keywords""\s+content=""(.*?)""";
            mc = Regex.Match(sHtml, sRule);
            if (mc.Success)
            {
                if (mc.Groups.Count > 1)
                    dic.Add("k", EbSite.Core.WebUtility.ReplaceUrl(mc.Groups[1].Value, ""));
            }

            sRule = @"\<title[^\>]*\>\s*(?<Title>.*?)\s*\</title\>";
            mc = Regex.Match(sHtml, sRule);
            if (mc.Success)
            {
                if (mc.Groups.Count > 1)
                    dic.Add("t", EbSite.Core.WebUtility.ReplaceUrl(mc.Groups[1].Value, ""));
            }

            string sbody = EbSite.Core.Strings.GetString.CutMiddleStr(sHtml, "<body", "</body>");
            if (!string.IsNullOrEmpty(sbody))
            {
                //GetString.NoHTML()
                sbody = EbSite.Core.Strings.GetString.CleanHtml(sbody);
                //sbody = sbody.Replace("\r", "").Replace("\n", "").Replace(" ", "").Replace("\t", "");
                sbody = EbSite.Core.WebUtility.ReplaceUrl(sbody, "***");
                dic.Add("b", sbody);
            }

            return dic;
        }
        public static string ReplaceUrl(string sText,string sReplaceTag)
        {
           return GetString.RegexReplace(sText, @"(?<url>(http:|https:[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[~])*)", sReplaceTag);
        }

        public static string GetPageContentAuto(string sUrl)
        {
            string htm = string.Empty;
            var data = new System.Net.WebClient { }.DownloadData(sUrl); //根据textBox1的网址下载html
            var r_utf8 = new System.IO.StreamReader(new System.IO.MemoryStream(data), Encoding.UTF8); //将html放到utf8编码的StreamReader内
            var r_gbk = new System.IO.StreamReader(new System.IO.MemoryStream(data), Encoding.Default); //将html放到gbk编码的StreamReader内
            var t_utf8 = r_utf8.ReadToEnd(); //读出html内容
            var t_gbk = r_gbk.ReadToEnd(); //读出html内容
            if (!isLuan(t_utf8)) //判断utf8是否有乱码
            {
                htm = t_utf8;
                
            }
            else
            {
                htm = t_gbk;
                 
            }
            return htm;
        }
        /// <summary>
        /// 判断是否有乱码
        /// </summary>
        /// <param name="txt">The text.</param>
        /// <returns><c>true</c> if the specified text is luan; otherwise, <c>false</c>.</returns>
       private static bool isLuan(string txt)
        {
            var bytes = Encoding.UTF8.GetBytes(txt);
            //239 191 189
            for (var i = 0; i < bytes.Length; i++)
            {
                if (i < bytes.Length - 3)
                    if (bytes[i] == 239 && bytes[i + 1] == 191 && bytes[i + 2] == 189)
                    {
                        return true;
                    }
            }
            return false;
        }

        /// <summary>
        /// 提取网址
        /// </summary>
        /// <param name="sText">The s text.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GetTextUrls(string sText)
        {
            List<string> Urls = new List<string>();
            //string sRule = @"(?i)www\.\w*\.(com.cn|gov.cn|net.cn|org.cn|top|com|net|org|cn|cc|info|me|tv|xyz|ws|tw|tel|mobi|asia|name|hk|eu|us|in|one|online|wiki|love|pw|club|ren|co|so|wang)";

            string sRule = @"(?<url>(http:|https:[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[~])*)";

            MatchCollection mcsCollection = Regex.Matches(sText, sRule);

            foreach (Match mc in mcsCollection)
            {
                if (mc.Groups.Count > 0)
                {
                    string sUrl = mc.Groups[0].Value;
                    if (!string.IsNullOrEmpty(sUrl))
                    {
                        Urls.Add(sUrl.Trim());
                    }

                }
            }

            sRule = @"(?i)[a-z]*[0-9]*\.\w*\.(com.cn|gov.cn|net.cn|org.cn|top|com|net|org|cn|cc|info|me|tv|xyz|ws|tw|tel|mobi|asia|name|hk|eu|us|in|one|online|wiki|love|pw|club|ren|co|so|wang)";

            mcsCollection = Regex.Matches(sText, sRule);

            foreach (Match mc in mcsCollection)
            {
                if (mc.Groups.Count > 0)
                {
                    string sUrl = mc.Groups[0].Value;
                    if (!string.IsNullOrEmpty(sUrl))
                    {
                        if (Urls.Contains(sUrl)||Urls.Contains(string.Concat("http://",sUrl))|| Urls.Contains(string.Concat("https://", sUrl)))
                            continue;
                        Urls.Add(sUrl.Trim());
                    }

                }
            }

            sRule = @"[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?";

            mcsCollection = Regex.Matches(sText, sRule);

            foreach (Match mc in mcsCollection)
            {
                if (mc.Groups.Count > 0)
                {
                    string sUrl = mc.Groups[0].Value;
                    if (!string.IsNullOrEmpty(sUrl))
                    {
                        if (Urls.Contains(sUrl) || Urls.Contains(string.Concat("http://", sUrl)) || Urls.Contains(string.Concat("https://", sUrl)))
                            continue;
                        Urls.Add(sUrl.Trim());
                    }

                }
            }

            List<string> rz = new List<string>();
            List<string> rzSave = new List<string>();
            foreach (var url in Urls)
            {

                if (!url.StartsWith("https://"))
                {
                    if (!url.StartsWith("http://"))
                        rz.Add(string.Concat("http://", url));
                    else
                    {
                        rz.Add(url);
                    }
                }
                else
                {
                    rz.Add(url);
                }

                if(url.EndsWith("/"))
                    rzSave.Add(url);
            }
            foreach (var url in rzSave)
            {
               string newurl = url.Remove(url.Length - 1, 1);
                if (rz.Contains(newurl))
                {
                    rz.Remove(newurl);
                }

            }

            //foreach (var url in rz)
            //{
            //    if (!CheckURLValid(url))
            //        rz.Remove(url);
            //}

            return rz;
        }

        //public static bool CheckURLValid( string surl)
        //{
        //    Uri uriResult;
        //    return Uri.TryCreate(surl, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        //}

        /// <summary>
        /// 检测指定的 Uri 是否有效
        /// </summary>
        /// <param name="url">指定的Url地址</param>
        /// <returns>bool</returns>
        public static bool ValidateUrl(string url)
        {
            

            try
            {
                Uri newUri = new Uri(url);
                WebRequest req = WebRequest.Create(newUri);
                //req.Timeout				= 10000;
                WebResponse res = req.GetResponse();
                HttpWebResponse httpRes = (HttpWebResponse)res;

                if (httpRes.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>  
        /// 获取远程文件的大小
        /// </summary>
        /// <param name="sHttpUrl"></param>
        /// <returns></returns>
        public static long GetFileSize(string sHttpUrl)
        {
            long size = 0;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(sHttpUrl);
            HttpWebResponse myRes = (HttpWebResponse)myReq.GetResponse();
            size = myRes.ContentLength;
            myRes.Close();

            return size;
        }

        #region 文件下载
        // 输出硬盘文件，提供下载 支持大文件、续传、速度限制、资源占用小
        // 输入参数 _fileName: 下载文件名， _fullPath: 带文件名下载路径， _speed 每秒允许下载的字节数
        // 返回是否成功
        /// <summary>
        /// 输出硬盘文件，提供下载 支持大文件、续传、速度限制、资源占用小
        /// </summary>
        /// <param name="_fileName">下载文件名</param>
        /// <param name="_fullPath">带文件名下载路径</param>
        /// <param name="_speed">每秒允许下载的字节数</param>
        /// <returns>返回是否成功</returns>
        public static bool DownloadFile(string _fullPath, string _fileName, long _speed)
        {
            HttpRequest _Request = System.Web.HttpContext.Current.Request;
            HttpResponse _Response = System.Web.HttpContext.Current.Response;

            try
            {
                FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(myFile);
                try
                {
                    _Response.AddHeader("Accept-Ranges", "bytes");
                    _Response.Buffer = false;
                    long fileLength = myFile.Length;
                    long startBytes = 0;

                    int pack = 10240; //10K bytes
                    //int sleep = 200;   //每秒5次   即5*10K bytes每秒
                    decimal dcPack = 1000 * pack / _speed;
                    int sleep = (int)Math.Floor(dcPack) + 1;
                    if (_Request.Headers["Range"] != null)
                    {
                        _Response.StatusCode = 206;
                        string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                        startBytes = Convert.ToInt64(range[1]);
                    }
                    _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                    if (startBytes != 0)
                    {
                        _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                    }
                    _Response.AddHeader("Connection", "Keep-Alive");
                    _Response.ContentType = "application/octet-stream";
                    _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));


                    br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                    decimal dcFileLength = (fileLength - startBytes) / pack;
                    int maxCount = (int)Math.Floor(dcFileLength) + 1;

                    for (int i = 0; i < maxCount; i++)
                    {
                        if (_Response.IsClientConnected)
                        {
                            _Response.BinaryWrite(br.ReadBytes(pack));
                            Thread.Sleep(sleep);
                        }
                        else
                        {
                            i = maxCount;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    br.Close();
                    myFile.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 下载服务器上的文件（适用于非WEB路径下，且是大文件，该方法在IE中不会显示下载进度）
        /// </summary>
        /// <param name="path">下载文件的绝对路径</param>
        /// <param name="saveName">保存的文件名，包括后缀符</param>
        public static void Download(string path, string saveName)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(saveName, System.Text.Encoding.UTF8));
            //Response.TransmitFile(path);
            Response.End();
        }


        /// <summary>
        /// 下载服务器上的文件（适用于非WEB路径下，且是大文件，该方法在IE中会显示下载进度）
        /// </summary>
        /// <param name="path">下载文件的绝对路径</param>
        /// <param name="saveName">保存的文件名，包括后缀符</param>
        public static void DownloadFile(string path, string saveName)
        {
            Stream iStream = null;


            // Buffer to read 10K bytes in chunk:
            byte[] buffer = new Byte[10240];

            // Length of the file:
            int length;

            // Total bytes to read:
            long dataToRead;

            // Identify the file to download including its path.
            string filepath = path;

            // Identify the file name.
            string filename = Path.GetFileName(filepath);

            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Web.HttpContext.Current.Response.Clear();

                // Total bytes to read:
                dataToRead = iStream.Length;

                long p = 0;
                if (System.Web.HttpContext.Current.Request.Headers["Range"] != null)
                {
                    System.Web.HttpContext.Current.Response.StatusCode = 206;
                    p = long.Parse(System.Web.HttpContext.Current.Request.Headers["Range"].Replace("bytes=", "").Replace("-", ""));
                }
                if (p != 0)
                {
                    System.Web.HttpContext.Current.Response.AddHeader("Content-Range", "bytes " + p.ToString() + "-" + ((long)(dataToRead - 1)).ToString() + "/" + dataToRead.ToString());
                }
                System.Web.HttpContext.Current.Response.AddHeader("Content-Length", ((long)(dataToRead - p)).ToString());
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(saveName, System.Text.Encoding.UTF8));

                iStream.Position = p;
                dataToRead = dataToRead - p;
                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (System.Web.HttpContext.Current.Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10240);

                        // Write the data to the current output stream.
                        System.Web.HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data to the HTML output.
                        System.Web.HttpContext.Current.Response.Flush();

                        buffer = new Byte[10240];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                System.Web.HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                }

                System.Web.HttpContext.Current.Response.End();
            }
        }
        #endregion


        #region 获取指定页面的内容
        /// <summary>
        /// 从指定的URL下载页面内容(使用WebRequest)
        /// </summary>
        /// <param name="url">指定URL</param>
        /// <returns></returns>
        public static string LoadURLString(string url)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream stream = myWebResponse.GetResponseStream();

            string strResult = "";
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8"));//gb2312
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            int i = 0;
            while (count > 0)
            {
                i += Encoding.UTF8.GetByteCount(read, 0, 256);
                String str = new String(read, 0, count);
                strResult += str;
                count = sr.Read(read, 0, 256);
            }

            return strResult;
        }
        public static string LoadURLStringUTF8(string url)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream stream = myWebResponse.GetResponseStream();

            string strResult = "";
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8"));
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            int i = 0;
            while (count > 0)
            {
                i += Encoding.UTF8.GetByteCount(read, 0, 256);
                String str = new String(read, 0, count);
                strResult += str;
                count = sr.Read(read, 0, 256);
            }

            return strResult;
        }


        /// <summary>
        /// 从指定的URL下载页面内容(使用WebClient)
        /// </summary>
        /// <param name="url">指定URL</param>
        /// <returns></returns>
        public static string LoadPageContent(string url)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            byte[] pageData = wc.DownloadData(url);
            return (Encoding.GetEncoding("gb2312").GetString(pageData));
        }

        /// <summary>
        /// 从指定的URL下载页面内容(使用WebClient)
        /// </summary>
        /// <param name="url">指定URL</param>
        /// <returns></returns>
        public static string LoadPageContent(string url, string postData)
        {
            WebClient wc = new WebClient();

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");


            byte[] pageData = wc.UploadData(url, "POST", Encoding.Default.GetBytes(postData));


            return (Encoding.GetEncoding("gb2312").GetString(pageData));
        }
        #endregion


        #region 远程服务器下载文件
        /// <summary>
        /// 远程提取文件保存至服务器上(使用WebRequest)
        /// </summary>
        /// <param name="url">一个URI上的文件</param>
        /// <param name="saveurl">文件保存在服务器上的全路径</param>
        public static void RemoteGetFile(string url, string saveurl)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream stream = myWebResponse.GetResponseStream();

            //获得请求的文件大小
            int fileSize = (int)myWebResponse.ContentLength;

            int bufferSize = 102400;
            byte[] buffer = new byte[bufferSize];
            FObject.WriteFile(saveurl, "temp");
            // 建立一个写入文件的流对象
            FileStream saveFile = File.Create(saveurl, bufferSize);
            int bytesRead;
            do
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                saveFile.Write(buffer, 0, bytesRead);
            } while (bytesRead > 0);

            saveFile.Flush();
            saveFile.Close();
            stream.Flush();
            stream.Close();
        }

        /// <summary>
        /// 远程提取一个文件保存至服务器上(使用WebClient)
        /// </summary>
        /// <param name="url">一个URI上的文件</param>
        /// <param name="saveurl">保存文件</param>
        public static void WebClientGetFile(string url, string saveurl)
        {
            WebClient wc = new WebClient();

            try
            {
                FObject.WriteFile(saveurl, "temp");
                wc.DownloadFile(url, saveurl);
            }
            catch
            { }

            wc.Dispose();
        }

        /// <summary>
        /// 远程提取一组文件保存至服务器上(使用WebClient)
        /// </summary>
        /// <param name="urls">一组URI上的文件</param>
        /// <param name="saveurls">保存文件</param>
        public static void WebClientGetFile(string[] urls, string[] saveurls)
        {
            WebClient wc = new WebClient();
            for (int i = 0; i < urls.Length; i++)
            {
                try
                {

                    wc.DownloadFile(urls[i], saveurls[i]);
                }
                catch
                { }
            }
            wc.Dispose();
        }
        #endregion


        #region 文件上传
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="upfile">获取客户段上传的文件</param>
        /// <param name="limitType">允许上传的文件类型，null值为无限制</param>
        /// <param name="limitSize">上传文件的大小限制(0为无限制)</param>
        /// <param name="autoName">是否自动命名</param>
        /// <param name="savepath">上传文件的保存路径</param>
        /// <returns>string[]</returns>
        public static string[] UploadFile(HttpPostedFile upfile, string limitType, int limitSize, bool autoName, string savepath)
        {
            string[] strResult = new string[5];
            string[] extName = null;
            if (!Object.Equals(limitType, null) || Object.Equals(limitType, ""))
            {
                extName = cConvert.SplitArray(limitType, ',');
            }

            int fileSize = upfile.ContentLength;								// 上传文件大小
            string fileClientName = upfile.FileName;							// 在客户端的文件全路径
            string fileFullName = Path.GetFileName(fileClientName);				// 上传文件名（包括后缀符）
            if (fileFullName == null || fileFullName == "")
            {
                strResult[0] = "无文件";
                strResult[1] = "";
                strResult[2] = "";
                strResult[3] = "";
                strResult[4] = "<font color=red>失败</font>";
                return strResult;
            }
            else
            {
                string fileType = upfile.ContentType;								// 上传文件的MIME类型
                string[] array = cConvert.SplitArray(fileFullName, '.');
                string fileExt = array[array.Length - 1];							// 上传文件后缀符
                int fileNameLength = fileFullName.Length - fileExt.Length - 1;
                string fileName = "";												// 上传文件名（不包括后缀符）
                if (autoName)
                {
                    fileName = "_" + GetString.MakeName();
                }
                else
                {
                    fileName = fileFullName.Substring(0, fileNameLength);
                }


                string savename = fileName + "." + fileExt;
                strResult[0] = fileClientName;
                strResult[1] = savename;
                strResult[2] = fileType;
                strResult[3] = fileSize.ToString();
                bool EnableUpload = false;
                if (limitSize <= fileSize && limitSize != 0)
                {
                    strResult[4] = "<font color=red>失败</font>，上传文件过大";
                    EnableUpload = false;
                }
                else if (extName != null)
                {
                    for (int i = 0; i <= extName.Length - 1; i++)
                    {
                        if (string.Compare(fileExt, extName[i].ToString(), true) == 0)
                        {
                            EnableUpload = true;
                            break;
                        }
                        else
                        {
                            strResult[4] = "<font color=red>失败</font>，文件类型不允许上传";
                            EnableUpload = false;
                        }
                    }
                }
                else
                {
                    EnableUpload = true;
                }

                // 符合上传条件，开始执行上传文件操作。
                if (EnableUpload)
                {
                    try
                    {
                        string savefile = savepath + savename;
                        FObject.WriteFile(savefile, "临时文件");
                        upfile.SaveAs(savefile);
                        strResult[4] = "成功";
                        //strResult[4] = "成功<!--" + GetString.GetRealPath(savepath) + savename + "-->";
                    }
                    catch (Exception exc)
                    {
                        strResult[4] = "<font color=red>失败</font><!-- " + exc.Message + " -->";
                    }
                }

                return strResult;
            }
        }
        #endregion
    }
}
